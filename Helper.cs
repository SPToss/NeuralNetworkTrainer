using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer
{
    public class Helper
    {
        private Dictionary<string, string> Data;

        public Helper()
        {
            Data = CreateControlData();
        }
        private Dictionary<string, string> CreateControlData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 0; i <= 255; i++)
            {
                string value = string.Empty;
                if(i== 0)
                {
                    value = "0";
                }
                else
                {
                    value = "1";
                }

                value = value.PadRight(i, '0');                
                value = value.PadLeft(255, '0');
                string key = Convert.ToString(i, 2);
                key = key.PadLeft(8, '0');
                result.Add(key, value);
            }
            return result;
        }

        public Dictionary<int,int[]> GetInputs()
        {
            int i = 0;
            Dictionary<int, int[]> inputs = new Dictionary<int, int[]>();
            foreach(var data in Data)
            {
                var chars = data.Key.ToCharArray();
                List<int> inputsValue = new List<int>();
                foreach(var inputChar in chars)
                {
                    inputsValue.Add((int)Char.GetNumericValue(inputChar));
                }
                inputs.Add(i, inputsValue.ToArray());
                i++;
            }
            return inputs;
        }

        public Dictionary<int,int[]> GetOutputs()
        {
            int i = 0;
            Dictionary<int, int[]> outputs = new Dictionary<int, int[]>();
            foreach (var data in Data)
            {
                var chars = data.Value.ToCharArray();
                List<int> outputsValue = new List<int>();
                foreach (var inputChar in chars)
                {
                    outputsValue.Add((int)Char.GetNumericValue(inputChar));
                }
                outputs.Add(i, outputsValue.ToArray());
                i++;
            }
            return outputs;
        }
    }
}
