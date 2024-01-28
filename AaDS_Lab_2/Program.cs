using System.Diagnostics;

namespace AaDS_Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            float[] buffer = FirstNSequenceElements(10);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            ///////////////////////////////////////////////////////////////////////////////
            foreach(float f in buffer)
                Console.Write(f + " ");
            Console.WriteLine();
            string arithmetic;
            while (true)
            {
                arithmetic = Console.ReadLine();
                if (arithmetic == " ")
                    break;
                Console.WriteLine(isCorrect(arithmetic));
            }
            ///////////////////////////////////////////////////////////////////////////////
            Edge[] data = new Edge[14];
            data[0] = new Edge(2, 1, 2);
            data[1] = new Edge(4, 1, 4);
            data[2] = new Edge(6, 1, 7);
            data[3] = new Edge(1, 2, 3);
            data[4] = new Edge(2, 2, 5);
            data[5] = new Edge(8, 2, 8);
            data[6] = new Edge(1, 2, 4);
            data[7] = new Edge(7, 3, 5);
            data[8] = new Edge(5, 4, 6);
            data[9] = new Edge(1, 4, 7);
            data[10] = new Edge(2, 5, 7);
            data[11] = new Edge(2, 5, 8);
            data[12] = new Edge(1, 6, 7);
            data[13] = new Edge(2, 7, 8);
            Edge[] answer = KruskalAlgorithm.GetEdges(8, data);
            Console.WriteLine("KruskalAlgorithm:");
            foreach (var now in answer)
            {
                Console.WriteLine("{0}-{1} {2}", now.FirstVertex, now.SecondVertex, now.Weight);
            }
            ///////////////////////////////////////////////////////////////////////////////
            IList<IList<(int, int)>> adj = new List<IList<(int adjVertex, int Weight)>>();
            adj.Add(new List<(int, int)>() { });
            adj.Add(new List<(int, int)>() { (2, 2), (4, 4), (7, 6)});
            adj.Add(new List<(int, int)>() { (1, 2), (4, 1), (3, 1), (5, 2), (8, 8)});
            adj.Add(new List<(int, int)>() { (2, 1), (5, 7)});
            adj.Add(new List<(int, int)>() { (1, 4), (6, 5), (7, 1), (2, 1)});
            adj.Add(new List<(int, int)>() { (2, 2), (3, 7), (7, 2), (8, 2)});
            adj.Add(new List<(int, int)>() { (4, 5), (7, 1)});
            adj.Add(new List<(int, int)>() { (1, 6), (4, 1), (5, 2), (6, 1), (8, 2) });
            adj.Add(new List<(int, int)>() { (2, 8), (5, 2), (7, 2)});
            answer = PrimAlgorithm.GetEdges(8, adj);
            Console.WriteLine("PrimAlgorithm:");
            foreach (var now in answer)
            {
                Console.WriteLine("{0}-{1} {2}", now.FirstVertex, now.SecondVertex, now.Weight);
            }

        }
        // Первые n элементов заданной последовательности
        private static float[] FirstNSequenceElements(int n)
        {
            //a(n) = 3^(n+1) / n! , где n принадлежит [0; +inf)
            float[] elements = new float[n + 1];
            elements[0] = 3;
            recursive(1);
            return elements;
            void recursive(int now)
            {
                if(now > n)
                    return;
                elements[now] = elements[now - 1] * 3 / now;
                recursive(now + 1);
            }
        }
        // Корректность скобочной последовательности
        private static bool isCorrect(string arithmetic)
        {
            Stack<char> counter = new Stack<char>();
            foreach (char symbol in arithmetic)
            {
                if (symbol == '(')
                    counter.Push(symbol);
                else if (symbol == ')')
                {
                    if (counter.Count > 0)
                        counter.Pop();
                    else return false;
                }
            }
            return counter.Count == 0;
        }  
    }
}