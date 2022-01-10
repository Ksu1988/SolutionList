using ConsoleList;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
       
        [Test]
        public void AddTest()
        {
            var list = new NewLinkedList<int>();  
            list.Add(3);
            Assert.AreEqual(list.Count,1);
        }
        
        [Test]
        public void ContainTest()
        {
            var list = new NewLinkedList<int>();  
            list.Add(3);
            Assert.AreEqual(list.Count,1);
            Assert.IsTrue(list.Contains(3));
            Assert.IsFalse(list.Contains(5));
        }
        
        [Test]
        public void RemoveTest()
        {
            var list = new NewLinkedList<string>();  
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            Assert.AreEqual(list.Count,5);
            list.Remove("one");
            Assert.IsFalse(list.Contains("one"));
            list.Remove("three");
            list.Remove("five");
            Assert.AreEqual(list.Count,2);
            Assert.IsFalse(list.Contains("three"));
            Assert.IsFalse(list.Contains("five"));
            Assert.IsTrue(list.Contains("two"));
            Assert.IsTrue(list.Contains("four"));
        }
        
        [Test]
        public void CopyTest()
        {
            var list = new NewLinkedList<string>();  
            list.Add("one");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            var newList = new string[10];
            list.CopyTo(newList,3);
            Assert.AreEqual(newList[3],"one");
        }
    }
}