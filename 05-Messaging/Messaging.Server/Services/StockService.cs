public record Stock(string Name, double Price);

public class StockService
{
    private TaskCompletionSource<Stock?> _tcs = new();
    private long _id = 0;
    
    public void Reset()
    {
        _tcs = new TaskCompletionSource<Stock?>();
    }

    public void NotifyNewStockAvailable()
    {
        _tcs.TrySetResult(new Stock($"Stock Name {_id++}", Random.Shared.Next(0, 500)));
    }

    public Task<Stock?> WaitForNewStock()
    {
        // Simulate some delay in Item arrival
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(Random.Shared.Next(0, 5)));
            NotifyNewStockAvailable();
        });
        
        return _tcs.Task;
    }
}