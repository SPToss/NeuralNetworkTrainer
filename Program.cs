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
            Network network = new Network(8, 46, 255);
            network.Train(0.1, 0.2);
            var stop = 0; 
        }
    }
}