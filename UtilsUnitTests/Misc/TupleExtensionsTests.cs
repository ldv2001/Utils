using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils.Misc;

namespace UtilsUnitTests.Misc
{
    [TestClass]
    public class TupleExtensionsTests
    {

        private static Tuple<String, String> testTuple;
        private static String leftObject;
        private static String rightObject;

        [ClassInitialize]
        public static void Initializer(TestContext context)
        {

            leftObject = "left";
            rightObject = "right";

            testTuple = new Tuple<String, String>(leftObject, rightObject);
        }


        [ClassCleanup]
        public static void Cleaner()
        {
            leftObject = null;
            rightObject = null;
            testTuple = null;
        }


        [TestMethod]
        public void LeftTest()
        {
            Assert.AreEqual("left", testTuple.Left());
        }

        [TestMethod]
        public void RightTest()
        {
            Assert.AreEqual("right", testTuple.Right());
        }
    }
}
