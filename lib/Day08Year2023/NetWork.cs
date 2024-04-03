using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class NetWork
    {
        const string SPAWN_POINT = "AAA";
        const char SPAWN_POINTS = 'A';
        public NodeBuilder nodeBuilder = new();

        public List<Node> GetFirstNode(string[] linesNodes, bool isBonus)
        {
            List<Node> nodesNameList = nodeBuilder.NodeNameListBuilder(linesNodes);
            List<Node> nodesList = nodeBuilder.NodeListBuilder(linesNodes, nodesNameList);
            return nodesList.FindAll(x => isBonus ? x.Name[^1] == SPAWN_POINTS : x.Name == SPAWN_POINT);
        }
    }
}
