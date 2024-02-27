public class ChainList
{
    private int count;
    private Node head;

    public ChainList() 
    {
        head = null;
        count = 0;
    }

    private Node find(int pos)
    {
        if (pos >= count || pos<0)
        {
            return null;
        }
        int i = 0;
        Node p = head;
        while (p!=null && i < pos)
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

    public int Count
    { get { return count; } }

    public void Add(int num)
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

    public void Insert(int num, int pos)
    {
        if(pos<0 || pos > count)
        {
            Console.WriteLine("Insert ChainList Impossible");
        }
        else
        {
            if (count == 0 || pos == count)
            {
                Add(num);
            }
            else
            {
                Node node = new Node(num, null);
                node.Next = find(pos);
                if (pos == 0)
                {
                    head = node;
                }
                else
                {
                    find(pos - 1).Next = node;
                }
                count++;
            }
        }
    }

    public void Delete(int pos)
    {
        if(count==0 || pos>=count)
        {
            Console.WriteLine("Delete ChainList Impossible");
        }
        else
        {
            if (pos == 0)
            {
                head = head.Next;
                //find(pos).Next = null;
            }
            else 
            {
                Node preNode = find(pos - 1);
                preNode.Next = preNode.Next.Next;
            }
            /*if (pos > 0 && pos < count-1)
            {
                find(pos - 1).Next = find(pos + 1);
                //find(pos).Next = null;
            }*/
            count--;
        }
    }
    public void Print()
    {
        for(int i = 0; i < count; i++)
        {
            Console.WriteLine(find(i).Data);
        }
    }

    public void Clear()
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
}