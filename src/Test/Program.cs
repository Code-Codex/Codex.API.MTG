using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codex.API.MTG;
namespace Test
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var cards = new Cards().Where(set:"ktk").Where(colors: "red,white,blue").Where(page:1,pageSize:5).All().Result;
         foreach (var card in cards)
         {
            Console.WriteLine(card.Name);
         }
         Console.ReadKey();
      }
   }
}
