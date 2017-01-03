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
        public OutputNeuron(int hiddentCount) : base()
        {
            for (int i = 0; i < hiddentCount; i++)
            {
                _inputVages.Add(GetSartWage());
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
                newVage.Add(vage * trainRate * BackPropagationValue * hiddens[iterator++].NeuronValue);
            }
            _inputVages.Clear();
            _inputVages.AddRange(newVage);
        }
    }
}
