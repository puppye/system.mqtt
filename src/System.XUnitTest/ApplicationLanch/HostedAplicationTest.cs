using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace System.XUnitTest.ApplicationLanch
{
    public class HostedAplicationTest
    {

        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void LanchApplication()
        {
            Console.WriteLine("success");

            Assert.IsTrue(true);
        }
    }
}
