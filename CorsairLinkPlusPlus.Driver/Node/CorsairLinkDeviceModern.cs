﻿using CorsairLinkPlusPlus.Driver.USB;
using System;

namespace CorsairLinkPlusPlus.Driver.Node
{
    public class CorsairLinkDeviceModern : CorsairLinkDevice
    {
        internal CorsairLinkDeviceModern(CorsairLinkUSBDevice usbDevice, byte channel) : base(usbDevice, channel) { }

        public byte GetDeviceID()
        {
            return ReadSingleByteRegister(0x00);
        }

        public int GetFirmwareVersion()
        {
            return BitConverter.ToInt16(ReadRegister(0x01, 2), 0);
        }

        public override string GetDeviceName()
        {
            switch (GetDeviceID())
            {
                case 0x37:
                    return "Corsair H80";
                case 0x38:
                    return "Corsair Cooling Node";
                case 0x39:
                    return "Corsair Lighting Node";
                case 0x3A:
                    return "Corsair H100";
                case 0x3B:
                    return "Corsair H80i";
                case 0x3C:
                    return "Corsair H100i";
                case 0x3D:
                    return "Corsair Commander Mini";
                case 0x3E:
                    return "Corsair H110i";
                case 0x3F:
                    return "Corsair Hub";
                case 0x40:
                    return "Corsair H100iGT";
                case 0x41:
                    return "Corsair H110iGT";
            }
            return "Unknown Modern Device (0x" + string.Format("{0:x2}", GetDeviceID()) + ")";
        }

        public override string GetCoolerType(int id)
        {
            int devID = GetDeviceID();
            if (devID == 0x3B || devID == 0x3C || devID == 0x3E || devID == 0x40 || devID == 0x41)
            {
                if (id == GetCoolerCount() - 1)
                    return "Pump";
            }
            return base.GetCoolerType(id);
        }

        public override int GetCoolerCount()
        {
            return ReadSingleByteRegister(0x11);
        }

        protected void SetCurrentFan(int id)
        {
            WriteSingleByteRegister(0x10, (byte)id);
        }

        internal override double GetCoolerRPM(int id)
        {
            SetCurrentFan(id);
            return BitConverter.ToInt16(ReadRegister(0x16, 2), 0);
        }

        public override int GetTemperatureCount()
        {
            return ReadSingleByteRegister(0x0D);
        }

        public override int GetLEDCount()
        {
            return ReadSingleByteRegister(0x05);
        }
    }
}