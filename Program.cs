using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace NeuralNetworkTrainer
{
    class Program
    {
        public static Stopwatch stopwatch = new Stopwatch();
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to NetworkTrainingProgram. Please chose operation...");
                Console.WriteLine("************************************************************");
                Console.WriteLine("1 - Train new Network");

                int option;

                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
                stopwatch.Start();
                switch (option)
                {
                    case 1:
                        {
                            var properData = new Helper().CreateControlData();
                            DisplayTime("Created data to train");
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Wrong Number");
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                DisplayTime(string.Format("An exeption occured : {0}", e));
            }
            finally
            {
                stopwatch.Stop();
                DisplayTime("Process finished. Press <ENTER> to Exit");
                Console.ReadLine();
            }
        }

        public static void DisplayTime(string description)
        {
            var ts = stopwatch.Elapsed;
            var elapsedTime = string.Format("{4}: {0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10, "RunTime");
            Console.WriteLine("Opertation : {0} complete.", description);
            Console.WriteLine("Total Time : {0}", elapsedTime);
            Console.WriteLine("___________________________________________________________");
        }
    }
}
