using System;

public class Testing
{
    public void Test()
    { 
        Random random = new Random();
        ChainList ChList = new ChainList();
        ArrayList ArList = new ArrayList();

        
        Console.WriteLine("Testing start");
        Console.WriteLine();
        
        for (int i = 0; i < 7500; i++)
        
        {
            int j = random.Next(0,4);
            int number = random.Next(2,6000);
            int position = random.Next(99);
            switch (j)
            {
                case 0:
                    ChList.Add(number);
                    ArList.Add(number);
                    break;
                case 1:
                    ChList.Insert(position, number);
                    ArList.Insert(position, number);
                    break;
                case 2:
                    ChList.Delete(position);
                    ArList.Delete(position);
                    break;
                case 3:
                    ChList.Clear();
                    ArList.Clear();
                    break;
                case 4:
                    ChList.Print();
                    ArList.Print();
                    break;
                }
        }
        Console.WriteLine();
        Console.WriteLine("Testing done");        
    }
}
