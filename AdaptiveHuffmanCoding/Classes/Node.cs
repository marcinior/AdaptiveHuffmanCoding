namespace AdaptiveHuffmanCoding.Classes
{
    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public Node ParentNode { get; set; }
        public int NodeValue { get; set; }
        public string NodeKey { get; set; }
        public int Id { get; set; }
        public string BinaryCode { get; set; }
        public double OccurenceProbability { get; set; }
        public int Depth { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Node(Node parentNode, ref Node leftChild, ref Node rightChild, int nodeValue, string nodeKey, int id)
        {
            this.Id = id;
            this.ParentNode = parentNode;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.NodeValue = nodeValue;
            this.NodeKey = nodeKey;

            if (leftChild != null)
            {
                leftChild.ParentNode = this;
            }

            if (rightChild != null)
            {
                rightChild.ParentNode = this;
            }
        }
        public Node() {}

        public bool IsValueNode => this.NodeKey.Equals(string.Empty);
        public bool IsCharNode => !this.NodeKey.Equals(string.Empty);
        public bool HasChild => this.LeftChild != null || this.RightChild != null;
        public bool HasParent => this.ParentNode != null;
        public static bool IsLeftChild(Node child)
        {
            return child.ParentNode.LeftChild.Id == child.Id;
        }
    }
}
