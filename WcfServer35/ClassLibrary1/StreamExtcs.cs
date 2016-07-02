using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ClassLibrary1
{
    public static class StreamExtcs
    {
        public static byte[] ReadBytes(this Stream stream)
        {
            return ReadBytes(stream, 10240);
        }

        public static byte[] ReadBytes(this Stream stream, int count)
        {
            if (count < 0) throw new ArgumentOutOfRangeException("count", "要求非负数");
            var bs = new byte[count];
            var offset = 0;
            for (int n = -1; n != 0 && count > 0; count -= n, offset += n) n = stream.Read(bs, offset, count);
            if (offset != bs.Length) Array.Resize(ref bs, offset);
            return bs;
        }
    }
}
