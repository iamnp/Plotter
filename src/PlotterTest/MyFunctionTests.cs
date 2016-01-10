using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plotter;

namespace PlotterTest
{
    [TestClass]
    public class MyFunctionTests
    {
        [TestMethod]
        public void FunctionValueTest()
        {
            // Arrange.
            MyFunction func = new MyFunction { Y = 0.827, Z = 25.001 };

            // Act.
            double val = func[6.251];

            // Assert.
            Assert.AreEqual(0.7121, val, 1e-4);
        }
    }
}