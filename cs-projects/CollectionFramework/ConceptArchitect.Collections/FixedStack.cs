namespace ConceptArchitect.Collections
{
    public class FixedStack
    {

        private int size;
        int count = 0;
        int lastElement = -1;

        public FixedStack(int size)
        {
            this.size = size;
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
            count++;
            return true;
        }

        public int Pop()
        {
            count--;
            return lastElement;
        }
    }
}