using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncMorningRoutineApp
{
    class Program
    {
        //##########################################################
        //STEP 1 - Initial setup
        ///// <summary>
        ///// Normal Synchronously executed Main
        ///// </summary>
        ///// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Egg eggs = FryEggs(2);
        //    Console.WriteLine("eggs are ready");

        //    Bacon bacon = FryBacon(3);
        //    Console.WriteLine("bacon is ready");

        //    Toast toast = ToastBread(2);
        //    ApplyButter(toast);
        //    ApplyJam(toast);
        //    Console.WriteLine("toast is ready");

        //    Juice oj = PourOj();
        //    Console.WriteLine("oj is ready");
        //    Console.WriteLine("Breakfast is ready!");
        //}
        //##########################################################

        //##########################################################
        //STEP 2 - Make main responsive
        /// <summary>
        /// The main thread is responsive but the tasks are executed sequentially.
        /// This code doesn't block while the eggs or the bacon are cooking.
        /// This code won't start any other tasks though.
        /// You'd still put the toast in the toaster and stare at it until it pops.
        /// But at least, you'd respond to anyone that wanted your attention.
        /// In a restaurant where multiple orders are placed,
        /// the cook could start another breakfast while the first is cooking.
        /// added await keywords before method and took the .Await()
        /// off Task.Delay(3000).Await() in the fry methods
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        //static async Task Main(string[] args)
        //{
        //    numberOfBreakfastMade += 1;
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Egg eggs = await FryEggsAsync(2);
        //    Console.WriteLine("eggs are ready");

        //    Bacon bacon = await FryBaconAsync(3);
        //    Console.WriteLine("bacon is ready");

        //    Toast toast = await ToastBreadAsync(2);
        //    ApplyButter(toast);
        //    ApplyJam(toast);
        //    Console.WriteLine("toast is ready");

        //    Juice oj = PourOj();
        //    Console.WriteLine("oj is ready");
        //    Console.WriteLine($"Breakfast {numberOfBreakfastMade} ready!");
        //}
        //##########################################################

        ////##########################################################
        ////STEP 3 - Transform Main to execute the task parallel by storing the tasks when they start instead of awaiting them 
        ////You start all the asynchronous tasks at once. You await each task only when you need the results.
        //static async Task Main(string[] args)
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    numberOfBreakfastMade += 1;
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Task<Egg> eggsTask = FryEggsAsync(2);
        //    Task<Bacon> baconTask = FryBaconAsync(3);
        //    Task<Toast> toastTask = ToastBreadAsync(2);

        //    //if any work in the toast making process is async then the whole process is async
        //    Toast toast = await toastTask;
        //    ApplyButter(toast);
        //    ApplyJam(toast);
        //    Console.WriteLine("toast is ready");
        //    Juice oj = PourOj();
        //    Console.WriteLine("oj is ready");

        //    Egg eggs = await eggsTask;
        //    Console.WriteLine("eggs are ready");
        //    Bacon bacon = await baconTask;
        //    Console.WriteLine("bacon is ready");

        //    Console.WriteLine("Breakfast is ready!");
        //    watch.Stop();
        //    Console.WriteLine(watch.Elapsed.TotalSeconds);
        //}
        ////##########################################################

        ////##########################################################
        ////STEP 4 - extracting toast task to compose a method of toast related stuff
        //static async Task Main(string[] args)
        //{
        //    Stopwatch watch = new Stopwatch();
        //    watch.Start();
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Task<Egg> eggsTask = FryEggsAsync(2);
        //    Task<Bacon> baconTask = FryBaconAsync(3);
        //    Task<Toast> toastTask = ToastWithButterAndJamToastBreadAsync(2);

        //    Juice oj = PourOj();
        //    Console.WriteLine("oj is ready");

        //    Toast toast = await toastTask;
        //    Console.WriteLine("toast is ready");

        //    Egg eggs = await eggsTask;
        //    Console.WriteLine("eggs are ready");

        //    Bacon bacon = await baconTask;
        //    Console.WriteLine("bacon is ready");

        //    Console.WriteLine("Breakfast is ready!");
        //    watch.Stop();
        //    Console.WriteLine(watch.Elapsed.TotalSeconds);
        //}
        ////##########################################################

        //##########################################################
        //STEP 5a - Task.WhenAll(IEnumerable<Task> task) -  Creates a task that will complete when all of the System.Threading.Tasks.Task objects in an array have completed.
        //static async Task Main(string[] args)
        //{
        //    Coffee cup = PourCoffee();
        //    Console.WriteLine("coffee is ready");

        //    Task<Egg> eggsTask = FryEggsAsync(2);
        //    Task<Bacon> baconTask = FryBaconAsync(3);
        //    Task<Toast> toastTask = ToastWithButterAndJamToastBreadAsync(2);

        //    Juice oj = PourOj();
        //    Console.WriteLine("oj is ready");

        //    await Task.WhenAll(eggsTask, baconTask, toastTask);
        //    Console.WriteLine("Breakfast is ready!");
        //}
        //##########################################################

        //##########################################################
        //STEP 5a - Task.WhenAny()
        //     5b - Task.WhenAll(IEnumerable<Task> task) -  Creates a task that will complete when all of the System.Threading.Tasks.Task objects in an array have completed.
        static async Task Main(string[] args)
        {
            await BreakFast_WhenAny();

            await BreakFast_WhenAll();
        }
        //##########################################################

        private static async Task BreakFast_WhenAll()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastWithButterAndJamToastBreadAsync(2);

            Juice oj = PourOj();
            Console.WriteLine("oj is ready");

            await Task.WhenAll(eggsTask, baconTask, toastTask);
            Console.WriteLine("Breakfast is ready!");
        }

        private static async Task BreakFast_WhenAny()
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastWithButterAndJamToastBreadAsync(2);

            Juice oj = PourOj();
            Console.WriteLine("oj is ready");

            List<Task> breakFastTask = new List<Task> {eggsTask, baconTask, toastTask};
            while (breakFastTask.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(breakFastTask);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("egg is ready");
                }

                if (finishedTask == baconTask)
                {
                    Console.WriteLine("bacon is ready");
                }

                if (finishedTask == toastTask)
                {
                    Console.WriteLine("toast is ready");
                }

                breakFastTask.Remove(finishedTask);
            }

            Console.WriteLine("Breakfast is ready!");
        }
        //##########################################################

        private static async Task<Toast> ToastWithButterAndJamToastBreadAsync(int toasts)
        {
            //if any work in the toast making process is async then the whole process is async
            Toast toast = await ToastBreadAsync(toasts);
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static async Task<Egg> FryEggsAsync(int i)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {i} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static async Task<Bacon> FryBaconAsync(int i)
        {
            Console.WriteLine($"putting {i} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < i; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Toast> ToastBreadAsync(int i)
        {
            for (int slice = 0; slice < i; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Juice PourOj()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        //private static Toast ToastBread(int slices)
        //{
        //    for (int slice = 0; slice < slices; slice++)
        //    {
        //        Console.WriteLine("Putting a slice of bread in the toaster");
        //    }
        //    Console.WriteLine("Start toasting...");
        //    Task.Delay(3000).Wait();
        //    Console.WriteLine("Remove toast from toaster");

        //    return new Toast();
        //}

        //private static Bacon FryBacon(int slices)
        //{
        //    Console.WriteLine($"putting {slices} slices of bacon in the pan");
        //    Console.WriteLine("cooking first side of bacon...");
        //    Task.Delay(3000).Wait();
        //    for (int slice = 0; slice < slices; slice++)
        //    {
        //        Console.WriteLine("flipping a slice of bacon");
        //    }
        //    Console.WriteLine("cooking the second side of bacon...");
        //    Task.Delay(3000).Wait();
        //    Console.WriteLine("Put bacon on plate");

        //    return new Bacon();
        //}

        //private static Egg FryEggs(int howMany)
        //{
        //    Console.WriteLine("Warming the egg pan...");
        //    Task.Delay(3000).Wait();
        //    Console.WriteLine($"cracking {howMany} eggs");
        //    Console.WriteLine("cooking the eggs ...");
        //    Task.Delay(3000).Wait();
        //    Console.WriteLine("Put eggs on plate");

        //    return new Egg();
        //}

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }

    internal class Juice
    {
    }

    internal class Toast
    {
    }

    internal class Bacon
    {
    }

    internal class Egg
    {
    }

    internal class Coffee
    {
    }
}
