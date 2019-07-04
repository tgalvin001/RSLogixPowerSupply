using System;
using System.Collections.Generic;

namespace RSLogixPowerSupply
{

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
            AddItem = 1,
            EditItem = 2,
            
            Exit = 3
        }

        private enum addItemMenu : int
        {
            AddPowerSupply = 1,
            BackToMainMenu = 2
        }

        private static readonly string MainMenuText =
            "RSLogixCode PowerSupply Code Generator\n" +
            "--------------------------------------\n" +
            "\t1 - Add Item\n" +
            "\t2 - Edit List\n" +
            "\t3 - Exit\n"+
            "Your Option: ";

        private static readonly string addItemText =
            "Add Item Menu\n" +
            "--------------\n" +
            "\t1 - Add Power Supply\n" +
            "\t2 - Go back to main menu\n" +
            "Your Option: ";

        private void functionOneSpecific()
        {
            Console.WriteLine("IN private function");
        }



        static void Main(string[] args)
        {
            bool endApp = false;
            MainMenu MainMenuAction;
            addItemMenu addItemMenuAction;
            displayOne();
            PowerSupply PWS1 = new PowerSupply();
            PWS1.network = 3;
            PWS1.NodeList.Add(2);
            PWS1.NodeList.Add(13);
            foreach (var i in PWS1.NodeList)
            {
                Console.WriteLine($"Network {PWS1.network} Node:{i}");
            }
            List<PowerSupply> PowerSupplyList = new List<PowerSupply>();

            while (!endApp)


            {
                Console.Write(MainMenuText);


                // MainMenu MainMenuAction = (MainMenu)Enum.Parse(typeof(MainMenu), Console.ReadLine()); // convert string to ENUM

                if (!Enum.TryParse(Console.ReadLine(), out MainMenuAction))
                    Console.WriteLine("I do not understand your option");

                if (MainMenuAction == MainMenu.AddItem)
                {
                    bool enditemMenu = false;
                    do
                    {

                        Console.Write(addItemText);

                        if (!Enum.TryParse(Console.ReadLine(), out addItemMenuAction))
                            Console.WriteLine("I do not understand your option");
                        else if (addItemMenuAction == addItemMenu.AddPowerSupply)
                        {
                            Console.Write("What is the PWS number: ");
                            PowerSupply newPowerSupply = new PowerSupply();
                            newPowerSupply.powerSupplyNumber = Console.ReadLine();
                            Console.Write("Which PDP is the PWS fed from: ");
                            newPowerSupply.PDPFeed = Console.ReadLine();
                            Console.Write("Which AC leg is the PWS fed from: ");
                            newPowerSupply.ACFeed = Console.ReadLine();
                            PowerSupplyList.Add(newPowerSupply);


                        }
                        else
                        {
                            enditemMenu = true;
                            foreach (var i in PowerSupplyList)
                            {
                                Console.WriteLine(i.powerSupplyNumber);
                            }
                        }





                    }
                    while (!enditemMenu);

                }
                if (MainMenuAction == MainMenu.EditItem)
                {
                    //TODO
                }
                if (MainMenuAction == MainMenu.Exit)
                {
                    Console.WriteLine("Goodbye!");
                    endApp = true;
                }

               

            }



        }    
        
    }
    
}
