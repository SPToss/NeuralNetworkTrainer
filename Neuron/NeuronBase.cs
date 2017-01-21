using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public abstract class NeuronBase
    {
        public static Random random = null;
        public double NeuronValue { get; set; }
        public double BackPropagationValue { get; set;}
        public string Name;

        public NeuronBase()
        {
            if(random == null)
            {
                random = new Random(DateTime.Now.Millisecond);
            }
        }
        public double GetSartWage()
        {
            return random.NextDouble() * (1 / Math.Sqrt(310) - (-1/Math.Sqrt(310))) + (-1/Math.Sqrt(310)) ;
        }


        public double ActivationFunction(double value)
        {
            return 1 / (1 + Math.Pow(Math.E, -value));
        }
    }
}
