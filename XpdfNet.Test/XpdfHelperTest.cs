﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Text.RegularExpressions;

namespace XpdfNet.Test
{
    public class XpdfHelperTest
    {
        private XpdfHelper XpdfHelper;
        

        public XpdfHelperTest()
        {
            this.XpdfHelper = new XpdfHelper();
        }

        [Fact]
        public void ToText_ShouldReturnText()
        {
            // Arrange

            // Act
            string actual = this.XpdfHelper.ToText("./sample1.pdf");
            actual = actual.Replace("\f", "");
            actual = Regex.Replace(actual, @"\r\n?|\n", string.Empty);

            // Assert
            string expected = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Expected.txt"));
            expected = Regex.Replace(expected, @"\r\n?|\n", string.Empty);

            Assert.Equal(expected, actual);
        }
    }
}
