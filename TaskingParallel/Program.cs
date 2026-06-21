
public class Program
{
    public static async Task iteration()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }
    }

    public static async Task<int> sumArray(int[] arr)
    {
        int sum = 0;

        for(int i = 0; i < arr.Length; i++)
        {
            sum+= arr[i];
        }
        return sum;
    }

    public static async Task<int> maxArray(int[] arr)
    {
        int max = arr[0];

        for (int i = 0; i < arr.Length; i++)
        {
            if( arr[i] > max )
                max = arr[i];
        }
        return max;
    }

    /*
    public static async Task Main(string[] args)
    {
        Console.WriteLine("starting");
        var task1 = Task.Run(() => iteration());
        var task2 = Task.Run(() => iteration());
        await Task.WhenAll(task1, task2);
        Console.WriteLine("ending");
    }
    */
    public static async Task Main(string[] args)
    {
        Console.WriteLine("starting");
        int[] arr = { 1, 2, 3, 4, 5 };
        var task1=Task<int>.Run(() => sumArray(arr));
        var task2=Task<int>.Run(() => maxArray(arr));
        await Task.WhenAll(task1, task2);
        Console.WriteLine(task1.Result);
        Console.WriteLine(task2.Result);
        Console.WriteLine("ending");
    }
}
