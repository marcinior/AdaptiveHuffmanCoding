using AdaptiveHuffmanCoding.Classes;
using System;

namespace AdaptiveHuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            HuffmanTree tree = new HuffmanTree();
            tree.AddLetter("b");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("o");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("o");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("k");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("k");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("e");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("e");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("p");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("e");
            Console.WriteLine(tree.GetEncodedString());
            tree.AddLetter("r");
            Console.WriteLine(tree.GetEncodedString());
            tree.PrintTree();
            Console.ReadKey();
        }
    }
}
