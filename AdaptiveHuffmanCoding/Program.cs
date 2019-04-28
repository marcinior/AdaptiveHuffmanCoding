using AdaptiveHuffmanCoding.Classes;
using System;

namespace AdaptiveHuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree tree = new HuffmanTree();
            tree.AddLetter("t");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("e");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("l");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("e");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("i");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("n");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("f");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("o");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("r");
            //Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("m");
            tree.AddLetter("a");
            tree.AddLetter("t");
            tree.AddLetter("y");
            tree.AddLetter("k");
            tree.AddLetter("a");
            Console.WriteLine(tree.GetEncodedString());
            Console.WriteLine("Entropia:" + tree.Entropy + "Sr dl slowa: " + tree.AverageCodewordLength);
            tree.PrintTree();
            Console.ReadKey();
        }
    }
}
