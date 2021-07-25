using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Model;
using HomeWork.Enum;
using System.Linq;

namespace HomeWork
{
    class Program
    {

        static List<EndPoint> listEndPoint = new List<EndPoint>();

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
                        Console.WriteLine("insert a new endpoint");
                        break;
                    case "3":
                        deleleEndPoint();
                        break;
                    case "4":
                        listAllEndPoint();
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
                if (exitApplication != true)
                {
                    userOption = printUserOptions();
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number");
            string serialNumber = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");
            int meterModel = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Insert the Meter's Number");
            string meterNumber = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Insert the Firmware Version");
            string firmwareVersion = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Select a State Bellow:");
            Console.WriteLine("* 0) Disconnected");
            Console.WriteLine("* 1) Connected");
            Console.WriteLine("* 2) Armed");
            int state = int.Parse(Console.ReadLine());

            EndPoint newEndPoint = new EndPoint(serialNumber: serialNumber,
                                             meterModel: (EMeterModel)meterModel,
                                             meterNumber: Convert.ToInt32(meterNumber),
                                             firmwareVersion: firmwareVersion,
                                             state: (EState)state);


            listEndPoint.Add(newEndPoint);
            Console.WriteLine();
            showAllEndPoint();

        }

        private static void showAllEndPoint()
        {
            for (int i = 0; i < listEndPoint.Count; i++)
            {
                EndPoint endPoint = listEndPoint[i];
                Console.WriteLine(endPoint.serialNumber);
            }
        }

        private static EndPoint searchEndPoint()
        {
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number to find it");
            string serialNumber = Console.ReadLine();

            EndPoint endPoint = listEndPoint.Where(m => m.serialNumber == serialNumber).FirstOrDefault();

            return endPoint;
        }


        private static void deleleEndPoint()
        {
            EndPoint endPoint = searchEndPoint();

            if (endPoint != null)
            {
                Console.WriteLine("Would you like delete it? (Y/N)");
                printEndPoint(endPoint);
                string userOption = Console.ReadLine();

                if (userOption.ToUpper() == "Y")
                {
                    Console.WriteLine("delete it");
                }
            }
            else
            {
                Console.WriteLine("Endpoint has not found");
            }
        }

        private static void printEndPoint(EndPoint endPoint)
        {
            Console.WriteLine("SerialNumber:            Model:          Number:          Firmware:          State:");
            Console.WriteLine("{0}                     {1}           {2}              {3}                {4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.state);
            Console.WriteLine();
        }


        private static void listAllEndPoint()
        {
            if (listEndPoint.Count() > 0)
            {
                Console.WriteLine("SerialNumber:            Model:          Number:          Firmware:          State:");
                foreach (var endPoint in listEndPoint)
                {
                    Console.WriteLine("{0}                     {1}           {2}              {3}                {4}", endPoint.serialNumber, endPoint.meterModel, endPoint.meterNumber, endPoint.firmwareVersion, endPoint.state);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Any endPoint has founded");
            }

        }



    }
}
