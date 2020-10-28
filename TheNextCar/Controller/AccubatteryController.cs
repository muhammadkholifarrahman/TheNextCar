using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubatteryController
    {
        private Accubattery accubattery;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubatteryController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattery = new Accubattery(12);
        }

        public bool accubatteryIsOn()
        {
            return this.accubattery.isOn();
        }
        public void turnOn()
        {
            this.accubattery.turnOn();
            this.callbackOnPowerChanged.OnPowerChangedStatus("ON", "power is on");

        }
        public void turnOff()
        {
            this.accubattery.turnOff();
            this.callbackOnPowerChanged.OnPowerChangedStatus("OFF", "power is off");
        }
    }

}

interface OnPowerChanged
{
    void OnPowerChangedStatus(string value, string message);
}