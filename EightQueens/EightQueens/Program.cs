using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.BackTracking(new List<Tuple<int, int>>() { new Tuple<int, int>(1,1) });
        }
    }
}
