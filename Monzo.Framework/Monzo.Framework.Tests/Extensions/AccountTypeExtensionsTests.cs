namespace Monzo.Framework.Tests.Extensions
{
    using Monzo.Framework.Enums;
    using Monzo.Framework.Extensions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="AccountTypeExtensions"/> class.
    /// </summary>
    [TestFixture]
    public class AccountTypeExtensionsTests
    {
        /// <summary>
        /// Ensures when the UKRetail enum is given, the relevant desc is given.
        /// </summary>
        [Test]
        public void GetDescription_UkRetail_Description()
        {
            Assert.AreEqual("uk_retail", AccountType.UKRetail.GetDescription());
        }

        /// <summary>
        /// Ensures when the UKPrepaid enum is given, the relevant desc is given.
        /// </summary>
        [Test]
        public void GetDescription_UkPrepaid_Description()
        {
            Assert.AreEqual("uk_prepaid", AccountType.UKPrepaid.GetDescription());
        }
    }
}