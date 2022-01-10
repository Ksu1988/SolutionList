using System.Collections;
using System.Collections.Generic;

namespace ConsoleList
{
    public class NewLinkedList<T> : ICollection<T>
    {
        private ListNode<T> _first;
        
        private ListNode<T> _last;
        public IEnumerator<T> GetEnumerator()
        {
            ListNode<T> current = _first;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
           var node = new ListNode<T>(item);
           if (_first == null)
           {
               _first = node;
               _last = node;
           }
           else
           {
               _last.NextNode = node;
               _last = node;
           }

           Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.NextNode;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ListNode<T> current = _first;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.NextNode;
            }
        }

        public bool Remove(T item)
        {
            var current = _first;
            ListNode<T> previous = null;
            if (current == null)
            {
                
            }
            // 1: Пустой список: ничего не делать.
            // 2: Один элемент: установить Previous = null.
            // 3: Несколько элементов:
            //    a: Удаляемый элемент первый.
            //    b: Удаляемый элемент в середине или конце.

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    // Узел в середине или в конце.
                    if (previous != null)
                    {
                        // Случай 3b.

                        // До:    Head -> 3 -> 5 -> null
                        // После: Head -> 3 ------> null
                        previous.NextNode = current.NextNode;

                        // Если в конце, то меняем _tail.
                        if (current.NextNode == null)
                        {
                            _last = previous;
                        }
                    }
                    else
                    {
                        // Случай 2 или 3a.

                        // До:    Head -> 3 -> 5
                        // После: Head ------> 5

                        // Head -> 3 -> null
                        // Head ------> null
                        _first = _first.NextNode;

                        // Список теперь пустой?
                        if (_first == null)
                        {
                            _last = null;
                        }
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.NextNode;
            }
            return false;
        }

        public int Count { get; private set; }
        
        public bool IsReadOnly => false;
    }
}