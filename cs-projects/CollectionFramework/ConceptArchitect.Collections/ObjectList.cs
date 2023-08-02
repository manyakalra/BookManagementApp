namespace ConceptArchitect.Collections
{
    

    public class ObjectList
    {
        class Node
        {
            public object Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }


        private Node first;

        public ObjectList(params object[] items)
        {
            foreach (var item in items)
                Add(item);
        }

        public int Length
        {
            get
            {
                int count = 0;
                for (var n = first; n != null; n = n.Next)
                    count++;

                return count;
            }
        }

        public void Add(object item)
        {
            var newNode=new Node() { Value = item };

            if(first==null)
                first=newNode;
            else
            {
                var n = first;
                while(n.Next!=null)
                    n=n.Next;

                newNode.Previous = n;
                n.Next=newNode;
            }


        }

        public object Get(int index)
        {
            if(index<0 || index>=Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");

            var n = first;
            for(int i=0; i<index ; i++)
                n=n.Next;

            return n.Value;
        }

        public void Set(int index, object value)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");

            var n = first;
            for (int i = 0; i < index; i++)
                n = n.Next;

            n.Value = value;
        }

        public object Remove(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");

            var d = first;
            for (int i = 0; i < index; i++)
                d = d.Next;


            if(d.Next!=null)
                d.Next.Previous = d.Previous;

            if (d.Previous != null)
                d.Previous.Next = d.Next;
            else
                first = d.Next;


            return d.Value;
        }

        public void Insert(int index, object v2)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");

            var n = first;
            for (int i = 0; i < index; i++)
                n = n.Next;

            //insert after n
            var newNode = new Node() { Value = v2 };

            newNode.Previous = n.Previous;
            newNode.Next = n;

            if (n.Previous != null)
                n.Previous.Next = newNode;
            else
                first = newNode;

            n.Previous = newNode;


            
        }

        public int IndexOf(object value)
        {
            int index = 0;

            for (Node n = first; n != null; n = n.Next)
                if (n.Value == value)
                    return index;
                else
                    index++;

            return -1;

        }

        public override string ToString()
        {
            if (first == null)
                return "(empty)";

            var str = "[\t";
            for (var n = first; n != null; n = n.Next)
                str += $"{n.Value}\t";

            return str + "]";
        }
    }
}