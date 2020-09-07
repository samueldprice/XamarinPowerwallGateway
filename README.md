# XamarinPowerwallGateway

This project serves 2 purposes. 

1. I wanted to learn some Xamarin and Android development skills

2. I am working on a project in my spare time to make an Arduino power controller for my immersion heater to only use spare power from my solar panels. The rough requirements are outlined below

I'm only looking at it from time to time as I get a minute and the inspiration and its more a learning process than a working product. I am putting it here on github to document my learning experience.


## Requirements
I have a Tesla powerwall. The powerwall monitors energy coming from my solar panels and also power coming from or to the grid and the battery that it controls, and the power drawn by the house. I also have an electric immersion heater (actually its a SunAmp heat storage device that acts like an immersion heater). Currently this is on an off-the-shelf timer based controller with manual override.

The Tesla powerwall exposes data about the battery and the various power flows on an API on a WPA encrypted private WIFI network that it hosts. The api controller uses HTTPS with a custom certificate. The Wifi network is not connected to the internet.

I have an Arduino device I am building that can access Wifi and BluetoothLE but it is not able to access the powerwall HTTPS as its certificate chain and HTTPS implementation is very basic. I want the Arduino device to be able to access data about the power flows so it can turn the boilder on or off intelligently.

I also want to monitor the Powerwall and the boiler from a touchscreen in my kitchen. Therefore I decided to make an Android app to run on an old phone/tablet that 
a) Accesses the Powerwalls API and makes this data available via BluetoothLE
b) Displays information about the power flows.
