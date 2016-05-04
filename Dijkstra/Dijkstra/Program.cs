using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// Реализация алгоритма Дейкстры. Содержит матрицу смежности в виде массивов вершин и ребер
/// </summary>
class DekstraAlgorim
{

    public Point[] points { get; private set; }
    public Rebro[] rebra { get; private set; }
    public Point BeginPoint { get; private set; }

    public DekstraAlgorim(Point[] pointsOfgrath, Rebro[] rebraOfgrath)
    {
        points = pointsOfgrath;
        rebra = rebraOfgrath;
    }
    /// <summary>
    /// Запуск алгоритма расчета
    /// </summary>
    /// <param name="beginp"></param>
    public void AlgoritmRun(Point beginp)
    {
        if (this.points.Count() == 0 || this.rebra.Count() == 0)
        {
            throw new DekstraException("Массив вершин или ребер не задан!");
        }
        else
        {
            BeginPoint = beginp;
            OneStep(beginp);
            foreach (Point point in points)
            {
                Point anotherP = GetAnotherUncheckedPoint();
                if (anotherP != null)
                {
                    OneStep(anotherP);
                }
                else
                {
                    break;
                }

            }
        }

    }
    /// <summary>
    /// Метод, делающий один шаг алгоритма. Принимает на вход вершину
    /// </summary>
    /// <param name="beginpoint"></param>
    public void OneStep(Point beginpoint)
    {
        foreach (Point nextp in Pred(beginpoint))
        {
            if (nextp.IsChecked == false)//не отмечена
            {
                float newmetka = beginpoint.ValueMetka + GetMyRebro(nextp, beginpoint).Weight;
                if (nextp.ValueMetka > newmetka)
                {
                    nextp.ValueMetka = newmetka;
                    nextp.predPoint = beginpoint;
                }
                else
                {

                }
            }
        }
        beginpoint.IsChecked = true;//вычеркиваем
    }
    /// <summary>
    /// Поиск соседей для вершины. Для неориентированного графа ищутся все соседи.
    /// </summary>
    /// <param name="currpoint"></param>
    /// <returns></returns>
    private IEnumerable<Point> Pred(Point currpoint)
    {
        IEnumerable<Point> firstpoints = from ff in rebra where ff.FirstPoint == currpoint select ff.SecondPoint;
        IEnumerable<Point> secondpoints = from sp in rebra where sp.SecondPoint == currpoint select sp.FirstPoint;
        IEnumerable<Point> totalpoints = firstpoints.Concat<Point>(secondpoints);
        return totalpoints;
    }
    /// <summary>
    /// Получаем ребро, соединяющее 2 входные точки
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private Rebro GetMyRebro(Point a, Point b)
    {//ищем ребро по 2 точкам
        IEnumerable<Rebro> myr = from reb in rebra where (reb.FirstPoint == a & reb.SecondPoint == b) || (reb.SecondPoint == a & reb.FirstPoint == b) select reb;
        if (myr.Count() > 1 || myr.Count() == 0)
        {
            throw new DekstraException("Не найдено ребро между соседями!");
        }
        else
        {
            return myr.First();
        }
    }
    /// <summary>
    /// Получаем очередную неотмеченную вершину, "ближайшую" к заданной.
    /// </summary>
    /// <returns></returns>
    private Point GetAnotherUncheckedPoint()
    {
        IEnumerable<Point> pointsuncheck = from p in points where p.IsChecked == false select p;
        if (pointsuncheck.Count() != 0)
        {
            float minVal = pointsuncheck.First().ValueMetka;
            Point minPoint = pointsuncheck.First();
            foreach (Point p in pointsuncheck)
            {
                if (p.ValueMetka < minVal)
                {
                    minVal = p.ValueMetka;
                    minPoint = p;
                }
            }
            return minPoint;
        }
        else
        {
            return null;
        }
    }

    public List<Point> MinPath1(Point end)
    {
        List<Point> listOfpoints = new List<Point>();
        Point tempp = new Point();
        tempp = end;
        while (tempp != this.BeginPoint)
        {
            listOfpoints.Add(tempp);
            tempp = tempp.predPoint;
        }

        return listOfpoints;
    }
}

/// <summary>
/// Класс, реализующий ребро
/// </summary>
class Rebro
{
    public Point FirstPoint { get; private set; }
    public Point SecondPoint { get; private set; }
    public float Weight { get; private set; }

    public Rebro(Point first, Point second, float valueOfWeight)
    {
        FirstPoint = first;
        SecondPoint = second;
        Weight = valueOfWeight;
    }

}
/// <summary>
/// Класс, реализующий вершину графа
/// </summary>
class Point
{
    public float ValueMetka { get; set; }
    public string Name { get; private set; }
    public bool IsChecked { get; set; }
    public Point predPoint { get; set; }
    public object SomeObj { get; set; }
    public Point(int value, bool ischecked)
    {
        ValueMetka = value;
        IsChecked = ischecked;
        predPoint = new Point();
    }
    public Point(int value, bool ischecked, string name)
    {
        ValueMetka = value;
        IsChecked = ischecked;
        Name = name;
        predPoint = new Point();
    }
    public Point()
    {
    }
}

// <summary>
/// для печати графа
/// </summary>
static class PrintGrath
{
    public static List<string> PrintAllPoints(DekstraAlgorim da)
    {
        List<string> retListOfPoints = new List<string>();
        foreach (Point p in da.points)
        {
            retListOfPoints.Add(string.Format("point name={0}, point value={1}, predok={2}", p.Name, p.ValueMetka, p.predPoint.Name ?? "нет предка"));
        }
        return retListOfPoints;
    }
    public static List<string> PrintAllMinPaths(DekstraAlgorim da)
    {
        List<string> retListOfPointsAndPaths = new List<string>();
        foreach (Point p in da.points)
        {

            if (p != da.BeginPoint)
            {
                string s = string.Empty;
                foreach (Point p1 in da.MinPath1(p))
                {
                    s += string.Format("{0} ", p1.Name);
                }
                s = Reverse(s);
                retListOfPointsAndPaths.Add(string.Format("Point = {0}, MinPath from {1} = {2}{3}", p.Name, da.BeginPoint.Name, da.BeginPoint.Name, s));
            }

        }
        return retListOfPointsAndPaths;
    }
    public static string Reverse(string text)
    {
        if (text == null) return null;
        char[] array = text.ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }
}

class DekstraException : ApplicationException
{
    public DekstraException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main(string[] args)
    {
        Point[] v = new Point[5];
        v[0] = new Point(0, false, "1");
        v[1] = new Point(9999, false, "2");
        v[2] = new Point(9999, false, "3");
        v[3] = new Point(9999, false, "4");
        v[4] = new Point(9999, false, "5");
        Rebro[] rebras = new Rebro[7];
        rebras[0] = new Rebro(v[0], v[1], 10);
        rebras[1] = new Rebro(v[0], v[4], 100);//FC
        rebras[2] = new Rebro(v[0], v[3], 30);//FA
        rebras[3] = new Rebro(v[1], v[2], 50);//bc
        rebras[4] = new Rebro(v[2], v[4], 10);//be
        rebras[5] = new Rebro(v[2], v[3], 20);//be
        rebras[6] = new Rebro(v[3], v[4], 60);//be

        DekstraAlgorim da = new DekstraAlgorim(v, rebras);
        da.AlgoritmRun(v[0]);
        List<string> b = PrintGrath.PrintAllMinPaths(da);
        for (int i = 0; i < b.Count; i++)
            Console.WriteLine(b[i]);
        Console.ReadKey(true);
    }
}