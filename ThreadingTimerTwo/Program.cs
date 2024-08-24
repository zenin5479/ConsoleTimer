using System;
using System.Diagnostics;
using System.Threading;

// System.Threading.Timer

namespace ThreadingTimerTwo
{
   internal class Program
   {
      static void Main()
      {
         Stopwatch stopwatch = new Stopwatch();
         stopwatch.Start();
         Thread.Sleep(1000);
         stopwatch.Stop();
         Console.WriteLine($"Всего миллисекунд: {stopwatch.Elapsed.TotalMilliseconds:F4}");
         Console.WriteLine($"Общее количество секунд: {stopwatch.Elapsed.TotalSeconds:F7}");

         // Возвращает прошедшее время в качестве значения временного интервала
         TimeSpan ts = stopwatch.Elapsed;
         Console.WriteLine("Время выполнения " + ts);
         Console.WriteLine("Время выполнения " + ts.TotalMilliseconds);

         Console.ReadLine();
      }
   }
}