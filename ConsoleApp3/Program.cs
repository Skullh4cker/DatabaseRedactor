using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace ConsoleApp3
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            List<IngredientData> dataIngredients = new List<IngredientData>();
            var path = "C:/Users/Skullhacker/Downloads/main1000menu.json";
            using (StreamReader sr = new StreamReader(path))
            {
                recipes = JsonSerializer.Deserialize<List<Recipe>>(sr.ReadToEnd());
            }
            while (true)
            {
                dataIngredients = GetUniqueIngredients(recipes);
                PrintAllIngredients(dataIngredients);
                int a;
                if (int.TryParse(Console.ReadLine(), out a))
                {
                    string oldName = dataIngredients[a].Ingredient.Name;
                    string newName = Console.ReadLine();
                    foreach (var recipe in recipes)
                    {
                        foreach (var ingredient in recipe.Ingredients)
                        {
                            if (ingredient.Name == oldName)
                            {
                                ingredient.Name = newName;
                            }
                        }
                    }
                }
                else { break; }
            }

            var options1 = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            using (StreamWriter writer = new StreamWriter("C:/Users/Skullhacker/Desktop/test.json"))
            {
                writer.WriteLine(JsonSerializer.Serialize(recipes, options1));
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
        public static List<IngredientData> GetUniqueIngredients(List<Recipe> recipes)
        {
            List<IngredientData> list = new List<IngredientData>();

            foreach (var recipe in recipes)
            {
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (!list.Any(x => x.Ingredient.Name == ingredient.Name))
                        list.Add(new IngredientData(ingredient, 1));
                    else
                        list.Find(x => x.Ingredient.Name == ingredient.Name).IngredientCount++;

                }
            }
            list = list.OrderByDescending(x => x.IngredientCount).ToList(); 
            return list;
        }
        public static void PrintAllIngredients(List<IngredientData> ingredients)
        {
            foreach(var ingredient in ingredients)
            {
                 Console.WriteLine($"{ingredients.IndexOf(ingredient)}. {ingredient.Ingredient.Name} ({ingredient.IngredientCount})");
            }
        }
    }
}
