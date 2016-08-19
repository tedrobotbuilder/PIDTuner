// LineFollow

// #####################  DoLineFollowSetup  ############################################
// #####################  DoLineFollowSetup  ############################################
// #####################  DoLineFollowSetup  ############################################
// here we calibrate the line sensors

void DoLineFollowSetup() {
  static boolean s_startLineFollow = true;
  static boolean s_QTRCalibrated = false;

  while(s_QTRCalibrated == false){
    QTRCal();
    s_QTRCalibrated = true;// kill this part of the loop
  } 
  
  FollowLineLoop(); // follow the line
//  PrintQTR();
//  PrintCalQTR();
//  delay(200);
}

// #####################  FollowLineLoop  ############################################
// #####################  FollowLineLoop  ############################################
// #####################  FollowLineLoop  ############################################
// here we follow the line

void FollowLineLoop() { //%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  float linesToAvg = 5;
   
  float pLine=0;
  static float iLine=0; 
  static float s_ki;
  float dLine=0; 
  float lineError=0;
  float s_last_pLine = 0;
  static boolean s_firstD = true; // keep first PID D term from exploding
  static boolean s_rampedUpSpeed = false;
  static long s_FollowLine_millis = millis() - 5;
  static long s_FollowLinePrint_millis = millis() - 51;
  int millisPerLoop = 50;
  static long s_millisOffLine = 0;
  static long s_millisOffLineCount = 0;
    
  if((millis() - s_FollowLine_millis) < millisPerLoop){
    return;// Has not been long enough to run this function
  }
  s_FollowLine_millis = millis();
 
  // ramp up to max speed
  if(Bot.Speed < g_MaxFollowSpeed){
    Bot.Speed += +300;
  }else{
    Bot.Speed = g_MaxFollowSpeed;
    s_rampedUpSpeed = true;
  }
  
  // Get the position of the line which is the error: P
  unsigned int position = qtrLine.readLine(lineSensorValues);
  lineError = (((float)position) - ( (NUM_SENSORS*1000/2)-500) ); //the center reading
  pLine = lineError;
  
  // Compute the derivative (change in the error): D
  if(s_firstD == false){// first time through: don't let D be large
    dLine = pLine - s_last_pLine;
  } else {
    dLine = 0; 
    s_firstD = false;
  }
  
  // integral (sum of the errors over time) of the position: I
  if(s_ki == ki) {
    iLine = iLine + pLine;
  } else {
    // ki changed while tuning, so clear iLine:
    iLine = 0;
  }
  
  // Remember the last position and last ki.
  s_last_pLine = pLine;
  s_ki = ki;

  float power_difference = float(pLine*kp - iLine*ki + dLine*kd);

  int rightSpeed = ( constrain(Bot.Speed - power_difference, -31900, 31900) );
  int leftSpeed = ( constrain(Bot.Speed + power_difference, -31900, 31900) );
  
  RoboDrive(leftSpeed, rightSpeed);
  
  if((millis() - s_FollowLinePrint_millis) > 200){
    return;// Has not been long enough to print
  }
  s_FollowLinePrint_millis = millis();

    terminal.print(pLine*kp);
    terminal.print(",");
    terminal.print(iLine*ki);
    terminal.print(",");
    terminal.print(dLine*kd);
//    terminal.print(",");
//    terminal.print(g_lapTime);
    terminal.println(",");// must end with line feed and comma
}
