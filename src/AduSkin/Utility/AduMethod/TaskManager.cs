using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AduSkin.Utility.AduMethod
{
    /// <summary>
    /// Task管理器
    /// </summary>
    public class TaskManager
    {
        public static void Run(Action action)
        {
            Task.Factory.StartNew(() =>
            {
                action();
            });
        }

        //public static void Run(Action action, Action<Task> callback)
        //{
        //    Task.Factory.StartNew(() =>
        //    {
        //        action();
        //    }).ContinueWith((state) =>
        //    {
        //        Execute.OnUIThread(() =>
        //        {
        //            callback?.Invoke(state);
        //        });
        //    });
        //}

        public static Task Any(Action action, int timeout)
        {
            Task taskRun = new Task(() =>
            {
                action();
            });

            Task taskTimeOut = new Task(() =>
            {
                Thread.Sleep(timeout);
            });

            //启动2个任务
            taskRun.Start();
            taskTimeOut.Start();

            Task.WaitAny(taskRun,taskTimeOut);

            //回调
            return taskRun;
        }

        /// <summary>
        /// 等待完成，或者提前
        /// </summary>
        public static Task Wait(bool ident)
        {
            Task task = Any(() =>
            {
                while (true)
                {
                    if (ident)
                    {
                        break;
                    }
                    Thread.Sleep(25);
                }
            }, 500);
            return task;
        }

        /// <summary>
        /// 读取异步数据，超时时间很长
        /// </summary>
        public static Task WaitMax(bool ident)
        {
            Task task = Any(() =>
            {
                while (true)
                {
                    if (ident)
                    {
                        break;
                    }
                    Thread.Sleep(25);
                }
            }, 30000);
            return task;
        }
    }

}
