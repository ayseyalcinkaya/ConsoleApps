using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp
{
    internal class Program
    {
        private static List<TeamMember> teamMembers = new List<TeamMember>()
        {
        new TeamMember(1, "Ahmet"),
        new TeamMember(2, "Ayşe"),
        new TeamMember(3, "Mehmet")
        };

        private static Board board = new Board();

        public static void Main(string[] args)
        {
            AddSampleCards();

            bool exit = false;
            while (!exit)
            {
                Menu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListBoard();
                        break;
                    case "2":
                        AddCard();
                        break;
                    case "3":
                        RemoveCard();
                        break;
                    case "4":
                        MoveCard();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("(1) Board Listelemek (2) Board'a Kart Eklemek (3) Board'dan Kart Silmek (4) Kart Taşımak (5) Çıkış");
        }

        private static void AddSampleCards()
        {
            var card1 = new Card("Kart 1", "Bu bir TODO kartıdır", teamMembers[0], Size.S);
            var card2 = new Card("Kart 2", "Bu bir IN PROGRESS kartıdır", teamMembers[1], Size.M);
            var card3 = new Card("Kart 3", "Bu bir DONE kartıdır", teamMembers[2], Size.L);

            board.ToDo.Add(card1);
            board.InProgress.Add(card2);
            board.Done.Add(card3);
        }

        private static void ListBoard()
        {
            Console.WriteLine("Board Listesi:");
            Console.WriteLine("\nTODO Line");
            Console.WriteLine("************************");
            ListCards(board.ToDo);

            Console.WriteLine("\nIN PROGRESS Line");
            Console.WriteLine("************************");
            ListCards(board.InProgress);

            Console.WriteLine("\nDONE Line");
            Console.WriteLine("************************");
            ListCards(board.Done);
        }
        private static void ListCards(List<Card> cards)
        {
            if (cards.Count == 0)
            {
                Console.WriteLine(" ~ BOŞ ~");
            }
            else
            {
                foreach (var card in cards)
                {
                    Console.WriteLine($" Başlık      : {card.Title}");
                    Console.WriteLine($" İçerik      : {card.Content}");
                    Console.WriteLine($" Atanan Kişi : {card.AssignedMember.Name}");
                    Console.WriteLine($" Büyüklük    : {card.CardSize}");
                    Console.WriteLine("-");
                }
            }
        }
        private static void AddCard()
        {
            Console.WriteLine("Yeni Kart Ekleme");

            Console.Write("Başlık Giriniz               : ");
            string title = Console.ReadLine();

            Console.Write("İçerik Giriniz               : ");
            string content = Console.ReadLine();

            Console.Write("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5) : ");
            int sizeInput = Convert.ToInt32(Console.ReadLine());
            Size size = (Size)sizeInput;

            Console.WriteLine("Kişi Seçiniz:");
            foreach (var member in teamMembers)
            {
                Console.WriteLine($"ID: {member.Id} - İsim: {member.Name}");
            }
            Console.Write("Kişi ID'si Giriniz: ");
            int memberId = Convert.ToInt32(Console.ReadLine());

            var assignedMember = teamMembers.FirstOrDefault(m => m.Id == memberId);
            if (assignedMember == null)
            {
                Console.WriteLine("Hatalı girişler yaptınız! İşlem iptal ediliyor.");
                return;
            }

            var newCard = new Card(title, content, assignedMember, size);

            board.ToDo.Add(newCard);
            Console.WriteLine("Kart başarıyla eklendi!");
        }

        private static void RemoveCard()
        {
            Console.WriteLine("Kart Silme");

            Console.Write("Lütfen silmek istediğiniz kartın başlığını yazınız: ");
            string title = Console.ReadLine();

            bool found = RemoveCardFromList(board.ToDo, title) ||
                         RemoveCardFromList(board.InProgress, title) ||
                         RemoveCardFromList(board.Done, title);

            if (!found)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı.");
                Console.WriteLine("1) Silmeyi sonlandırmak için");
                Console.WriteLine("2) Yeniden denemek için");
                Console.Write("Seçiminiz: ");
                string choice = Console.ReadLine();

                if (choice == "2")
                {
                    RemoveCard();
                }
            }
            else
            {
                Console.WriteLine("Kart(lar) başarıyla silindi.");
            }
        }

        private static bool RemoveCardFromList(List<Card> cards, string title)
        {
            var cardsToRemove = cards.Where(c => c.Title == title).ToList();
            if (cardsToRemove.Count > 0)
            {
                foreach (var card in cardsToRemove)
                {
                    cards.Remove(card);
                }
                return true;
            }
            return false;
        }
    
        private static void MoveCard()
        {
            Console.WriteLine("Kart Taşıma");

            Console.Write("Lütfen taşımak istediğiniz kartın başlığını yazınız: ");
            string title = Console.ReadLine();

            Card cardToMove = FindCard(title);

            if (cardToMove == null)
            {
                Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı.");
                OfferRetryOption();
            }
            else
            {
                ShowCardDetails(cardToMove);
                Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        MoveCardToList(cardToMove, board.ToDo);
                        break;
                    case "2":
                        MoveCardToList(cardToMove, board.InProgress);
                        break;
                    case "3":
                        MoveCardToList(cardToMove, board.Done);
                        break;
                    default:
                        Console.WriteLine("Hatalı bir seçim yaptınız!");
                        break;
                }
            }
        }

        private static Card FindCard(string title)
        {
            return board.ToDo.Concat(board.InProgress).Concat(board.Done)
                             .FirstOrDefault(c => c.Title == title);
        }

        private static void ShowCardDetails(Card card)
        {
            Console.WriteLine("Bulunan Kart Bilgileri:");
            Console.WriteLine($"Başlık      : {card.Title}");
            Console.WriteLine($"İçerik      : {card.Content}");
            Console.WriteLine($"Atanan Kişi : {card.AssignedMember.Name}");
            Console.WriteLine($"Büyüklük    : {card.CardSize}");
        }

        private static void MoveCardToList(Card card, List<Card> targetList)
        {
            RemoveCardFromAllLists(card);
            targetList.Add(card);
            Console.WriteLine("Kart başarıyla taşındı.");
        }

        private static void RemoveCardFromAllLists(Card card)
        {
            board.ToDo.Remove(card);
            board.InProgress.Remove(card);
            board.Done.Remove(card);
        }

        private static void OfferRetryOption()
        {
            Console.WriteLine("1) İşlemi sonlandırmak için");
            Console.WriteLine("2) Yeniden denemek için");
            Console.Write("Seçiminiz: ");
            string choice = Console.ReadLine();

            if (choice == "2")
            {
                MoveCard();
            }
        }
    }

}
