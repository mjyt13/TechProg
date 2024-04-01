namespace Lists
{
    internal class Lists
    {
        static void Main(string[] strings)
        {
            Random random = new();
            BaseList ArList = new ArrayList();
            BaseList ChList = new ChainList();

            int number, position, j;

            for (int i = 0; i < 9000; i++)
            {
                j = random.Next(7);
                number = random.Next(530001);
                position = random.Next(999);
                switch (j)
                {
                    case 1:
                        ChList.Add(number);
                        ArList.Add(number);
                        break;
                    case 2:
                        ChList.Insert(position, number);
                        ArList.Insert(position, number);
                        break;
                    case 3:
                        ChList.Delete(position);
                        ArList.Delete(position);
                        break;
                    case 4:
                        Console.WriteLine(ChList[position]);
                        Console.WriteLine(ArList[position]);
                        break;
                    case 5:
                        ChList[position] = number;
                        ArList[position] = number;
                        break;
                    case 6:
                        ArList.Sort();
                        ChList.Sort();
                        break;
                }
            }

            ChList.Print();
            Console.WriteLine();
            ArList.Print();
            Console.WriteLine();
            if (ArList.IsEqual(ChList)) Console.WriteLine("Lists are equal");//сравнение после большого цикла, необязательна сортировка
            else Console.WriteLine("Lists are not equal");

            // первая проверка на отсортированность
            if (ArList.IsSorted()) Console.WriteLine("ArrayList is sorted");
            else Console.WriteLine("ArrayList is not sorted");
            if (ChList.IsSorted()) Console.WriteLine("ChainList is sorted");
            else Console.WriteLine("ChainList is not sorted");


            Console.WriteLine("chlist kount is"+ChList.Count);
            Console.WriteLine("arlist kount is "+ ArList.Count);
            //клонирование
            BaseList ArListB = ArList.Clone();
            BaseList ChListB = ChList.Clone();

            if (ArListB.IsEqual(ArList))
            {
                Console.WriteLine("Cloning of Arraylist happened successfully");
                ArListB.Sort();
                if (ArListB.IsNotDistored(ArList)) Console.WriteLine("Sorting is RIGHT (ArrayList)");
                else Console.WriteLine("Sorting is WRONG!!! (ArrayList)");
            }
            else Console.WriteLine("Cloning of ArrayList failed");

            if (ChListB.IsEqual(ChList)) 
            {
                Console.WriteLine("Cloning of ChainList happened successfully");
                ChListB.Sort();
                if (ChListB.IsNotDistored(ChList)) Console.WriteLine("Sorting is RIGHT (ChainList)");
                else Console.WriteLine("Sorting is WRONG!!! (ChainList)");
            }
            else Console.WriteLine("Cloning of ChainList failed");
            if (ChListB.IsEqual(ArListB)) Console.WriteLine("Copying got successful");
            else Console.WriteLine("Copying failed");

            //сортировки 1, после них должны быть одинаковые списки
            ArList.Sort();
            ChList.Sort();
            if (ArList.IsEqual(ChList)) Console.WriteLine("Sorting happened successfully");
            else Console.WriteLine("Sorting failed");

            // сортировки 2, проверка на упорядоченность и отсутствие искажений
            if (ArList.IsSorted()) Console.WriteLine("ArrayList is sorted");
            else Console.WriteLine("ArrayList is not sorted");
            if (ChList.IsSorted()) Console.WriteLine("ChainList is sorted");
            else Console.WriteLine("ChainList is not sorted");



            /*int kount = 0;
            for (int i = 0; i < ChList.Count; i++)
            {
                if (ArList[i] == ChList[i])
                {
                    kount++;
                }
            }
            Console.WriteLine("Quantity of matches is " + kount);
            Console.WriteLine("Quantity of elements is " + ArList.Count);*/
        }
    }
}