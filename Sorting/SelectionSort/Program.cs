using static Sortings;
using static Infrastructure;

//int[] array = CreateArray(10, max: 50);
// PrintArray(array); //было до изменений в infras и sorting(добавили this и return)
// SortSelection(array);
// PrintArray(array);

10.CreateArray(max: 50)
  .PrintArray("; ")
  .SortSelection()
  .PrintArray(" | ");