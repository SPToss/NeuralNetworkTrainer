using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public class OutputNeuron : NeuronBase
    {
        public List<double> _inputVages { get; set; } = new List<double>();
        public double ExpectedOutput { get; set; }
        public List<double> InputsDeltas { get; set; } = new List<double>();
        public OutputNeuron(int hiddentCount) : base()
        {
            Name = @"OutputNeuron\OutputVage";
            for (int i = 0; i < hiddentCount; i++)
            {
                _inputVages.Add(GetSartWage());
                InputsDeltas.Add(0);
            }
        }
        public double CalculateValue(List<double> hiddenValues)
        {
            double x = 0.0;
            int iterator = 0;
            foreach (var hidden in hiddenValues)
            {
                x += (hidden * _inputVages[iterator]);
                iterator++;
            }
            NeuronValue = ActivationFunction(x);
            return NeuronValue;
        }

        public double CalculateBackPropagation()
        {
            BackPropagationValue =  (ExpectedOutput - NeuronValue) * (NeuronValue * (1 - NeuronValue));
            return BackPropagationValue;
        }

        public void UpdateVage(List<HiddenNeuron> hiddens, double trainRate)
        {
            int iterator = 0;
            List<double> newVage = new List<double>();
            foreach (var vage in _inputVages)
            {
                var delta = trainRate * BackPropagationValue * hiddens[iterator++].NeuronValue;
                double newVages = vage + delta;
                newVages += 0.01 * InputsDeltas[--iterator];
                newVage.Add(newVages);
                //newVage.Add(vage + trainRate * BackPropagationValue * hiddens[hiddens++].NeuronValue);
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
