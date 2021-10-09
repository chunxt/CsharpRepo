using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelForeachDemo();
        }
        static void ParallelForeachDemo()
        {
            var dic = LoadData();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            var res = dic.Values.AsParallel().Where(e => e.Age > 20 && e.Age < 25);
            foreach (var item in res)
            {
                Console.WriteLine($"{item.ID}  {item.Age}");
            }
            sw.Stop();
            Console.WriteLine($"消耗的时间为{sw.ElapsedMilliseconds}");
        }
        public static ConcurrentDictionary<int,Student> LoadData()
        {
            ConcurrentDictionary<int, Student> dic = new ConcurrentDictionary<int, Student>();
            ParallelOptions options = new ParallelOptions();
            //指定使用的硬件线程数为4
            options.MaxDegreeOfParallelism = 4;
            //预加载15000条数据
            Parallel.For(0, 15000, options, i =>
               {
                   Student st = new Student()
                   {
                       ID = i + 1,
                       Name = "tcx" + i,
                       Age = i % 151,
                       CreateTime = DateTime.Now.AddSeconds(i)
                   };
                   dic.TryAdd(i,st);
               });
            return dic;
        }
        static void Credit()
        {
            Console.WriteLine("******************  发起信用卡扣款中  ******************");

            Thread.Sleep(2000);

            Console.WriteLine("扣款成功！");
        }

        static void Email()
        {
            Console.WriteLine("******************  发送邮件确认单！*****************");

            Thread.Sleep(3000);

            Console.WriteLine("email发送成功！");

        }
    }
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

