using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RESTAPIDEMO.Models
{
     [JsonObject, Serializable]
     public partial class Commands
    {
        public int Id { get; set; }
        public string Tile { get; set; }
        public string Command { get; set; }
        public string ConsoleType { get; set; }
    }

     [JsonObject, Serializable]
     public class CommandList
     {
          public IEnumerable<Commands> commandList;
     }
}
