﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class Queue<T>
    {

        protected class Node
        {
            public T Data { set; get; }

            public Node Next { set; get; }

        }
    }
}