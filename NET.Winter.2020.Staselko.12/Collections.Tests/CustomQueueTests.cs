using NUnit.Framework;
using System;

namespace Collections.Tests
{ 
    public class CustomQueueTests
    {
        [Test]
        public void Enqueue_ThreeIntElementsInQueueAndDequeue()
        {
            var stack = new CustomQueue<int>();
            stack.Enqueue(1);
            stack.Enqueue(2);
            stack.Enqueue(3);
            stack.Dequeue();
            
            bool actual = stack.Contains(1);
            Assert.AreEqual(false, actual);
        }

        [Test]
        public void Enqueue_ThreeStringElementsInQueueAndDequeue()
        {
            var stack = new CustomQueue<String>();
            stack.Enqueue("Natasha");
            stack.Enqueue("Skeet");
            stack.Enqueue("PashaFast");
            stack.Dequeue();

          
            string pashafast = "Skeet";
            Assert.AreEqual(pashafast, stack.Peek());
        }

        [Test]
        public void Ctor_CreateQueueFromArrayWith3Elements()
            => Assert.AreEqual(new CustomQueue<int>(collection: new int[] { 1, 2, 3 }).Count, 3);

        [Test]
        public void Ctor_CreateQueueFixCapecity_Test()
            => Assert.AreEqual(new CustomQueue<int>(4).Count, 0);

        [Test]
        public void GetEnumerator_WithBlockIterator_Test()
        {
            int[] array = new int[] { 1, 2, 3, 4, 5, 6 };

            var stack = new CustomQueue<int>(collection: array);
            
            int i = 0;
            foreach (var item in stack)
            {
                Assert.AreEqual(item, array[i++]);
            }
        }

        [Test]
        public void Enqueue_ThreeStructElements()
        {
            var queue = new CustomQueue<Point>();
            queue.Enqueue(new Point (1, 2));
            queue.Enqueue(new Point ( 2, 2 ));
            queue.Enqueue(new Point (5,  2 ));

            bool actual = queue.Contains(new Point ( 1,  2 ));
            Assert.AreEqual(true, actual);
        }

        [Test]
        public void Enqueue_TwoClassElements()
        {
            var queue = new CustomQueue<Note>();
            queue.Enqueue(new Note("PashaFast", "BSU", "Bla-bla", 1));
            queue.Enqueue(new Note("JohnSkeet", "C#", "Bla-bla-bla", 2));
    
            bool actual = queue.Contains(new Note("PashaFast", "BSU", "Bla-bla", 1));
            Assert.AreEqual(true, actual);
        }
    }
}