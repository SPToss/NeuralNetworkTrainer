using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NeuralNetworkTrainer
{
    public class FileHelper
    {
        private const string filePath = "E:/Weights.txt";
        public static void SaveDataToFile(double[] data)
        {
            using(StreamWriter sr = new StreamWriter(@filePath))
            {
                foreach(var item in data)
                {
                    sr.WriteLine(item.ToString());
                }
            }           
        }

        public static double[] LoadDataFromFile()
        {   
            var lines = File.ReadLines(@filePath).ToArray();
            return lines.Select(x => Convert.ToDouble(x)).ToArray();
        }
    }
}
