using System.Collections.Generic;
using System.Linq;

namespace AdaptiveHuffmanCoding.Classes
{
    public static class NodeListHelper
    {
        public static Node GetNodeByLetter(this List<Node> nodes, string letter) {
            return nodes.Single(n => n.NodeKey.Equals(letter));
        }

        public static bool TreeContainsLetter(this List<Node> nodes, string letter)
        {
            return nodes.Where(n => n.NodeKey.Equals(letter)).Count() > 0;
        }

        public static int GetNodeIdByLetter(this List<Node> nodes, string letter)
        {
            return nodes.Single(n => n.NodeKey.Equals(letter)).Id;
        }

        public static Node GetNodeToSwap(this List<Node> nodes, int errorNodeIndex)
        {
            for(int i = nodes.Count - 1; i > errorNodeIndex; i--)
            {
                if (nodes[i].NodeValue < nodes[errorNodeIndex].NodeValue)
                    return nodes[i];
            }

            return null;
        }

        public static string GetLetterBinaryCode(this List<Node> nodes, string letter)
        {
            return nodes.Single(n => n.NodeKey.Equals(letter))?.BinaryCode;
        }

        public static Node GetRootNode(this List<Node> nodes) => nodes.Single(n => !n.HasParent);
    }
}
