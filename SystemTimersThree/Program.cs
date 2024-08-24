using System;
using System.IO;
using System.Text;
using System.Timers;

// System.Timers

namespace SystemTimersThree
{
   internal class Program
   {
      static void Main()
      {
         // Реализация обработчиков
         // До сих пор использовали явно определенные методы в качестве обработчиков событий для таймера
         // Однако есть больше возможностей для реализации обработчиков
         // Всякий раз, когда имеем дело с действительно простыми обработчиками,
         // возможно использовать лямбда-синтаксис для сокращения реализации
         //Timer timer = new Timer(1000);
         //timer.Elapsed += (sender, eventArgs) =>
         //{
         //   Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}");
         //};

         //timer.Start();

         // Возможно реализовать асинхронные обработчики событий
         // Вариант 1
         //Timer timer = new Timer(1000);
         //timer.Elapsed += async (sender, eventArgs) =>
         //{
         //   await Task.Run(() => Console.WriteLine($"Прошедшее событие в {eventArgs.SignalTime:G}"));
         //};

         //timer.Start();

         // Вариант 2
         // Создаем StringWriter и заполняем его
         //StringWriter sw = new StringWriter();
         //Timer timer = new Timer(1000);
         //timer.Elapsed += async (sender, eventArgs) =>
         //{
         //   // Заполняем StringWriter
         //   await sw.WriteAsync($"Прошедшее событие в {eventArgs.SignalTime:G}");
         //   // Печатаем StringWriter
         //   Console.WriteLine(sw);
         //   // Возвращаем базовый объект StringBuilder
         //   StringBuilder sb = sw.GetStringBuilder();
         //   // Очищаем StringBuilder
         //   //sb.Remove(0, sb.Length);
         //   sb.Clear();
         //   //Console.WriteLine(sw);
         //};
         //timer.Start();

         // Вариант 3
         // Создаем StringBuilder
         //StringBuilder sb = new StringBuilder();
         //// Создаем StringWriter
         //StringWriter sw = new StringWriter(sb);
         //Timer timer = new Timer(1000);
         //timer.Elapsed += async (sender, eventArgs) =>
         //{
         //   // Заполняем StringWriter
         //   await sw.WriteAsync($"Прошедшее событие в {eventArgs.SignalTime:G}");
         //   // Печатаем StringWriter
         //   Console.WriteLine(sw);
         //   // Очищаем StringBuilder
         //   //sb.Remove(0, sb.Length);
         //   sb.Clear();
         //   //Console.WriteLine(sw);
         //};
         //timer.Start();

         // Вариант 4
         Timer timer = new Timer(1000);
         timer.Elapsed += async (sender, eventArgs) =>
         {
            // Создаем StringBuilder
            StringBuilder sb = new StringBuilder();
            // Создаем StringWriter
            await using StringWriter sw = new StringWriter(sb);
            // Заполняем StringWriter
            await sw.WriteAsync($"Прошедшее событие в {eventArgs.SignalTime:G}");
            // Печатаем StringWriter
            Console.WriteLine(sw);
            // Очищаем StringBuilder
            //sb.Remove(0, sb.Length);
            sb.Clear();
            //Console.WriteLine(sw);
         };
         timer.Start();

         Console.ReadLine();
      }
   }
}