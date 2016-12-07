using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codex.API.MTG
{
   public class ForeignName
   {
      [JsonProperty("name")]
      public string Name { get; set; }
      [JsonProperty("imageUrl")]
      public string ImageURL { get; set; }
      [JsonProperty("language")]
      public string Language { get; set; }
      [JsonProperty("multiverseid")]
      public int MultiverseID { get; set; }
   }
}
