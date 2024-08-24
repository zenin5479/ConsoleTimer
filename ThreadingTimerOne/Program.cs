using System;
using System.Threading;

// System.Threading.Timer

namespace ThreadingTimerOne
{
   internal class Program
   {
      static void Main()
      {
         // Создаем AutoResetEvent чтобы сигнализировать о достижении порога тайм-аута в обратном вызове по таймеру
         // AutoResetEvent событие синхронизации потоков, которое при сигнале освобождает один поток ожидания и автоматически сбрасывает его
         AutoResetEvent autoEvent = new AutoResetEvent(false);

         StatusChecker statusChecker = new StatusChecker(7);

         // Создаем таймер, который запускает проверку состояния через 0,5 секунды, и каждые 0,5 секунды после этого
         Console.WriteLine("{0:h:mm:ss.fff} Создание таймера\n", DateTime.Now);
         Timer stateTimer = new Timer(statusChecker.CheckStatus, autoEvent, 500, 500);

         // При появлении сигнала автоматического события изменяем период на каждые 0,3 секунды.
         autoEvent.WaitOne();
         stateTimer.Change(0, 300);
         Console.WriteLine("\nИзменение периода на 0,3 секунды.\n");

         // Когда автоматическое событие подаст сигнал во второй раз, отключаем таймер
         autoEvent.WaitOne();
         stateTimer.Dispose();
         Console.WriteLine("\nОсвобождение ресурсов");

         Console.ReadLine();
      }
   }

   class StatusChecker
   {
      private int _invokeCount;
      private readonly int _maxCount;

      public StatusChecker(int count)
      {
         _invokeCount = 0;
         _maxCount = count;
      }

      // Метод вызывается делегатом таймера
      public void CheckStatus(object stateInfo)
      {
         AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
         Console.WriteLine("{0:h:mm:ss.fff} Проверка статуса {1}", DateTime.Now, (++_invokeCount).ToString());

         if (_invokeCount == _maxCount)
         {
            // Сбрасываем счетчик и подаем сигнал ожидающему потоку
            _invokeCount = 0;
            autoEvent.Set();
         }
      }
   }
}