using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lib.Day08Year2023
{
    public class NodeBuilder
    {
        public Regex pattern = new(@"([A-Z]{3}) = \(([A-Z]{3}), ([A-Z]{3})\)");
        public List<Node> NodeNameListBuilder(string[] linesNodes)
        {
            List<Node> nodeList = new List<Node>();

            foreach (string line in linesNodes)
            {
                Node node = new Node();

                Match match = pattern.Match(line);                     
                node.Name = match.Groups[1].Value;                  
                nodeList.Add(node);            
            }
            return nodeList;
        }
        public List<Node> NodeListBuilder(string[] linesNodes, List<Node> nodesNameList)
        {          
            List<Node> fullNodeList = new();

            for (int i = 0;i< linesNodes.Length;i++)
            {
                Node currentNode = nodesNameList[i];
                Match match = pattern.Match(linesNodes[i]);
                string nodeNameLeft = match.Groups[2].Value;
                string nodeNameRight = match.Groups[3].Value;

                currentNode.Links.Add(nodesNameList.Find(x => x.Name == nodeNameLeft));
                currentNode.Links.Add(nodesNameList.Find(x => x.Name == nodeNameRight));
                
                fullNodeList.Add(currentNode);
            }
            return fullNodeList;
        }
    }
}
