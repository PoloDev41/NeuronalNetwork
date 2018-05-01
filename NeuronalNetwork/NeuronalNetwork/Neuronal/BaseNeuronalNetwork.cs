using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.Neuronal
{
    /// <summary>
    /// base class of a neuronal network
    /// </summary>
    public class BaseNeuronalNetwork
    {
        /// <summary>
        /// layers of the network
        /// </summary>
        public Layer[] Layers { get; internal set; }

        public double[] LastOuputs { get; internal set; }

        public Layer LastLayer
        {
            get
            {
                return Layers[Layers.Length - 1];
            }
        }

        public double[] ComputeOutputs(double[] inputs)
        {
            double[] layerOuts = Layers[0].ComputeOutputs(inputs);
            for (int i = 1; i < Layers.Length; i++)
            {
                layerOuts = Layers[i].ComputeOutputs(layerOuts);
            }
            LastOuputs = layerOuts;

            return layerOuts;
        }
    }
}
