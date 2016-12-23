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
            Network network = new Network(8, 46, 256);
            network.Test();
            var stop = 0; 
        }
    }
}