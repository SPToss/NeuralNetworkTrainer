using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer
{
    public class Helper
    {
        public Dictionary<string, string> CreateControlData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            for (int i = 1; i <= 255; i++)
            {
                string value = string.Empty;
                value = "1";
                value = value.PadRight(i, '0');                
                value = value.PadLeft(255, '0');
                string key = Convert.ToString(i, 2);
                key = key.PadLeft(8, '0');
                result.Add(key, value);
            }
            return result;
        }
    }
}
