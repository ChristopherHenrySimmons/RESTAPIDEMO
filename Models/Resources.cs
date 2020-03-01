using System;
using System.Collections.Generic;

namespace RESTAPIDEMO.Models
{
    public partial class Resources
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Langues { get; set; }
    }
}
