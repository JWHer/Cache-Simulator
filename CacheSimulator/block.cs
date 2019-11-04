using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheSimulator
{
    interface Block { }

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

    class SetAsctvCache : Block
    {
        public BaseBlock[] blocks;
        public SetAsctvCache(uint setLen)
        {
            blocks = new BaseBlock[setLen];
        }
    }

    class DirectCache : BaseBlock
    {
        public DirectCache(uint tag, uint dataLen)
            : base(tag, dataLen) { }
    }

    class AsctvCache : BaseBlock
    {
        public AsctvCache(uint tag, uint dataLen)
            : base(tag, dataLen) { }
    }
}
