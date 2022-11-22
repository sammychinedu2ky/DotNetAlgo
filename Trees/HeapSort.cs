using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetAlgo.Trees
{
    internal class HeapSort
    {
        public void Heapify(int[] array, int maxIndex, int currentIndex)
        {
            int largest = currentIndex;
            int leftNodeIndex = 2 * currentIndex + 1;
            int rightNodeIndex = 2 * currentIndex + 2;
            // check if the left node exist and if it is greater than the largest value
            if (leftNodeIndex < maxIndex && array[leftNodeIndex] > array[largest])
            {
                largest = leftNodeIndex;
            }
            // check if the right node exist and if it is greater than the largest value
            if (rightNodeIndex < maxIndex && array[rightNodeIndex] > array[largest])
            {
                largest = rightNodeIndex;
            }
            // if the largest is not equal to the parent node(current index) swap and heapify downwards
            if (largest != currentIndex)
            {
                (array[currentIndex], array[largest]) = (array[largest], array[currentIndex]);
                Heapify(array, maxIndex, largest);
            }
        }
        public int[] array = null;
        public HeapSort(int[] array)
        {
            //  Create Heap 
            for (int nonLeafNode = (array.Length / 2) - 1; nonLeafNode >= 0; nonLeafNode--)
            {
                Heapify(array, array.Length, nonLeafNode);
            }
            this.array = array;

        }
        public int[] Sort()
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0);
            }
            return array;
        }
    }
}
