using NeuronalNetwork.ActivationFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.Neuronal
{
    /// <summary>
    /// neurone class
    /// </summary>
    public class Neurone
    {
        /// <summary>
        /// weight of the neurone
        /// </summary>
        public double[] Weight { get; internal set; }

        /// <summary>
        /// Activation function of the Neurone
        /// </summary>
        public IActivationFunction ActionFunction { get; internal set; }

        public double Error { get; internal set; }

        private double[] _lastInputs;

        private double _lastSum = 0;

        /// <summary>
        /// last output of the neurone
        /// </summary>
        public double LastOutput { get; internal set; }

        public double LastQuadraticError { get; set; }

        public Neurone(int numberInput, IActivationFunction function)
        {
            Weight = new double[numberInput+1];
            for (int i = 0; i < Weight.Length; i++)
            {
                Weight[i] = 0;
            }

            ActionFunction = function;
        }

        public double ComputeOutput(double[] inputs)
        {
            if (inputs.Length != Weight.Length - 1)
                throw new ArgumentException("inputs are not the same length same weight");

            _lastInputs = inputs;

            double sum = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                sum += inputs[i] * Weight[i];
            }
            sum += Weight[Weight.Length - 1]; //don't forget the threshold

            _lastSum = sum;
            LastOutput = ActionFunction.ComputeValue(_lastSum);

            return LastOutput;
        }

        public double ComputeError(double error)
        {
            Error = ActionFunction.ComputeDerivateValue(_lastSum) * (error);
            return Error;
        }

        public void RefreshWeights(double epsilon, double[] inputs)
        {
            for (int i = 0; i < Weight.Length-1; i++)
            {
                Weight[i] += epsilon * Error * inputs[i];
            }

            Weight[Weight.Length -1 ] += epsilon * Error;
        }
    }
}
