const int THREADS_NUMBER = 4;
const int SIZE = 100000;
object locker = new object();

Random random = new Random();
int[] resSerial = new int[SIZE].Select(r => random.Next(0, 5)).ToArray(); //one thread array
int[] resParallel = new int[SIZE]; // few threads array
Array.Copy(resSerial, resParallel, SIZE);


void CountingSortExtended(int[] inputArray)
{
   int max = inputArray.Max();
   int min = inputArray.Min();

   int offset = -min;
   int[] counters = new int[max + offset + 1];

   for (int i = 0; i < inputArray.Length; i++)
   {
      counters[inputArray[i] + offset]++;
   }

   Console.WriteLine(string.Join("; ", counters));

   int index = 0;
   for (int i = 0; i < counters.Length; i++)
   {
      for (int j = 0; j < counters[i]; j++)
      {
         inputArray[index] = i - offset;
         index++;
      }
   }
}


void CountingSortParallel(int[] inputArray, int[] counters, int offset, int startPos, int endPos)
{
   for (int i = startPos; i < endPos; i++)
   {
      lock (locker) //avoid conflicts within threads (few threads could try to write in one cell simultaneously)
      {
         counters[inputArray[i] + offset]++;
      }
   }
}



void PrepareParallelSorting(int[] inputArray)
{
   int max = inputArray.Max();
   int min = inputArray.Min();

   int offset = -min;
   int[] counters = new int[max + offset + 1];

   int eachTreadCalc = SIZE/THREADS_NUMBER;
   var threadsParall = new List<Thread>();

   for (int i = 0; i < THREADS_NUMBER; i++)
   {
      int startPos = i * eachTreadCalc;
      int endPos = (i+1) * eachTreadCalc;
      if(i == THREADS_NUMBER -1) endPos = SIZE;
      threadsParall.Add(new Thread(() => CountingSortParallel(inputArray, counters, offset, startPos, endPos)));
      threadsParall[i].Start();
   }

   foreach(var thread in threadsParall)
   {
      thread.Join();
   }

   int index = 0;
   for (int i = 0; i < counters.Length; i++)
   {
      for (int j = 0; j < counters[i]; j++)
      {
         inputArray[index] = i - offset;
         index++;
      }
   }
}



bool EqualityMatrix(int[] fMatrix, int[] sMatrix)
{
   bool result = true;

   for (int i = 0; i < SIZE; i++)
   {
      result = result && (fMatrix[i] == sMatrix[i]);
   }

   return result;
}


CountingSortExtended(resSerial);
PrepareParallelSorting(resParallel);

Console.WriteLine(EqualityMatrix(resSerial, resParallel));