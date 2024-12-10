using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1.Seviye Ödev: Kütüphane Yönetim Sistemi(Basit)
            //Senaryo:
            //Bir kütüphane için kitap ve üye bilgilerini takip eden basit bir sistem geliştireceğiz.

            //Yapılması Gerekenler:
            //Kitap Sınıfı:

            //Özellikler:
            //Kitap Adı(string)
            //Yazar(string)
            //ISBN Numarası(string)
            //Stok Adedi(int)
            //Metotlar:
            //Kitap Bilgilerini Getir: Kitap bilgilerini ekrana yazdırır.
            //Üye Sınıfı:

            //Özellikler:
            //Ad(string)
            //Soyad(string)
            //Üye ID(int)
            //Alınan Kitaplar(Bir liste, maksimum 3 kitap)
            //Metotlar:
            //Kitap Al: Belirtilen kitabı alır (stoktan düşer).
            //Kitap Teslim Et: Kitabı teslim eder (stoka geri ekler).
            //Uygulama Akışı:

            //Kullanıcı yeni bir kitap ekleyebilir.
            //Kullanıcı yeni bir üye ekleyebilir.
            //Kullanıcı bir üyeye kitap ödünç verebilir ve teslim alabilir.
            //Kitapların ve üyelerin listesini ekranda gösterebilir.


            Kitap[] kitaplar = new Kitap[5];

            kitaplar[0] = new Kitap("Arabacı", "Neyzen Tevfik", "523084730", 50);
            kitaplar[1] = new Kitap("Sefiller", "Victor Hugo", "9780140444308", 10);
            kitaplar[2] = new Kitap("Beyaz Zambaklar Ülkesinde", "Grigory Petrov", "9786053328287", 7);
            kitaplar[3] = new Kitap("Nutuk", "Mustafa Kemal Atatürk", "9789751029088", 15);
            kitaplar[4] = new Kitap("Simyacı", "Paulo Coelho", "9780061122415", 12);



            uye_class[] uyeler = new uye_class[4];

            uyeler[0] = new uye_class("Mazhar", "Kartal", 105);
            uyeler[1] = new uye_class("Ahmet", "Demir", 201);
            uyeler[2] = new uye_class("Ayşe", "Yılmaz", 202);
            uyeler[3] = new uye_class("Mehmet", "Kaya", 203);


            Console.WriteLine("Yapmak istediğiniz durumu giriniz:");
            if (!int.TryParse(Console.ReadLine(), out int durum))
            {
                Console.WriteLine("Geçerli bir sayı giriniz.");
                return;
            }




            switch (durum)
            {
                case 1:

                    kitaplar[0].Kitap_bilgileri_getir(kitaplar);

                    break;
                case 2:

                    foreach (var uyes in uyeler)
                    {
                        if (uyes != null)
                        {
                            uyes.UyeBilgileriGetir();
                        }
                    }
                    break;

                case 3:


                    foreach (var kitap in kitaplar)
                    {
                        if (kitap != null)
                        {
                            Console.WriteLine($"{Array.IndexOf(kitaplar, kitap) + 1}. Kitap Adı: {kitap.Kitap_Adi}, Yazar: {kitap.Yazar}, Stok Adet: {kitap.StokAdet}, ISBN: {kitap.ISBNNO}");
                        }
                    }

                    Console.WriteLine("Hangi numaralı kitabı almak istiyorsunuz?");
                    if (int.TryParse(Console.ReadLine(), out int kitapNo) && kitapNo > 0 && kitapNo <= kitaplar.Length)
                    {
                        Kitap secilenKitap = kitaplar[kitapNo - 1];
                        if (secilenKitap != null && secilenKitap.StokAdet > 0)
                        {
                            uyeler[4].kitap_al(secilenKitap);
                        }
                        else
                        {
                            Console.WriteLine("Seçilen kitap mevcut değil veya stokta yok.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz kitap numarası.");
                    }
                    break;

                case 4:
                    uyeler[4].Kitap_teslim_et(kitaplar[0]);
                    break;

                case 5:
                    Console.Write("Kitap adı: ");
                    string yeniKitapAdi = Console.ReadLine();

                    Console.Write("Yazar: ");
                    string yeniYazar = Console.ReadLine();

                    Console.Write("ISBN: ");
                    string yeniIsbn = Console.ReadLine();

                    Console.Write("Stok adedi: ");
                    int yeniStokAdet = Convert.ToInt32(Console.ReadLine());

                    Kitap yeniKitap = new Kitap(yeniKitapAdi, yeniYazar, yeniIsbn, yeniStokAdet);
                    Console.WriteLine($"{yeniKitap.Kitap_Adi} başarıyla eklendi!");
                    break;
                case 6:
                    Console.Write("Üye adı: ");
                    string yeniUyeAdi = Console.ReadLine();

                    Console.Write("Soyadı: ");
                    string yeniUyeSoyadi = Console.ReadLine();

                    Console.Write("Üye ID: ");
                    int yeniUyeId = Convert.ToInt32(Console.ReadLine());

                    uye_class yeniUye = new uye_class(yeniUyeAdi, yeniUyeSoyadi, yeniUyeId);
                    Console.WriteLine($"Üye {yeniUye.Ad} {yeniUye.Soyad} başarıyla eklendi!");
                    break;


            }


        }
    }
}