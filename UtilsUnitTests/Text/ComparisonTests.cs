using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Text;


namespace UtilsUnitTests.Text
{
    [TestClass]
    public class ComparisonTests
    {
        [TestMethod]
        public void CaseInsensitiveComparisonTest()
        {
            Assert.IsTrue(Comparison.CaseInsensitiveComparison("toto", "TOTO"));

            Assert.IsTrue(Comparison.CaseInsensitiveComparison("eeeeeeee", "ééééèèèè"));

            Assert.IsTrue(Comparison.CaseInsensitiveComparison("EEEEEEEE", "ééééèèèè"));

        }
    }
}
