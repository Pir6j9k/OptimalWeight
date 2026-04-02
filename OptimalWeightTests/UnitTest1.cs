using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimalWeight;
using System;


namespace OptimalWeightTests
{
    [TestClass]
    public class WeightCalculatorTests
    {
        private WeightCalculator calc;

        [TestInitialize]
        public void Setup()
        {
            calc = new WeightCalculator();
        }


        [TestMethod]
        public void Calc_InvalidHeight_ReturnsFalse()
        {
            var result = calc.Calculate("abc", "70", true);

            Assert.IsFalse(result.success);
        }

        [TestMethod]
        public void Calc_InvalidWeight_ReturnsFalse()
        {
            var result = calc.Calculate("180", "abc", true);

            Assert.IsFalse(result.success);
        }


        [TestMethod]
        public void Calc_HeightBelowMin_ReturnsFalse()
        {
            var result = calc.Calculate("129", "70", true);

            Assert.IsFalse(result.success);
        }

        [TestMethod]
        public void Calc_HeightAboveMax_ReturnsFalse()
        {
            var result = calc.Calculate("221", "70", true);

            Assert.IsFalse(result.success);
        }


        [TestMethod]
        public void Calc_WeightBelowMin_ReturnsFalse()
        {
            var result = calc.Calculate("180", "39", true);

            Assert.IsFalse(result.success);
        }

        [TestMethod]
        public void Calc_WeightAboveMax_ReturnsFalse()
        {
            var result = calc.Calculate("180", "171", true);

            Assert.IsFalse(result.success);
        }


        [TestMethod]
        public void Calc_Male_BelowNormal()
        {
            var result = calc.Calculate("180", "85", true);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Ниже нормы"));
        }

        [TestMethod]
        public void Calc_Male_Normal()
        {
            var result = calc.Calculate("180", "90", true);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Норма"));
        }

        [TestMethod]
        public void Calc_Male_AboveNormal()
        {
            var result = calc.Calculate("180", "100", true);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Выше нормы"));
        }


        [TestMethod]
        public void Calc_Female_Normal()
        {
            var result = calc.Calculate("170", "63", false);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Норма"));
        }

        [TestMethod]
        public void Calc_Female_BelowNormal()
        {
            var result = calc.Calculate("170", "55", false);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Ниже нормы"));
        }

        [TestMethod]
        public void Calc_Female_AboveNormal()
        {
            var result = calc.Calculate("170", "75", false);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Выше нормы"));
        }


        [TestMethod]
        public void Calc_Border_NormalRange()
        {
            var result = calc.Calculate("180", "90.4", true);

            Assert.IsTrue(result.success);
            Assert.IsTrue(result.message.Contains("Норма"));
        }
    }
}
