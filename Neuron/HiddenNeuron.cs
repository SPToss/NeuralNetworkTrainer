using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer.Neuron
{
    public class HiddenNeuron : NeuronBase
    {
        List<double> InputVages { get; set; } = new List<double>();
        public HiddenNeuron(int inputNeurons) : base()
        {
            for(int i = 0; i < inputNeurons; i++)
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
