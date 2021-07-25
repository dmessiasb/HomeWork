using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Controller;
using HomeWork.Model;

namespace HomeWork
{
    class Program
    {
        private static EndPointController endPoint = new EndPointController();

        static void Main(string[] args)
        {
            bool exitApplication = false;


            while (exitApplication != true)
            {
                string userOption = printUserOptions();

                switch (userOption)
                {
                    case "1":
                        insertEndPoint();
                        break;
                    case "2":
                        editEndPoint();
                        break;
                    case "3":
                        deleleEndPoint();
                        break;
                    case "4":
                        showAllEndPoint();
                        break;
                    case "5":
                        searchEndPoint();
                        break;
                    case "6":
                        Console.WriteLine("Would you like exit? (Y/N)");
                        userOption = Console.ReadLine();
                        if (userOption.ToUpper() == "Y")
                        {
                            exitApplication = true;
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option! Try again!");
                        break;
                }


            }
        }

        #region "UserOptions"
        private static string printUserOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Select a option bellow to start:");
            Console.WriteLine("* 1) Insert a new endpoint");
            Console.WriteLine("* 2) Edit an existing endpoint");
            Console.WriteLine("* 3) Delete an existing endpoint");
            Console.WriteLine("* 4) List all endpoints");
            Console.WriteLine("* 5) Find a endpoint by \"Endpoint Serial Number");
            Console.WriteLine("* 6) Exit");
            Console.WriteLine();
            return Console.ReadLine();
        }
        private static string askSerialNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number:");
            return Console.ReadLine();

        }

        private static int askMeterModel()
        {
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");

            int meterModel = int.Parse(Console.ReadLine());

            return meterModel;
        }

        private static int askMeterNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Meter's Number");
            return int.Parse(Console.ReadLine());
        }

        private static string askFirmwareVersion()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Firmware Version");
            return Console.ReadLine();
        }

        private static int askState()
        {
            Console.WriteLine();
            Console.WriteLine("Select a State Bellow:");
            Console.WriteLine("* 0) Disconnected");
            Console.WriteLine("* 1) Connected");
            Console.WriteLine("* 2) Armed");
            return int.Parse(Console.ReadLine());
        }
        #endregion


        private static void insertEndPoint()
        {
            string serialNumber = askSerialNumber();
            int meterModel = askMeterModel();
            int meterNumber = askMeterNumber();
            string firmwareVersion = askFirmwareVersion();
            int state = askState();

            endPoint.createEndPoint(serialNumber, meterModel, meterNumber, firmwareVersion, state);

            endPoint.readEndPoint(null);

        }
        private static void editEndPoint()
        {
            string serialNumber = askSerialNumber();
            var item = endPoint.searchEndPoint(serialNumber);

            if (item != null)
            {
                var state = askState();
                endPoint.updateEndPoint(serialNumber, state);
                endPoint.readEndPoint(null);
            }
            else
            {
                Console.Write("End Point Has not found");
            }
        }
        public static void searchEndPoint()
        {
            string serialNumber = askSerialNumber();
            endPoint.readEndPoint(serialNumber);
        }
        private static void showAllEndPoint()
        {
            endPoint.readEndPoint(null);
        }
        private static void deleleEndPoint()
        {
            string serialNumber = askSerialNumber();

            if (endPoint.searchEndPoint(serialNumber) != null)
            {
                Console.WriteLine("Would you like delete it? (Y/N)");
                string userOption = Console.ReadLine();
                if (userOption.ToUpper() == "Y")
                {
                    endPoint.deleleEndPoint(serialNumber);
                }
            }
            else
            {
                Console.WriteLine("Endpoint has not found");
            }
        }


        private void printEndPoint(EndPoint endPoint)
        {
            Console.WriteLine("SerialNumber:{0} Model:{1} Number:{2} Firmware:{3} State:{4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.state);
        }




    }
}
