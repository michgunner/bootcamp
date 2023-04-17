/* using System.Diagnostics; //help to test timing

int size = 1000000;
int count = 3;
int[] myArray = Enumerable.Range(1, size) //создает массив с цифрами
                          .Select(item => Random.Shared.Next(10)) //присваивает значения, shared - для безопасности при многопоточности
                          .ToArray();


Console.WriteLine($"[{string.Join(", ", myArray)}]");

Stopwatch sw = new(); //system.diagnostics
sw.Start();

int max = 0;
for (int j = 0; j < count; j++) max += myArray[j];
int temp = max;


for (int i = 1; i <= myArray.Length - count; i++)
{
   {
      temp = temp - myArray[i - 1] + myArray[i + count - 1];
   }
   if (temp > max) max = temp;
}
sw.Stop();

Console.WriteLine($"time = {sw.ElapsedMilliseconds}");
Console.WriteLine(max); */