using System;
using System.Timers;

// System.Timers

namespace SystemTimersTwo
{
   internal class Program
   {
      static void Main()
      {
         // Генерация повторяющихся событий с помощью таймера
         // Любой созданный таймер будет многократно вызывать события после запуска
         // Это связано с тем, что свойство таймера AutoReset по умолчанию установлено в true
         // Однако где нужен таймер для вызова события Elapsed только один раз,
         // необходимо установить свойство в AutoReset = false
         var timer = new Timer(1000);
         timer.Elapsed += OnEventExecution;
         // Отключить повторяющиеся события
         timer.AutoReset = false;
         timer.Start();

         Console.ReadLine();
      }

      public static void OnEventExecution(object sender, ElapsedEventArgs eventArgs)
      {
         Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}");
      }
   }
}