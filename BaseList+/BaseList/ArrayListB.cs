namespace Lists
{
    public class ArrayList<T> : BaseList<T> where T : IComparable<T>
    {
        private T[] buffer;

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
                    buffer[i] = value;
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
                    return buffer[i];
                }
            }
        }

        public ArrayList()
        {
            buffer = null;
            count = 0;
        }

        public override void Add(T num)
        {
            Expand();
            buffer[count] = num;
            count++;
            Changing();
        }
        public override void Delete(int index)
        {
            if (index < 0 || index >= count || count == 0)
            {
                throw new BadIndexException(index);
            }
            else
            {
                if (count == 1)
                {
                    Clear();
                }
                else
                {
                    for (int i = index; i < count - 1; i++) { buffer[i] = buffer[i + 1]; }
                    buffer[count - 1] = default(T);
                    count--;
                    Changing();
                }
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
                Expand();
                for (int i = count; i > index; i--)
                {
                    buffer[i] = buffer[i - 1];
                }
                buffer[index] = num;
                count++;
                Changing();
            }
        }
        public override void Clear()
        {
            count = 0;
            buffer = null;
            Changing();
        }
        private void Expand()
        {
            if (buffer != null)
            {
                T[] buffer = new T[count * 2];
                for (int i = 0; i < count; i++)
                {
                    buffer[i] = this.buffer[i];
                }
                this.buffer = buffer;
            }
            else buffer = new T[1];
        }
        protected override ArrayList <T> EmptyClone() { return new ArrayList<T>(); }
    }

}