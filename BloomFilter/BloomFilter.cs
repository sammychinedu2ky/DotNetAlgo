using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Hashing;
using System.ComponentModel;

namespace DotNetAlgo.BloomFilter
{
    internal class BloomFilter
    {
        public List<int> array = Enumerable.Repeat<int>(0, 100).ToList<int>();
        public BloomFilter()
        {

        }
        public void Add(string word)
        {
            array[XxHashWrapper1(word)] = 1;
            array[XxHashWrapper2(word)] = 1;
            array[XxHashWrapper3(word)] = 1;
        }
        public bool Contains(string word)
        {
            var first = array[XxHashWrapper1(word)];
            var second = array[XxHashWrapper2(word)];
            var third = array[XxHashWrapper3(word)];
            if ((first & second & third) == 1)
            {
                return true;
            }
            return false;
        }
        public int XxHashWrapper1(string word)
        {
            var bytes = new byte[4];
            XxHash32.TryHash(ASCIIEncoding.UTF8.GetBytes(word), bytes, out var _, 80);
            return Math.Abs(new ASCIIEncoding().GetString(bytes).GetHashCode() % 100);
        }
        public int XxHashWrapper2(string word)
        {

            var bytes = new byte[4];
            XxHash32.TryHash(ASCIIEncoding.UTF8.GetBytes(word), bytes, out var _, 100);
            return (Math.Abs(new ASCIIEncoding().GetString(bytes).GetHashCode() % 100));
        }
        public int XxHashWrapper3(string word)
        {

            var bytes = new byte[4];
            XxHash32.TryHash(ASCIIEncoding.UTF8.GetBytes(word), bytes, out var _, 130);
            return Math.Abs(new ASCIIEncoding().GetString(bytes).GetHashCode() % 100);
        }
    }
}
