using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDS_Lab_2
{
    internal class Edge : IComparable<Edge>
    {
        public int Weight { get; set; }
        public int FirstVertex { get; set; }
        public int SecondVertex { get; set; }
        public Edge(int weight = 0, int firstVertex = 0, int secondVertex = 0)
        {
            Weight = weight;
            FirstVertex = firstVertex;
            SecondVertex = secondVertex;
        }
        // Сравнение объектов класса Edge для того, чтобы можно было использовать встроенную сортировку
        public int CompareTo(Edge? other)
        {
            if (other is Edge edge) return Weight.CompareTo(edge.Weight);
            else throw new Exception("Incorrect Object");
        }
    }
}
