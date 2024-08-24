using System;
using System.Timers;

// System.Timers

namespace SystemTimersFive
{
   internal class Program
   {
      static void Main()
      {
         // Утилизация таймеров
         // Компонент Timer реализует интерфейс IDisposable
         // В большинстве случаев экземпляры таймера в приложениях будут автоматически удаляться, когда они выходят из области действия
         // Однако в некоторых случаях приходится делать это вручную
         using (Timer timer = new Timer(1000))
         {
            timer.Elapsed += (sender, eventArgs) =>
            {
               Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}");
            };
            timer.Start();
            // Избегать отправки области действия таймера слишком рано
            Console.ReadLine();
         }

         //Console.ReadLine();
      }
   }
}
