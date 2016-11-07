using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetworkTrainer
{
    public class Network
    {
        private Network(int inputNeural, int outputNeural, int hiddenNeural) { }

        public static Network Initate(int inputNeural, int outputNeural, int hiddenNeural)
        {
            return new Network(inputNeural, outputNeural, hiddenNeural);
        }
    }
}
    