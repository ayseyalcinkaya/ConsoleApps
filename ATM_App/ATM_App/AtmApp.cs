using System;
using System.Collections.Generic;
using System.IO;

class AtmApp
{
    private Dictionary<string, string> userAccounts; 
    private List<string> transactionLogs; 
    private string eodFilePath; 

    public AtmApp()
    {
        userAccounts = new Dictionary<string, string>();
        transactionLogs = new List<string>();
        eodFilePath = "EOD_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";

        userAccounts.Add("1234567890", "1234"); 
    }

    public void Start()
    {
        Console.WriteLine("ATM Uygulamasına Hoşgeldiniz!");

        if (ValidateUser())
        {
            ShowMainMenu();
        }
        else
        {
            Console.WriteLine("Hatalı giriş denemesi!");
        }
    }

    private bool ValidateUser()
    {
        Console.WriteLine("Kart numaranızı girin:");
        string cardNumber = Console.ReadLine();

        Console.WriteLine("PIN'inizi girin:");
        string pin = Console.ReadLine();

        if (userAccounts.ContainsKey(cardNumber))
        {
            return userAccounts[cardNumber] == pin;
        }
        else
        {
            Console.WriteLine("Kart numarası sistemde kayıtlı değil.");
            return false;
        }
    }

    private void ShowMainMenu()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Ana Menü:");
            Console.WriteLine("1. Para Çekme");
            Console.WriteLine("2. Para Yatırma");
            Console.WriteLine("3. Ödeme Yapma");
            Console.WriteLine("4. Gün Sonu İşlemleri");
            Console.WriteLine("5. Çıkış");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Çekmek istediğiniz miktarı girin:");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    WithdrawMoney(amount);
                    break;
                case 2:
                    Console.WriteLine("Para başarıyla yatırıldı.");
                    break;
                case 3:
                    Console.WriteLine("Ödeme başarıyla yapıldı.");
                    break;
                case 4:
                    ProcessEOD();
                    break;
                case 5:
                    exit = true; // Çıkış seçeneği, döngüyü sonlandırır
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
        Console.Read();
    }

    private void ProcessEOD()
    {

        File.WriteAllLines(eodFilePath, transactionLogs);
        Console.WriteLine("Gün sonu işlemleri kaydedildi: " + eodFilePath);
    }

    private void WithdrawMoney(decimal amount)
    {

        string logEntry = $"Para Çekme: {amount} çekildi. Tarih: {DateTime.Now}";

        transactionLogs.Add(logEntry);

        Console.WriteLine($"{amount} başarıyla çekildi.");
    }
}
