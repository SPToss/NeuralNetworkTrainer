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
        public double NeuronValue
        {
            get
            {
                return CalculateValue();
            }
        }
        public List<NeuronBase> NeuronChildren;

        public NeuronBase()
        {
            if(random == null)
            {
                random = new Random(DateTime.Now.Millisecond);
            }
        }

        public abstract double CalculateValue();

        public double GetSartWage()
        {
            return random.NextDouble() * (1 / Math.Sqrt(310) - (-1/Math.Sqrt(310))) + (-1/Math.Sqrt(310)) ;
        }

    }
}
