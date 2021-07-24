using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Model;
using HomeWork.Enum;

namespace HomeWork
{
    class Program
    {

        static List<EndPoint> listEndPont = new List<EndPoint>();

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
                        Console.WriteLine("insert a new endpoint");
                        break;
                    case "4":
                        Console.WriteLine("insert a new endpoint");
                        break;
                    case "5":
                        Console.WriteLine("insert a new endpoint");
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
            Console.WriteLine("Inserting a new endPoint");            
            Console.WriteLine();
            Console.WriteLine("Select a Meter Model Bellow:");
            Console.WriteLine("* 16) NSX1PSW");
            Console.WriteLine("* 17) NSX1P13W");
            Console.WriteLine("* 18) NSX2P3W");
            Console.WriteLine("* 19) NSX3P4W");
            int meterModel = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Insert the Serial Number");
            string serialNumber = Console.ReadLine();
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
                                             firmwareVersion: firmwareVersion,
                                             state: (EState)state);


            listEndPont.Add(newEndPoint);
            
        }



    }
}
