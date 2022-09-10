using System;
using System.Collections.Generic;

namespace Member.Context
{
    public partial class Memberlist
    {
        public long Id { get; set; }
        public long? Idpersonal { get; set; }
        public double? Totalpremium { get; set; }
        public string? Entryby { get; set; }
        public DateTime? Entrydate { get; set; }
    }
}
