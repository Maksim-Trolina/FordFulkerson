using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordFulkerson
{
    public class Node
    {
        public string Name { get; set; }

        public bool Visited { get; set; }
        public List<Edge> Edges { get; set; }

    }
}
