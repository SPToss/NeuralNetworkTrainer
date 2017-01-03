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
        public void Test()
        {
            List<double> inputValues = new List<double>();
            List<double> hiddenValues = new List<double>();
            List<double> outputValues = new List<double>();
            var currentDataSet = GetRandomInput();
            var currentInput = InputsValues[currentDataSet];
            var currentOutput = OutputsValues[currentDataSet];
            var iterator = 0;
            foreach(var input in Inputs)
            {
                input.InputValue = currentInput[iterator++];
            }
            iterator = 0;
            foreach (var output in Outputs)
            {
                output.ExpectedOutput = currentOutput[iterator++];
            }
            inputValues = Inputs.Select(x => x.CalculateValue()).ToList();
            hiddenValues = Hiddens.Select(x => x.CalculateValue(inputValues)).ToList();
            outputValues = Outputs.Select(x => x.CalculateValue(hiddenValues)).ToList();

            var outputBack = Outputs.Select(x => x.CalculateBackPropagation());
            iterator = 0;
            var hidddenBack = Hiddens.Select(x => x.CalculateBackPropagation(Outputs, iterator++)).ToList();
            iterator = 0;
            var inputBack = Inputs.Select(x => x.CalculateBackPropagation(Hiddens, iterator++)).ToList();

            Hiddens.ForEach(x => x.UpdateVage(Inputs, 1.2));

            Outputs.ForEach(x => x.UpdateVage(Hiddens, 1.2));
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
    