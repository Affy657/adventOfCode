using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class NetWork
    {
        public Node getFirstNode(string[] input) 
        {
            string[] linesNodes = input[2..];
            NodeBuilder nodeBuilder = new NodeBuilder();
            List<Node> nodesNameList = nodeBuilder.NodeNameListBuilder(linesNodes);
            List<Node> nodesList = nodeBuilder.NodeListBuilder(linesNodes, nodesNameList);
            return nodesList.Find(x => x.Name == "AAA");
        }
    }
}
