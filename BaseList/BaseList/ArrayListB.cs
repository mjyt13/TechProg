namespace Lists
{
    public class ArrayList : BaseList
    {
        private int[] buffer;

        public override int this[int i]
        {
            set
            {
                if (i >= count || i < 0)
                {

                }
                else
                {
                    buffer[i] = value;
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
                    return buffer[i];
                }
            }
        }

        public ArrayList()
        {
            buffer = null;
            count = 0;
        }

        public override void Add(int num)
        {
            Expand();
            buffer[count] = num;
            count++;
        }
        public override void Delete(int index)
        {
            if (index < 0 || index >= count || count == 0)
            {

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
                    buffer[count - 1] = 0;
                    count--;
                }
            }
        }
        public override void Insert(int num, int index)
        {
            if (index < 0 || index > count)
            {

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
            }
        }
        public override void Clear()
        {
            count = 0;
            buffer = null;
        }
        private void Expand()
        {
            if (buffer != null)
            {
                int[] buffer = new int[count * 2];
                for (int i = 0; i < count; i++)
                {
                    buffer[i] = this.buffer[i];
                }
                this.buffer = buffer;
            }
            else buffer = new int[1];
        }
        protected override ArrayList EmptyClone() { return new ArrayList(); }
    }

}