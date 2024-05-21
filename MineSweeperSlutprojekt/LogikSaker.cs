using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperSlutprojekt
{
    



    internal class LogikSaker
    {
        private bool[][] Mine_Map { get; }
        internal HashSet<int> Discovered { get; }
        internal HashSet<int> Flagged { get; }
        internal bool Started { get; set; }
        private int Row { get; set; }
        private int Col { get; set; }
        private int Mines { get; set; }

        public LogikSaker(int row, int col, int mines)
        {
            Mine_Map = new bool[row][];
            Discovered = new HashSet<int>();
            Flagged = new HashSet<int>();
            foreach (int i in Enumerable.Range(0, row))
            {
                Mine_Map[i] = new bool[col];
            }
            foreach (int i in Enumerable.Range(0, row))
            {
                foreach (int j in Enumerable.Range(0, col))
                {
                    Mine_Map[i][j] = false;
                }
            }
            Started = false;
            this.Row = row;
            this.Col = col;
            this.Mines = mines;
        }

        internal bool IsMine(int i, int j)
        {
            return Mine_Map[i][j];
        }






        internal void Initialize(int fx, int fy)
        {
            Started = true;
            HashSet<int> h = new HashSet<int>();
            int noll = 0;
            var rand = new Random();
            while (noll < Mines)
            {
                int i = rand.Next(Row);
                int j = rand.Next(Col);
                if (h.Contains(i * Col * j))
                {
                    continue;
                }
                if (Math.Abs(i - fx) < 2 && Math.Abs(j - fy) < 2)
                {
                    continue;
                }
                Mine_Map[i][j] = true;
                noll++;
                h.Add(i * Col * j);
            }
        }

        internal int CountMines(int x, int y)
        {
            int count = 0;
            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Row - 1); i++)
            {
                for (int j = Math.Max(y - 1, 0); i <= Math.Min(y + 1, Col - 1); j++)
                {
                    if (Mine_Map[i][j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool Win(int x, int y)
        {
            if(CountMines(x, y)==0)
            {
                return true;
            }
            return false;
        }


        public HashSet<int> GetNeighbors(int x, int y)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = Math.Max(x-1, 0); i<=Math.Min(x+1, Row-1); i++)
            {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Col - 1); j++)
                {
                    if(i!=x||j!=y)
                    {
                        result.Add(i * Col * j);
                    }
                }
            }
            return result;
        }

        internal HashSet<int> GetSafeIsland(int x, int y)
        {
            HashSet<int> result = new HashSet<int> ();
            Queue<int>q = new Queue<int>();
            bool[][] visited = new bool[Row][];
            foreach(int i in Enumerable.Range(0, Row))
            {
                visited[i] = new bool[Col];
            }
            foreach(int i in Enumerable.Range(0, Row))
            {
                foreach (int j in Enumerable.Range(0, Col))
                {
                    visited[i][j] = false;
                }
            }
            visited[x][y] = true;
            q.Enqueue(x * Col * y);
            while(q.Count > 0)
            {
                int d = q.Dequeue();
                result.Add (d);
                Discovered.Add(d);
                if(CountMines(d/Col, d % Col) > 0)
                {
                    continue;
                }
                foreach(int neighbor in GetNeighbors(d/Col, d %Col))
                {
                    if (!visited[neighbor / Col][neighbor % Col])
                    {
                        visited[neighbor / Col][neighbor % Col] = true;
                        q.Enqueue(neighbor);
                    }
                }
            }
            return result;
        }

    }


}
