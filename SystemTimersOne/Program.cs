using System;
using System.Timers;

// System.Timers

namespace SystemTimersOne
{
   internal class Program
   {
      static void Main()
      {
         // Как работает таймер в C#
         // Создаем экземпляр класса.
         // С помощью конструктора настраиваем интервал в 1000 миллисекунд (1 секунду)
         // После этого используем статический метод в качестве обработчика события и назначаем его событию таймера
         // Вызываем метод, чтобы события начинали срабатывать с определенным интервалом
         // Другой способ запустить таймер — установить свойство Enabled в положение true
         Timer timer = new Timer(1000);
         timer.Elapsed += OnEventExecution;
         timer.Start();
         //timer.Enabled = true;
         // При необходимости можем остановить таймер, вызвав его метод Stop()
         // или установив для его свойства Enabled значение false.
         //timer.Stop();
         //timer.Enabled = false;

         Console.ReadLine();
      }

      public static void OnEventExecution(object sender, ElapsedEventArgs eventArgs)
      {
         Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}");
      }
   }
}