using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Codex.API.MTG
{
   public class Card
   {
      [JsonProperty("name", Order = 1)]
      public string Name { get; set; }

      [JsonProperty("manaCost", Order = 2)]
      public string ManaCost { get; internal set; }

      [JsonProperty("cmc", Order = 3)]
      public int CastingManaCost { get; internal set; }

      [JsonProperty("Colors", Order = 4)]
      public string[] Colors { get; internal set; }

      [JsonProperty("colorIdentity", Order = 5)]
      public char[] ColorIdentity { get; set; }

      [JsonProperty("type", Order = 6)]
      public string Type { get; internal set; }

      [JsonProperty("supertypes", Order = 7)]
      public string[] SuperTypes { get; internal set; }

      [JsonProperty("types", Order = 8)]
      public string[] Types { get; internal set; }

      [JsonProperty("subtypes", Order = 9)]
      public string[] SubTypes { get; internal set; }

      [JsonProperty("rarity", Order = 10)]
      public string Rarity { get; internal set; }

      [JsonProperty("set", Order = 11)]
      public string Set { get; internal set; }

      [JsonProperty("setName", Order = 12)]
      public string SetName { get; internal set; }

      [JsonProperty("text", Order = 13)]
      public string Text { get; internal set; }

      [JsonProperty("artist", Order = 14)]
      public string Artist { get; internal set; }

      [JsonProperty("number", Order = 15)]
      public string Number { get; internal set; }

      [JsonProperty("power", Order = 16)]
      public string Power { get; internal set; }

      [JsonProperty("toughness", Order = 17)]
      public string Toughness { get; internal set; }

      [JsonProperty("layout", Order = 18)]
      public string Layout { get; internal set; }

      [JsonProperty("multiverseid", Order = 19)]
      public string MultiverseID { get; internal set; }

      [JsonProperty("imageUrl", Order = 20)]
      public string ImageURL { get; internal set; }

      [JsonProperty("watermark", Order = 21)]
      public string Watermark { get; internal set; }

      [JsonProperty("rulings", Order = 22)]
      public Ruling[] Rulings { get; internal set; }

      [JsonProperty("foreignNames", Order = 23)]
      public ForeignName[] ForeignNames { get; set; }

      [JsonProperty("printings", Order = 24)]
      public string[] Printings { get; internal set; }

      [JsonProperty("originalText", Order = 25)]
      public string OriginalText { get; set; }

      [JsonProperty("originalType", Order = 26)]
      public string OriginalType { get; set; }

      [JsonProperty("legalities", Order = 27)]
      public Lagality[] Legalities { get; internal set; }

      [JsonProperty("id", Order = 28)]
      public string ID { get; internal set; }
   }
}
