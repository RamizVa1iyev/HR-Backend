using HR.Business.Concrete;
using HR.DataAccess.Concrete.EntityFramework;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Models.Other;



int counter = 0;

for (int i = 0; i < 16; i++)
{
	for (int j = 0; j < 5; j++)
	{
		counter++;
	}

    for (int j = 0; j < 5; j++)
    {
        counter++;
    }
}

Console.WriteLine(counter);

Console.WriteLine("Executed successfully!");


Console.ReadLine();