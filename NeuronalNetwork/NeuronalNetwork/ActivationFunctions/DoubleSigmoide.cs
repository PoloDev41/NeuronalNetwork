using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuronalNetwork.ActivationFunctions
{
    /// <summary>
    /// Sigmoide function [-1;1]
    /// </summary>
    public class DoubleSigmoide : IActivationFunction
    {
        private double Sigmoide(double value)
        {
            if (value < -40)
                return -1;
            else if (value > 40)
                return 1;
            else
                return (1 / (1 + Math.Exp(-value)));
        }

        public double ComputeDerivateValue(double value)
        {
            double temp = Sigmoide(value);
            return 2 * temp * (1 - temp);
        }

        public double ComputeValue(double value)
        {
            return Sigmoide(value) * 2 - 1;
        }
    }
}
