/* Алгазин Константин
Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double).
Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).
*/
using System;

public delegate double Fun(double x, double a);

class Task1
{

    public static void Table(Fun F, double x, double a, double b)
    {
        Console.WriteLine("----- X ----- Y -----");
        while (x <= b)
        {
            Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
            x += 1;
        }
        Console.WriteLine("---------------------");
    }

    public static double MyFunc(double x, double a)
    {
        return a * (x * x);
    }
    public static double MySin(double x, double a)
    {
        return a * Math.Sin(x);
    }

    public void Run()
    {
        Console.WriteLine("Таблица функции a*x^2:");
        Table(new Fun(MyFunc), -2, 2, 2);
        Console.WriteLine("Таблица функции a*sin(x)");
        Table(MySin, -2, 1, 2);
    }
}
