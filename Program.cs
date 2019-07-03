using System;
using System.Collections.Generic;

namespace RSLogixPowerSupply
{

    //public class PowerSupply
    //{
    //    public List<int> NodeList = new List<int>();
    //    public int network = 0;
    //    public int PDPFeed = 0;
    //    public int ACFeed = 0;
    //}
    class Program
    {

       
            private static void displayOne()
            {
            Console.WriteLine("Do something funny");
            }

            public int displayTwo()
            {
                return 10;
            }
       

        private enum MainMenu : int
        {
            invalid = 0,
            addItem = 1,
            EditItem = 2,
            exit = 3

        }
        private static readonly string MainMenuText =
            "RSLogixCode PowerSupply Code Generator\n" +
            "--------------------------------------\n" +
            "\t1 - Add Item\n" +
            "\t2 - Edit List\n" +
            "\t3 - Exit\n"+
            "Your Option: ";

        private static readonly string addItemText =
            "Add Item Menun\n" +
            "--------------\n" +
            "\t1 - Do something" +
            "\t2 - Go back to main menu" +
            "Your Option: ";

        private void functionOneSpecific()
        {
            Console.WriteLine("IN private function");
        }

       

        static void Main(string[] args)
        {
            bool endApp = false;
            MainMenu MainMenuAction;
            displayOne();
            PowerSupply PWS1 = new PowerSupply();
            PWS1.network = 3;
            PWS1.NodeList.Add(2);
            PWS1.NodeList.Add(13);
            foreach(var i in PWS1.NodeList)
            {
                Console.WriteLine($"Network {PWS1.network} Node:{i}");
            }
            
            while (!endApp)


            {
                Console.Write(MainMenuText);


                // MainMenu MainMenuAction = (MainMenu)Enum.Parse(typeof(MainMenu), Console.ReadLine()); // convert string to ENUM
                
                if (!Enum.TryParse(Console.ReadLine(), out MainMenuAction))
                    Console.WriteLine("I do not understand your option");

                if(MainMenuAction == MainMenu.addItem)
                {
                    do
                    {
                        Console.WriteLine(addItemText);
                    }
                    while (Console.ReadLine() != "2");
                    
                }
                if (MainMenuAction == MainMenu.EditItem)
                {
                    //TODO
                }
                if (MainMenuAction == MainMenu.exit)
                {
                    Console.WriteLine("Goodbye!");
                    endApp = true;
                }

               

            }



        }    
        
    }
    
}
