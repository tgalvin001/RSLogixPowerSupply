using System;
using System.Collections.Generic;

namespace RSLogixPowerSupply
{

    class Program
    {

        private enum MainMenu : int
        { 
            AddItem = 1,
            EditItem = 2,
            
            Exit = 3
        }

        private enum addItemMenu : int
        {
            AddPowerSupply = 1,
            addNodes = 2,
            BackToMainMenu = 3
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
            "\t2 - Add Nodes\n" +
            "\t3 - Go back to main menu\n" +
            "Your Option: ";

        private void functionOneSpecific()
        {
            Console.WriteLine("IN private function");
        }
        private static void  PrintOffList(List<PowerSupply> t)
        {
            foreach(var i in t)
            {
                
                Console.WriteLine($"PWS{i.powerSupplyNumber} , AC{i.ACFeed}, PDP{i.PDPFeed} Network{i.network}");
                Console.Write($"XIC DNet0{i.network}.Module.Enable XIO DNet0{i.network}.Module.PwrOnTmr.EN ");
                foreach (var j in i.NodeList)
                {
                    Console.Write($"XIO DNet0{i.network}.Node[{j}].OK ");
                }
                Console.Write($"OTE IP67.PWS{i.powerSupplyNumber}_OFF");
            }
        }


        static void Main(string[] args)
        {
            bool endApp = false;
            MainMenu MainMenuAction;
            addItemMenu addItemMenuAction;
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
                        if (addItemMenuAction == addItemMenu.AddPowerSupply)
                        {
                            Console.Write("What is the PWS number: ");
                            PowerSupply newPowerSupply = new PowerSupply();
                            newPowerSupply.powerSupplyNumber = Console.ReadLine();
                            Console.Write("Which PDP is the PWS fed from: ");
                            newPowerSupply.PDPFeed = Console.ReadLine();
                            Console.Write("Which AC leg is the PWS fed from: ");
                            newPowerSupply.ACFeed = Console.ReadLine();
                            Console.Write("Which Network does this PWS feed: ");
                            newPowerSupply.network = Console.ReadLine();

                            PowerSupplyList.Add(newPowerSupply);


                        }
                        else if (addItemMenuAction == addItemMenu.addNodes)
                        {
                            if (PowerSupplyList.Count == 0)
                            {
                                Console.WriteLine("No PowerSupplies in List. Click 1 to add a PowerSupply");
                            }
                            else
                            {
                                Console.Write("Which Power Supply do you want to attach Nodes to: ");
                                string ID = Console.ReadLine();
                                int index = PowerSupplyList.FindIndex(r => r.powerSupplyNumber == ID);
                                if(index != -1)
                                {
                                    Console.WriteLine("Which Node to add: ");
                                    PowerSupplyList[index].AddNodeToPowerSupply(Console.ReadLine().Split(' '));
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Power Supply not found");
                                }
   
                            }
                           
                        }
                        else
                        {
                            enditemMenu = true;
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
                    PrintOffList(PowerSupplyList);

                    endApp = true;
                }

               

            }



        }    
        
    }
    
}
