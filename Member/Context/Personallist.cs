using System;
using System.Collections.Generic;

namespace Member.Context
{
    public partial class Personallist
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Entrydate { get; set; }
        public string? Entryby { get; set; }
    }
}
