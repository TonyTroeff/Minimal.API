namespace Core;

using Core.Contracts;

public class Calculator : ICalculator
{
    public int Add(int a, int b) => a + b;
    public Task<int> AddAsync(int a, int b, CancellationToken cancellationToken) => WaitAndExecute(this.Add, a, b);

    public int Subtract(int a, int b) => a - b;
    public Task<int> SubtractAsync(int a, int b, CancellationToken cancellationToken) => WaitAndExecute(this.Subtract, a, b);

    public int Multiply(int a, int b) => a * b;
    public Task<int> MultiplyAsync(int a, int b, CancellationToken cancellationToken) => WaitAndExecute(this.Multiply, a, b);

    public int Divide(int a, int b) => a / b;
    public Task<int> DivideAsync(int a, int b, CancellationToken cancellationToken) => WaitAndExecute(this.Divide, a, b);
    
    public int[] FindAllPrimes(int max)
    {
        var primes = new List<int>();

        for (var i = 2; i <= max; i++)
        {
            var isPrime = true;
            foreach (var p in primes)
            {
                if (i % p == 0) { isPrime = false; break; }
                if (p * p > i) break;
            }
            
            if (isPrime) primes.Add(i);
        }

        return primes.ToArray();
    }

    private static async Task<int> WaitAndExecute(Func<int, int, int> func, int a, int b)
    {
        await Task.Delay(2000);
        return func(a, b);
    }
}