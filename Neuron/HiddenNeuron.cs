using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public class HiddenNeuron : NeuronBase
    {
        private List<double> _inputVages { get; set; } = new List<double>();
        public HiddenNeuron(int inputCount) : base()
        {
            for (int i = 0; i < inputCount; i++)
            {
                _inputVages.Add(GetSartWage());
            }
        }
        public double CalculateValue(List<double> inputValues)
        {
            double x = 0.0;
            int iterator = 0;
            foreach (var input in inputValues)
            {
                x += (input * _inputVages[iterator]);
                iterator++;
            }
            NeuronValue = ActivationFunction(x);
            return NeuronValue;
        }
        public double CalculateBackPropagation(List<double> OutputValue)
        {
            var x = 0.0;
            var iterator = 0;
            foreach (var output in OutputValue)
            {
                x += output * _inputVages[iterator++];
            }

            BackPropagationValue = x;
            return x;
        }
    }
}
