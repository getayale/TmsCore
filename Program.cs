
using System.Diagnostics;

Console.WriteLine("=== Exercise 6: Async vs Blocking Demo ===\n");

var sw = Stopwatch.StartNew();


// 1. BLOCKING 

for (int i = 0; i < 5; i++)
{
    System.Threading.Thread.Sleep(300);
}

sw.Stop();
Console.WriteLine($"Blocking sequential: {sw.ElapsedMilliseconds}ms");


// 2. ASYNC SEQUENTIAL

sw.Restart();

for (int i = 0; i < 5; i++)
{
    await Task.Delay(300);
}

sw.Stop();
Console.WriteLine($"Async sequential: {sw.ElapsedMilliseconds}ms");


// 3. ASYNC PARALLEL (BEST)

sw.Restart();

var tasks = Enumerable.Range(0, 5)
    .Select(_ => Task.Delay(300));

await Task.WhenAll(tasks);

sw.Stop();
Console.WriteLine($"Async parallel: {sw.ElapsedMilliseconds}ms");

Console.WriteLine("\n=== End of Exercise 6 ===");