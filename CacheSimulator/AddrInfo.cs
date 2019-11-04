using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheSimulator
{
    public class AddrInfo
    {
        public uint tag;
        public uint loc;
        public double time;
        public string state;
        public AddrInfo child;
    }

    public class SetAddr : AddrInfo
    {
        public uint set;
    }
}
