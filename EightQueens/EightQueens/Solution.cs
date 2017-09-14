using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Solution
    {
        public void BackTracking(List<Tuple<int,int>> candicate)
        {
            if (Reject(candicate)) return;
            if (Accept(candicate)) Output(candicate);
            List<Tuple<int, int>> s = First(candicate);
            while (s != null)
            {
                BackTracking(s);
                s = Next(s);
            }
        }

        private bool NoHitsWithiTheList(List<Tuple<int, int>> candicate)
        {
            for (int i = 0; i < candicate.Count -1; i++)
            {
                if (candicate.Last().Item1 == candicate.ElementAt(i).Item1)
                {
                    //same row
                    return false;
                }
                if (candicate.Last().Item2 == candicate.ElementAt(i).Item2)
                {
                    //same column
                    return false;
                }
                if (Math.Abs( candicate.Last().Item1 - candicate.ElementAt(i).Item1 ) ==
                    Math.Abs(candicate.Last().Item2 - candicate.ElementAt(i).Item2))
                {
                    //same diagonal
                    return false;
                }
            }

            return true;
        }

        private List<Tuple<int, int>> Next(List<Tuple<int, int>> s)
        {
            var last = s.Last();
            
            var next = last.Item1 < 8 ? new Tuple<int, int>(last.Item1 + 1, last.Item2) :
                last.Item2 < 8 ? new Tuple<int, int>(1, last.Item2 + 1) : null;

            s.RemoveAt(s.Count-1);

            if (next != null)
            {
                s.Add(next);
                return s;
            }
            else
            {
                return null;
            }

            
        }

        private List<Tuple<int, int>> First(List<Tuple<int, int>> candicate)
        {
            if (candicate.Count < 8)
                candicate.Add(new Tuple<int, int>(1, 1));
            else
                return null;

            return candicate;
        }

        private void Output(List<Tuple<int, int>> candicate)
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    char ch = candicate.Contains(new Tuple<int,int>(i, j)) ? 'X' : 'O';
                    if (MustPaint(i, j))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(ch);
                }
                Console.WriteLine();
            }

            Console.ReadLine();

            Environment.Exit(0);
        }

        private bool MustPaint(int i, int j)
        {
            if ( (i % 2 == 1 && j % 2 == 1) || (i % 2 == 0 && j % 2 == 0))
                return true;
            return false;
        }

        private bool Accept(List<Tuple<int, int>> candicate)
        {            
            return NoHitsWithiTheList(candicate) && candicate.Count == 8;
        }

        private bool Reject(List<Tuple<int, int>> candicate)
        {
            return !NoHitsWithiTheList(candicate);
        }
    }
}
