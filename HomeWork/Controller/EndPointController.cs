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
        void createEndPoint(string serialNumber, EMeterModel MeterModel, int meterNumber, string firmwareVersion, EState state);
        EndPoint searchEndPoint(string serialNumber);
        void deleleEndPoint(string serialNumber);
        void readEndPoint(string serialNumber = null);
        void updateEndPoint(string serialNumber, EState state);

        EMeterModel askMeterModel();
    }

    class EndPointController : EndPoint
    {

        internal static List<EndPoint> listEndPoint = new List<EndPoint>();

        public void createEndPoint(string serialNumber, EMeterModel meterModel, int meterNumber, string firmwareVersion, EState state)
        {

            EndPoint newEndPoint = new EndPoint();
            newEndPoint.serialNumber = serialNumber;
            newEndPoint.meterModel = meterModel;
            newEndPoint.meterNumber = Convert.ToInt32(meterNumber);
            newEndPoint.firmwareVersion = firmwareVersion;
            newEndPoint.State = state;

            listEndPoint.Add(newEndPoint);


        }
        public void readEndPoint(string serialNumber = null)
        {
            if (listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null).Count() > 0)
            {
                foreach (var endPoint in listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null))
                {
                    printEndPoint(endPoint);
                }
            }
            else
            {
                Console.WriteLine("Any EndPoint has not found!");
            }

        }
        public void deleleEndPoint(string serialNumber)
        {
            listEndPoint.RemoveAll(x => x.serialNumber == serialNumber);
        }
        public void updateEndPoint(string serialNumber, EState state)
        {
            if (!string.IsNullOrWhiteSpace(serialNumber))
            {
                foreach (var item in listEndPoint.Where(x => x.serialNumber == serialNumber))
                {
                    item.State = state;
                }
            }
        }
        public EndPoint searchEndPoint(string serialNumber)
        {
            EndPoint endPoint = listEndPoint.Where(m => m.serialNumber == serialNumber).FirstOrDefault();

            return endPoint;
        }
        private void printEndPoint(EndPoint endPoint)
        {
            Console.WriteLine("SerialNumber:{0} Model:{1} Number:{2} Firmware:{3} State:{4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.State);
        }


        #region UserOptions        
        public string askSerialNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number:");

            try
            {
                serialNumber = Console.ReadLine();
                return serialNumber;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Put some value to Serial Number");
                return askSerialNumber();
            }

        }
        public EMeterModel askMeterModel()

        {
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");
            try
            {
                meterModel = (EMeterModel)int.Parse(Console.ReadLine());
                return meterModel;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("the value has out of range! Try Again!");
                return askMeterModel();
            }
            catch (FormatException)
            {
                Console.WriteLine("input string was not in a correct format!");
                return askMeterModel();
            }

        }
        public int askMeterNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Meter's Number");
            try
            {
                meterNumber = int.Parse(Console.ReadLine());
                return meterNumber;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("the value has out of range! Try Again!");
                return askMeterNumber();
            }
            catch (FormatException)
            {
                Console.WriteLine("input string was not in a correct format!");
                return askMeterNumber();
            }


        }
        public string askFirmwareVersion()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Firmware Version");
            try
            {
                firmwareVersion = Console.ReadLine();
                return firmwareVersion;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Put some value to Firmiware Version");
                return askSerialNumber();
            }
        }
        public EState askState()
        {
            Console.WriteLine();
            Console.WriteLine("Select a State Bellow:");
            Console.WriteLine("* 0) Disconnected");
            Console.WriteLine("* 1) Connected");
            Console.WriteLine("* 2) Armed");

            try
            {
                State = (EState)int.Parse(Console.ReadLine());
                return State;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("the value has out of range! Try Again!");
                return askState();
            }
            catch (FormatException)
            {
                Console.WriteLine("input string was not in a correct format!");
                return askState();
            }
        }
        #endregion
    }
}
