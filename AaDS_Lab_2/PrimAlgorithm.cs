using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AaDS_Lab_2
{
    internal class PrimAlgorithm
    {
        public static Edge[] GetEdges(int vertexCount, IList<IList<(int adjVertex, int Weight)>> adj)
        {
            bool[] isVisited = new bool[vertexCount + 1]; //Для того, чтобы определить посещенные вершины
            PriorityQueue<Edge, int> priorityQueue = new PriorityQueue<Edge, int>();//Ребра добавляются в ответ в порядке возрастания
            IList<Edge> answer = new List<Edge>();
            Random rand = new Random();
            int nowVertex = rand.Next(0, vertexCount); //Выбираем рандомную вершину, с которой начнется обход
            isVisited[nowVertex] = true;
            while (true)
            { 
                for (int i = 0; i < adj[nowVertex].Count; i++)//Обходим все смежные вершины
                {
                    if (!isVisited[adj[nowVertex][i].adjVertex])//Если данная вершина еще не встречалась, то ребро добавляется в очередь
                    {
                        priorityQueue.Enqueue(new Edge(adj[nowVertex][i].Weight, adj[nowVertex][i].adjVertex, nowVertex), adj[nowVertex][i].Weight);
                    }
                }
                isVisited[nowVertex] = true;     
                while (priorityQueue.Count > 0)//Убираем из очереди ребра, вершины которых уже изучены
                {
                    if (isVisited[priorityQueue.Peek().FirstVertex])
                        priorityQueue.Dequeue();
                    else break;
                }
                //Условие выхода из цикла - перебор всех ребер
                if(priorityQueue.Count == 0)
                    break;
                answer.Add(new Edge(priorityQueue.Peek().Weight, priorityQueue.Peek().FirstVertex, priorityQueue.Peek().SecondVertex));
                nowVertex = priorityQueue.Dequeue().FirstVertex;//Следующей обходим вершину, ребро которой оказалось самым маленьким на данный момент
            }
            return answer.ToArray();
        }
    }
}
