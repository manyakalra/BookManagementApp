namespace ConceptArchitect.Collections
{
    public class FixedStack<T>
    {

        public int Size { get { return arr.Length; }  }

        public int Length { get { return top; } }

        int top = 0;
        T []arr;
        public FixedStack(int size)
        {
            arr = new T[size];
        }

        public bool IsEmpty { 
            get
            {
                return top==0;
            }
        }


        public bool IsFull 
        { 
            get
            {
                return top == Size;
            }
        }

        
        
        public void Push(T value)
        {
            if (IsFull)
                throw new StackOverflowException($"Stack overflow while pushing: {value}");

            arr[top++] = value;
            
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new EmptyContainerException();
            top--;
            return arr[top];
        }

        public void Clear()
        {
            top = 0;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new EmptyContainerException();

            return arr[top - 1];
        }
    }
}