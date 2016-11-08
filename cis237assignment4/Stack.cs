using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Stack<T>
    {
        protected class Node
        {
            public T Data { set; get; }

            public Node Next { set; get; }
             
        }

        private Node _head;
        private Node _tail;
        private int _size;

        public bool EmptyBool
        {
            get { return _head == null; }
        }

        public int Size
        {
            get { return _size; }
        }

        //Add new item to front of the link  list
        public void AddToFront(T InputData)
        {
            Node _oldHead = _head;

            _head = new Node();

            _head.Data = InputData;

            _head.Next = _oldHead;

            _size++;

            if (_size == 1)
            {
                _tail = _head;
            }
        }

        //Add item to end of link list
        public void AddToBack(T InputData)
        {
            Node _oldTail = _tail;

            _tail = new Node();

            _tail.Data = InputData;

            _tail.Next = null;

            if (EmptyBool)
            {
                _head = _tail;
            }
            else
            {
                _oldTail.Next = _tail;
            }

            _size++;
        }

        //Removes item from thefront ofthe queue
        public T RemoveFromFront()
        {
            T removeData = _head.Data;

            _head = _head.Next;

            _size--;

            return removeData;
        }

        public Stack()
        {
            _head = null;
            _tail = null;
            _size = 0;
        } 
    }
}
