﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = System.Exception;

namespace Dekanat.DekanatLib.StripedHashSet
{
    public abstract class ABaseHashSet
    {
        protected List<Node>[] _table;
        protected long _setSize;

        public ABaseHashSet(int size)
        {
            _setSize = 0;
            _table = new List<Node>[size]
                .Select(x => new List<Node>())
                .ToArray();
        }

        protected abstract bool PolicyDemandsResize { get; }
        protected abstract void Resize();
        protected abstract void Acquire(Node x);
        protected abstract void Release(Node x);
        protected abstract int Hash(Node x, int hash);

        protected bool Contains(Node x)
        {
            Acquire(x);

            try
            {
                return _table[Hash(x, _table.Length)].Contains(x);
            }
            finally
            {
                Release(x);
            }
        }

        protected bool Add(Node x)
        {
            var rez = false;
            Acquire(x);

            try
            {
                var myBucket = Hash(x, _table.Length);
                if (!_table[myBucket].Contains(x))
                {
                    _table[myBucket].Add(x);
                    rez = true;
                    Interlocked.Increment(ref _setSize);
                }
            }
            finally
            {
                Release(x);
            }

            if (PolicyDemandsResize) Resize();

            return rez;
        }

        protected bool Remove(Node x)
        {
            var rez = false;
            Acquire(x);

            try
            {
                var myBucket = Hash(x, _table.Length);
                if (_table[myBucket].Contains(x))
                {
                    _table[myBucket].Remove(x);
                    rez = true;
                    Interlocked.Decrement(ref _setSize);
                }
            }
            finally
            {
                Release(x);
            }

            return rez;
        }

        public int Count() => (int)Interlocked.Read(ref _setSize);
    }
}
