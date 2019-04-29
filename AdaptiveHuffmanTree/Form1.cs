using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdaptiveHuffmanCoding.Classes;

namespace AdaptiveHuffmanTree
{
    public partial class Form1 : Form
    {
        private HuffmanTree huffmanTree;
        private Graphics graphics;
        private Bitmap tree;

        public Form1()
        {
            InitializeComponent();
            huffmanTree = new HuffmanTree();
            tree = new Bitmap(treePictureBox.ClientSize.Width, 
                treePictureBox.ClientSize.Height, 
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        private void addLetterButton_Click(object sender, EventArgs e)
        {
            if (!isInputValid())
                return;

            addLetter();
            drawTree(huffmanTree.GetNodes());
        }
        private void addLetter()
        {
            huffmanTree.AddLetter(letterToEncodeTextBox.Text);
            enteredTextBox.Text = huffmanTree.EnteredString;
            encodedTextBox.Text = huffmanTree.GetEncodedString();
            entropyTextBox.Text = huffmanTree.Entropy.ToString();
            averageCodewordLengthTextBox.Text = huffmanTree.AverageCodewordLength.ToString();
            insertLettersToListView(huffmanTree.GetLettersNodes());

            letterToEncodeTextBox.Clear();
            letterToEncodeTextBox.Focus();
        }
        private void insertLettersToListView(IList<Node> nodes)
        {
            lettersListView.Items.Clear();

            for(int i = 0; i < nodes.Count; i += 3)
            {
                lettersListView.Items.Add(new ListViewItem(new string[]
                {
                    nodes[i].NodeKey,
                    nodes[i].BinaryCode,
                    i + 1 < nodes.Count ? nodes[i+1].NodeKey : null,
                    i + 1 < nodes.Count ? nodes[i+1].BinaryCode : null,
                    i + 2 < nodes.Count ? nodes[i+2].NodeKey : null,
                    i + 2 < nodes.Count ? nodes[i+2].BinaryCode : null
                }));
            }
        }

        private bool isInputValid()
        {
            if (letterToEncodeTextBox.Text.Equals(string.Empty) || !char.IsLetterOrDigit(letterToEncodeTextBox.Text[0]))
            {
                MessageBox.Show("Enter digit or letter", "Entered value not valid");
                return false;
            }

            return true;
        }

        private void letterToEncodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || !isInputValid())
                return;

            addLetter();
            drawTree(huffmanTree.GetNodes());
        }

        private void drawTree(IList<Node> nodes)
        {
            graphics = Graphics.FromImage(tree);
            graphics.Clear(Color.White);
            int height = 0;
            int width = treePictureBox.ClientSize.Width / 2;
            int depth = 0;
            int diametr = 40;
            int parentNodeWidthDifference = 200;
            int parentNodeHeightDifference = 70;
            List<Tuple<Point, Point >> neighborNodes = new List<Tuple<Point, Point>>();
            
            foreach(Node node in nodes)
            {
                string text = node.IsCharNode ? node.NodeKey + ":" + node.NodeValue : node.NodeValue.ToString();

                if (node.NodeKey.Equals("NYT"))
                    text = node.NodeKey;

                if (node.Depth == 0)
                {
                    graphics.DrawNode(width, height, diametr, text);
                    node.PosX = width;
                    continue;
                }

                if(node.Depth > 1)
                {
                    parentNodeWidthDifference = 100;
                }

                if (node.Depth != depth)
                    height += parentNodeHeightDifference;

                if (Node.IsLeftChild(node))
                {
                    width = node.ParentNode.PosX - parentNodeWidthDifference;
                    node.PosX = width;
                    graphics.DrawNode(width, height, diametr, text);
                }
                else
                {
                    width = node.ParentNode.PosX + parentNodeWidthDifference;
                    node.PosX = width;
                    graphics.DrawNode(width, height, diametr, text);
                }

                neighborNodes.Add(new Tuple<Point, Point>(
                new Point(node.ParentNode.PosX + diametr / 2, node.ParentNode.Depth * parentNodeHeightDifference + diametr),
                new Point(node.PosX + diametr / 2, node.Depth * parentNodeHeightDifference)));
                depth = node.Depth;
            }

            drawEdges(neighborNodes, graphics);
            treePictureBox.Invalidate();
        }

        private void drawEdges(List<Tuple<Point, Point>> neighborNodes, Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 3);

            foreach(var neighborNodesTuple in neighborNodes)
            {
                graphics.DrawLine(pen, neighborNodesTuple.Item1, neighborNodesTuple.Item2);
            }
        }

        private void treePictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(tree, 0, 0, tree.Width, tree.Height);
        }
    }
}
