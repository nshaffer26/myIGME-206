using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Author: Nicholas Shaffer
// Date: 11/17/2020
namespace Shaffer_UnitTest03_Q2
{
    public enum room
    {
        Red, Orange, Yellow, Green, Blue, Indigo, Violet, Grey
    }

    static class Program
    {

        // ------------- Q2 ------------- START ------------- Q2 ------------- //
        static int[,] mCostGraph = new int[,]
        {
            //Red   Orange  Yellow  Green   Blue    Indigo  Violet  Grey
            { -1    , -1    , -1    , -1    ,  1    , -1    , -1    ,  5 },  //Red
            { -1    , -1    , -1    , -1    , -1    , -1    ,  1    , -1 },  //Orange
            { -1    , -1    , -1    ,  6    , -1    , -1    , -1    , -1 },  //Yellow
            { -1    , -1    , -1    , -1    , -1    , -1    , -1    , -1 },  //Green
            { -1    , -1    ,  8    , -1    , -1    ,  1    , -1    , -1 },  //Blue
            { -1    , -1    , -1    , -1    ,  1    , -1    , -1    ,  0 },  //Indigo
            { -1    , -1    ,  1    , -1    , -1    , -1    , -1    , -1 },  //Violet
            { -1    ,  1    , -1    , -1    , -1    ,  0    , -1    , -1 }   //Grey
        };

        static room[][] lRoomGraph = new room[][]
        {
            new room[] { room.Blue, room.Grey },        //Red
            new room[] { room.Violet },                 //Orange
            new room[] { room.Green },                  //Yellow
            null,                                       //Green
            new room[] { room.Yellow, room.Indigo },    //Blue
            new room[] { room.Blue, room.Grey },        //Indigo
            new room[] { room.Yellow },                 //Violet
            new room[] { room.Orange, room.Indigo }     //Grey
        };
        static int[][] lCostGraph = new int[][]
        {
            new int[] { 1, 5 },     //Red
            new int[] { 1 },        //Orange
            new int[] { 6 },        //Yellow
            null,                   //Green
            new int[] { 8, 1 },     //Blue
            new int[] { 1, 0 },     //Indigo
            new int[] { 1 },        //Violet
            new int[] { 1, 0 }      //Grey
        };
        // ------------- Q2 -------------  END  ------------- Q2 ------------- //

        // the current numeric representation of the state
        static int nState = (int)room.Red;

        static List<Node> game = new List<Node>();

        static void Main(string[] args)
        {
            // ------------- Q3 ------------- START ------------- Q3 ------------- //
            // A depth-first search
            DFS();
            // ------------- Q3 -------------  END  ------------- Q3 ------------- //

            // ------------- Q4 ------------- START ------------- Q4 ------------- //
            Node node;

            // Each node is the integer representation of a room, i.e., Red = 0, Orange = 1, Yellow = 2, etc.
            node = new Node(0);
            game.Add(node);

            node = new Node(1);
            game.Add(node);

            node = new Node(2);
            game.Add(node);

            node = new Node(3);
            game.Add(node);

            node = new Node(4);
            game.Add(node);

            node = new Node(5);
            game.Add(node);

            node = new Node(6);
            game.Add(node);

            node = new Node(7);
            game.Add(node);

            game[0].AddEdge(1, game[4]);
            game[0].AddEdge(5, game[7]);
            game[0].edges.Sort();

            game[1].AddEdge(1, game[6]);
            game[1].edges.Sort();

            game[2].AddEdge(6, game[3]);
            game[2].edges.Sort();

            // game[3] = Green, which has no reachable neighbors

            game[4].AddEdge(8, game[2]);
            game[4].AddEdge(1, game[5]);
            game[4].edges.Sort();

            game[5].AddEdge(1, game[4]);
            game[5].AddEdge(0, game[7]);
            game[5].edges.Sort();

            game[6].AddEdge(1, game[2]);
            game[6].edges.Sort();

            game[7].AddEdge(1, game[1]);
            game[7].AddEdge(0, game[5]);
            game[7].edges.Sort();

            List<Node> shortestPath = GetShortestPathDijkstra();
            Console.WriteLine();
            Console.WriteLine("Dijkstra's Shortest Path:");
            foreach(Node n in shortestPath)
            {
                Console.WriteLine((room)n.nState);
            }
            // ------------- Q4 -------------  END  ------------- Q4 ------------- //

            // ------------- Q5 ------------- START ------------- Q5 ------------- //
            LinkedList<RoomCell> linkedList = new LinkedList<RoomCell>();

            LinkedListNode<RoomCell> red = new LinkedListNode<RoomCell>(new RoomCell(room.Red));
            LinkedListNode<RoomCell> orange = new LinkedListNode<RoomCell>(new RoomCell(room.Orange));
            LinkedListNode<RoomCell> yellow = new LinkedListNode<RoomCell>(new RoomCell(room.Yellow));
            LinkedListNode<RoomCell> green = new LinkedListNode<RoomCell>(new RoomCell(room.Green));
            LinkedListNode<RoomCell> blue = new LinkedListNode<RoomCell>(new RoomCell(room.Blue));
            LinkedListNode<RoomCell> indigo = new LinkedListNode<RoomCell>(new RoomCell(room.Indigo));
            LinkedListNode<RoomCell> violet = new LinkedListNode<RoomCell>(new RoomCell(room.Violet));
            LinkedListNode<RoomCell> grey = new LinkedListNode<RoomCell>(new RoomCell(room.Grey));

            red.Value.nextNodes.Add((blue, 1));
            red.Value.nextNodes.Add((grey, 5));

            orange.Value.nextNodes.Add((violet, 1));

            yellow.Value.nextNodes.Add((green, 6));

            blue.Value.nextNodes.Add((yellow, 8));
            blue.Value.nextNodes.Add((indigo, 1));

            indigo.Value.nextNodes.Add((blue, 1));
            indigo.Value.nextNodes.Add((grey, 0));

            violet.Value.nextNodes.Add((yellow, 1));

            grey.Value.nextNodes.Add((orange, 1));
            grey.Value.nextNodes.Add((indigo, 0));
            // ------------- Q5 -------------  END  ------------- Q5 ------------- //

            Console.WriteLine();
        }

        static void DFS()
        {
            bool[] visited = new bool[lRoomGraph.Length];
            Console.WriteLine("Depth-First Search:");
            DFSUtil(nState, visited);
        }

        static void DFSUtil(int v, bool[] visited)
        {
            visited[v] = true;
            Console.WriteLine((room)v);

            room[] thisStateNeighbors = lRoomGraph[v];
            if (thisStateNeighbors != null)
            {
                foreach (room r in thisStateNeighbors)
                {
                    if (!visited[(int)r])
                    {
                        DFSUtil((int)r, visited);
                    }
                }
            }
        }

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[3]);
            BuildShortestPath(shortestPath, game[3]);
            shortestPath.Reverse();
            return (shortestPath);
        }

        static private void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static private int NodeOrderBy(Node n)
        {
            return n.minCostToStart;
        }

        static private void DijkstraSearch()
        {
            Node start = game[0];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();
            prioQueue.Add(start);

            do
            {
                // sort our prioQueue by minCostToStart
                // option #1, use .Sort() which sorts in place 
                // and uses the overloaded Node.CompareTo() method
                prioQueue.Sort();

                // option #2, use .OrderBy() with a delegate method or lambda expression 
                // to indicate which field to sort by
                // the next 5 lines are equivalent from descriptive to abbreviated:
                //prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                //prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                //prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                //prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                //prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);
                foreach (Edge cnn in node.edges)
                //.OrderBy(delegate(Edge n) { return n.cost; }))
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == game[3])
                {
                    return;
                }
            }
            while (prioQueue.Any());
        }
    }

    public class Node : IComparable<Node>
    {
        public int nState;
        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }

    public class RoomCell
    {
        // The current room
        public room thisRoom;

        // List of next nodes and their costs expressed as a tuple
        public List<(LinkedListNode<RoomCell>, int)> nextNodes;

        public RoomCell(room thisRoom)
        {
            this.thisRoom = thisRoom;
            nextNodes = new List<(LinkedListNode<RoomCell>, int)>();
        }
    }
}
