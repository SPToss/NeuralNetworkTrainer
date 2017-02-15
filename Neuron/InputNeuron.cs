using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public sealed class InputNeuron : NeuronBase
    {

        public List<double> InputVages { get; set; } = new List<double>();
        public List<int> InputValues { get; set; }
        public List<double> InputsDeltas { get; set; }= new List<double>();
        public InputNeuron(int inputCount) : base()
        {
            Name = @"InputNeuron\InputVage";
            for (int i = 0; i < inputCount; i++)
            {
                InputVages.Add(GetSartWage());
                InputsDeltas.Add(0);
            }
        }

        public double CalculateValue()
        {
            var value = 0.0;
            for(int i = 0; i< InputVages.Count; i++)
            {
                value += InputVages[i] * InputValues[i];
            }
            NeuronValue = ActivationFunction(value);
            return NeuronValue;
        }

        public double CalculateBackPropagation(List<HiddenNeuron> OutputValue,int iterator)
        {
            var x = 0.0;
            foreach (var output in OutputValue)
            {
                x += output.BackPropagationValue * output._inputVages[iterator];
            }

            BackPropagationValue = x * (NeuronValue * (1 - NeuronValue));
            return x;
        }

        public void UpdateVage(double trainRate)
        {
            //int iterator = 0;
            List<double> newVage = new List<double>();
            for(int i = 0; i< InputVages.Count(); i++)
            {
                var delta = trainRate * BackPropagationValue * InputValues[i];
                double newVages = InputVages[i] + delta;
                newVages += 0.01 * InputsDeltas[i];
                newVage.Add(newVages);
                InputsDeltas[i] = delta;
            }
            InputVages.Clear();
            InputVages.AddRange(newVage);
        }
        public void SaveToFIle(int i)
        {
            FileHelper.SaveDataToFile(InputVages.ToArray(), Name + i);
        }
    }
}
