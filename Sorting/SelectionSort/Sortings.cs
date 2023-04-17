public static class Sortings
{
   public static int[] SortSelection(this int[] collection)
{
   int size = collection.Length;

   for (int i = 0; i < size - 1; i++)
   {
      int position = i;
      for (int j = i+1; j < size; j++)
      {
         if(collection[j] < collection[position]) position = j;
      }
      int temp = collection[i];
      collection[i] = collection[position];
      collection[position] = temp;
   }
   return collection;
}
}