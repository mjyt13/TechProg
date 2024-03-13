public class ChainList
{
    private int count;
    private Node head;

    public ChainList() 
    {
        head = null;
        count = 0;
    }

    public int this[int i]
    {
        set {
            if (i >= count || i < 0 )
            {

            }
            else
            {
                find(i).Data = value;
            }
        }
        get {
                if (i >= count || i < 0)
                {
                    return -1;
                }
                else { return find(i).Data; }
        }       
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