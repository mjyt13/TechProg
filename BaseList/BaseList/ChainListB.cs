namespace Lists
{
    public class ChainList: BaseList
    {
        private Node head;
        
        public override int this[int i]
        {
            set
            {
                if (i >= count || i < 0)
                {

                }
                else
                {
                    find(i).Data = value;
                }
            }
            get
            {
                if (i >= count || i < 0)
                {
                    return -1;
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
        public override void Add(int num)
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
        }
        public override void Delete(int index)
        {
            if (count == 0 || index >= count)
            {

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
            }
        }
        public override void Insert(int num, int index)
        {
            if (index < 0 || index > count)
            {

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
                }
            }
        }
        public override void Clear()
        {
            head = null;
            count = 0;
        }
        private class Node
        {
            public int Data;
            public Node Next;
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }
        protected override ArrayList EmptyClone()
        {
            return new ArrayList();
        }
        public override void Sort ()
        {
            Node present;
            int temp;

            for (int i = 0;i < Count;i++)
            {
                present = head;
                while(present != null  && present.Next!=null)
                {
                    if(present.Data > present.Next.Data)
                    {
                        temp = present.Data;
                        present.Data = present.Next.Data;
                        present.Next.Data = temp;
                    }
                    present = present.Next;
                }
            }
        }
    }
}
