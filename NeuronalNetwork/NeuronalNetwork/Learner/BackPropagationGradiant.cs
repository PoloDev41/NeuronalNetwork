using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronalNetwork.Neuronal;

namespace NeuronalNetwork.Learner
{
    public class BackPropagationGradiant
    {
        public double LearningRate = 0.75;

        public double MeanQuadraticError = 0;

        public List<Sample> LearningBase { get; set; } = new List<Sample>();

        public BaseNeuronalNetwork Network { get; set; }

        public BackPropagationGradiant(BaseNeuronalNetwork network)
        {
            this.Network = network;
        }

        /// <summary>
        /// last quadratic error computed
        /// </summary>
        public double LastQuadraticError { get; internal set; }

        /// <summary>
        /// compute the quadratic error
        /// </summary>
        /// <param name="expected">expected outputs</param>
        /// <returns>quadratic error</returns>
        public double ComputeQuadraticError(double[] expected)
        {
            if (expected.Length != Network.Layers[Network.Layers.Length - 1].Neurones.Length)
                throw new ArgumentException();

            double sum = 0;
            for (int i = 0; i < expected.Length; i++)
            {
                sum += Math.Pow(expected[i] - Network.LastLayer.Neurones[i].LastOutput, 2);
            }

            LastQuadraticError = sum / 2;
            return LastQuadraticError;
        }

        public void LearnOneSample(Sample sample)
        {
            double[] outs = Network.ComputeOutputs(sample.Inputs);
            double[] error = new double[sample.Outputs.Length];
            for (int i = 0; i < error.Length; i++)
            {
                error[i] = sample.Outputs[i] - outs[i];
            }
            for (int i = Network.Layers.Length - 1; i >= 0; i--)
            {
                Network.Layers[i].ComputeError(error);
                error = Network.Layers[i].ComputePonderateError();
            }
            for (int i = 0; i < Network.Layers.Length; i++)
            {
                for (int j = 0; j < Network.Layers[i].Neurones.Length; j++)
                {
                    Network.Layers[i].Neurones[j].RefreshWeights(LearningRate, sample.Inputs);
                }
            }

            ComputeQuadraticError(sample.Outputs);
        }

        public void LearnOneLoopBase()
        {
            double sum = 0;
            for (int i = 0; i < LearningBase.Count; i++)
            {
                LearnOneSample(LearningBase[i]);
                sum += LastQuadraticError;
            }
            MeanQuadraticError = sum / LearningBase.Count;
        }

        public void AddSample(Sample sample)
        {
            LearningBase.Add(sample);
        }
    }
}
