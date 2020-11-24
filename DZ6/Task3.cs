using System;
using System.Collections;
using System.IO;

class Task3
{
    public void Run()
    {
        int numOfBachelors = 0;
        int numOfMasters = 0;
        // Создадим необобщенный список
        ArrayList list = new ArrayList();
        // Запомним время в начале обработки данных
        DateTime dt = DateTime.Now;
        StreamReader sr = new StreamReader("..\\..\\students_1.csv");
        while (!sr.EndOfStream)
        {
            try
            {
                string[] s = sr.ReadLine().Split(';');
                // Console.WriteLine("{0}", s[0], s[1], s[2], s[3], s[4]);
                list.Add(s[1] + " " + s[0]);// Добавляем склееные имя и фамилию
                if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
            }
            catch
            {
            }
        }
        sr.Close();
        list.Sort();
        Console.WriteLine("Всего студентов:{0}", list.Count);
        Console.WriteLine("Магистров:{0}", magistr);
        Console.WriteLine("Бакалавров:{0}", bakalavr);
        foreach (var v in list) Console.WriteLine(v);
        // Вычислим время обработки данных
        Console.WriteLine(DateTime.Now - dt);
        Console.ReadKey();
    }

}
