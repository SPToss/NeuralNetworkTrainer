using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public class OutputNeuron : NeuronBase
    {
        List<double> InputVages { get; set; } = new List<double>();
        public OutputNeuron(int hiddenNeurons) : base()
        {
            for (int i = 0; i < hiddenNeurons; i++)
            {
                InputVages.Add(GetSartWage());
            }
        }
        public override double CalculateValue()
        {
            return 0.0;
        }
    }
}
