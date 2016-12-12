using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public sealed class InputNeuron : NeuronBase
    {

        public double InputVage { get; set; }

        public InputNeuron() : base()
        {

            InputVage = GetSartWage();
        }

        public override double CalculateValue()
        {
            return 0.0;
        }
    }
}
