using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codex.API.MTG
{
   public class Ruling
   {
      [JsonProperty("date")]
      public DateTime Date { get; set; }
      [JsonProperty("text")]
      public string Text { get; set; }
   }
}
