﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1.Common;

namespace DDDTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var val = Class1.Add(1, 2);
            Assert.AreEqual(3, val);
        }
    }
}
