// #define SAMPLES 500
// #define SENSOR_TEMP A2
// #define TEMPO_LEITURA 1000
// #define TEMP_CRITICA 29.00

// int tempvector[SAMPLES];
// double tempSensor = 0.0;
// int valAnalog = 0;
// unsigned long tempoAnterior = millis();

// void setup()
// {
//   Serial.begin(9600);
//   analogReference(DEFAULT);
// }

// void loop()
// {
//   if ((millis() - tempoAnterior) > TEMPO_LEITURA)
//   {
//     tempSensor = 0;

//     for (int i = 0; i < SAMPLES; i++)
//     {
//       valAnalog = analogRead(SENSOR_TEMP);
//       tempvector[i] = (valAnalog * 5.0 * 100.0) / 1023.0;
//       tempSensor = tempSensor + tempvector[i];
//     }

//     tempSensor = tempSensor / SAMPLES;
//     Serial.println(tempSensor);
//     tempoAnterior = millis();
//   }
// }
