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
        public double InputValue { get; set; }
        public InputNeuron() : base()
        {

            InputVage = GetSartWage();
        }

        public double CalculateValue()
        {
            NeuronValue = ActivationFunction(InputVage * InputValue);
            return NeuronValue;
        }
    }
}
