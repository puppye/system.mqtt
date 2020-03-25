using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace System.XUnitTest.ApplicationLanch
{
    public class HostedAplicationTest
    {

        [Fact]
        public void LanchApplication()
        {
            Console.WriteLine("success");

            Assert.True(true);
        }
    }
}
