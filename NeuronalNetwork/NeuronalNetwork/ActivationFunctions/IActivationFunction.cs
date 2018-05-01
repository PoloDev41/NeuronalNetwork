using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.ActivationFunctions
{
    /// <summary>
    /// interface of a activation function
    /// </summary>
    public interface IActivationFunction
    {
        /// <summary>
        /// compute the Y of a given X
        /// </summary>
        /// <param name="value">X value</param>
        /// <returns>Y value</returns>
        double ComputeValue(double value);

        /// <summary>
        /// compute the derivate value of a given X
        /// </summary>
        /// <param name="value">X value</param>
        /// <returns>Y value</returns>
        double ComputeDerivateValue(double value);
    }
}
