using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Controller;


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
                        Console.WriteLine("Invalid option! Try again! ");
                        waitOperation();
                        Console.Clear();
                        break;
                }


            }
        }

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
        private static void insertEndPoint()

        {
            string serialNumber = endPoint.askSerialNumber();

            if (endPoint.searchEndPoint(serialNumber) == null)
            {
                var meterModel = endPoint.askMeterModel();

                int meterNumber = endPoint.askMeterNumber();
                string firmwareVersion = endPoint.askFirmwareVersion();
                var state = endPoint.askState();

                endPoint.createEndPoint(serialNumber, meterModel, meterNumber, firmwareVersion, state);

                Console.WriteLine("the endPoint was successfully included!");
                endPoint.readEndPoint(serialNumber);

            }
            else
            {
                Console.WriteLine("The endPoint serial number has already exist!");
            }
            waitOperation();
            Console.Clear();
        }
        private static void editEndPoint()
        {
            string serialNumber = endPoint.askSerialNumber();
            var item = endPoint.searchEndPoint(serialNumber);

            if (item != null)
            {
                endPoint.readEndPoint(item.serialNumber);
                var state = endPoint.askState();
                endPoint.updateEndPoint(serialNumber, state);
                endPoint.readEndPoint(null);
            }
            else
            {
                Console.Write("the endPoint has been not found! ");
            }
            waitOperation();
            Console.Clear();
        }
        public static void searchEndPoint()
        {
            string serialNumber = endPoint.askSerialNumber();
            endPoint.readEndPoint(serialNumber);
            waitOperation();
            Console.Clear();
        }
        private static void showAllEndPoint()
        {
            endPoint.readEndPoint(null);
            waitOperation();
            Console.Clear();
        }
        private static void deleleEndPoint()
        {
            string serialNumber = endPoint.askSerialNumber();

            if (endPoint.searchEndPoint(serialNumber) != null)
            {
                endPoint.readEndPoint(serialNumber);
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

            waitOperation();
            Console.Clear();
        }
        private static void waitOperation()
        {
            Console.WriteLine("Press any Key to continue");
            string wait = Console.ReadLine();
        }

    }
}
