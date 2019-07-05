using System;
using System.Collections.Generic;
using System.Text;

namespace RSLogixPowerSupply
{
    public class PowerSupply
    {
        public List<String> NodeList = new List<String>();
        public String powerSupplyNumber = null;
        public String network = null;
        public String PDPFeed = null;
        public String ACFeed = null;

        public void AddNodeToPowerSupply(string[] nodes)
        {
            foreach(var s in nodes)
            {
                NodeList.Add(s);
            }
            
        }

        public void PrintNodeList()
        {
            if (NodeList.Count < 1)
                Console.WriteLine("No nodes");
            else
            {
                foreach (var i in NodeList)
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
