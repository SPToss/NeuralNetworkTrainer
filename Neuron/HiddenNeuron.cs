using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public class HiddenNeuron : NeuronBase
    {
        public List<double> _inputVages { get; set; } = new List<double>();
        public List<double> InputsDeltas { get; set; } = new List<double>();
        public HiddenNeuron(int inputCount) : base()
        {
            Name = @"HiddenNeuron\HiddenVage";
            for (int i = 0; i < inputCount; i++)
            {
                _inputVages.Add(GetSartWage());
                InputsDeltas.Add(0);
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
        public double CalculateBackPropagation(List<OutputNeuron> OutputValue, int iterator)
        {
            var x = 0.0;
            foreach (var output in OutputValue)
            {
                x += output.BackPropagationValue * output._inputVages[iterator];
            }

            BackPropagationValue = x * (NeuronValue * (1 - NeuronValue));
            return x;
        }

        public void UpdateVage(List<InputNeuron> inputs, double trainRate)
        {
            int iterator = 0;
            List<double> newVage = new List<double>();
            foreach(var vage in _inputVages)
            {
                var delta = trainRate * BackPropagationValue * inputs[iterator++].NeuronValue;
                double newVages = vage + delta;
                newVages += 0.01 * InputsDeltas[--iterator];
                newVage.Add(newVages);
                InputsDeltas[iterator] = delta;
                iterator++;
            }
            _inputVages.Clear();
            _inputVages.AddRange(newVage);
        }

        public void SaveToFIle(int i)
        {
            FileHelper.SaveDataToFile(_inputVages.ToArray(), Name + i);
        }
    }
}
