// Sharp IR Sensors

// Distance (cm) = 9462/(SensorValue - 16.92) 

//#define PipeSensorPin 3


void PipeSensor(){//========================================================================
  static float g_countPipeSensor=0;
  static float g_sumPipeSensor=0;
  static float g_sumSquaresPipeSensor=0;
  static float g_distancePipeSensor=0;
  static float g_stdDevPipeSensor=0;
  
//  Serial3.println(g_countPipeSensor);
  //Note: the closer the object the higher the reading.  At point blank about 400.
  //at about 5 feet: zero.  140 is about 38 inches
      
  float numberOfavg = 20; // number of readings per avg
  float rawIR = analogRead(A5); // read the sensor
  g_sumPipeSensor += rawIR; // sum the raws
  g_sumSquaresPipeSensor += pow(rawIR, 2); // sum the squares of the raws
  
  g_countPipeSensor++;  
  
  //Serial.print(rawIR);
  //Serial.println(",");
  
  if(g_countPipeSensor == numberOfavg){
    g_distancePipeSensor = g_sumPipeSensor / numberOfavg; // get avg distance reading before we sqr it
    g_sumPipeSensor = pow(g_sumPipeSensor,2); // square the sum
    g_stdDevPipeSensor = ( g_sumSquaresPipeSensor - (g_sumPipeSensor/ numberOfavg) )/ (numberOfavg - 1);
        
    g_countPipeSensor = 0;
    g_sumPipeSensor = 0;
    g_sumSquaresPipeSensor = 0;  

    //Serial.print(rawIR); 
    //Serial.print(",");  
//    Serial.print("Dist: "); 
//    Serial.print(rawIR); 
//    Serial.println(",");  
    
//    if(g_stdDevPipeSensor < 150){
//      Serial.print(g_distancePipeSensor); 
//      g_lastDistance = g_distancePipeSensor;
//    }else{
//      Serial.print(g_lastDistance); 
//    }
//    Serial.println(",");  

//    if((millis() - g_PipeSensor_millis) > 200) {   
//      g_PipeSensor_millis = millis(); 
      Serial.print(g_distancePipeSensor);
      Serial.print("\t");
      Serial.println(g_stdDevPipeSensor);
//    }
    
    if(g_distancePipeSensor > 130 && g_stdDevPipeSensor < 150){
//      XBeeSend("pi",1);
//      tone(ledPin, 1000, 20);
//      delay(10);
//      Serial3.print(g_distancePipeSensor);
//      Serial3.print("\t");
//      Serial3.print(g_stdDevPipeSensor);
//      Serial3.print("\t");
//      Serial3.print(X_pos);
//      Serial3.print("\t");
      Serial3.println("pipe");
      g_seePipe = true;
//    }else{
//      Serial3.print(g_distancePipeSensor);
//      Serial3.print("\t");
//      Serial3.println(g_stdDevPipeSensor);
    }
//      XBeeSend("pi",0);
  }
}
