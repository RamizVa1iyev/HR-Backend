using HR.Entities.Models.Other;


var tabel = new TabelDataStructure();

tabel.Add(new TabelRow
            (
                new TabelMainData
                    (
                        1, 1, "Asim", "Alizada", "Ali", 1200, "Programmer", "Main office"
                    ),
                new TabelValues(),
                10
            )
         );
tabel[0].Values.SetAll("8");
tabel[0].Show();

Console.WriteLine("Executed successfully!");


Console.ReadLine();