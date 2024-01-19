using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    internal class Program
    {
        static Dictionary<string, int> voteCounts = new Dictionary<string, int>();
        static List<string> categories = new List<string> { "Film", "Tech Stack", "Spor" };
        static List<string> registeredUsers = new List<string>();

        static void Main()
        {
            InitializeCategories();
            DisplayCategories();


            while (true)
            {
                Console.WriteLine("\nOylama yapmak için kullanıcı adınızı girin (Çıkmak için 'exit' yazın):");
                string username = Console.ReadLine();

                if (username.ToLower() == "exit") break;

                if (registeredUsers.Contains(username))
                {
                    CastVote(username);
                }
                else
                {
                    Console.WriteLine("Kullanıcı kayıtlı değil. Kayıt olmak için 'yes' yazın, iptal etmek için herhangi bir tuşa basın:");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        RegisterUser(username);
                        CastVote(username);
                    }
                }
                DisplayResults();        
            }
        }

        static void InitializeCategories()
        {
            foreach (var category in categories)
            {
                voteCounts[category] = 0;
            }
        }

        static void DisplayCategories()
        {
            Console.WriteLine("Oylama için Kategoriler:");
            foreach (var category in categories)
            {
                Console.WriteLine($"- {category}");
            }
        }

        static void RegisterUser(string username)
        {
            registeredUsers.Add(username);
            Console.WriteLine("Kullanıcı başarıyla kaydedildi.");
        }

        static void CastVote(string username)
        {
            Console.WriteLine("Lütfen oylamak istediğiniz kategoriyi girin:");
            string category = Console.ReadLine();

            if (categories.Contains(category))
            {
                voteCounts[category]++;
                Console.WriteLine($"Teşekkürler, {username}. Oyunuz '{category}' kategorisine kaydedildi.");
            }
            else
            {
                Console.WriteLine("Geçersiz kategori.");
            }
        }

        static void DisplayResults()
        {
            Console.WriteLine("\nOylama Sonuçları:");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category}: {voteCounts[category]} Oy");
            }
        }
    }
}
