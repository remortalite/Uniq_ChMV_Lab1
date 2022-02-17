public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello from Main()");

        TestHW1.Run();
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
        if (customers.Length == 0)
            return 0;
        while (true)
        {
            int emptyQue;
            while ((emptyQue = getEmptyQue(que)) != -1 && count < customers.Length)
            {
                que[emptyQue] = customers[nextPerson];
                nextPerson++;
                count++;
            }

            makeStep(que, ref step);

            if (count >= customers.Length && isQueEmpty(que))
                break;
        }
        // Console.WriteLine($"Steps: {step}");
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

public class TestHW1
{

    public static void Run()
    {
        Test1();
        Test2();
        Test3();
        Test4();
        Test5();
        Test6();
        Test7();
        Test8();

        PrintResults();
    }

    static int Test1()
    {
        string name = "Test1";
        int[] customers = { 5, 3, 4 };
        int n = 1;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 12;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test2()
    {
        string name = "Test2";
        int[] customers = { 10, 2, 3, 3 };
        int n = 2;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 10;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test3()
    {
        string name = "Test3";
        int[] customers = { 2, 3, 10 };
        int n = 2;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 12;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test4()
    {
        string name = "Test4";
        int[] customers = { 5, 4, 3, 4, 5 };
        int n = 3;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 9;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test5()
    {
        string name = "Test5";
        int[] customers = { 5, 4, 3, 4, 5, 4, 2 };
        int n = 3;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 9;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test6()
    {
        string name = "Test6";
        int[] customers = { 5, 4, 3, 4, 5, 4, 3 };
        int n = 3;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 10;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }

    static int Test7()
    {
        string name = "Test7";
        int[] customers = {};
        int n = 3;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 0;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        Console.WriteLine($"result: {result}");
        testFail(name);
        return 0;
    }

    static int Test8()
    {
        string name = "Test8";
        int[] customers = { 1 };
        int n = 30;
        long result = HW1.QueueTime(customers, n);
        long resultCorrect = 1;
        if (result == resultCorrect)
        {
            testSuccess(name);
            return 1;
        }
        testFail(name);
        return 0;
    }
    static int correct = 0;
    static int wrong = 0;

    static void testSuccess(string name)
    {
        Console.WriteLine($"{name} is completed succesfully.");
        ++correct;
    }

    static void testFail(string name)
    {
        Console.WriteLine($"{name} is failed.");
        ++wrong;
    }

    static void PrintResults() => Console.WriteLine("--------\n" +
                                                    $"Tests succesfully completed: {correct}/{correct + wrong}");
}