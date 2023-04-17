const int N = 1000;
const int THREADS_NUMBER = 8;

int[,] serialMulRes = new int[N, N]; // one thread result (matrix multiplication)
int[,] threadMulRes = new int[N, N]; // parallel result

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secoundMatrix = MatrixGenerator(N, N);

SerialMatrixMultiplication(firstMatrix, secoundMatrix);
PrepareParallelMatrixMul(firstMatrix, secoundMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));





int[,] MatrixGenerator(int rows, int columns)
{
   Random random = new Random();
   int[,] resultat = new int[rows, columns];

   for (int i = 0; i < rows; i++)
   {
      for (int j = 0; j < columns; j++)
      {
         resultat[i, j] = random.Next(-100, 150);
      }
   }
   return resultat;
}

void SerialMatrixMultiplication(int[,] fMatrix, int[,] sMatrix)
{
   if (fMatrix.GetLength(1) != sMatrix.GetLength(0)) throw new Exception("Cannot multiply matrix");
   for (int i = 0; i < fMatrix.GetLength(0); i++)
   {
      for (int j = 0; j < sMatrix.GetLength(1); j++)
      {
         for (int k = 0; k < sMatrix.GetLength(0); k++)
         {
            serialMulRes[i, j] += fMatrix[i, k] * sMatrix[k, j];
         }
      }
   }
}


void PrepareParallelMatrixMul(int[,] fMatrix, int[,] sMatrix)
{
   if (fMatrix.GetLength(1) != sMatrix.GetLength(0)) throw new Exception("Cannot multiply matrix");
   int eachThreadCalc = N / THREADS_NUMBER;
   var threadsList = new List<Thread>();

   for (int i = 0; i < THREADS_NUMBER; i++)
   {
      int startPos = i * eachThreadCalc;
      int endPos = (i + 1) * eachThreadCalc;
      if (i == THREADS_NUMBER) endPos = N;

      threadsList.Add(new Thread(() => ParallelMatrixMultiplication(fMatrix, sMatrix, startPos, endPos)));
      threadsList[i].Start();
   }
   for (int i = 0; i < THREADS_NUMBER; i++)
   {
      threadsList[i].Join();
   }
}


void ParallelMatrixMultiplication(int[,] fMatrix, int[,] sMatrix, int startPos, int endPos)
{
   for (int i = startPos; i < endPos; i++)
   {
      for (int j = 0; j < sMatrix.GetLength(1); j++)
      {
         for (int k = 0; k < sMatrix.GetLength(0); k++)
         {
            threadMulRes[i, j] += fMatrix[i, k] * sMatrix[k, j];
         }
      }
   }
}


bool EqualityMatrix(int[,] fMatrix, int[,] sMatrix)
{
   bool result = true;

   for (int i = 0; i < fMatrix.GetLength(0); i++)
   {
      for (int j = 0; j < fMatrix.GetLength(1); j++)
      {
         result = result && (fMatrix[i, j] == sMatrix[i, j]);
      }
   }
   return result;
}

