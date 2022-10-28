using Ladeskab;
using Ladeskab.Interfaces;
using System;


namespace AppLadeskab
{ 
     class Program
    {
        static void Main(string[] args)
        {
            // Assemble your system here from all the classes
            IWrite write = new Write();
            ILogFile log = new LogFile(write);
            IDoor door = new Door();
            IRfidReader rfidReader = new RfidReader();
            ILogFile logfile = new LogFile(write);

            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        door.DoorOpened();
                        break;

                    case 'C':
                        door.DoorClosed();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.RfidRead(id);

                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }

}