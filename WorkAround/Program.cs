
var input = "";

var list = new Dictionary<string, double[]>();

do
{
    input = Console.ReadLine();
    var array = Array.ConvertAll(input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray(), double.Parse);
    if(input != "")
        list.Add(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0], array);

} while (input != "");

foreach (var item in list.Keys)
{
    Console.Write(item + " ");
    var value = list[item];

    Console.Write(Math.Round((value.Sum() / value.Length) * 3));
    Console.WriteLine();
}
