using System;
using System.Threading.Tasks;
using System.Timers;


// System.Timers

namespace SystemTimersFour
{
   internal class Program
   {
      static void Main()
      {
         // Обработка исключений
         // Всякий раз, когда обработчик событий таймера выбрасывает исключение, компонент таймера перехватывает его и подавляет
         // Следующий код не будет записывать сообщения об исключениях в консоль
         //Timer timer = new Timer(1000);
         //timer.Elapsed += (sender, eventArgs) =>
         //{
         //   Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}");
         //   throw new Exception();
         //};
         //timer.Start();

         // Исключения, возникающие в асинхронных обработчиках, не будут подавляться компонентом таймера
         // Программа покажет сообщение об ошибке и завершит работу
         Timer timer = new Timer(1000);
         timer.Elapsed += async (sender, eventArgs) =>
         {
            await Task.Run(() => Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}"));
            throw new Exception();
         };
         timer.Start();

         Console.ReadLine();
      }
   }
}