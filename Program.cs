using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VarosokDolgozat;

Collection<Varos> varosok = [];
using StreamReader sr = new(@"..\..\..\src\varosok.csv", Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) varosok.Add(new(sr.ReadLine()!));

Console.WriteLine($"A kollekció hossza: {varosok.Count}");

//1
Console.WriteLine($"A kínai nagyvárosokban összesen {Math.Round(varosok.Where(v => v.OrszagNev == "Kína").Sum(v => v.Nepesseg), 2)} millió fő él.");

//2
Console.WriteLine($"Az indiai nagyvárosok átlag lélekszáma {Math.Round(varosok.Where(v => v.OrszagNev == "India").Average(v => v.Nepesseg), 2)} millió.");

//3
Console.WriteLine($"A legnépesebb nagyváros:\n{varosok.MaxBy(v => v.Nepesseg)}");

//4
var sorrend = varosok.Where(v => v.Nepesseg > 20).ToList().OrderByDescending(v => v.Nepesseg);
Console.WriteLine("20 millió lakos feletti nagyvárosok [csökkenő  sorrendben]:");
foreach (var item in sorrend)
{
    Console.WriteLine($"\t{item.VarosNev}");
}

//5
Console.WriteLine($"Azoknak az országoknak a száma, amik több várossal is szerepelnek a listában: {varosok.GroupBy(v => v.OrszagNev).Count(g => g.Count() > 1)}");

//6
Console.WriteLine($"A legtöbb nagyváros neve ezzel a betűvel kezdődik: {varosok.GroupBy(v => v.VarosNev[0]).MaxBy(g => g.Count()).Key}");
