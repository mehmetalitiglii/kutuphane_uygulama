using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane
{
    public class Kitap
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

        public string Kitap_Adi { get; set; }
        public string Yazar { get; set; }
        public string ISBNNO { get; set; }
        public int StokAdet { get; set; }


        public Kitap(string kitapadi, string yazar, string isbn, int stok_adet)
        {

            this.StokAdet = stok_adet;
            this.Yazar = yazar;
            this.Kitap_Adi = kitapadi;
            this.ISBNNO = isbn;

        }


        public void Kitap_bilgileri_getir(Kitap[] kitaplar)
        {
            for (int i = 0; i < kitaplar.Length; i++)
            {
                if (kitaplar[i] != null)
                {
                    Console.WriteLine($"{i + 1}. Kitap Adı; {kitaplar[i].Kitap_Adi}, Yazar: {kitaplar[i].Yazar} Stok Adet: {kitaplar[i].StokAdet} ISBN: {kitaplar[i].ISBNNO}");
                }
            }
        }



    }


    //// ÜYELERİN YÖNETİLDİĞİ CLASS
    public class uye_class
    {

        //ÜYELERİN ÖZELLİKLERİ
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public int Uye_ID { get; set; }

        public Kitap[] Alinan_Kitaplar { get; set; }


        //ÖZELLİKLERİN İÇİNE DEĞER ATMAMIZI SAĞLAYAN CONSTRUCTOR METOT
        public uye_class(string ad, string soyad, int uye_ID)
        {
            this.Ad = ad;
            this.Soyad = soyad;
            this.Uye_ID = uye_ID;
            this.Alinan_Kitaplar = new Kitap[3];
        }


        //STOKTAN KİTAP ALINDIĞINDA KİTAP SAYISINI AZALTAN METOT
        public void kitap_al(Kitap kitap)
        {
            if (Alinan_Kitaplar.Any(k => k == null) && kitap.StokAdet > 0)
            {
                for (int i = 0; i < Alinan_Kitaplar.Length; i++)
                {
                    if (Alinan_Kitaplar[i] == null)
                    {
                        Alinan_Kitaplar[i] = kitap;
                        kitap.StokAdet--;
                        Console.WriteLine($"{kitap.Kitap_Adi} kitabı başarıyla alındı");
                        return;
                    }

                }


            }
            else
            {
                Console.WriteLine("Kitap alınamıyor. Maksimum limit ya da stok yok.");
            }
        }

        //STOĞA KİTAP TESLİM EDİLDİĞİNDE STOKTAKİ KİTAP SAYISINI ARTTIRAN METOT
        public void Kitap_teslim_et(Kitap kitap)
        {
            if (Alinan_Kitaplar.Length > 0)
            {
                for (int i = Alinan_Kitaplar.Length - 1; i >= 0; i--)
                {
                    if (Alinan_Kitaplar[i] != null)
                    {
                        Alinan_Kitaplar[i] = null;
                        kitap.StokAdet++;
                        Console.WriteLine($"{kitap.Kitap_Adi} kitabı başarıyla teslim edildi");
                        return;
                    }
                }
                //alinan_kitaplar.Remove(kitap);
                //kitap.stok_adet++;
                //Console.WriteLine($"{kitap.kitap_adi} kitabı başarıyla teslim edildi.");
            }
            else
            {
                Console.WriteLine("teslim edilecek kitap bulunamadı");
            }

        }

        //ÜYE BİLGİLERİNİ DÖNDÜR

        public void UyeBilgileriGetir()
        {
            int alinanKitapSayisi = Alinan_Kitaplar.Count(k => k != null);
            Console.WriteLine($"Kitap Ad: {Ad}, Soyad: {Soyad}, ID: {Uye_ID}, Alınan Kitap Sayısı: {alinanKitapSayisi}");

        }


    }
}