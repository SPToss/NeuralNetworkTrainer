using log4net.Config;
using NeuralNetworkTrainer;
using NeuralNetworkTrainer.Neuron;
using System;
using System.Collections.Generic;

namespace NeuralNetworkTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            string t = string.Empty;
            List<string> eleme = new List<string>();
            var tt = 0;
            for(int i = 0; i<=7; i++)
            {
                string str = "InputNeuronVage" + i + " = ";
                var s = @"E:\NeuralNetwork\InputNeuron\InputVage" + i + ".txt";
                var ae = FileHelper.LoadDataFromFile(s);
                foreach(var ss in ae)
                {
                    str +=ss.ToString().Replace(',', '.') + ';';
                }
                str = str.TrimEnd(';');
                str = str.TrimEnd(',');
                eleme.Add(str);
            }
            FileHelper.SaveDataToFile(eleme.ToArray(), "aaaaa");
           
            //Network network = new Network(8, 46, 255);
            //network.Train(0.1, 0.2);
            var stop = 0; 
        }
    }
}