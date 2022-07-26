using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Controller;

namespace HomeWork.Interfaces
{
   public interface IEndPoint
    {       
            void createEndPoint(string serialNumber, EMeterModel MeterModel, int meterNumber, string firmwareVersion, EState state);
            EndPoint searchEndPoint(string serialNumber);
            void deleleEndPoint(string serialNumber);
            void readEndPoint(string serialNumber = null);
            void updateEndPoint(string serialNumber, EState state);

            EMeterModel askMeterModel();       
    }
}
