using System;

namespace PerancanganAnalisa2
{
    class Program
    {
        static void Main(string[] args)
        {
            DayTime jawab1 = Jawab1();
            DayTime jawab2 = Jawab2();
            DayTime jawab3 = Jawab3();
            Console.WriteLine("Nama : Misbah Ramadani");
            Console.WriteLine("Tugas 2");
            Console.WriteLine($"Jawaban soal 1 = {jawab1.jam}:{jawab1.menit}:{jawab1.detik}");
            Console.WriteLine($"Jawaban soal 2 = {jawab2.jam}:{jawab2.menit}:{jawab2.detik}");
            Console.WriteLine($"Jawaban soal 3 = {jawab3.jam}:{jawab3.menit}:{jawab3.detik}");
        }

        private class DayTime
        {
            public int jam { get; set; }
            public int menit { get; set; }
            public int detik { get; set; }
        }
        private static int GetTotalSecond(DayTime param)
        {
            int jamKeDetik = param.jam * 3600;
            int menitKeDetik = param.menit * 60;
            int totalDetik = param.detik + jamKeDetik + menitKeDetik;
            return totalDetik;
        }
        private static DayTime ConvertSecondToDaytime(int second)
        {
            int jam = second / 3600;
            int menit = (second % 3600) / 60;
            int detik = second % 60;

            DayTime result = new DayTime();

            result.detik = detik;
            result.menit = menit;
            result.jam = jam;
            return result;
        }
        private static DayTime Jawab1()
        {
            DayTime waktuBerangkat = new DayTime()
            {
                jam = 8,
                menit = 52,
                detik = 45
            };
            int totalWaktuBerangkatDetik = GetTotalSecond(waktuBerangkat);
            int waktuPerjalanan = 5000; // dalam satuan detik
            int totalDetikTiba = totalWaktuBerangkatDetik + waktuPerjalanan;

            DayTime waktuTiba = ConvertSecondToDaytime(totalDetikTiba);
            return waktuTiba;
        }

        private static DayTime Jawab2()
        {
            DayTime waktuBerangkat = new DayTime()
            {
                jam = 8,
                menit = 52,
                detik = 45
            };

            DayTime waktuTiba = new DayTime()
            {
                jam = 12,
                menit = 15,
                detik = 10
            };

            int totalWaktuBerangkat = GetTotalSecond(waktuBerangkat);
            int totalWaktuTiba = GetTotalSecond(waktuTiba);

            int totalWaktuPerjalanan = totalWaktuTiba - totalWaktuBerangkat;

            DayTime waktuPerjalanan = ConvertSecondToDaytime(totalWaktuPerjalanan);
            return waktuPerjalanan;
        }

        private static DayTime Jawab3()
        {

            int jarakM = 900;
            int kecepatanAliMeterPerDetik = 3;
            int kecepatanBaduMeterPerDetik = 2;
            DayTime aliBerangkat = new DayTime()
            {
                jam = 8,
                menit = 0,
                detik = 0
            };
            DayTime baduBerangkat = new DayTime()
            {
                jam = 8,
                menit = 1,
                detik = 40
            };
            int totalDetikAli = GetTotalSecond(aliBerangkat);
            int totalDetikBadu = GetTotalSecond(baduBerangkat);
            //  08:01:40 - 08:00:00 = 100 detik
            int selisihWaktu = totalDetikBadu - totalDetikAli;
            // selisih jarak antara ali & badu = 3 meter/detik * 100 detik = 300 m
            int selisihJarak = kecepatanAliMeterPerDetik * selisihWaktu;

            // waktu papasan = (jarak - selisih jarak) / (k1 + k2)
            // 900 - 300 = 600
            int jarakSisa = jarakM - selisihJarak;
            // 3 + 2 = 5
            int totalKecepatan = kecepatanAliMeterPerDetik + kecepatanBaduMeterPerDetik;
            // 600 / 5 = 120
            int waktuPapasan = jarakSisa / totalKecepatan;
            int totalWaktu = totalDetikBadu + waktuPapasan;

            DayTime papasan = ConvertSecondToDaytime(totalWaktu);

            return papasan;

        }


    }
}
