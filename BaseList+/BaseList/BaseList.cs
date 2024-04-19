using System.Collections;

namespace Lists
{
    abstract public class BaseList<T>: IEnumerable<T> where T : IComparable<T>
    {
        //comparing
        public int CompareTo(T other)
        {
            return this.CompareTo(other);
        }

        //numerating
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new BaseListNumerator(this);
        }
        private class BaseListNumerator: IEnumerator<T>
        {
            BaseList<T> list;
            int index = -1;

            public BaseListNumerator(BaseList<T> list)
            {
                this.list = list;
            }
            public T Current => list[index];
            object IEnumerator.Current => Current;
            public bool MoveNext()
            {
                index++;
                if (index < list.Count) return true;
                else return false;
            }
            public void Reset()
            {
                index = -1;
            }
            public void Dispose()
            {

            }
        }
        
        //events
        public delegate void Handler();
        public event Handler Change;
        protected void Changing() { Change?.Invoke(); }

        //main part
        protected int count;
        public int Count { get { return count; } }
        public abstract void Add(T num);
        public abstract void Delete(int index);
        public abstract void Insert(T num, int index);
        public abstract void Clear();
        public abstract T this[int i] { get; set; }
        public void Print()
        {
            foreach (T num in this)
            {
                Console.WriteLine(num);
            }
        }

        public void Assign(BaseList<T> source)
        {
            this.Clear();
            /*for (int i = 0; i < source.Count; i++)
            {
                this.Add(source[i]);
            }*/
            foreach(T num in source)
            {
                this.Add(num);
            }
        }

        public void AssignTo(BaseList<T> destination)
        {
            destination.Clear();
            foreach(T num in this)
            {
                destination.Add(num);
            }
            /*for (int i = 0; i < this.Count; i++)
            {
                destination.Add(this[i]);
            }*/
        }

        public BaseList<T> Clone()
        {
            BaseList<T> baselist = EmptyClone();
            baselist.Assign(this);
            return baselist;
        }

        protected abstract BaseList<T> EmptyClone();

        /*protected bool IsEqual(BaseList<T> other)
        {
            if (other.Count != this.Count) return false;
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (this[i].CompareTo(other[i]) != 0) return false;
                }
                return true;
            }
        }*/

        public void SaveToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < this.Count; i++)
                {
                    sw.WriteLine(this[i].ToString());
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                this.Clear();
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Trim() != "")
                        {
                            T item = (T)Convert.ChangeType(line, typeof(T));
                            this.Add(item);
                        }
                    }
                }
            }
            catch
            {
                throw new BadFileException();
            }
        }
        public static bool operator ==(BaseList<T> source, BaseList<T> other)
        {
            if (other.Count != source.Count) return false;
            else
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (source[i].CompareTo(other[i]) != 0) return false;
                }
                return true;
            }
        }
        public static bool operator !=(BaseList<T> source, BaseList<T> other)
        {
            if (other.Count != source.Count) return true;
            else
            {
                for (int i = 0; i < source.Count; i++)
                {
                    if (source[i].CompareTo(other[i]) != 0) return true;
                }
                return false;
            }
        }
        public static BaseList<T> operator +(BaseList<T> source, BaseList<T> other)
        {
            BaseList<T> result = source.Clone();
            foreach (T num in other)
            {
                result.Add(num);
            }
            return result;
        }
        public virtual void Sort()
        {
            int i, j;
            T var1;
            for (i = 1; i < this.Count; i++)
            {
                var1 = this[i];
                j = i - 1;
                while (j >= 0 && this[j].CompareTo(var1) > 0) //what about overriding comparing? LIKE public static bool operator(T a, T b){ 
                {
                    this[j + 1] = this[j];
                    j--;
                }
                this[j + 1] = var1;
            }
            Changing();
        }

    }

    class BadIndexException: Exception
    {
        int index;
        public BadIndexException(int index) : base()
        {
            this.index = index;
        }
    }

    class BadFileException: Exception
    {
        public BadFileException() : base()
        {
 
        }
    }
}