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
        private string enteredString;

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
            enteredString += letter;

            if (nodes.TreeContainsLetter(letter))
            {
                Node nodeToUpdate = nodes.GetNodeByLetter(letter);
                nodeToUpdate.NodeValue++;
                CorrectTheTree();
                UpdateParentNodeValues(letter,false);
            }
            else
            {
                Node newNode = new Node();
                newNode.NodeKey = letter;
                newNode.NodeValue = 1;
                newNode.Id = 1;

                Node interiorNode = new Node(nytNode.ParentNode, ref nytNode, ref newNode, 1, string.Empty, 2);

                if (interiorNode.ParentNode != null)
                    interiorNode.ParentNode.LeftChild = interiorNode;

                nodes.Where(n => n.Id != 0).ToList().ForEach(n => n.Id += 2);
                nodes.Add(newNode);
                nodes.Add(interiorNode);
                UpdateParentNodeValues(letter, true);
            }
        }

        public string GetEncodedString()
        {
            StringBuilder encodedStringBuilder = new StringBuilder();

            foreach(var letter in enteredString.ToCharArray())
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
                encodedStringBuilder.Append(new string(charArray));
            }

            return encodedStringBuilder.ToString();
        }
        private void CorrectTheTree()
        {

            while(!IsTreeValid(out int errorNodeIndex))
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

            for(int i = 0; i < nodes.Count -2; i++)
            {
                if(nodes[i+1].NodeValue < nodes[i].NodeValue)
                {
                    errorNodeIndex = i;
                    return false;
                }
            }

            errorNodeIndex = -1;
            return true;
        }

        public void PrintTree()
        {
            var nodes = this.nodes.OrderByDescending(n => n.Id).ToList();

            for(int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine($"Key: {nodes[i].NodeKey} Value: {nodes[i].NodeValue} Id: {nodes[i].Id} LeftChild: {nodes[i].LeftChild?.Id} RightChild: {nodes[i].RightChild?.Id}\t");
            }         
        }
    }
}
