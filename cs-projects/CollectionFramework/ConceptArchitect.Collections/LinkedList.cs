namespace ConceptArchitect.Collections
{

    public delegate bool Matcher<T>(T item);


    public class LinkedList<X> : IIndexedList<X>
    {
        class Node
        {
            public X Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }


        private Node first, last;
        int length = 0;

        public LinkedList(params X[] items)
        {
            foreach (var item in items)
                Add(item);
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public IIndexedList<X> Add(X item)
        {
            var newNode = new Node() { Value = item, Previous = last };

            if (first == null) //list is empty
                first = newNode;
            else
                last.Next = newNode;

            last = newNode;
            length++;

            return this;
        }

        private Node Locate(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException($"Invalid Index {index}");

            var n = first;
            for (int i = 0; i < index; i++)
                n = n.Next;

            return n;

        }

        public X this[int index]
        {
            get
            {
                return Locate(index).Value;
            }
            set
            {
                Locate(index).Value = value;
            }
        }

        public X Get(int index)
        {

            return Locate(index).Value;
        }

        public void Set(int index, X value)
        {
            Locate(index).Value = value;
        }

        public X Remove(int index)
        {
            var d = Locate(index);


            if (d.Next != null)
                d.Next.Previous = d.Previous;

            if (d.Previous != null)
                d.Previous.Next = d.Next;
            else
                first = d.Next;

            length--;
            return d.Value;
        }

        public void Insert(int index, X value)
        {
            var n = Locate(index);

            //insert after n
            var newNode = new Node() { Value = value };
            length++;
            newNode.Previous = n.Previous;
            newNode.Next = n;

            if (n.Previous != null)
                n.Previous.Next = newNode;
            else
                first = newNode;

            n.Previous = newNode;



        }

        public int IndexOf(X value)
        {
            int index = 0;

            for (Node n = first; n != null; n = n.Next)
                if (n.Value.Equals(value))
                    return index;
                else
                    index++;

            return -1;

        }

        public int LastIndexOf(X value)
        {
            int index = -1;
            int i = 0;
            for (Node n = first; n != null; n = n.Next)
            {
                if (n.Value.Equals(value))
                    index = i;

                i++;
            }

            return index;

        }

        public int Count(X value)
        {
            var count = 0;
            for (var n = first; n != null; n = n.Next)
            {
                if (n.Value.Equals(value))
                    count++;
            }
            return count;
        }



        public void Show()
        {
            for (var n = first; n != null; n = n.Next)
            {
                Console.WriteLine(n.Value);
            }
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