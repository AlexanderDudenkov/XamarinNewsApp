﻿using NewsApp.util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace NUnit.Tests
{
    [TestFixture]
    public class IFormattingStringTests    {

        private IFormattingString subject;

        [SetUp]
        public void BeforeTestSuit()
        {
            subject = new Mock<IFormattingString>(MockBehavior.Strict).Object;
            //subject = new FormattingString();
        }

        [Test]
        public void BlankDesc_DefaultDescLength_ReturnBlankString()
        {
            var result = subject.FormattingDescription(Constants.SYMBOLS,"");
            Assert.AreEqual("", result);
        }
    }
}
