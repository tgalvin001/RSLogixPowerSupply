using System;
using System.Collections.Generic;
using System.Text;

namespace RSLogixPowerSupply
{
    public class PowerSupply
    {
        public List<int> NodeList = new List<int>();
        public int network = 0;
        public int PDPFeed = 0;
        public int ACFeed = 0;
    }
}
