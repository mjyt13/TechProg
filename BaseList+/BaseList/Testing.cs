using System;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using System.Reflection;

namespace Lists
{
    internal class Lists
    {
        static void Main(string[] strings)
        {
            Random random = new();
            
            BaseList<double> ArList = new ArrayList<double>();
            BaseList<double> ChList = new ChainList<double>();

            int position, j, chainindexcounter, arrayindexcounter;
            int arrayeventcounter, chaineventcounter;
            //string oper;
            double number;
            chainindexcounter = 0;
            arrayindexcounter = 0;

            arrayeventcounter = 0;
            chaineventcounter = 0;

            void ChainHandle() => chaineventcounter++;
            void ArrayHandle() => arrayeventcounter++;

            ArList.Change += ArrayHandle;
            ChList.Change += ChainHandle;

            for (int i = 0; i < 2000; i++)
            {
                j = random.Next(7);
                number = random.NextDouble()*random.Next(530000);
                position = random.Next(999);
                //ChList.Action(j, number, position, chainindexcounter);
                //ArList.Action(j, number, position, arrayindexcounter);
                try
                {
                    switch (j)
                    {
                        case 1:
                            ChList.Add(number); break;
                        case 2:
                            ChList.Insert(number, position); break;
                        case 3:
                            ChList.Delete(position); break;
                        case 4:
                            Console.WriteLine(ChList[position]); break;
                        case 5:
                            ChList[position] = number; break;
                        case 6:
                            ChList.Sort(); break;
                    }
                }
                catch (BadIndexException)
                {
                    chainindexcounter++;
                }
                try
                {
                    switch (j)
                    {
                        case 1:
                            ArList.Add(number); break;
                        case 2:
                            ArList.Insert(number, position); break;
                        case 3:
                            ArList.Delete(position); break;
                        case 4:
                            Console.WriteLine(ArList[position]); break;
                        case 5:
                            ArList[position] = number; break;
                        case 6:
                            ArList.Sort(); break;
                    }
                }
                catch (BadIndexException)
                {
                    arrayindexcounter++;
                }
            }

            ChList.Print();
            Console.WriteLine();
            ArList.Print();
            Console.WriteLine();
            if (ArList==ChList) Console.WriteLine("Lists are equal");//сравнение после большого цикла, необязательна сортировка
            else Console.WriteLine("Lists are not equal");

            if (arrayindexcounter == chainindexcounter) Console.WriteLine("Number of Exceptions is equal and equals "+chainindexcounter);
            else Console.WriteLine("Number of Exceptions is NOT equal");

            if(arrayeventcounter==chaineventcounter) Console.WriteLine("Number of Events is equal and equals "+chaineventcounter);
            else Console.WriteLine("Number of Events is NOT equal , first is"+arrayeventcounter+" and second is "+chaineventcounter);

            Console.WriteLine("chlist kount is"+ChList.Count);
            Console.WriteLine("arlist kount is "+ ArList.Count);
            
            //клонирование
            BaseList<double> ArListB = ArList.Clone();
            BaseList<double> ChListB = ChList.Clone();

            if (ArListB==ArList)
            {
                Console.WriteLine("Cloning of Arraylist happened successfully");
                ArListB.Sort();
            }
            else Console.WriteLine("Cloning of ArrayList failed");

            if (ChListB==ChList) 
            {
                Console.WriteLine("Cloning of ChainList happened successfully");
                ChListB.Sort();
            }
            else Console.WriteLine("Cloning of ChainList failed");
            
            if (ChListB==ArListB) Console.WriteLine("Copying got successful");
            else Console.WriteLine("Copying failed");

            //сортировки 1, после них должны быть одинаковые списки
            ArList.Sort();
            ChList.Sort();
            if (ArList==ChList) Console.WriteLine("Sorting happened successfully");
            else Console.WriteLine("Sorting failed");

            //попробовать сохранить файл
            ChListB.SaveToFile("D://chainlist.txt");
            ArListB.SaveToFile("D://arraylist.txt");

            //может ли список исказиться при сохранении в файл?? не знаю, лучше его не трогать после изменения
            BaseList<double> ChListC = new ChainList<double>();
            BaseList<double> ArListC = new ArrayList<double>();

            try
            {
                ChListC.LoadFromFile("D://chainlist.txt");
                if (ChListC == ChList) Console.WriteLine("Saving and loading for chain got successful");
                else Console.WriteLine("Saving and loading for chain Failed");
            }
            catch (BadFileException)
            {
                Console.WriteLine("Working with file (chain) failed early");
            }

            try
            {
                ArListC.LoadFromFile("D://arraylist.txt");
                if (ArListC == ArList) Console.WriteLine("Saving and loading for array got successful");
                else Console.WriteLine("Saving and loading for array Failed");
            }
            catch (BadFileException) 
            {
                Console.WriteLine("Working with file (array) failed early");
            }
            

            
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