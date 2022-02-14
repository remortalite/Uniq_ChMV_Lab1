public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Hello from Main()");
        HW1.QueueTime(new int[] { 10, 2, 3, 3 }, 2);
	}
}

public class HW1
{
	public static long QueueTime(int[] customers, int n)
	{
		int nextPerson = 0;
		int count = 0;
		int[] que = new int[n];
		int step = 0;
		while (true)
        {
			if (count < customers.Length)
			{
				int emptyQue = getEmptyQue(que);
				if (emptyQue != -1)
				{
					que[emptyQue] = customers[nextPerson];
					nextPerson++;
					count++;
				}
			}

			makeStep(que, ref step);

			if (count >= customers.Length && isQueEmpty(que))
				break;
		}
		Console.WriteLine($"Steps: {step}");
		return step;

		int getEmptyQue(int[] que)
        {
			for (int i = 0; i < que.Length; ++i)
            {
				if (que[i] == 0)
					return i;
            }
			return -1;
        }

		void makeStep(int[] que, ref int step)
        {
			for (int i = 0; i < que.Length; ++i)
            {
				if (que[i] > 0)
					--que[i];
            }
			++step;
        }

		bool isQueEmpty(int[] que)
        {
			foreach (var el in que)
            {
				if (el != 0)
					return false;
            }
			return true;
        }
	}
}