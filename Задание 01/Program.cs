using System;

namespace Задание_01

//1.Разработать статический класс для работы с окружностью. Класс должен содержать 3 метода:
//метод, определяющий длину окружности по заданному радиусу;
//метод, определяющий площадь круга по заданному радиусу;
//метод, проверяющий принадлежность точки с координатами(x, y) кругу с радиусом r и координатами центра x0, y0.
{
    class Program
    {
        static void Main(string[] args)
        {
            Double x0, y0, r, tx, ty;
            bool check;

            Console.WriteLine("Вас приветствует КАЛЬКУЛЯТОР окружности на плосткости XOY !!!");
            Console.WriteLine();

        ReadCenter:
            Console.WriteLine("Введите координаты центра окружности [X0, Y0]:");
            try { x0 = Convert.ToDouble(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadCenter; }
            try { y0 = Convert.ToDouble(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadCenter; }

        ReadRadius:
            Console.WriteLine("Введите значение радиуса окружности R:");
            try { r = Convert.ToDouble(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadRadius; }

            Console.WriteLine("Длина данной окружности составляет: {0:F2}.", CircleConvertor.LengthFromRadius(r));
            Console.WriteLine("Площадь круга данной окружности составляет: {0:F2}.", CircleConvertor.SquareFromRadius(r));
            Console.WriteLine();

        ReadPoint:
            Console.WriteLine("Введите координаты точки на плоскости для проверки её вхождения в область, ограниченную данной окружностью XoYoR [X, Y]:");
            try { tx = Convert.ToDouble(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadPoint; }
            try { ty = Convert.ToDouble(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadPoint; }

            CircleConvertor.CheckPointIn(x0, y0, r, tx, ty, out check);

            if (check == true) { Console.WriteLine("Данная точка X,Y входит в область данной окружности XoYoR."); }
            else { Console.WriteLine("Точка не входит в область данной окружности XoYoR"); }
            Console.WriteLine();
            Console.WriteLine("До свидания!");
            Console.ReadKey();
        }
    }
    
    //Статический класс для работы с окружностью
    public static class CircleConvertor
    {
        public static double LengthFromRadius(double radius)
        {
            double length = 2 * Math.PI * radius;
            return length;
        }

        public static double SquareFromRadius(double radius)
        {
            double length = Math.PI * Math.Pow(radius, 2);
            return length;
        }

        public static void CheckPointIn(double x0, double y0, double R, double tX, double tY, out bool IN)
        {
            double trad = Math.Sqrt(Math.Pow((tX - x0), 2) + Math.Pow((tY - y0), 2));
            IN = true;
            if (trad > R) { IN = false; }
        }

    }
}
