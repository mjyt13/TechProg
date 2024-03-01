/*using System;

int sam, mas, asm;
sam = 56; mas = 772; asm = 1173;
ArrayList ArList = new ArrayList();
ChainList ChList = new ChainList();

ArList.Add(sam); ChList.Add(sam);
ArList.Add(mas); ChList.Add(mas);
ArList.Add(asm); ChList.Add(asm);

Console.WriteLine("KOLVO v Arliste "+ArList.Count);

Console.WriteLine("KOLVO v CHliste - "+ChList.Count);

Console.WriteLine();

ArList.Print();

Console.WriteLine();

ChList.Print();

Console.WriteLine();

ChList.Insert(99999, 1);

Console.WriteLine();

ChList.Print();

Console.WriteLine();

ChList.Delete(2);

Console.WriteLine("KOLBO is "+ChList.Count);

ChList.Print();*/

internal class Prog
{
    static void Main(string[] args)
    {
        Random random = new Random();
        ArrayList ArList = new ArrayList();
        ChainList ChList = new ChainList();

        int number, position, j;

        for (int i = 0; i < 530000; i++)
        {
            j = random.Next(6);
            number = random.Next(60000);
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
                    ChList.Clear();
                    ArList.Clear();
                    break;
                case 5:
                    Console.WriteLine(ChList[position]);
                    Console.WriteLine(ArList[position]);
                    break;
            }
        }

        ChList.Print();
        Console.WriteLine();
        ArList.Print();

        int kount = 0;
        for (int i = 0; i < ChList.Count; i++)
        {
            if (ArList[i] == ChList[i])
            {
                kount++;
            }
        }
        Console.WriteLine("Quantity of matches is "+kount);
        Console.WriteLine("Quantity of elements is "+ArList.Count);
    }
}
