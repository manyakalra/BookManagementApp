using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Collections
{
    public class DynamicArray<T> : IIndexedList<T>
    {
        T[] array;
        private int growFactor;

        public int Capacity => array.Length;

        public DynamicArray(int growFactor=10)
        {
            array = new T[growFactor];
            this.growFactor = growFactor;
        }

        private void EnsureCapacity()
        {
            if( Length==Capacity)
            {
                var newArray = new T[Capacity+growFactor];
                Array.Copy(array,newArray, array.Length);
                array=newArray;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");
        }

        public T this[int index] { 
            get  
            {
                ValidateIndex(index);
                return array[index];
            } 
            set
            {
                ValidateIndex(index);
                array[index] = value;
            }
        }

        public int Length { get; private set; }

        public IIndexedList<T> Add(T item)
        {
            EnsureCapacity();
            array[Length++] = item;

            return this;
        }

        public int IndexOf(T value)
        {
            for (var i = 0; i < Length; i++)
                if (value.Equals(array[i]))
                    return i;

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>() { Target = this };
        }

        class DynamicArrayEnumerator<T> : IEnumerator<T>
        {
            int index = -1;
            public DynamicArray<T> Target { get; set; }
            public T Current
            {
                get
                {
                    return Target[index];
                }
            }

            public bool MoveNext()
            {
                index++;
                return index < Target.Length;
            }



            public void Reset()
            {
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current => throw new NotImplementedException();

        }
    }
}
