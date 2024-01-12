using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneBook
    {
        private List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>();
        }

        public void DefaultContacts()
        {
            contacts.Add(new Contact("Ali", "Yılmaz", "05051234567"));
            contacts.Add(new Contact("Aysun", "Kara", "05059876543"));
            contacts.Add(new Contact("Ahmet", "Demir", "05055678901"));
            contacts.Add(new Contact("Fatma", "Çelik", "05053334455"));
            contacts.Add(new Contact("Mehmet", "Öztürk", "05057778899"));
        }

        public void AddNewContact()
        {
            Console.Write("Lütfen isim giriniz             : ");
            string firstName = Console.ReadLine();

            Console.Write("Lütfen soyisim giriniz          : ");
            string lastName = Console.ReadLine();

            Console.Write("Lütfen telefon numarası giriniz : ");
            string phoneNumber = Console.ReadLine();

            Contact newContact = new Contact(firstName, lastName, phoneNumber);
            contacts.Add(newContact);

            Console.WriteLine($"{firstName} {lastName} başarıyla eklendi.");
        }

        public void DeleteContact()
        {
            while (true)
            {
                Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
                string name = Console.ReadLine();

                var matchedContacts = contacts.Where(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                       || c.LastName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchedContacts.Count == 0)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("1) Silmeyi sonlandırmak için");
                    Console.WriteLine("2) Yeniden denemek için");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                }
                else
                {
                    Contact contactToDelete = matchedContacts.First();
                    Console.WriteLine($"{contactToDelete.FirstName} {contactToDelete.LastName} isimli kişi rehberden silinmek üzere, onaylıyor musunuz? (y/n)");
                    string confirmation = Console.ReadLine();
                    if (confirmation.ToLower() == "y")
                    {
                        contacts.Remove(contactToDelete);
                        Console.WriteLine($"{contactToDelete.FirstName} {contactToDelete.LastName} adlı kişi rehberden silindi.");
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void UpdateContact()
        {
            while (true)
            {
                Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
                string name = Console.ReadLine();

                var matchedContacts = contacts.Where(c => c.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                       || c.LastName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();

                if (matchedContacts.Count == 0)
                {
                    Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("1) Güncellemeyi sonlandırmak için");
                    Console.WriteLine("2) Yeniden denemek için");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        break;
                    }
                }
                else
                {
                    Contact contactToUpdate = matchedContacts.First();

                    Console.Write("Yeni isim giriniz (Mevcut: {0}): ", contactToUpdate.FirstName);
                    string newFirstName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newFirstName))
                    {
                        contactToUpdate.FirstName = newFirstName;
                    }

                    Console.Write("Yeni soyisim giriniz (Mevcut: {0}): ", contactToUpdate.LastName);
                    string newLastName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newLastName))
                    {
                        contactToUpdate.LastName = newLastName;
                    }

                    Console.Write("Yeni telefon numarası giriniz (Mevcut: {0}): ", contactToUpdate.PhoneNumber);
                    string newPhoneNumber = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newPhoneNumber))
                    {
                        contactToUpdate.PhoneNumber = newPhoneNumber;
                    }

                    Console.WriteLine($"{contactToUpdate.FirstName} {contactToUpdate.LastName} adlı kişinin bilgileri güncellendi.");
                    break;
                }
            }
        }



        public void ListContacts()
        {
            Console.WriteLine("\nTelefon Rehberi");
            Console.WriteLine("**********************************************");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"isim: {contact.FirstName} Soyisim: {contact.LastName} Telefon Numarası: {contact.PhoneNumber}");
            }
        }

        public void SearchContacts()
        {
            Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine("1) İsim veya soyisime göre arama yapmak için");
            Console.WriteLine("2) Telefon numarasına göre arama yapmak için");
            string choice = Console.ReadLine();

            List<Contact> matchedContacts = new List<Contact>();

            switch (choice)
            {
                case "1":
                    Console.Write("Lütfen aramak istediğiniz isim veya soyismi giriniz: ");
                    string name = Console.ReadLine().ToLower();
                    matchedContacts = contacts.Where(c => c.FirstName.ToLower().Contains(name)
                                                       || c.LastName.ToLower().Contains(name)).ToList();
                    break;
                case "2":
                    Console.Write("Lütfen aramak istediğiniz telefon numarasını giriniz: ");
                    string phoneNumber = Console.ReadLine();
                    matchedContacts = contacts.Where(c => c.PhoneNumber.Contains(phoneNumber)).ToList();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    return;

            }

            if (matchedContacts.Count == 0)
            {
                Console.WriteLine("Arama sonucuna göre herhangi bir veri bulunamadı.");
            }
            else
            {
                Console.WriteLine("\nArama Sonuçlarınız:");
                Console.WriteLine("**********************************************");
                foreach (var contact in matchedContacts)
                {
                    Console.WriteLine($"isim: {contact.FirstName} Soyisim: {contact.LastName} Telefon Numarası: {contact.PhoneNumber}");
                }
            }
        }
    }
}
