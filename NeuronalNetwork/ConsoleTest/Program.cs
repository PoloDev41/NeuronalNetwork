using NeuronalNetwork.Neuronal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronalNetwork.Learner;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FullyConnectedNetwork net = new FullyConnectedNetwork(2,
                                                            2,2, 1);
            BackPropagationGradiant teacher = new BackPropagationGradiant(net);

            Sample sample1 = new Sample()
            {
                Inputs = new double[] { 0, 0 },
                Outputs = new double[] { 1 },
            };
            Sample sample2 = new Sample()
            {
                Inputs = new double[] { 1, 0 },
                Outputs = new double[] { -1 },
            };
            Sample sample3 = new Sample()
            {
                Inputs = new double[] { 0, 1 },
                Outputs = new double[] { -1 },
            };
            Sample sample4 = new Sample()
            {
                Inputs = new double[] { 1, 1 },
                Outputs = new double[] { 1 },
            };

            teacher.AddSample(sample1);
            teacher.AddSample(sample2);
            teacher.AddSample(sample3);
            teacher.AddSample(sample4);

            Console.WriteLine("*************");
            Console.WriteLine("Test XOR gate");
            Console.WriteLine("*************");

            while(true)
            {
                for (int x = 0; x < 2; x++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        teacher.LearnOneLoopBase();
                    }
                    Console.WriteLine("3 learnings, mean error: " + teacher.MeanQuadraticError);
                    Console.WriteLine("Ouputs, with {0,1}");
                    DisplayVector(net.ComputeOutputs(sample2.Inputs));
                    Console.WriteLine("Ouputs, with {1,1}");
                    DisplayVector(net.ComputeOutputs(sample4.Inputs));
                    Console.WriteLine(Environment.NewLine);
                }

                DisplayNeuronalNetwork(net);
                Console.WriteLine("done.");
                Console.ReadLine();

                Console.Clear();
            }
            
        }

        static void DisplayNeuronalNetwork(BaseNeuronalNetwork net)
        {
            for (int i = 0; i < net.Layers.Length; i++)
            {
                Console.WriteLine("Layer number "+i+": ");
                for (int j = 0; j < net.Layers[i].Neurones.Length; j++)
                {
                    DisplayVector(net.Layers[i].Neurones[j].Weight);
                }
            }
            Console.WriteLine(Environment.NewLine);
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
