
using System;
using System.IO;

class Task2
{
    public delegate double Fun(double x);

    public static double MyFun1(double x)
    {
        return x * x - 50 * x + 10;
    }
    public static double MyFun2(double x)
    {
        return 2 * (x * x);
    }
    public static void SaveFunc(Fun F, string fileName, double a, double b, double h)
    {
        FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(fs);
        double x = a;
        while (x <= b)
        {
            bw.Write(F(x));
            x += h;// x=x+h;
        }
        bw.Close();
        fs.Close();
    }
    public static double[] Load(string fileName, out double min)
    {
        FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        BinaryReader bw = new BinaryReader(fs);
        double[] d = new double[fs.Length / sizeof(double)];
        d[0] = bw.ReadDouble();
        min = d[0];
        for (int i = 1; i < fs.Length / sizeof(double); i++)
        {
            d[i] = bw.ReadDouble();
            if (d[i] < min) min = d[i];
        }
        bw.Close();
        fs.Close();
        return d;

    }
    public void Run()
    {
        Fun[] fun = new Fun[3];
        fun[0] = MyFun1;
        fun[1] = MyFun2;
        fun[2] = Math.Sin;
        string FileName = "data.bin";
        Console.WriteLine("Введи значение от:");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введи значение до:");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введи шаг функции:");
        double h = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Выбери функцию:\n1) x * x - 50 * x + 10\n2) 2*x^2\n3) sin(x)");
        int caseSwitch = int.Parse(Console.ReadLine());
        switch (caseSwitch)
        {
            case 1:
                SaveFunc(fun[0], FileName, a, b, h);
                break;
            case 2:
                SaveFunc(fun[1], FileName, a, b, h);
                break;
            case 3:
                SaveFunc(fun[2], FileName, a, b, h);
                break;
            default:
                Console.WriteLine("Что то не работает");
                break;
        }
        double min = 0;
        double[] mas = Load(FileName, out min);
        Console.WriteLine("Массив считанных значений:");
        for (int i = 0; i < mas.Length; i++)
        {
            Console.WriteLine(mas[i]);
        }
        Console.WriteLine($"Минимальное значение из этого массива: {min}");
    }
}