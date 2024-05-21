using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperSlutprojekt
{

    internal class LogikSaker
    {
        private bool[][] Bomb_Karta { get; }
        internal HashSet<int> Upptäckt { get; }
        internal HashSet<int> Markerad { get; }
        internal bool Startat { get; set; }
        private int Rad { get; set; }
        private int Kol { get; set; }
        private int Bomber { get; set; }

        public LogikSaker(int rad, int kol, int bomber)
        {
            Bomb_Karta = new bool[rad][];
            Upptäckt = new HashSet<int>();
            Markerad = new HashSet<int>();
            for (int i = 0; i < rad; i++)
            {
                Bomb_Karta[i] = new bool[kol];
            }
            Startat = false;
            this.Rad = rad;
            this.Kol = kol;
            this.Bomber = bomber;
        }

        internal bool BombKoll(int i, int j)
        {
            return Bomb_Karta[i][j];
        }

        internal void Startup(int fx, int fy)
        {
            Startat = true;
            HashSet<int> h = new HashSet<int>();
            int noll = 0;
            var rand = new Random();
            while (noll < Bomber)
            {
                int i = rand.Next(Rad);
                int j = rand.Next(Kol);
                int index = i * Kol + j;
                if (h.Contains(index) || (Math.Abs(i - fx) < 2 && Math.Abs(j - fy) < 2))
                {
                    continue;
                }
                Bomb_Karta[i][j] = true;
                noll++;
                h.Add(index);
            }
        }

        internal int BombRäkning(int x, int y)
        {
            int count = 0;
            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Rad - 1); i++)
            {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Kol - 1); j++)
                {
                    if (Bomb_Karta[i][j])
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public bool VinstKoll()
        {
            for (int i = 0; i < Rad; i++)
            {
                for (int j = 0; j < Kol; j++)
                {
                    int index = i * Kol + j;
                    if (!Bomb_Karta[i][j] && !Upptäckt.Contains(index))
                    {
                        return false;
                    }
                    if (Bomb_Karta[i][j] && !Markerad.Contains(index))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public HashSet<int> GrannKoll(int x, int y)
        {
            HashSet<int> result = new HashSet<int>();
            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, Rad - 1); i++)
            {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, Kol - 1); j++)
                {
                    if (i != x || j != y)
                    {
                        result.Add(i * Kol + j);
                    }
                }
            }
            return result;
        }

        internal HashSet<int> GetSafeIsland(int x, int y)
        {
            HashSet<int> result = new HashSet<int>();
            Queue<int> q = new Queue<int>();
            bool[][] visited = new bool[Rad][];
            for (int i = 0; i < Rad; i++)
            {
                visited[i] = new bool[Kol];
            }
            visited[x][y] = true;
            q.Enqueue(x * Kol + y);
            while (q.Count > 0)
            {
                int d = q.Dequeue();
                result.Add(d);
                Upptäckt.Add(d);
                int currentX = d / Kol;
                int currentY = d % Kol;
                if (BombRäkning(currentX, currentY) > 0)
                {
                    continue;
                }
                foreach (int neighbor in GrannKoll(currentX, currentY))
                {
                    int neighborX = neighbor / Kol;
                    int neighborY = neighbor % Kol;
                    if (!visited[neighborX][neighborY])
                    {
                        visited[neighborX][neighborY] = true;
                        q.Enqueue(neighbor);
                    }
                }
            }
            return result;
        }
    }
}
