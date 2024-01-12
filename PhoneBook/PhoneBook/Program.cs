using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.DefaultContacts(); 

            while (true)
            {
                Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("1) Yeni Numara Kaydetmek");
                Console.WriteLine("2) Varolan Numarayı Silmek");
                Console.WriteLine("3) Varolan Numarayı Güncelleme");
                Console.WriteLine("4) Rehberi Listelemek");
                Console.WriteLine("5) Rehberde Arama Yapmak");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        phoneBook.AddNewContact();
                        break;
                    case "2":
                        phoneBook.DeleteContact();
                        break;
                    case "3":
                        phoneBook.UpdateContact();
                        break;
                    case "4":
                        phoneBook.ListContacts();
                        break;
                    case "5":
                        phoneBook.SearchContacts();
                        break;


                }
            }
        }
    }
}
