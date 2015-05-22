using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Text;


namespace UtilsUnitTests.Text
{
    [TestClass]
    public class StringOperationsTests
    {
        [TestMethod]
        public void RemoveDiacriticsTest()
        {
            Assert.AreEqual("eeau", "éèàù".RemoveDiacritics());
        }


        [TestMethod]
        public void RegExpReplaceTest()
        {
            Assert.AreEqual("toto", "test".RegExpReplace("t[a-z]+t", "toto"));
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.IsTrue("".IsEmpty());
            Assert.IsTrue(" ".IsEmpty());
            Assert.IsFalse("a".IsEmpty());
        }
    }
}
