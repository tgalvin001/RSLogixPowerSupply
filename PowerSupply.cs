using System;
using System.Collections.Generic;
using System.Text;

namespace RSLogixPowerSupply
{
    public class PowerSupply
    {
        public List<int> NodeList = new List<int>();
        public String powerSupplyNumber = null;
        public int network = 0;
        public String PDPFeed = null;
        public String ACFeed = null;
    }
}
