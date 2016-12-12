using NeuralNetworkTrainer.Neuron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer
{
    public class Network
    {
        public static Random random;
        public Dictionary<int, int[]> InputsValues {get;set;}
        public Dictionary<int, int[]> OutputsValues { get; set; }
        public List<InputNeuron> Inputs { get; set; } = new List<InputNeuron>();
        public List<HiddenNeuron> Hiddens { get; set; } = new List<HiddenNeuron>();
        public List<OutputNeuron> Outputs { get; set; } = new List<OutputNeuron>();
        public Network(int inputs, int hidden, int outputs)
        {
            random = new Random(DateTime.Now.Millisecond);
            Helper helper = new Helper();
            InputsValues = helper.GetInputs();
            OutputsValues = helper.GetOutputs();
            for(int i = 0; i< inputs; i++)
            {
                Inputs.Add(new InputNeuron());
            }
            for (int i = 0; i < hidden; i++)
            {
                Hiddens.Add(new HiddenNeuron(Inputs.Count));
            }
            for (int i = 0; i < outputs; i++)
            {
                Outputs.Add(new OutputNeuron(Hiddens.Count));
            }
        }

        public void Train(int trainRate)
        {
            var _trainRate = trainRate;
        }

        private int GetRandomInput()
        {
            return random.Next(0, InputsValues.Count - 1);
        }
    }
}
    