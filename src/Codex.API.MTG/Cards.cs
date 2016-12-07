using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Codex.API.MTG
{
   public class Cards
   {
      private Dictionary<string, string> _queryParameters;
      private const string API_PATH = "https://api.magicthegathering.io/v1/cards";

      public Cards()
      {
         _queryParameters = new Dictionary<string, string>();
      }

      /// <summary>
      /// Card filtering
      /// </summary>
      /// <param name="name">The card name. For split, double-faced and flip cards, just the name of one side of the card. Basically each ‘sub-card’ has its own record.</param>
      /// <param name="layout">The card layout. Possible values: normal, split, flip, double-faced, token, plane, scheme, phenomenon, leveler, vanguard</param>
      /// <param name="cmc">Converted mana cost. Always a number.</param>
      /// <param name="colors">The card colors. Usually this is derived from the casting cost, but some cards are special (like the back of dual sided cards and Ghostfire).</param>
      /// <param name="colorIdentity">The card colors by color code. [“Red”, “Blue”] becomes [“R”, “U”]</param>
      /// <param name="type">The card type. This is the type you would see on the card if printed today. Note: The dash is a UTF8 'long dash’ as per the MTG rules</param>
      /// <param name="supertypes">The supertypes of the card. These appear to the far left of the card type. Example values: Basic, Legendary, Snow, World, Ongoing</param>
      /// <param name="types">The types of the card. These appear to the left of the dash in a card type. Example values: Instant, Sorcery, Artifact, Creature, Enchantment, Land, Planeswalker</param>
      /// <param name="subtypes">The subtypes of the card. These appear to the right of the dash in a card type. Usually each word is its own subtype. Example values: Trap, Arcane, Equipment, Aura, Human, Rat, Squirrel, etc.</param>
      /// <param name="rarity">The rarity of the card. Examples: Common, Uncommon, Rare, Mythic Rare, Special, Basic Land</param>
      /// <param name="set">The set the card belongs to (set code).</param>
      /// <param name="setName">	The set the card belongs to.</param>
      /// <param name="text">The oracle text of the card. May contain mana symbols and other symbols.</param>
      /// <param name="flavor">The flavor text of the card.</param>
      /// <param name="artist">The artist of the card. This may not match what is on the card as MTGJSON corrects many card misprints.</param>
      /// <param name="number">The card number. This is printed at the bottom-center of the card in small text. This is a string, not an integer, because some cards have letters in their numbers.</param>
      /// <param name="power">The power of the card. This is only present for creatures. This is a string, not an integer, because some cards have powers like: “1+*”</param>
      /// <param name="toughness">The toughness of the card. This is only present for creatures. This is a string, not an integer, because some cards have toughness like: “1+*”</param>
      /// <param name="loyalty">The loyalty of the card. This is only present for planeswalkers.</param>
      /// <param name="foreignName">The name of a card in a foreign language it was printed in</param>
      /// <param name="language">The language the card is printed in. Use this parameter when searching by foreignName</param>
      /// <param name="gameFormat">The game format, such as Commander, Standard, Legacy, etc. (when used, legality defaults to Legal unless supplied)</param>
      /// <param name="legality">The legality of the card for a given format, such as Legal, Banned or Restricted.</param>
      /// <param name="page">The page of data to request</param>
      /// <param name="pageSize">The amount of data to return in a single request. The default is 100, the max is 1000. If more than 1000 is requested, 100 will be returned.</param>
      /// <param name="orderBy">The field to order by in the response results</param>
      /// <returns></returns>
      public Cards Where
        (string name = "", string layout = "",
        int cmc = -1, string colors = "",
        string colorIdentity = "", string type = "",
        string supertypes = "", string types = "",
        string subtypes = "", string rarity = "",
        string set = "", string setName = "",
        string text = "", string flavor = "",
        string artist = "", string number = "",
        string power = "", string toughness = "",
        string loyalty = "", string foreignName = "",
        string language = "", string gameFormat = "",
        LegalState legality = LegalState.All, uint page = 0,
        uint pageSize = 0, string orderBy = "")
      {
         addParam(nameof(name), name);
         addParam(nameof(layout), layout);
         if (cmc >= 0)
            addParam(nameof(cmc), cmc);
         addParam(nameof(colors), colors);
         addParam(nameof(colorIdentity), colorIdentity);
         addParam(nameof(type), type);
         addParam(nameof(supertypes), supertypes);
         addParam(nameof(types), types);
         addParam(nameof(subtypes), subtypes);
         addParam(nameof(rarity), rarity);
         addParam(nameof(set), set);
         addParam(nameof(text), text);
         addParam(nameof(flavor), flavor);
         addParam(nameof(artist), artist);
         addParam(nameof(number), number);
         addParam(nameof(power), power);
         addParam(nameof(toughness), toughness);
         addParam(nameof(loyalty), loyalty);
         addParam(nameof(foreignName), foreignName);
         addParam(nameof(language), language);
         addParam(nameof(gameFormat), gameFormat);
         if (legality != LegalState.All)
            addParam(nameof(legality), legality);
         if (page > 0)
            addParam(nameof(page), page);
         if (pageSize > 0)
            addParam(nameof(pageSize), pageSize);
         addParam(nameof(orderBy), orderBy);
         return this;
      }

      public async Task<IEnumerable<Card>> All()
      {
         StringBuilder builder = new StringBuilder(API_PATH);
         if (_queryParameters.Count > 0)
         {
            builder.Append('?');
         }

         int index = 0;
         foreach (var param in _queryParameters)
         {
            if (index > 0)
               builder.Append('&');
            builder.Append($"{param.Key}={param.Value}");
            index++;
         }
         using (var httpClient = new HttpClient())
         {
            var json = await httpClient.GetStringAsync(builder.ToString());
            return JsonConvert.DeserializeObject<ResultArray>(json).cards;
         }
      }

      private bool addParam(string key, object value)
      {
         var valString = value.ToString();
         if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(valString))
         {
            if (valString.Contains(","))
               valString = $"\"{valString}\"";
            _queryParameters[key] = valString;
            return true;
         }
         return false;
      }

      internal class ResultArray
      {
         public Card[] cards;
      }
   }
}