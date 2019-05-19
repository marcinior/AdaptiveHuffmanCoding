using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AdaptiveHuffmanCoding.Classes;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;

namespace AdaptiveHuffmanTree
{
    public partial class Form1 : Form
    {
        private HuffmanTree huffmanTree;
        private Graphics graphics;
        private Bitmap tree;
        private Tuple<int[],int> smallTreeEdgeLengths;
        private Tuple<int[], int> mediumTreeEgdeLenghts;
        private Tuple<int[], int> bigTreeEdgeLenghts;

        public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            huffmanTree = new HuffmanTree();
            smallTreeEdgeLengths = new Tuple<int[], int>(new int[] { 340, 165, 100, 50, 30}, 70);
            mediumTreeEgdeLenghts = new Tuple<int[], int>(new int[] { 285, 145, 70, 55, 40, 20, 15, 15 }, 60);
            bigTreeEdgeLenghts = new Tuple<int[], int>(new int[] { 200, 130, 110, 160, 60, 40, 25, 15, 15 }, 50);
            
            tree = new Bitmap(treePictureBox.ClientSize.Width,
                treePictureBox.ClientSize.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }

        private async void sendTextButton_Click(object sender, EventArgs e)
        {
            if (!isInputValid())
                return;

            handleSendTextButtonClick();
        }

        private void clearApp()
        {
            treePictureBox.BackColor = Color.White;
            graphics.Clear(Color.White);
            treePictureBox.Refresh();
            enteredTextBox.Text = null;
            encodedTextBox.Text = null;
            entropyTextBox.Text = null;
            averageCodewordLengthTextBox.Text = null;
            lettersListView.Items.Clear();
            huffmanTree = new HuffmanTree();
        }

        private async Task sendLetters()
        {
            char[] inputTextWithourControlSequences = letterToEncodeTextBox.Text.Where(c => !char.IsControl(c)).ToArray();

            foreach (var letter in inputTextWithourControlSequences)
            {
                huffmanTree.AddLetter(letter.ToString());
                string encodedString = huffmanTree.GetEncodedString();

                enteredTextBox.Text = huffmanTree.EnteredString;
                encodedTextBox.Text = huffmanTree.GetEncodedString();
                entropyTextBox.Text = huffmanTree.Entropy.ToString();
                averageCodewordLengthTextBox.Text = huffmanTree.AverageCodewordLength.ToString();
                insertLettersToListView(huffmanTree.GetLettersNodes());

                if(drawTreeInRealTimeCheckbox.Checked)
                    drawTree(huffmanTree.GetNodes());

                await Task.Delay(500);
            }

            if(!drawTreeInRealTimeCheckbox.Checked)
                drawTree(huffmanTree.GetNodes());

            letterToEncodeTextBox.Clear();
            letterToEncodeTextBox.Focus();
            clearButton.Enabled = true;
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
            if (letterToEncodeTextBox.Text.Equals(string.Empty) || !char.IsLetter(letterToEncodeTextBox.Text[0]))
            {
                MessageBox.Show(Properties.Resources.InvalidInputErrorMessage, Properties.Resources.ErrorDialogName);
                return false;
            }

            return true;
        }

        private void letterToEncodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || !isInputValid())
                return;

            handleSendTextButtonClick();
        }

        private void drawTree(IList<Node> nodes)
        {
            var treeDimensions = getTreeDimensions();
            int[] lineLengths = treeDimensions.Item1;
            graphics = Graphics.FromImage(tree);
            graphics.Clear(Color.White);
            int height = 0;
            int width = treePictureBox.ClientSize.Width / 2;
            int depth = 0;
            int diametr = 30;
            int parentNodeWidthDifference = 340;
            int parentNodeHeightDifference = treeDimensions.Item2;
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
                    node.PosY = height;
                    continue;
                }

                if (node.Depth != depth)
                {
                    height += parentNodeHeightDifference;
                    Console.WriteLine(lineLengths.Length);
                    parentNodeWidthDifference = lineLengths[node.Depth - 1];
                }

                if (Node.IsLeftChild(node))
                {
                    width = node.ParentNode.PosX - parentNodeWidthDifference;
                    node.PosX = width;
                    node.PosY = height;
                }
                else
                {
                    width = node.ParentNode.PosX + parentNodeWidthDifference;
                    node.PosX = width;
                    node.PosY = height;
                }

                Point point1 = new Point(node.ParentNode.PosX + diametr / 2, node.ParentNode.Depth * parentNodeHeightDifference + diametr);
                Point point2 = new Point(node.PosX + diametr / 2, node.Depth * parentNodeHeightDifference);
                graphics.DrawNode(node.PosX, node.PosY, diametr, text);
                neighborNodes.Add(new Tuple<Point, Point>(point1, point2));
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

        private Tuple<int[], int> getTreeDimensions()
        {
            if (huffmanTree.Depth <= 5)
                return smallTreeEdgeLengths;

            if (huffmanTree.Depth <= 7)
                return mediumTreeEgdeLenghts;

            return bigTreeEdgeLenghts;
        }

        private void treePictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(tree, 0, 0, tree.Width, tree.Height);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            clearApp();
        }

        private async void handleSendTextButtonClick()
        {
            try
            {
                clearButton.Enabled = false;
                sendTextButton.Enabled = false;
                drawTreeInRealTimeCheckbox.Enabled = false;

                await sendLetters();

                clearButton.Enabled = true;
                sendTextButton.Enabled = true;
                drawTreeInRealTimeCheckbox.Enabled = true;

            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.Message + Properties.Resources.ErrorMessage,
                                                        Properties.Resources.ErrorDialogName, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    clearApp();
                }
                else
                {
                    this.Close();
                }
            }
        }
    }
}