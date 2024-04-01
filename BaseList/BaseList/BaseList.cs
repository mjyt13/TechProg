namespace Lists
{
    abstract public class BaseList
    {
        protected int count;
        public int Count { get { return count; }  }
        public abstract void Add(int num);
        public abstract void Delete(int index);
        public abstract void Insert(int num, int index);
        public abstract void Clear();
        public abstract int this[int i] { get; set; }
        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine(this[i]);
            }
        }

        public void Assign(BaseList source)
        {
            this.Clear();
            for (int i = 0; i < source.Count; i++)
            {
                this.Add(source[i]);
            }
        }

        public void AssignTo(BaseList destination)
        {
            destination.Clear();
            for(int i = 0; i<this.Count; i++)
            {
                destination.Add(this[i]);
            }
        }

        public BaseList Clone()
        {
            BaseList baselist = EmptyClone();
            baselist.Assign(this);
            return baselist;
        }

        protected abstract BaseList EmptyClone();
        
        // start of writing optional methods
        public bool IsSorted()
        {
            for (int i = 0;i < this.Count-1;i++)
            {
                if(this[i] > this[i+1]) return false;
            }
            return true;
        }

        public bool IsNotDistored(BaseList source)
        {
            if(source == null) return false;
            if(source.Count != this.Count) return false;
            else
            {
                int matches = 0;
                for (int i = 0; i < source.Count; i++)
                {
                    for (int j = 0; j < this.Count; j++)
                    {
                        if (source[i] == this[j])
                        {
                            this.Delete(j);
                            matches++;
                            break;
                        }
                    }
                }
                if (matches == source.Count) return true;
                else return false;
            }
        }
        // finish of writing optional
        public bool IsEqual(BaseList other)
        {
            if(other.Count != this.Count) return false;
            else
            {
                for(int i = 0;i < this.Count;i++)
                {
                    if (this[i] != other[i]) return false;
                }
                return true;
            }
        }

        public virtual void Sort ()
        {
            int k, j;
            for(int i = 1; i < this.Count;i++)
            {
                k = this[i];
                j = i - 1;
                while (j >= 0 && this[j] > k)
                {
                    this[j+1] = this[j];
                    j--;
                }
                this[j + 1] = k;
            }
        }
    }
}