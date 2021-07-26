using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HomeWork.Model;
using HomeWork.Enum;

namespace HomeWork.Controller
{

    public interface IEndPoint
    {
        void createEndPoint(string serialNumber, int MeterModel, int meterNumber, string firmwareVersion, int state);
        EndPoint searchEndPoint(string serialNumber);
        void deleleEndPoint(string serialNumber);
        void readEndPoint(string serialNumber = null);
        void updateEndPoint(string serialNumber, int state);
    }

    class EndPointController : IEndPoint
    {
        static List<EndPoint> listEndPoint = new List<EndPoint>();

        public void createEndPoint(string serialNumber, int meterModel, int meterNumber, string firmwareVersion, int state)
        {
            EndPoint newEndPoint = new EndPoint(serialNumber: serialNumber,
                                             meterModel: (EMeterModel)meterModel,
                                             meterNumber: Convert.ToInt32(meterNumber),
                                             firmwareVersion: firmwareVersion,
                                             state: (EState)state);

            listEndPoint.Add(newEndPoint);
        }
        public void readEndPoint(string serialNumber = null)
        {
            if (listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null).Count() > 0)
            {
                foreach (var endPoint in listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null))
                {
                    if (endPoint != null)
                    {
                        printEndPoint(endPoint);
                    }
                    else{
                        Console.WriteLine("The EndPoint has not found ({0})", serialNumber);
                    }
                }
            }
            else
            {
                Console.WriteLine("Any End Point has found!!");
            }

        }
        public void deleleEndPoint(string serialNumber)
        {
            listEndPoint.RemoveAll(x => x.serialNumber == serialNumber);
        }
        public void updateEndPoint(string serialNumber, int state)
        {
            foreach (var item in listEndPoint.Where(x => x.serialNumber == serialNumber))
            {
                item.state = (EState)state;
            }
        }
        public EndPoint searchEndPoint(string serialNumber)
        {
            EndPoint endPoint = listEndPoint.Where(m => m.serialNumber == serialNumber).FirstOrDefault();

            return endPoint;
        }
        private void printEndPoint(EndPoint endPoint)
        {
            Console.WriteLine("SerialNumber:{0} Model:{1} Number:{2} Firmware:{3} State:{4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.state);
        }


    }
}
