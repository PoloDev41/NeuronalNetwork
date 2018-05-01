using NeuronalNetwork.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.Neuronal
{
    /// <summary>
    /// layer of a neuronal network
    /// </summary>
    public class Layer
    {
        /// <summary>
        /// neurones of the layer
        /// </summary>
        public Neurone[] Neurones { get; internal set; }

        /// <summary>
        /// last outputs of the layer
        /// </summary>
        public double[] LastOutputs { get; internal set; }

        /// <summary>
        /// create a new layer
        /// </summary>
        /// <param name="input">number of inputs</param>
        /// <param name="numberNeurones">number of neurone of the layer</param>
        public Layer(int input, int numberNeurones)
        {
            LastOutputs = new double[numberNeurones];
            Neurones = new Neurone[numberNeurones];
            for (int i = 0; i < Neurones.Length; i++)
            {
                Neurones[i] = new Neurone(input, new DoubleSigmoide());
            }
        }

        public double[] ComputeOutputs(double[] inputs)
        {
            for (int i = 0; i < Neurones.Length; i++)
            {
                LastOutputs[i] = Neurones[i].ComputeOutput(inputs);
            }
            return LastOutputs;
        }
    }
}
