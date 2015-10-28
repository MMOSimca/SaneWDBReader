using System;
using System.IO;
using System.Text;

namespace WDBReader
{
    class DataStore
    {
        BinaryReader r;
        public DataStore(BinaryReader rd)
        {
            r = rd;
        }

        int bitPos = 8;
        int curr;

        public int GetBit()
        {
            if (bitPos == 8)
            {
                curr = r.ReadByte();
                bitPos = 0;
            }

            int result = (curr >> 7);
            curr <<= 1; curr &= 0xff; ++bitPos;
            return result;
        }

        public uint GetBits(int count)
        {
            uint result = 0;
            while (count > 0)
            {
                count--;
                result |= ((uint)GetBit() << count);
            }
            return result;
        }

        public int GetIntByBits(int count)
        {
            return unchecked((int)GetBits(count));
        }

        public float GetFloat()
        {
            Flush();
            var buf = r.ReadBytes(4);
            return BitConverter.ToSingle(buf, 0);
        }

        public int GetInt()
        {
            Flush();
            var buf = r.ReadBytes(4);
            return BitConverter.ToInt32(buf, 0);
        }

        public uint GetUInt()
        {
            Flush();
            var buf = r.ReadBytes(4);
            return BitConverter.ToUInt32(buf, 0);
        }

        public bool GetBool()
        {
            return GetBit() != 0;
        }

        public void Flush()
        {
            bitPos = 8;
        }

        public byte GetByte()
        {
            return r.ReadByte();
        }

        public byte[] GetBytes(int count)
        {
            return r.ReadBytes(count);
        }

        // This assumes there is NOT a null-terminator after the string and that you have already read its prefixed length
        public string GetString(int count)
        {
            if (count > 0)
            {
                return Encoding.UTF8.GetString(GetBytes(count));
            }
            else
            {
                return "";
            }
        }

        // This assumes there was no prefixed length and only stops reading when it finds the null character
        public string GetCString()
        {
            string newString = "";
            char temp = (char)GetByte();
            while (temp != '\0')
            {
                newString += temp;
                temp = (char)GetByte();
            }
            return newString;
        }

        public long Position
        {
            get
            {
                return r.BaseStream.Position;
            }
        }

        public bool EndOfStream
        {
            get
            {
                return r.BaseStream.Length <= r.BaseStream.Position;
            }
        }
    }
}
