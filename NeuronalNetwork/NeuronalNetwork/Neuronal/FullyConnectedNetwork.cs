using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.Neuronal
{
    /// <summary>
    /// handle a fully connect neuronal network
    /// </summary>
    public class FullyConnectedNetwork: BaseNeuronalNetwork
    {
        /// <summary>
        /// create a fully connected network
        /// </summary>
        /// <param name="numberInputs">number of inputs</param>
        /// <param name="nbrNeuroneOnLayer">number of neurone of each layers</param>
        public FullyConnectedNetwork(int numberInputs, params int[] nbrNeuroneOnLayer)
        {
            if (nbrNeuroneOnLayer.Length == 0)
                throw new ArgumentException("The netowkr shall have one layer minimum.");

            Layers = new Layer[nbrNeuroneOnLayer.Length];
            Layers[0] = new Layer(numberInputs, nbrNeuroneOnLayer[0]);
            for (int i = 1; i < nbrNeuroneOnLayer.Length; i++)
            {
                Layers[i] = new Layer(nbrNeuroneOnLayer[i-1], nbrNeuroneOnLayer[i]);
            }
        }
    }
}
