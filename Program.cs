using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdb2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var pub = new Countdown();
            var sub1 = new Subscriber();
            var sub2 = new Subscriber2();
            var sub3 = new Subscriber3();
            pub.Handler += new Countdown.EvHandler(sub1.OnSubscribe);
            pub.Handler += new Countdown.EvHandler(sub2.OnSubscribe);
            pub.Handler += new Countdown.EvHandler(sub3.OnSubscribe);
            pub.Publish();
            Console.ReadLine();
        }
    }
    class Countdown
    {
        public delegate void EvHandler(int a);
        public event EvHandler? Handler;
        private void OnPublish()
        {
            Thread.Sleep(WaitTime);
            Handler?.Invoke(WaitTime/1000);
        }
        private int waitTime = 5;
        public int WaitTime { get => waitTime; set => waitTime = value; }
        public void Publish ()
        {
            Console.WriteLine("Введите время ожидания сообщения в секундах");
            bool successful;
            int i;
            do
            {
                successful = int.TryParse(Console.ReadLine(), out i);
            } while (!successful);
            WaitTime = i * 1000;
            Console.WriteLine("Сообщение было создано");
            OnPublish();
        }
    }
    class Subscriber
    {
        public void OnSubscribe(int a)
        {
            Console.WriteLine("Sub1 got message in {0} seconds",a);
        }
    }
    class Subscriber2
    {
        public void OnSubscribe(int a)
        {
            Console.WriteLine("Sub2 got message in {0} seconds", a);
        }
    }
    class Subscriber3
    {
        public void OnSubscribe(int a)
        {
            Console.WriteLine("Sub3 got message in {0} seconds", a);
        }
    }
}