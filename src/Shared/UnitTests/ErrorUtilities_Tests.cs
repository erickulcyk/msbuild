﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#region Using directives

using System;
using Microsoft.Build.Shared;

using NUnit.Framework;
#endregion

namespace Microsoft.Build.UnitTests
{
    [TestFixture]
    sealed public class ErrorUtilities_Tests
    {
        [Test]
        public void VerifyThrowFalse()
        {
            try
            {
                ErrorUtilities.VerifyThrow(false, "msbuild rules");
            }
            catch (InternalErrorException e)
            {
                Assert.IsTrue(e.Message.Contains("msbuild rules"), "exception message");
                return;
            }

            Assert.Fail("Should have thrown an exception");
        }

        [Test]
        public void VerifyThrowTrue()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "msbuild rules");
        }

        [Test]
        public void VerifyThrow0True()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "blah");
        }

        [Test]
        public void VerifyThrow1True()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "{0}", "a");
        }

        [Test]
        public void VerifyThrow2True()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "{0}{1}", "a", "b");
        }

        [Test]
        public void VerifyThrow3True()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "{0}{1}{2}", "a", "b", "c");
        }

        [Test]
        public void VerifyThrow4True()
        {
            // This shouldn't throw.
            ErrorUtilities.VerifyThrow(true, "{0}{1}{2}{3}", "a", "b", "c", "d");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void VerifyThrowArgumentArraysSameLength1()
        {
            ErrorUtilities.VerifyThrowArgumentArraysSameLength(null, new string[1], string.Empty, string.Empty);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [Test]
        public void VerifyThrowArgumentArraysSameLength2()
        {
            ErrorUtilities.VerifyThrowArgumentArraysSameLength(new string[1], null, string.Empty, string.Empty);
        }

        [ExpectedException(typeof(ArgumentException))]
        [Test]
        public void VerifyThrowArgumentArraysSameLength3()
        {
            ErrorUtilities.VerifyThrowArgumentArraysSameLength(new string[1], new string[2], string.Empty, string.Empty);
        }

        [Test]
        public void VerifyThrowArgumentArraysSameLength4()
        {
            ErrorUtilities.VerifyThrowArgumentArraysSameLength(new string[1], new string[1], string.Empty, string.Empty);
        }
    }
}
