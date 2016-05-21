// Sharp IR Sensors 

float g_lapTime=0;

void PipeSensor(){//========================================================================
  static float g_countPipeSensor=0;
  static float g_sumPipeSensor=0;
  static float g_sumSquaresPipeSensor=0;
  static float g_distancePipeSensor=0;
  static float g_stdDevPipeSensor=0;
  static float s_lastLapTime=millis();
  
  //Note: the closer the object the higher the reading.  At point blank about 400.
  //at about 5 feet: zero.  140 is about 38 inches
      
  float numberOfavg = 20; // number of readings per avg
  float rawIR = analogRead(A5); // read the sensor
  g_sumPipeSensor += rawIR; // sum the raws
  g_sumSquaresPipeSensor += pow(rawIR, 2); // sum the squares of the raws
  
  g_countPipeSensor++;  
  
  if(g_countPipeSensor == numberOfavg){
    g_distancePipeSensor = g_sumPipeSensor / numberOfavg; // get avg distance reading before we sqr it
    g_sumPipeSensor = pow(g_sumPipeSensor,2); // square the sum
    g_stdDevPipeSensor = ( g_sumSquaresPipeSensor - (g_sumPipeSensor/ numberOfavg) )/ (numberOfavg - 1);
        
    g_countPipeSensor = 0;
    g_sumPipeSensor = 0;
    g_sumSquaresPipeSensor = 0;  
    
    double lapTime = millis() - s_lastLapTime;
      
    if(g_distancePipeSensor > 250 && g_stdDevPipeSensor < 10 && lapTime > 1000){
//      Serial.println(lapTime/1000);
      s_lastLapTime=millis();
//      g_lapTime = lapTime;
      terminal.print("lt");
      terminal.print(lapTime);
      terminal.println("#");   
      delay(10);
      terminal.print("lt");
      terminal.print(lapTime);
      terminal.println("#");     
    }
  }
}
