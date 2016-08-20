// Motors

//  roboclaw.ResetEncoders(0x80);

// ================== Initialize Motors ===================

void Init_Motors() {  
  roboclaw.begin(38400);
  delay(50);
  roboclaw.ResetEncoders(0x80);
  delay(50);
  RoboDuty(0,0);
}

// ================== ReturnLeftEnc ===================

int32_t ReturnLeftEnc() {
  int32_t tempEncRead=0;
  int tempI=0;
  bool validRC=false;
  uint8_t statusEnc=0;

  do{
    tempEncRead = roboclaw.ReadEncM1(0x80, &statusEnc, &validRC);
    tempI++;
  }while(!validRC && tempI<1000);

  return -tempEncRead;
}

// ================== ReturnRightEnc ===================

int32_t ReturnRightEnc() {
  int32_t tempEncRead;
  int tempI=0;
  bool validRC;
  uint8_t statusEnc;
  
  do{
    tempEncRead = roboclaw.ReadEncM2(0x80, &statusEnc, &validRC);
    tempI++;
  }while(!validRC && tempI<1000);
  
  return tempEncRead;
}

// ================== ReturnAvgEnc ===================

float ReturnAvgEnc() {
  return ( float( ReturnRightEnc() ) + float( ReturnLeftEnc() ) ) /2;
}

// ================== RoboDrive - Speed Control ===================

// Drive both at a given speed motors with Roboclaw. "-" corrects for sign on reversed motor
void RoboDrive(int _Left, int _Right) {  
  roboclaw.SpeedM1(0x80,-_Left);
  roboclaw.SpeedM2(0x80,_Right);
}

// ================== RoboDuty - Voltage Control ===================

// Drive both motors at a voltage/duty level with Roboclaw. "-" corrects for sign on reversed motor
void RoboDuty(int _Left, int _Right) {  
  roboclaw.DutyM1(0x80,-_Left);
  roboclaw.DutyM2(0x80,_Right);
}

// ================== ReadBattVolts ===================

// Read battery volts from Roboclaw
float ReadBattVolts() {
  float tempBattReading;
  int i=0;
  bool validRC;
  
  do{
    tempBattReading = float(roboclaw.ReadMainBatteryVoltage(address, &validRC))/10;
    i++;
//    delay(1);
//    terminal.print("batt: ");
//    terminal.print(tempBattReading);
//    terminal.print(" flag:");
//    terminal.println(validRC);
    if (i > 3) {
      tempBattReading = -1;
      Bot.BattReadingGood = false;
      break;// exit if we dont get it in 3 tries
    }
  }while(!validRC && i<10);
  
  if(validRC) Bot.BattReadingGood = true;

  return tempBattReading;
}



// ================== RoboStop ===================

void RoboStop() {
  RoboDrive(0,0);
  delay(500);
  RoboDuty(0,0);
  while(true);
}


// ================== RoboBrake ===================

void RoboBrake() {
  RoboDrive(0,0);
  delay(50);
}

