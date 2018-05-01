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
    public class FullyConnectedNetwork
    {
        /// <summary>
        /// layers of the network
        /// </summary>
        public Layer[] Layers { get; internal set; }

        public double[] LastOuputs { get; internal set; }

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

        public double[] ComputeOutputs(double[] inputs)
        {
            double[] layerOuts = Layers[0].ComputeOutputs(inputs);
            for (int i = 1; i < Layers.Length; i++)
            {
                layerOuts = Layers[1].ComputeOutputs(layerOuts);
            }
            LastOuputs = layerOuts;

            return layerOuts;
        }
    }
}
