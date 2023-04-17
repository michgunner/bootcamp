using System.Diagnostics;

/* int[] array = new int[5];
for (int i = 0; i < 5; i++)
   array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
Console.WriteLine(array[3]); */
//Сложность алгоритма О(1)(о от одного) - за сколько действий выполняется алгоритм (в данном случае 1(строка 5)), т.е. чтобы найти 3 элемент было только действие совершено




/* int size = 5;
int[] array = new int[size];
for (int i = 0; i < size; i++)
   array[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("[" + string.Join(", ", array) + "]");
Console.WriteLine(array[3]); */
//[4, 5, 3, 1, 2]
//O(size) - O(5) (если считать сумму циклом(+ + + + + ))
//sort - [1, 2, 3, 4, 5] = O(n*log(n))
//((5+1)/2) * 5(последовательность) - О(1) (еще добавить sort)




/* int num = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= num; i++)
{
   Console.Write(i + " ");
   for (int j = 2; j <= num; j++)
      Console.Write(i * j + " ");
   Console.WriteLine();
} */
//O(n^2)




/* 
int num2 = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[num2, num2];

Stopwatch sw = new(); //system.diagnostics
sw.Start();

for (int i = 0; i < num2; i++)
{
   for (int j = 0; j < num2; j++)
   {
      matrix[i, j] = (i+1) * (j+1);
      matrix[j, i] = (i+1) * (j+1);
   }
}

sw.Stop();
Console.WriteLine($"time = {sw.ElapsedMilliseconds}");

for (int i = 0; i < num2; i++)
{
   for (int j = 0; j < num2; j++)
   {
      Console.Write(matrix[i,j] +  " ");
   }
   Console.WriteLine();
} */

//улучшенная версия прошлрой задачи
//O(n^2 / 2)