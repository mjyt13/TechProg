public class ArrayList
{
    private int[] buffer;
    private int count;
    
    public int Count
    {
        get { return count; } 
    }

    int this[int i]
    {   set 
        { if (i > count || i < 0)
            {
                
            }else 
            {
                buffer[i] = value;
            }
        }
        get 
        {if (i > count || i < 0)
            {
                return -1;
            }
            else { return buffer[i]; }
        }
    }

    public ArrayList() 
    {      
        buffer = new int [1];
        count = 0;
    }
    
    public void Insert(int num, int index)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Insert ArrayList Impossible");
        }
        else
        {
            Expand();
            for(int i = count; i > index; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[index] = num;
            count++;
        }

    }

    public void Delete(int index)//vniamnie
    {
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Delete ArrayList Impossible");
        }
        else
        {
            for(int i = index; i < count-1; i++)
            {
                buffer[i] = buffer[i + 1];
            }
            buffer[count - 1] = 0;
            count--;
        }
    }
    public void Add(int num) 
    {
        Expand();
        buffer[count] = num;
        count++;
    }

    public void Clear() 
    {
        count = 0;
        buffer = null;
        buffer = new int[1];
    }

    private void Expand()
    {   
        if (count == this.buffer.Length)
            {
            int[] buffer = new int[count * 2];
            for (int i = 0; i < count; i++)
            {
                buffer[i] = this.buffer[i];
            }
            this.buffer = buffer;
        }
    }
    
    public void Print()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(buffer[i]);
        }
    }
}