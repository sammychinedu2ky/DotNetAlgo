using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Lists
{
    internal class ArrayList<T> : IArrayList<T>
    {
        private Dictionary<int, T> _items = new();
        public int Length { get; set; } = 0;

        public void Delete(int index)
        {
           // Console.WriteLine(Length);
            while(index < Length-1)
            {
                _items[index] = _items[index+1];
                index++;

            }
            _items.Remove(Length-1);
           // return default;
        }

        public T Get(int index)
        {
            return _items[index];
        }
        public Dictionary<int, T> GetItems() => _items;
        public T Pop()
        {
            var item = _items[Length - 1];
            _items.Remove(Length - 1);
            Length--;
            return item;
        }

        public void Push(T value)
        {
            _items[Length] = value;
            Length++;
        }
    }
    interface IArrayList<T>
    {
        int Length { get; set; }
        void Push(T value);
        T Pop();
        T Get(int index);
        void Delete(int index);
    }
}
