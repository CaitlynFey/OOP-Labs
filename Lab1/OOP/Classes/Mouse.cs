using System;

namespace OOP.Classes
{
    [Serializable()]
    [System.Runtime.Serialization.DataContract]
    public class Mouse: InputDevice
    {
        private int Buttons { get; set; }
        private int ScrollWheels { get; set; }
    }
}