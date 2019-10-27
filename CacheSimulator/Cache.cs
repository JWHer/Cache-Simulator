using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheSimulator
{
    enum Type{Direct, Associative, SetAssociative};

    class Memory
    {
        public readonly double speed;
        public Memory(double speed)
        {
            this.speed = speed;
        }
    }

    class Cache:Memory
    {
        uint memSize;   // Parent의 크기       (byte)
        uint wordSize;  // Word의 크기         (bit)
        uint wordLen;   // Word의 길이         (byte)
        uint cacheSize; // Cache의 크기        (byte)
        uint lineSize;  // Cache line의 크기   (byte)
        uint lineLen;   // Cache line의 길이   (개)
        uint tagLen;    // tag의 길이          (bit)
        uint setSize;   // Set-Associative     (way)
        uint setLen;    // Set-Associative     (bit)

        uint addrPC;    // Program Counter
        uint befrPC;
        bool jump, first;
        uint count = 0;

        public uint hitCount { get; set; }
        // miss
        public uint compulsory { get; set; }
        public uint conflict { get; set; }
        public uint capacity { get; set; }

        Type cacheType;
        Block[] mem;
        Memory parent;
        Random random;
        string vict = "LFU";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t">Type of cache</param>
        /// <param name="speed">hit시 속도</param>
        /// <param name="parent">parent memory</param>
        /// <param name="memSize">512MB 까지 지원 (2^32bit/8)</param>
        /// <param name="wordSize">32bit or 64bit</param>
        /// <param name="cacheSize"></param>
        /// <param name="lineSize">bit usually 64bit</param>
        /// <param name="setSize">power of 2</param>
        public Cache(Type t, double speed, Memory parent,
            uint memSize, uint wordSize,
            uint cacheSize, uint lineSize, uint setSize=1)
            :base(speed)
        {
            cacheType = t;
            //this.speed=speed; speed on base
            this.parent = parent;

            this.memSize = memSize;
            this.wordSize = wordSize;

            this.cacheSize = cacheSize;
            this.lineSize = lineSize;
            this.setSize = setSize;
            setLen = (uint) Math.Log(setSize,2);

            random = new Random();
            addrPC = befrPC = 0;
            hitCount = compulsory = conflict = capacity = 0;

            // 메모리의 바이트 길이를 구합니다.
            if (Math.Log(memSize, 2) > 24)
            {
                throw new ArgumentException("Memory is too big\r\n");
            }
            uint memByteLen = (uint)Math.Log(memSize, 2);
            // 메모리블록 바이트 길이를 구합니다.
            wordLen = (uint)Math.Log(wordSize / 8, 2);
            // 메모리의 주소 길이를 구합니다.
            uint memAddrLen = memByteLen - wordLen;

            // 캐시의 주소 길이를 구합니다.
            lineLen = cacheSize / lineSize;
            if (lineLen <= 0)
                throw new ArgumentException("Cache is too small\r\n" +
                    "increase cache or reduce line size\r\n");

            switch (cacheType)
            {
                case Type.Direct:
                    // 태그의 길이를 구합니다.
                    tagLen = memAddrLen - (uint)Math.Log(lineLen, 2);
                    if (tagLen + wordSize > lineSize*8)
                    {
                        uint available = lineSize - wordSize
                            + (uint)Math.Log(lineLen, 2) + wordLen*8;
                        throw error(available);
                    }

                    mem = new DirectCache[lineLen];
                    break;

                case Type.Associative:
                    // 태그의 길이를 구합니다.
                    tagLen = memAddrLen;
                    if (tagLen + wordSize > lineSize*8)
                    {
                        uint available = lineSize*8 - wordSize + wordLen*8;
                        throw error(available);
                    }

                    mem = new AsctvCache[lineLen];
                    break;

                case Type.SetAssociative:
                    lineLen /= setSize;
                    if (lineLen <= 0)
                        throw new ArgumentException("Set nums error(reduce set size)\r\n");
                    // 태그의 길이를 구합니다.
                    tagLen = memAddrLen - (uint)Math.Log(lineLen, 2) - setLen;
                    if (tagLen + wordSize > lineSize*8)
                    {
                        uint available = lineSize*8 - wordSize*setLen
                            + (uint)Math.Log(lineLen, 2) + setLen + wordLen*8;
                        throw error(available);
                    }

                    mem = new SetAsctvCache[lineLen];
                    break;

                default:
                    throw new ArgumentException("Cache Type Error\r\n");
            }
        }
        // End of Constructor

        public AddrInfo Load(double locality, int loop=1)
        {
            double totalTime = 0;
            uint pc = 0;
            AddrInfo addrInfo;
            if (cacheType == Type.SetAssociative)
            {
                addrInfo = new SetAddr();
            }
            else
            {
                addrInfo= new AddrInfo();
            }

            for (int i=0; i<loop; i++)
            {
                if(random.NextDouble() > locality)
                {
                    pc = randomAddr();
                    totalTime+=Lookup(pc, addrInfo);
                }
                else
                {
                    pc = sequentialAddr();
                    totalTime += Lookup(pc, addrInfo);
                }
            }
            addrInfo.time = totalTime;
            
            return addrInfo;
        }

        public uint lineLength() { return lineLen; }

        private uint randomAddr()
        {
            if (jump)
            {
                addrPC = befrPC;
            }
            else
            {
                addrPC = (uint)random.Next() % memSize;
                first = true;
            }
            jump = !jump;
            return addrPC;
        }

        private uint sequentialAddr()
        {
            if (!jump && first)
            {
                befrPC = addrPC;
                first = false;
            }
            return addrPC++ % memSize;
        }
        
        private double Lookup(uint pc, AddrInfo addrInfo)
        {
            // ----------------mem addr---------------- (byte)
            // ----------------Byte Len--------------<< (cache saved by word)
            // ----tag Len---(-line Len-------------)<<
            

            switch (cacheType)
            {
                case Type.Direct:
                    {
                        uint tag = (pc / (wordSize / 8)) / lineLen;
                        uint loc = (pc / (wordSize / 8)) % lineLen;
                        addrInfo.tag = tag;
                        addrInfo.loc = loc;

                        // Look up
                        if (mem[loc] == null)
                        {
                            compulsory++;
                            addrInfo.state = "compulsory";
                            mem[loc] = new DirectCache(tag, wordSize);
                            setMemInfo(addrInfo);
                        }
                        else
                        {
                            // Hit
                            if (((BaseBlock)mem[loc]).tag == tag)
                            {
                                hitCount++;
                                addrInfo.state = "hit";
                                setMemInfo(addrInfo);
                                return speed;
                            }
                            else
                            {
                                conflict++;
                                addrInfo.state = "conflict";
                                ((BaseBlock)mem[loc]).tag = tag;
                                setMemInfo(addrInfo);
                            }
                        }
                        // Miss
                        if (parent is Cache)
                        {
                            addrInfo.child = new AddrInfo();
                            return ((Cache)parent).Lookup(pc, addrInfo.child);
                        }
                        else
                            return parent.speed;
                    }
                case Type.Associative:
                    {
                        uint tag = (pc / (wordSize / 8));
                        uint loc = 0;
                        addrInfo.tag = tag;
                        // Look up
                        while (loc < mem.Length && mem[loc] != null)
                        {
                            // Hit
                            if (((BaseBlock)mem[loc]).tag == tag)
                            {
                                hitCount++;
                                ((AsctvCache)mem[loc]).readOrder = count++;
                                addrInfo.loc = loc;
                                addrInfo.state = "hit";
                                setMemInfo(addrInfo);
                                return speed;
                            }
                            loc++;
                        }
                        // Cache Full
                        if (lineLen == loc)
                        {
                            capacity++;
                            addrInfo.state = "capacity";
                            // Victim algorithm
                            loc = victim();
                        }
                        else
                        {
                            compulsory++;
                            addrInfo.state = "compulsory";
                        }
                        mem[loc] = new AsctvCache(tag, wordSize);
                        ((AsctvCache)mem[loc]).readOrder = count++;
                        addrInfo.loc = loc;
                        setMemInfo(addrInfo);
                        // Miss
                        if (parent is Cache)
                        {
                            addrInfo.child = new AddrInfo();
                            return ((Cache)parent).Lookup(pc, addrInfo.child);
                        }
                        else
                            return parent.speed;
                    }

                case Type.SetAssociative:
                    {
                        uint tag = (pc / (wordSize / 8)) / lineLen;
                        uint loc = (pc / (wordSize / 8)) % lineLen;
                        addrInfo.tag = tag;
                        addrInfo.loc = loc;

                        uint set = 0;
                        // Look up
                        if (mem[loc] == null)
                        {
                            compulsory++;
                            addrInfo.state = "compulsory";
                            mem[loc] = new SetAsctvCache(setSize);
                        }
                        else
                        {
                            while (set < setSize && ((SetAsctvCache)mem[loc]).blocks[set] != null)
                            {
                                // Hit
                                if (((SetAsctvCache)mem[loc]).blocks[set].tag == tag)
                                {
                                    ((SetAsctvCache)mem[loc]).blocks[set].readOrder = count++;
                                    hitCount++;
                                    addrInfo.state = "hit";
                                    ((SetAddr)addrInfo).set = set;
                                    setMemInfo(addrInfo);
                                    return speed;
                                }
                                set++;
                            }
                            // Cache Full
                            if (setSize == set)
                            {
                                conflict++;
                                addrInfo.state = "conflict";
                                // Victim algorithm
                                set = ((SetAsctvCache)mem[loc]).victim();
                            }
                            else
                            {
                                compulsory++;
                                addrInfo.state = "compulsory";
                            }
                        }
                        ((SetAsctvCache)mem[loc]).blocks[set] = new BaseBlock(tag, wordSize);
                        ((SetAsctvCache)mem[loc]).blocks[set].readOrder = count++;
                        ((SetAddr)addrInfo).set = set;
                        setMemInfo(addrInfo);
                        // Miss
                        if (parent is Cache)
                        {
                            addrInfo.child = new AddrInfo();
                            return ((Cache)parent).Lookup(pc, addrInfo.child);
                        }
                        else
                            return parent.speed;
                    }

                default:
                    throw new Exception("Cache Type Error");
            }
        }

        private void setMemInfo(AddrInfo addrInfo)
        {
            addrInfo.mem= new bool[lineLen];
            for(int i=0; i<lineLen; i++)
            {
                if (mem[i] != null)
                    addrInfo.mem[i] = true;
            }
        }

        private uint victim()
        {
            uint loc = 0;
            uint lru = 0;
            // Look up
            while (loc < mem.Length && mem[loc] != null)
            {
                if (((AsctvCache)mem[lru]).readOrder > ((AsctvCache)mem[loc]).readOrder)
                    lru = loc;
                loc++;
            }
            return lru;
        }

        private Exception error(uint available)
        {
            available = (uint)Math.Log(available, 2);
            string msg;
            if (available > 20)
            {
                available -= 20;
                msg = "MB)";
            }
            else if (available > 10)
            {
                available -= 10;
                msg = "KB)";
            }
            else
            {
                msg = "Byte)";
            }
            msg = String.Format("Cache is too small\r\n" +
                "increase cache size, line size\r\n" +
                "decrease mem size, word size\r\n" +
                "(your cache support only {0}\r\n",
                Math.Pow(2, available)) + msg;
            return new ArgumentException(msg);
        }
    }
    /// <summary> multilevel cache seems like this
    /// 
    ///Memory memory = new Memory(100);
    ///Cache cache1 = new Cache(Type.Direct, 10,
    ///    memory, 1024 * 1024, 32,
    ///    1024, 64, 1);
    ///Cache cache0 = new Cache(Type.Associative, 1,
    ///    cache1, 1024 * 1024, 32,
    ///    512, 64, 1);
    ///    
    /// </summary>

    interface Block { }

    class SetAsctvCache : Block
    {
        public BaseBlock[] blocks;
        public SetAsctvCache(uint setLen)
        {
            blocks = new BaseBlock[setLen];
        }
        public uint victim()
        {
            uint set = 0;
            uint lru = 0;
            while(set<blocks.Length && blocks[set] != null)
            {
                if(blocks[lru].readOrder > blocks[set].readOrder)
                {
                    lru = set;
                }
                set++;
            }
            return lru;
        }
    }

    class BaseBlock : Block
    {
        public uint readOrder;
        public uint tag;
        public byte[] data;

        public BaseBlock(uint tag, uint dataLen)
        {
            this.tag = tag;
            data = new byte[dataLen];
        }
    }

    class DirectCache : BaseBlock
    {
        public DirectCache(uint tag, uint dataLen)
            : base(tag, dataLen) { }
    }

    class AsctvCache: BaseBlock
    {
        public AsctvCache(uint tag, uint dataLen)
            :base(tag, dataLen) { }
    }

    public class AddrInfo
    {
        public uint tag;
        public uint loc;
        public double time;
        public string state;
        public bool[] mem;
        public AddrInfo child;
    }

    public class SetAddr : AddrInfo
    {
        public uint set;
    }
}
