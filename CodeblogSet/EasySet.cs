using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeblogSet
{
    public class EasySet<T> : IEnumerable
    {
        private List<T> items = new List<T>();

        public int Count => items.Count;

        public EasySet() { }

        public EasySet(T item)
        {
            items.Add(item);
        }

        public EasySet(IEnumerable<T> items)
        {
            this.items = items.ToList();
        }

        public void Add(T item)
        {
            if(items.Contains(item))
            {
                return;
            }

            //foreach(var i in items)
            //{
            //    if(i.Equals(item))
            //    {
            //        return;
            //    }
            //}

            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public EasySet<T> Union(EasySet<T> set)
        {
            //return new EasySet<T>(items.Union(set.items));

            EasySet<T> result = new EasySet<T>();

            foreach (var item in items)
            {
                result.Add(item);
            }

            foreach (var item in set.items)
            {
                result.Add(item);
            }

            return result;
        }

        public EasySet<T> Intersection(EasySet<T> set)
        {
            //return new EasySet<T>(items.Intersect(set.items));

            var result = new EasySet<T>();
            EasySet<T> big;
            EasySet<T> small;

            if (Count >= set.Count)
            {
                big = this;
                small = set;
            }
            else
            {
                big = set;
                small = this;
            }

            foreach(var item1 in small.items)
            {
                foreach(var item2 in big.items)
                {
                    if(item1.Equals(item2))
                    {
                        result.Add(item1);
                        break;
                    }
                }
            }

            return result;
        }

        public EasySet<T> Difference(EasySet<T> set)
        {
            //return new EasySet<T>(items.Except(set.items));

            var result = new EasySet<T>(items);

            foreach(var item in set.items)
            {
                result.Remove(item);
            }

            return result;
        }

        public bool Subset(EasySet<T> set)
        {
            //return items.All(i => set.items.Contains(i));

            foreach(var item1 in items)
            {
                var equals = false;

                foreach(var item2 in set.items)
                {
                    if(item1.Equals(item2))
                    {
                        equals = true;
                        break;
                    }
                }

                if(!equals)
                {
                    return false;
                }
            }

            return true;
        }

        public EasySet<T> SymmetricDifference(EasySet<T> set)
        {
            //return new EasySet<T>(items.Except(set.items).Union(set.items.Except(items)));

            var result = new EasySet<T>();

            foreach(var item1 in items)
            {
                var equals = false;

                foreach(var item2 in set.items)
                {
                    if(item1.Equals(item2))
                    {
                        equals = true;

                        break;
                    }
                }

                if(equals == false)
                {
                    result.Add(item1);
                }
            }

            foreach (var item1 in set.items)
            {
                var equals = false;

                foreach (var item2 in items)
                {
                    if (item1.Equals(item2))
                    {
                        equals = true;

                        break;
                    }
                }

                if (equals == false)
                {
                    result.Add(item1);
                }
            }

            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
