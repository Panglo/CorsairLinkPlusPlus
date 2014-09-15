using CorsairLinkPlusPlus.Driver.Link;
using HidLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsairLinkPlusPlus.Driver.USB
{
    public class CorsairLinkUSBDeviceBootloader : CorsairLinkUSBDeviceOld
    {
        internal CorsairLinkUSBDeviceBootloader(HidDevice hidDevice) : base(hidDevice) { }

        public override string GetName()
        {
            return "Corsair Bootloader";
        }
    }
}