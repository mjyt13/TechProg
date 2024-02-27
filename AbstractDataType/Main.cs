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
Random random = new Random();
ArrayList ArList = new ArrayList();
ChainList ChList = new ChainList();

Console.WriteLine("Testing start");
Console.WriteLine();

int number, position, j;

for (int i = 0; i < 7500; i++)
{
    j = random.Next(6);
    number = random.Next(60000);
    position = random.Next(99);
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
            ChList.Print();
            ArList.Print();
            break;
    }
    
}

Console.WriteLine();
Console.WriteLine("Testing done");
