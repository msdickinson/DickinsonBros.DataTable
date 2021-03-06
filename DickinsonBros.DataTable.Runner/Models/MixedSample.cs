﻿using System;

namespace DickinsonBros.DataTable.Runner.Models
{
    public class MixedSample
    {
        public bool Bool { get; set; }
        public byte Byte { get; set; }
        public sbyte SByte { get; set; }
        public char Char { get; set; }
        public decimal Decimal { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
        public int Int { get; set; }
        public uint UInt { get; set; }
        public long Long { get; set; }
        public ulong ULong { get; set; }
        public short Short { get; set; }
        public ushort UShort { get; set; }
        public Guid Guid { get; set; }
        public System.DateTime DateTime { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public EnumSample Enum { get; set; }
        public byte[] ByteArray { get; set; }
        public string String { get; set; }
    }
}
