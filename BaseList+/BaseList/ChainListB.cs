namespace Lists
{
    public class ChainList<T>: BaseList <T> where T : IComparable<T>
    {
        private Node head;
        
        public override T this[int i]
        {
            set
            {
                if (i >= count || i < 0)
                {
                    throw new BadIndexException(i);
                }
                else
                {
                    find(i).Data = value;
                    Changing();
                }
            }
            get
            {
                if (i >= count || i < 0)
                {
                    throw new BadIndexException(i);
                }
                else 
                { 
                    return find(i).Data;
                }
            }
        }

        public ChainList()
        {
            head = null;
            count = 0;
        }

        private Node find(int pos)
        {
            if (pos >= count || pos < 0)
            {
                return null;
            }
            int i = 0;
            Node p = head;
            while (p != null && i < pos)
            {
                p = p.Next;
                i++;
            }
            if (i == pos)
            {
                return p;
            }
            else
            {
                return null;
            }
        }
        public override void Add(T num)
        {
            Node node = new Node(num, null);
            if (count == 0)
            {
                head = node;
            }
            else
            {
                find(count - 1).Next = node;
            }

            count++;
            Changing();
        }
        public override void Delete(int index)
        {
            if (count == 0 || index >= count || index <0)
            {
                throw new BadIndexException(index);
            }
            else
            {
                if (index == 0)
                {
                    head = head.Next;
                    //find(pos).Next = null;
                }
                else
                {
                    Node preNode = find(index - 1);
                    preNode.Next = preNode.Next.Next;
                }
                count--;
                Changing();
            }
        }
        public override void Insert(T num, int index)
        {
            if (index < 0 || index > count)
            {
                throw new BadIndexException(index);
            }
            else
            {
                if (count == 0 || index == count)
                {
                    Add(num);
                }
                else
                {
                    Node node = new Node(num, null);
                    node.Next = find(index);
                    if (index == 0)
                    {
                        head = node;
                    }
                    else
                    {
                        find(index - 1).Next = node;
                    }
                    count++;
                    Changing();
                }
            }
        }
        public override void Clear()
        {
            head = null;
            count = 0;
            Changing();
        }
        private class Node
        {
            public T Data;
            public Node Next;
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        protected override ChainList<T> EmptyClone()
        {
            return new ChainList<T>();
        }
        /*public override void Sort ()
        {
            Node present;
            T temp;
            for (int i = 0;i < Count;i++)
            {
                present = head;
                while(present != null  && present.Next!=null)
                {
                    if(present.Data.CompareTo(present.Next.Data)>0)
                    {
                        temp = present.Data;
                        present.Data = present.Next.Data;
                        present.Next.Data = temp;
                    }
                    present = present.Next;
                }
            }
            Changing();
        }*/
    }
}
