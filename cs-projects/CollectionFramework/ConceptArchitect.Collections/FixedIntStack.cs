namespace ConceptArchitect.Collections
{
    public class FixedIntStack
    {

        private int size;
        int count = 0;
        int lastElement = -1;
        int []arr;
        public FixedIntStack(int size)
        {
            this.size = size;
            arr = new int[size];
        }

        bool empty = true;
        public bool IsEmpty { 
            get
            {
                return count==0;
            }
        }


        
        

        public bool IsFull 
        { 
            get
            {
                return count == size;
            }
        }

        
        
        public bool Push(int value)
        {
            if (IsFull)
                return false;

            lastElement = value;
            arr[count++] = value;
            
            return true;
        }

        public int Pop(out bool checkSuccess)
        {
            checkSuccess = !IsEmpty;
            if(!checkSuccess)
            {
                return 0;
            }
            count--;
            return arr[count];
        }

        public void Clear()
        {
            count = 0;
        }

        public int Peek(out bool success)
        {
            success = !IsEmpty;
            if(!success)
            {
                return 0;
            }
            return lastElement;
        }
    }
}