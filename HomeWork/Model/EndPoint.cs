using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Enum;

namespace HomeWork.Model
{
    public class EndPoint
    {
        public string serialNumber { get; set; }
        public EMeterModel meterModel { get; set; }
        public int meterNumber { get; set; }
        public string firmwareVersion { get; set; }
        public EState state { get; set; }

        public EndPoint(string serialNumber, EMeterModel meterModel, int meterNumber, string firmwareVersion, EState state)
        {
            this.serialNumber = serialNumber;
            this.meterModel = meterModel;
            this.meterNumber = meterNumber;
            this.firmwareVersion = firmwareVersion;
            this.state = state;
        }
    }
}
