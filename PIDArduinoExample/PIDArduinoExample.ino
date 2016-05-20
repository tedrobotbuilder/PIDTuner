// Linefollow Robot

#include "BMSerial.h" // RoboClaw
#include "RoboClaw.h" // RoboClaw
#include <QTRSensors.h> // Pololu QTR sensors

// ================== Constants ===================
#define ledPin         13
#define address        0x80      //Roboclaw Address

//Setup communcaitions with roboclaw motor controler
BMSerial terminal(0,1); // serial print replacement
RoboClaw roboclaw(19,18,10000);// RX, TX, Timeout (ms)

// ================== C class for this robot ===========
// This is a work in progress. I would like to convert OO code
class PERobot{
 public:
 boolean BattReadingGood=false;
 float Speed=0;

 PERobot(){ //the constructor
   //i=0;
 }
};

PERobot Bot = PERobot();// instance is Bot

// ================== QTR Line =========================
#define NUM_SENSORS 24 // number of sensors used
#define TIMEOUT 2500   // waits for max 2500 micro sec for sensor outputs to go low
#define EMITTER_PIN 8  // pin used to switch sensors on or off

QTRSensorsRC qtrLine(// setup digital line sensors
(unsigned char[]){
  46,44,42,40,38,36,34,32, 22,23,24,25,26,27,28,29, 47,45,43,41,39,37,35,33
}
  //22,23,24,25,26,27,28,29} center
  //47,45,43,41,39,37,35,33} right
  //46,44,42,40,38,36,34,32} left
,
NUM_SENSORS, TIMEOUT, EMITTER_PIN
);

unsigned int lineSensorValues[NUM_SENSORS];

// ================== QTR Edge =========================
QTRSensorsAnalog qtrEdge(// setup analog edge sensors
(unsigned char[]){
  0,1},// sensors on analog pins 0 and 1
2, // # sensors
15, // # readings to avg
QTR_NO_EMITTER_PIN // no on/off pin
);

unsigned int edgeSensorValues[2];

// ================== Globals ===================

//#define PipeSensorPin A3

// Line follow globals
float g_MaxFollowSpeed = 12000;//10200
float kp= 2.8;//2.8
float ki= .02;//.14
float kd= .5;

/* odometer maintains these global variables: */
float thetaH;         /* bot heading */
float X_pos;          /* bot X position in inches */
float Y_pos;          /* bot Y position in inches */
boolean PcDataComplete = false;  // whether the string is complete

float g_adjustVar=0; // number sent from remote to adjust variables on the fly

int g_mode=0;
int g_modeLineFollow=1;//sub-mode for Linefollowing, change parameters

float g_heading;
long g_startTime;
int g_wiiAngle = 4000;
long g_printTime;
boolean g_motorModeSet = false;

boolean g_seeObLeft = false;
boolean g_seeObRight = false;
boolean g_seePipe = false;

boolean g_StopBullDozer = false;
boolean g_endOfTable = false;
boolean g_isPushing = false;

long g_mem_millis;
String pushPipeStep;
float g_total_inches=0;
float g_last_total_inches=0;

float target_distance;         	/* distance in inches from position */
float heading_error;            /* heading error in degrees */
float target_bearing; 

// Robot's Start/Stop state holder
boolean g_Start = false;

//int freeRam(){
//  extern int __heap_start, *__brkval; 
//  int v; 
//  return (int) &v - (__brkval == 0 ? (int) &__heap_start : (int) __brkval); 
//}

// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
// ================== Setup =====================================================================
// %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

void setup() { 
  delay(100); //wait for everythign to power up 

  //Serial.begin(115200); // USB and Bluefruit, was just USB 
  
  terminal.begin(9600);
  delay(50);  
  
  Init_Motors();

  pinMode(A3, INPUT);
   
  // QTR Setup
  pinMode(EMITTER_PIN, OUTPUT);// turns QTR line sensors on and off
//  qtrLine.emittersOff();
  digitalWrite(EMITTER_PIN, LOW);
  
  pinMode(ledPin, OUTPUT); // Speaker and LED Pin 13

  Serial2.begin(9600); // XBee, was not used before on PE1
  delay(50);  

  terminal.println("Begin Setup");   
  delay(50);

  terminal.print( "Battery: " );  //show batt volts
  float battReading;
  battReading = ReadBattVolts();
  terminal.println(battReading);
  
  if( (battReading < 10.5) && (battReading > 6) ){ //bellow 6 means we are on USB power
    terminal.println( "Battery Low!" );  //show batt volts USB
//    Melody(ledPin, 500, 2000);
  } 

  terminal.println("End Setup"); 
//  delay(50);  

  Melody(ledPin, 1000, 10);
}

// #####################  Main Loop  ############################################
// #####################  Main Loop  ############################################
// #####################  Main Loop  ############################################
// #####################  Main Loop  ############################################

void loop() {
  static boolean s_hasBeenStarted = false;
  static int32_t s_batCheckMillis=0; 
  
  PipeSensor();
  
  if((millis() - s_batCheckMillis) > 240000) {
    //Melody(ledPin, 500, 2000);//4 min alarm
    s_batCheckMillis = millis();
  }
  
//Output some data to test DataPlot
//  static float xtempx = .01;
//  xtempx++;
//  terminal.print(xtempx);
//  terminal.println(",");
//  delay(50);
    
  if(g_Start){
    s_hasBeenStarted = true;
    DoLineFollowSetup();
    s_batCheckMillis = millis();
  } else if (s_hasBeenStarted) {//stopped and has been started before
    g_MaxFollowSpeed = 2000;
    DoLineFollowSetup();
    delay(2000);
    RoboDrive(0,0);
    delay(500);
    RoboDuty(0,0);
    s_hasBeenStarted=false;// kill this loop
    terminal.println("Stopped");
    CheckBotBattery();
  }
}    

// #####################  CheckBotBattery  ############################################
// #####################  CheckBotBattery  ############################################
// #####################  CheckBotBattery  ############################################

void CheckBotBattery() {//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  float battReading=0;
  battReading = ReadBattVolts();
  
  if( (battReading < 10.3) && (battReading > 6) ){
    terminal.print( battReading ); 
//    g_Start = false;
    terminal.println( " Battery Low!" );  //show batt volts USB
    Melody(ledPin, 500, 1);
  } 
}
  
// #####################  HandelStartButton  ############################################
// #####################  HandelStartButton  ############################################
// #####################  HandelStartButton  ############################################
// ================== Toggle Start/Stop Flag ===================
// Called by TwoWaySerial code, still in use!

void HandelStartButton() {//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% 
  //  Serial.print(g_Start);
  //  Serial.print(":");

  g_Start = 1; // Start = Yes
  Melody(ledPin, 1000, 1);
  delay(1);
//  XBeeSend("ss",1);//Tell remote start
}

// #####################  HandelStopButton  ############################################
// #####################  HandelStopButton  ############################################
// #####################  HandelStopButton  ############################################
void HandelStopButton() { 
  g_Start = 0; // Start = No
  Melody(ledPin, 200, 1);
  delay(1);
//  XBeeSend("ss",0);//Tell remote stop

  //  Serial.println(g_Start);
}

