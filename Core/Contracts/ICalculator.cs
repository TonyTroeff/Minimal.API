namespace Core.Contracts;

public interface ICalculator
{
    int Add(int a, int b);
    Task<int> AddAsync(int a, int b, CancellationToken cancellationToken);
    
    int Subtract(int a, int b);
    Task<int> SubtractAsync(int a, int b, CancellationToken cancellationToken);

    int Multiply(int a, int b);
    Task<int> MultiplyAsync(int a, int b, CancellationToken cancellationToken);

    int Divide(int a, int b);
    Task<int> DivideAsync(int a, int b, CancellationToken cancellationToken);

    int[] FindAllPrimes(int max);
}