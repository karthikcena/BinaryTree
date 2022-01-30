using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BinaryTreeEval.Program;

namespace Unit_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateValue()
        {
            string s = "((15/(7-(1+1)))*3)-(2+(1+1))";
            s = "(" + s;
            s += ")";
            Node root = buildTree(s);
            var result = evalTree(root);
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void CalculateDifferentValue()
        {
            string s = "(15+(6+8))";
            s = "(" + s;
            s += ")";
            Node root = buildTree(s);
            var result = evalTree(root);
            Assert.AreEqual(result, 29);
        }

        [TestMethod]
        public void CalculateAnotherValue()
        {
            string s = "((3/(7-6))*(8+(3-1)))";
            s = "(" + s;
            s += ")";
            Node root = buildTree(s);
            var result = evalTree(root);
            Assert.AreEqual(result, 30);
        }

        [TestMethod]
        public void HandlingNegativeInteger()
        {
            string s = "((15/(7-(1+1)))*-3)-(2+(1+1))";
            s = "(" + s;
            s += ")";
            Node root = buildTree(s);
            var result = evalTree(root);
            Assert.AreEqual(result, -13);
        }
    }
}
