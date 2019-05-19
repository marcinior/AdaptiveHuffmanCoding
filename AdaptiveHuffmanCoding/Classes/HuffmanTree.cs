using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaptiveHuffmanCoding.Classes
{
    public class HuffmanTree
    {
        private Node nytNode;
        private List<Node> nodes;

        public string EnteredString { get; private set; }
        public double Entropy { get; private set; }
        public double AverageCodewordLength { get; private set; }

        public HuffmanTree()
        {
            Node nytNode = new Node();
            nytNode.NodeKey = "NYT";
            nytNode.Id = 0;
            this.nytNode = nytNode;

            nodes = new List<Node>();
            nodes.Add(nytNode);
        }

        public void AddLetter(string letter)
        {
            EnteredString += letter;
            Node node = null;

            if (nodes.TreeContainsLetter(letter))
            {
                node = nodes.GetNodeByLetter(letter);
                node.NodeValue++;
                CorrectTheTree();
                UpdateParentNodeValues(letter, false);
            }
            else
            {
                node = new Node();
                node.NodeKey = letter;
                node.NodeValue = 1;
                node.Id = 1;
                node.OccurenceProbability = 1 / EnteredString.Length;

                Node interiorNode = new Node(nytNode.ParentNode, ref nytNode, ref node, 1, string.Empty, 2);

                if (interiorNode.ParentNode != null)
                    interiorNode.ParentNode.LeftChild = interiorNode;

                nodes.Where(n => n.Id != 0).ToList().ForEach(n => n.Id += 2);
                nodes.Add(node);
                nodes.Add(interiorNode);
                UpdateParentNodeValues(letter, true);
            }

            UpdateLettersBinaryCodeAndOccurenceProbabilty();
        }

        public IList<Node> GetLettersNodes() => nodes.Where(n => n.IsCharNode && !n.NodeKey.Equals("NYT")).ToList();
        public IList<Node> GetNodes() => nodes.OrderByDescending(n => n.Id).ToList();

        private void UpdateLettersBinaryCodeAndOccurenceProbabilty()
        {
            var letterNodes = nodes.Where(n => n.IsCharNode && !n.NodeKey.Equals("NYT"));
            Entropy = 0;
            AverageCodewordLength = 0;

            foreach(var node in letterNodes)
            {
                node.BinaryCode = GetEncodedLetter(node.NodeKey);
                node.Depth = node.BinaryCode.Length;
                node.ParentNode.Depth = node.Depth - 1;
                node.OccurenceProbability = (double)node.NodeValue / EnteredString.Length;
                UpdateEntropy(node);
                UpdateAverageCodewordLength(node);
            }

            Node rootNode = nodes.GetRootNode();
            rootNode.Depth = 0;
            rootNode.LeftChild.Depth = 1;
            rootNode.RightChild.Depth = 1;
            nytNode.Depth = nytNode.ParentNode.RightChild.Depth;
        }

        private void UpdateEntropy(Node node)
        {
            Entropy += node.OccurenceProbability * Math.Log((1 / node.OccurenceProbability), 2);
        }

        private void UpdateAverageCodewordLength(Node node)
        {
            AverageCodewordLength += node.OccurenceProbability * node.BinaryCode.Length;
        }

        public string GetEncodedString()
        {
            StringBuilder encodedStringBuilder = new StringBuilder();

            foreach (var letter in EnteredString.ToCharArray())
            {
                encodedStringBuilder.Append(nodes.GetLetterBinaryCode(letter.ToString()));
            }

            return encodedStringBuilder.ToString();
        }

        public int Depth => nodes.Max(n => n.Depth);

        private string GetEncodedLetter(string letter)
        {
            Node currentNode = nodes.GetNodeByLetter(letter.ToString());
            string binaryString = Node.IsLeftChild(currentNode) ? "0" : "1";

            currentNode = currentNode.ParentNode;

            while (currentNode.HasParent)
            {
                binaryString += Node.IsLeftChild(currentNode) ? "0" : "1";
                currentNode = currentNode.ParentNode;
            }

            char[] charArray = binaryString.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void CorrectTheTree()
        {
            while (!IsTreeValid(out int errorNodeIndex))
            {
                Node errorNode = nodes[errorNodeIndex];
                Node nodeToSwap = nodes.GetNodeToSwap(errorNodeIndex);
                Node tempNode = new Node
                {
                    Id = errorNode.Id,
                    ParentNode = errorNode.ParentNode,
                };

                bool nodesHaveCommonParent = errorNode.ParentNode.Id == nodeToSwap.ParentNode.Id;

                if (nodesHaveCommonParent)
                {
                    SwapParentChildrens(errorNode, nodeToSwap);
                    SwapParentChildrens(tempNode, errorNode);
                }
                else
                {
                    SwapParentChildrens(errorNode, nodeToSwap);
                    SwapParentChildrens(nodeToSwap, errorNode);
                    errorNode.ParentNode = nodeToSwap.ParentNode;
                    nodeToSwap.ParentNode = tempNode.ParentNode;
                }

                errorNode.Id = nodeToSwap.Id;
                nodeToSwap.Id = tempNode.Id;
            }
        }

        private void SwapParentChildrens(Node firstNode, Node secondNode)
        {
            if (Node.IsLeftChild(firstNode))
            {
                firstNode.ParentNode.LeftChild = secondNode;
            }
            else
            {
                firstNode.ParentNode.RightChild = secondNode;
            }
        }

        private void UpdateParentNodeValues(string letter, bool isNewNode)
        {
            Node nodeToUpdate = nodes.GetNodeByLetter(letter);

            if (isNewNode)
                nodeToUpdate = nodeToUpdate.ParentNode;

            while (nodeToUpdate.HasParent)
            {
                nodeToUpdate = nodeToUpdate.ParentNode;
                nodeToUpdate.NodeValue++;
                CorrectTheTree();
            }
        }

        private bool IsTreeValid(out int errorNodeIndex)
        {
            nodes = nodes.OrderBy(n => n.Id).ToList();

            for (int i = 0; i < nodes.Count - 2; i++)
            {
                if (nodes[i + 1].NodeValue < nodes[i].NodeValue)
                {
                    errorNodeIndex = i;
                    return false;
                }
            }

            errorNodeIndex = -1;
            return true;
        }

        public void PrintTree() //For test purposes
        {
            var nodes = this.nodes.OrderByDescending(n => n.Id).ToList();
            int depth = 0;

            for (int i = 0; i < nodes.Count; i++)
            {

                if (nodes[i].Depth != depth)
                    Console.WriteLine("-----------");

                Console.WriteLine($"Key: {nodes[i].NodeKey} Value: {nodes[i].NodeValue} Id: {nodes[i].Id} LeftChild: {nodes[i].LeftChild?.Id} RightChild: {nodes[i].RightChild?.Id}");

                depth = nodes[i].Depth;
            }
        }
    }
}