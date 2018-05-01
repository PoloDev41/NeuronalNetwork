using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuronalNetwork.Neuronal;
using NeuronalNetwork.Learner;

namespace UnitTest
{
    [TestClass]
    public class FullyConnectedNetworkTest
    {
        [TestMethod]
        public void BasicNeuronalNetworkFullyConnected()
        {
            try
            {
                FullyConnectedNetwork net = new FullyConnectedNetwork(2,
                                                            2, 2, 1);
                double[] outs = net.ComputeOutputs(new double[] { 2, 5 });

                Assert.AreEqual(0, outs[0]);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            
        }

        [TestMethod]
        public void LearnSample()
        {
            try
            {
                FullyConnectedNetwork net = new FullyConnectedNetwork(2,
                                                                      2, 2, 1);
                BackPropagationGradiant teacher = new BackPropagationGradiant(net);

                double[] ZeroInput = new double[] { 0, 0 };
                double[] OutputsZeroInput = new double[] { 0 };
                net.ComputeOutputs(ZeroInput);

                Assert.AreEqual(0,teacher.ComputeQuadraticError(OutputsZeroInput)); //should equals because 0

                Sample sample1 = new Sample()
                {
                    Inputs = ZeroInput,
                    Outputs = OutputsZeroInput
                };
                teacher.LearnOneSample(sample1);

                double[] OnesInput = new double[] { 1, 1 };
                double[] OutputsOnesInput = new double[] { 1 };
                net.ComputeOutputs(OnesInput);
                double errorNoLearn = teacher.ComputeQuadraticError(OutputsOnesInput);
                Assert.AreNotEqual(0, errorNoLearn);

                Sample sample2 = new Sample()
                {
                    Inputs = OnesInput,
                    Outputs = OutputsOnesInput
                };
                teacher.LearnOneSample(sample2);
                net.ComputeOutputs(OnesInput);
                double errorLearn = teacher.ComputeQuadraticError(OutputsOnesInput);
                Assert.IsTrue(errorLearn < errorNoLearn);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
            
        }
    }
}
