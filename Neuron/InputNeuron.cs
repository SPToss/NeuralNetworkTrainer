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

        public double CalculateBackPropagation(List<HiddenNeuron> OutputValue,int iterator)
        {
            var x = 0.0;
            foreach (var output in OutputValue)
            {
                x += output.BackPropagationValue * output._inputVages[iterator];
            }

            BackPropagationValue = x;
            return x;
        }
    }
}
