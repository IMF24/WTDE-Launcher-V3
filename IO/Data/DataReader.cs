// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       D A T A       R E A D E R
//
//    Helpful class for reading binary data from a file.
// ----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTDE_Launcher_V3.IO.Data {
    public class DataReader {
        public long Offset = 0;

        public long Length = 0;

        public byte[] Data;

        public bool IsLittleEndian = false;

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public DataReader(byte[] data, long offset = 0, bool isLE = false) {
            this.Data = data;
            this.Offset = offset;
            this.Length = data.Length;
            this.IsLittleEndian = isLE;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public long Tell() {
            return this.Offset;
        }

        public void Seek(long offset) {
            this.Offset += offset;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public sbyte Int8() {
            var value = this.Data[this.Offset];
            this.Offset++;
            return (sbyte) value;
        }

        public byte UInt8() {
            var value = this.Data[this.Offset];
            this.Offset++;
            return value;
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public short Int16() {
            var value = BitConverter.ToInt16(this.Data, (int) this.Offset);
            this.Offset += 2;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToInt16(revData, 0);
            } else {
                return value;
            }
        }

        public ushort UInt16() {
            var value = BitConverter.ToUInt16(this.Data, (int) this.Offset);
            this.Offset += 2;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToUInt16(revData, 0);
            } else {
                return value;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public int Int32() {
            var value = BitConverter.ToInt32(this.Data, (int) this.Offset);
            this.Offset += 4;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToInt32(revData, 0);
            } else {
                return value;
            }
        }

        public uint UInt32() {
            var value = BitConverter.ToUInt32(this.Data, (int) this.Offset);
            this.Offset += 4;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToUInt32(revData, 0);
            } else {
                return value;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        public long Int64() {
            var value = BitConverter.ToInt64(this.Data, (int) this.Offset);
            this.Offset += 8;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToInt64(revData, 0);
            } else {
                return value;
            }
        }

        public ulong UInt64() {
            var value = BitConverter.ToUInt64(this.Data, (int) this.Offset);
            this.Offset += 8;
            if (IsLittleEndian) {
                var revData = BitConverter.GetBytes(value);
                Array.Reverse(revData);
                return BitConverter.ToUInt64(revData, 0);
            } else {
                return value;
            }
        }

        // - - - - - - - - - - - - - - - - - - - - - - - - - -
    }
}
