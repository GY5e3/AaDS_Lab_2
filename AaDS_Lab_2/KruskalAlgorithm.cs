using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDS_Lab_2
{
    internal class KruskalAlgorithm
    {   
        // Тело алгоритма
        public static Edge[] GetEdges(int vertexCount, Edge[] edges)
        {
            Create(vertexCount);
            Array.Sort(edges);
            int finalCount = vertexCount - 1; //Число ребер, которое должно быть в минимальном остовном дереве для этого графа
            List<Edge> answer = new List<Edge>();
            for (int i = 0; i < edges.Length; i++)
            {
                int firstVertex = edges[i].FirstVertex - 1;
                int secondVertex = edges[i].SecondVertex - 1;
                if (Find(firstVertex) != Find(secondVertex)) // Если вершины текущего ребра лежат в разных множествах, то объединяем эти множества
                {                                                                // Иными словами, соединяем ребром две компоненты связности графа
                    Union(firstVertex, secondVertex);
                    answer.Add(edges[i]);
                }
                if (answer.Count == finalCount)
                {
                    break;
                }
            }
            return answer.ToArray();
        }
        // Система непересекающихся множеств
        private static int[] pointers; 
        private static int[] rank; // Высота дерева
        private static void Create(int n)
        {
            pointers = new int[n];
            rank = new int[n];
            for (int i = 0; i < n; i++)
            {
                pointers[i] = i;
            }
        }
        //Введем поиск главного элемента множества по дереву и выполняем сжатие пути для всех элементов дерева
        private static int Find(int x)
        {
            int root = x;
            while (pointers[root] != root)//Находим корень дерева
                root = pointers[root];
            int now = x;
            while (pointers[now] != now)//Идем по тому же пути, меняя для всех элементов корень, чтобы в дальнейшем можно было найти корень множества за О(1)
            {
                int lastPointer = pointers[now];//Указатель на элемент, который в дереве находится выше
                pointers[now] = root;
                now = lastPointer;
            }
            return root;
        }
        // Выполняем операцию объединения множеств: привязываем дерево с меньшим рангом к дереву с большим рангом
        private static void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y)
                return;
            if (rank[x] == rank[y])
                rank[x]++;
            if (rank[x] > rank[y])
                pointers[y] = x;
            else pointers[x] = y;
        }
    }
}
