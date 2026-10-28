using System;
using System.Collections.Generic;
using System.Text;
using Smallbiz.Domain.Validation;

namespace Smallbiz.Tests
{
    [TestClass]
    public sealed class NipValidatorTests
    {
        
        [TestMethod]
        public void IsValid_Null_ZwracaFalse()
        {
            Assert.IsFalse(NipValidator.IsValid(null));
        }

        [TestMethod]
        [DataRow("1234563218")]
        [DataRow("123-456-32-18")]
        [DataRow("5846127309")]
        public void IsValid_PoprawnyNip_ZwracaTrue(string nip)
        {
            Assert.IsTrue(NipValidator.IsValid(nip));
        }

        [TestMethod]
        [DataRow("1234563219")]
        [DataRow("123456321")]
        [DataRow("12345632181")]
        [DataRow("A234563215")]
        [DataRow("")]
        [DataRow("    ")]
        [DataRow("\uFF11234563216")]
        public void IsValid_NiepoprawnyNip_ZwracaFalse(string nip)
        {
            Assert.IsFalse(NipValidator.IsValid(nip));
        }

    }
}
