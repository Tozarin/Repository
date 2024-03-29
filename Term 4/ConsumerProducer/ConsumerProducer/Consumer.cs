﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerProducer.Locks;

namespace ConsumerProducer
{
    public class Consumer
    {
        private Thread thread;
        private List<Data<string>> tasks;
        private volatile bool stop;
        private ILock locker;

        public Consumer(ILock locker, List<Data<string>> tasks, string threadName)
        {
            this.locker = locker;

            thread = new Thread(Work);
            thread.Name = threadName;
            this.tasks = tasks;
            stop = false;
            thread.Start();
        }

        private void Work()
        {
            while (!stop)
            {
                locker.Lock();
                if (tasks.Count > 0)
                {
                    var gettedData = tasks.First();
                    Console.WriteLine($"Consumer {Thread.CurrentThread.Name} get data from {gettedData.Inf}");
                    tasks.RemoveAt(0);
                }
                locker.Unlock();

                Thread.Sleep(1000);
            }
        }

        private void Stop()
        {
            stop = true;
        }

        public void Join()
        {
            Stop();
            thread.Join();
        }
    }
}
