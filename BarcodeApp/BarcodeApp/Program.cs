using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using ZXing;
using System.Drawing.Imaging;
using System.Drawing;
using Image = System.Drawing.Image;

namespace BarcodeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 100,
                    Width = 300
                }
            };

            Console.Write("Barkod için metin girin: ");
            string barcodeText = Console.ReadLine();
            var barcodeBitmap = writer.Write(barcodeText);

            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "barcode.png");
            barcodeBitmap.Save(path, ImageFormat.Png);
            Console.WriteLine($"Barkod, masaüstünde 'barcode.png' olarak kaydedildi: {path}");


            var reader = new BarcodeReader();
            var barcodeBitmapRead = (Bitmap)Image.FromFile(path);
            var result = reader.Decode(barcodeBitmapRead);
            if (result != null)
            {
                Console.WriteLine($"Barkod içeriği: {result.Text}");
            }
            else
            {
                Console.WriteLine("Barkod okunamadı.");
            }

            Console.ReadLine();
        }
    }
}
