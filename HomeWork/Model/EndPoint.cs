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

        private string serialNumber { get; set; }
        private EMeterModel meterModel { get; set; }
        private string number { get; set; }
        private string firmwareVersion { get; set; }
        private EState state { get; set; }

        public EndPoint(string serialNumber, EMeterModel meterModel, string firmwareVersion, EState state)
        {
            this.serialNumber = serialNumber;
            this.meterModel = meterModel;
            this.firmwareVersion = firmwareVersion;
            this.state = state;
        }
    }
}
