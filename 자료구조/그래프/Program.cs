using System.Xml.Linq;

namespace DataStructure_Day2
{
    #region 과제 1. 그래프 구현하기
    internal class Program
    {

        public class Graph<T>
        {
            List<int> list;
            List<List<int>> edge;
            Dictionary<T,int> nameToId = new Dictionary<T,int>();
            Dictionary<int, T> idToName = new Dictionary<int, T>();

            public Graph()
            {
                list = new List<int>();
                edge = new List<List<int>>();
            }

            public void AddNode(T name)
            {
                if (nameToId.ContainsKey(name) == false) 
                {
                    nameToId.Add(name, list.Count);
                    idToName.Add(list.Count, name);
                    list.Add(list.Count);
                    edge.Add(new List<int>() );
                }
            }

            public void AddEdge(T from , T to) 
            {
                if (nameToId.ContainsKey(from) && nameToId.ContainsKey(to))
                {
                    var fromId = nameToId[from];
                    var toId = nameToId[to];
                    edge[fromId].Add(toId);
                }
            }

            public void PrintGraph()
            {
                for (int i = 0; i < edge.Count; i++)
                {
                    Console.WriteLine($"{idToName[i]}노드 :");
                    foreach (var neighborId in edge[i])
                    {
                        Console.WriteLine($"    {idToName[neighborId]}노드");
                    }
                }                
            }
        }

        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            for (int i = 0; i<8;i++)
            {
                graph.AddNode(i);
            }
            graph.AddEdge(0, 4);
            graph.AddEdge(1, 0);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 0);
            graph.AddEdge(4, 7);
            graph.AddEdge(5, 3);
            graph.AddEdge(6, 7);
            graph.AddEdge(7, 5);
            graph.AddEdge(7, 6);

            graph.PrintGraph();
        }
    }
    #endregion
}
