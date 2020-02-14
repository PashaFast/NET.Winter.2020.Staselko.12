using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    /// <summary>
    /// CustomQueue ckass.
    /// </summary>
    /// <typeparam name="T">Input parameter.</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Constants

        private const int DefaultCapacity = 4;

        #endregion

        #region Fields

        private T[] array;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        public CustomQueue()
        {
            this.array = Array.Empty<T>();
            this.Count = 0;
            this.Version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        /// <param name="capacity">Input capacity.</param>
        public CustomQueue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)} can not be less or equal zero!");
            }

            this.array = new T[capacity];
            this.Count = 0;
            this.Version = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomQueue{T}"/> class.
        /// </summary>
        /// <param name="collection">Input collection.</param>
        public CustomQueue(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentOutOfRangeException($"{nameof(collection)} can not be null!");
            }

            ICollection<T> copyCollection = collection as ICollection<T>;

            if (copyCollection != null)
            {
                int count = copyCollection.Count;
                this.array = new T[count];
                copyCollection.CopyTo(this.array, 0);
                this.Count = count;
            }
            else
            {
                this.Count = 0;

                this.array = new T[DefaultCapacity];

                foreach (var item in collection)
                {
                    this.Enqueue(item);
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets property.
        /// </summary>
        /// <value>
        /// Count.
        /// </value>
        public int Count { get; private set; }

        private int Version { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item at the end of the queue.
        /// </summary>
        /// <returns>Output parameter T.</returns>
        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation, queue is empty!");
            }

            this.Version++;

            T item1 = this.array[0];
            this.Count--;
            T[] newArray = new T[this.Count];
            Array.Copy(this.array, 1, newArray, 0, this.Count);
            this.array = newArray;

            return item1;
        }

        /// <summary>
        /// Returns the first element from the front of the queue without deleting it.
        /// </summary>
        /// <returns>Output parameter T.</returns>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation, queue is empty!");
            }

            return this.array[0];
        }

        /// <summary>
        /// Adds an item to the end of the queue.
        /// </summary>
        /// <param name="item">Input item for adding.</param>
        public void Enqueue(T item)
        {
            if (this.Count == this.array.Length)
            {
                T[] newArray = new T[(this.array.Length == 0) ? DefaultCapacity : 2 * this.array.Length];
                Array.Copy(this.array, 0, newArray, 0, this.Count);
                this.array = newArray;
            }

            this.array[this.Count++] = item;

            this.Version++;
        }

        /// <summary>
        /// ToArray method.
        /// </summary>
        /// <returns>Array of T.</returns>
        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];

            int i = 0;

            while (i < this.Count)
            {
                newArray[i] = this.array[this.Count - i - 1];
                i++;
            }

            return newArray;
        }

        /// <summary>
        /// Сhecks if an item is in the queue.
        /// </summary>
        /// <param name="item">Item checking.</param>
        /// <returns>True if the item is queued false otherwise.</returns>
        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.array[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Clear equeue.
        /// </summary>
        public void Clear()
        {
            Array.Clear(this.array, 0, this.Count);
            this.Count = 0;
            this.Version++;
        }

        #endregion

        #region IEnumerable<T> interface implementation

        /// <summary>
        /// GetEnumerator method.
        /// </summary>
        /// <returns>Enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
            => new Enumerator(this);

        /// <summary>
        /// GetEnumerator method.
        /// </summary>
        /// <returns>Enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        #region Struct Enumerator

        /// <summary>
        /// Enumerator struct.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private readonly int version;
            private int currentIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="Enumerator"/> struct.
            /// </summary>
            /// <param name="collection">Input collection.</param>
            public Enumerator(CustomQueue<T> collection)
            {
                if (collection == null)
                {
                    throw new ArgumentNullException(nameof(collection), "cannot be null");
                }

                this.version = collection.Version;
                this.currentIndex = -1;
                this.queue = collection;
            }

            /// <summary>
            /// Gets the element in the queue at the current position of the enumerator.
            /// </summary>
            /// <value>
            /// The element in the queue at the current position of the enumerator.
            /// </value>
            public T Current
            {
                get
                {
                    if (this.currentIndex == -1 || this.currentIndex == this.queue.Count)
                    {
                        throw new InvalidOperationException("Queue was changed!");
                    }

                    return this.queue.array[this.currentIndex];
                }
            }

            /// <summary>
            /// Gets current method.
            /// </summary>
            /// <value>
            /// The element in the queue at the current position of the enumerator.
            /// </value>
            object IEnumerator.Current => this.Current;

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            public void Reset() => this.currentIndex = -1;

            /// <summary>
            /// Advances the enumerator to the next element of the queue.
            /// </summary>
            /// <returns>True if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the queue.</returns>
            public bool MoveNext()
            {
                if (this.queue.Version != this.version)
                {
                    throw new InvalidOperationException("Queue was changed!");
                }

                return ++this.currentIndex < this.queue.Count;
            }

            /// <summary>
            /// Dispose method.
            /// </summary>
            public void Dispose()
            {
            }
        }

        #endregion

        #endregion
    }
}