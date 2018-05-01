using NeuronalNetwork.Neuronal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FullyConnectedNetwork net = new FullyConnectedNetwork(2, 
                                                            2, 2, 1);
            double[] outs = net.ComputeOutputs(new double[] { 2,5 });
            DisplayVector(outs);

            Console.WriteLine("done.");
            Console.ReadLine();
        }

        static void DisplayVector(double[] vector)
        {
            string vec = vector[0].ToString();
            for (int i = 1; i < vector.Length; i++)
            {
                vec += ";" + vector[i];
            }

            Console.WriteLine("{" + vec + "}");
        }
    }
}
