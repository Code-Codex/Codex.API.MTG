using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codex.API.MTG
{
   public class Lagality
   {
      [JsonProperty("format")]
      public string Format { get; set; }

      [JsonProperty("legality")]
      [JsonConverter(typeof(StringEnumConverter))]
      public LegalState State { get; set; }
   }
}
