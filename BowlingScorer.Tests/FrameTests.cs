using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingScorer;

namespace BowlingScorer.Tests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void Result_OneRollOf10_ReturnsStrike()
        {
            var frame = new Frame(10);
            Assert.AreEqual("X", frame.Mark);
        }

        [TestMethod]
        public void Result_TwoRollsSum10_ReturnsSpare()
        {
            var frame = new Frame(5, 5);
            Assert.AreEqual("5/", frame.Mark);
        }

        [TestMethod]
        public void Result_TwoRollsSumLT10_ReturnsMiss()
        {
            var frame = new Frame(5, 4);
            Assert.AreEqual("5[4]", frame.Mark);
        }

    }
}
