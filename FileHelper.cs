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
        public static void SaveDataToFile(double[] data,string fileName)
        {
            using (StreamWriter sr = new StreamWriter(@"E:\NeuralNetwork\" + fileName + ".txt"))
            {
                foreach(var item in data)
                {
                    sr.WriteLine(item.ToString());
                }
            }           
        }

        public static void SaveDataToFile(string[] data, string fileName)
        {
            using (StreamWriter sr = new StreamWriter(@"E:\NeuralNetwork\" + fileName + ".txt"))
            {
                foreach (var item in data)
                {
                    sr.WriteLine(item);
                }
            }
        }

        public static double[] LoadDataFromFile(string filename)
        {   
            var lines = File.ReadLines(@filename).ToArray();
            return lines.Select(x => Convert.ToDouble(x)).ToArray();
        }
    }
}
