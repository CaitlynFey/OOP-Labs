using System;

namespace OOP.Classes
{
    [Serializable()]
    [System.Runtime.Serialization.DataContract]
    public class Device
    {
        public string ProductName { get; set; }
        public string ManufacturerName { get; set; }
    }
}