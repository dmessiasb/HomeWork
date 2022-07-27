using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Application;
using HomeWork.Entities;



namespace HomeWork.UI
{


    class Program
    {

       static EndPointController endPoint = new EndPointController();
                
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
                        Console.WriteLine("Invalid option! Try again! ");
                        waitOperation();
                        Console.Clear();
                        break;
                }
            }
        }

        static string printUserOptions()
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
        static void insertEndPoint()

        {
            string serialNumber = askSerialNumber();

            if (endPoint.Search(serialNumber) == null)
            {
                var meterModel = askMeterModel();

                int meterNumber = askMeterNumber();
                string firmwareVersion = askFirmwareVersion();
                var state = askState();

                endPoint.Create(serialNumber, meterModel, meterNumber, firmwareVersion, state);

                Console.WriteLine("the endPoint was successfully included!");
                endPoint.Read(serialNumber);

            }
            else
            {
                Console.WriteLine("The endPoint serial number has already exist!");
            }
            waitOperation();
            Console.Clear();
        }
        static void editEndPoint()
        {
            string serialNumber = askSerialNumber();
            var item = endPoint.Search(serialNumber);

            if (item != null)
            {
                endPoint.Read(item.serialNumber);
                var state = askState();
                endPoint.Update(serialNumber, state);
                endPoint.Read(null);
            }
            else
            {
                Console.Write("the endPoint has been not found! ");
            }
            waitOperation();
            Console.Clear();
        }
        static void searchEndPoint()
        {
            string serialNumber = askSerialNumber();
            endPoint.Read(serialNumber);
            waitOperation();
            Console.Clear();
        }
        static void showAllEndPoint()
        {
            var listEndPoint = endPoint.Read();
            printEndPoint(listEndPoint);
            waitOperation();
            Console.Clear();
        }
        static void deleleEndPoint()
        {
            string serialNumber = askSerialNumber();

            if (endPoint.Search(serialNumber) != null)
            {
                endPoint.Read(serialNumber);
                Console.WriteLine("Would you like delete it? (Y/N)");
                string userOption = Console.ReadLine();
                if (userOption.ToUpper() == "Y")
                {
                    endPoint.Delete(serialNumber);
                }
            }
            else
            {
                Console.WriteLine("Endpoint has not found");
            }

            waitOperation();
            Console.Clear();
        }
        static void waitOperation()
        {
            Console.WriteLine("Press any Key to continue");
            string wait = Console.ReadLine();
        }
        static void printEndPoint(List<EndPoint> listEndPoint)
        {
            if (listEndPoint.Count()>0)
            {
                foreach (var endPoint in listEndPoint)
                {
                    Console.WriteLine("SerialNumber:{0} Model:{1} Number:{2} Firmware:{3} State:{4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.State);
                }
            }
            else
            {
                Console.WriteLine("Any Endpoint hasn't found");
            }
        }



        #region UserOptions        
        static string askSerialNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number:");

            try
            {
                string serialNumber = Console.ReadLine();
                return serialNumber;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Put some value to Serial Number");
                return askSerialNumber();
            }

        }
        static EMeterModel askMeterModel()

        {
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");
            try
            {
                var meterModel = (EMeterModel)int.Parse(Console.ReadLine());
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
        static int askMeterNumber()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Meter's Number");
            try
            {
                var meterNumber = int.Parse(Console.ReadLine());
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
        static string askFirmwareVersion()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Firmware Version");
            try
            {
                var firmwareVersion = Console.ReadLine();
                return firmwareVersion;

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Put some value to Firmiware Version");
                return askSerialNumber();
            }
        }
        static EState askState()
        {
            Console.WriteLine();
            Console.WriteLine("Select a State Bellow:");
            Console.WriteLine("* 0) Disconnected");
            Console.WriteLine("* 1) Connected");
            Console.WriteLine("* 2) Armed");

            try
            {
                var State = (EState)int.Parse(Console.ReadLine());
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
