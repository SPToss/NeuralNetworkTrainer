using log4net;
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
        private static readonly ILog Log = LogManager.GetLogger(typeof(Network));

        public static Random random;
        public Dictionary<int, int[]> InputsValues {get;set;}
        public Dictionary<int, int[]> OutputsValues { get; set; }
        public List<InputNeuron> Inputs { get; set; } = new List<InputNeuron>();
        public List<HiddenNeuron> Hiddens { get; set; } = new List<HiddenNeuron>();
        public List<OutputNeuron> Outputs { get; set; } = new List<OutputNeuron>();
        int iteration = 0;
        public double error = 0.0;
        public Network(int inputs, int hidden, int outputs)
        {

            iteration = 0;
            error = 1.0;
            random = new Random(DateTime.Now.Millisecond);
            Helper helper = new Helper();
            InputsValues = helper.GetInputs();
            OutputsValues = helper.GetOutputs();
            for(int i = 0; i< inputs; i++)
            {
                Inputs.Add(new InputNeuron(inputs));
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
        public void Train(double wantetError,double trainRate)
        {
            var lastError = 0.0;
            while (error > wantetError)
            {
                iteration++;
                List<double> inputValues = new List<double>();
                List<double> hiddenValues = new List<double>();
                List<double> outputValues = new List<double>();
                var currentDataSet = GetRandomInput();
                var currentInput = InputsValues[currentDataSet];
                var currentOutput = OutputsValues[currentDataSet];
                var iterator = 0;
                foreach (var input in Inputs)
                {
                    input.InputValues = currentInput.ToList();
                }
                iterator = 0;
                foreach (var output in Outputs)
                {
                    output.ExpectedOutput = currentOutput[iterator++];
                }
                inputValues = Inputs.Select(x => x.CalculateValue()).ToList();
                hiddenValues = Hiddens.Select(x => x.CalculateValue(inputValues)).ToList();
                outputValues = Outputs.Select(x => x.CalculateValue(hiddenValues)).ToList();

                var outputBack = Outputs.Select(x => x.CalculateBackPropagation()).ToList();
                //foreach(var t in Outputs)
                //{
                //    var x = t.CalculateBackPropagation();
                //}
                iterator = 0;
                var hidddenBack = Hiddens.Select(x => x.CalculateBackPropagation(Outputs, iterator++)).ToList();
                iterator = 0;
                var inputBack = Inputs.Select(x => x.CalculateBackPropagation(Hiddens, iterator++)).ToList();

                Inputs.ForEach(x => x.UpdateVage(trainRate));

                Hiddens.ForEach(x => x.UpdateVage(Inputs, trainRate));

                Outputs.ForEach(x => x.UpdateVage(Hiddens, trainRate));

                if (iteration % 5000 == 0)
                {
                    error = 0;
                    for (int i = 0; i < InputsValues.Count; i++)
                    {
                        var currentInputT = InputsValues[i];
                        var currentOutputT = OutputsValues[i];
                        foreach (var input in Inputs)
                        {
                            input.InputValues = currentInputT.ToList();
                        }
                        iterator = 0;
                        foreach (var output in Outputs)
                        {
                            output.ExpectedOutput = currentOutputT[iterator++];
                        }
                        inputValues = Inputs.Select(x => x.CalculateValue()).ToList();
                        hiddenValues = Hiddens.Select(x => x.CalculateValue(inputValues)).ToList();
                        outputValues = Outputs.Select(x => x.CalculateValue(hiddenValues)).ToList();

                        foreach (var outp in Outputs)
                        {
                            error += Math.Pow((outp.NeuronValue - outp.ExpectedOutput), 2.0);
                        }

                    }
                    Console.Write($"{error}");
                    if (error < lastError)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.WriteLine($"            change  : {error - lastError}");
                    Console.ResetColor();
                    Log.Debug($"Iteration : {iteration} \t Current Error : {error} \t Change : {error - lastError}");
                    lastError = error;
                    int it = 0;
                    Inputs.ForEach(x => x.SaveToFIle(it++));
                    it = 0;
                    Hiddens.ForEach(x => x.SaveToFIle(it++));
                    it = 0;
                    Outputs.ForEach(x => x.SaveToFIle(it++));
                }
            }

        }

        private int GetRandomInput()
        {
            return random.Next(0, InputsValues.Count - 1);
        }
    }
}
    