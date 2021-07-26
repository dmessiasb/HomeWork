using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Controller;
using HomeWork.Enum;


namespace HomeWork
{
    class Program
    {
        private static EndPointController endPoint = new EndPointController();
        private enum Enum{ };
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

        #region UserOptions
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
            string meterModel = "";
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");
            meterModel = Console.ReadLine();

            while ((isInteger(meterModel) == false) || (isInMeterModelRange(meterModel)) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Select a Meter Model Bellow:");
                Console.WriteLine("* 16) NSX1PSW");
                Console.WriteLine("* 17) NSX1P13W");
                Console.WriteLine("* 18) NSX2P3W");
                Console.WriteLine("* 19) NSX3P4W");
                meterModel = Console.ReadLine();
            }

            return int.Parse(meterModel);
        }
        private static int askMeterNumber()
        {

            string meterNumber = "";
            Console.WriteLine();
            Console.WriteLine("Insert the Meter's Number");
            meterNumber = Console.ReadLine();

            while (isInteger(meterNumber) == false)
            {
                waitOperation();
                Console.WriteLine();
                Console.WriteLine("Insert the Meter's Number");
                meterNumber = Console.ReadLine();

            }
            return int.Parse(meterNumber);
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
            string state = "";
            state = Console.ReadLine();

            while ((isInteger(state) == false) || (isInStateRange(state)) == false)
            {
                Console.WriteLine();
                Console.WriteLine("Select a State Bellow:");
                Console.WriteLine("* 0) Disconnected");
                Console.WriteLine("* 1) Connected");
                Console.WriteLine("* 2) Armed");
                state = Console.ReadLine();
            }

            return int.Parse(state);
        }
        #endregion


        #region Validation
        private static bool isInteger(string number)
        {
            bool validation = true;
            try
            {
                if (int.Parse(number) < 0)
                {
                    Console.Write("the value typed has invalid ({0})! Try again! ", number);
                    validation = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ": ({0}) Try again! ", number);
                validation = false;
            }

            return validation;

        }

        private static bool isInMeterModelRange(string number)
        {
            bool validation = false;
            int result = 0;

            var values = EMeterModel.GetValues(typeof(EMeterModel)).Cast<int>().OrderBy(x => x);

            if (int.TryParse(number, out result)==true)
            {
                if ((result >= values.First()) && (result <= values.Last()))
                {
                    validation = true;                    
                }
                else
                {
                    Console.WriteLine("the value has out of range ({0})! Try Again!", result);
                    waitOperation();
                }

            }

            return validation;

        }

        private static bool isInStateRange(string number)
        {
            bool validation = false;
            int result = 0;

            var values = EState.GetValues(typeof(EState)).Cast<int>().OrderBy(x => x);

            if (int.TryParse(number, out result) == true)
            {
                if ((result >= values.First()) && (result <= values.Last()))
                {
                    validation = true;
                }
                else
                {
                    Console.WriteLine("the value was out of range ({0})! Try Again!", result);
                    waitOperation();
                }

            }

            return validation;

        }
        #endregion

        private static void insertEndPoint()

        {
            string serialNumber = askSerialNumber();

            if (endPoint.searchEndPoint(serialNumber) == null)
            {
                int meterModel = askMeterModel();
                int meterNumber = askMeterNumber();
                string firmwareVersion = askFirmwareVersion();
                int state = askState();

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
            string serialNumber = askSerialNumber();
            var item = endPoint.searchEndPoint(serialNumber);

            if (item != null)
            {
                endPoint.readEndPoint(item.serialNumber);
                var state = askState();
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
            string serialNumber = askSerialNumber();
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
