using NUnit.Framework;
using AdaptiveHuffmanCoding.Classes;

namespace AdaptiveHuffmanCoding.Tests
{
    public class AdaptiveHuffmanTests 
    {
        [Test]
        [TestCase("bookkeeper", "10000000101111110111110101")]
        [TestCase("mississippi", "1001110011001110110111")]
        [TestCase("engineering", "11100110010111101010010011")]
        [TestCase("sleeplessness","0101111110011011100100011100")]
        [TestCase("aardvark","0010110111101011101")]
        public void AdaptiveHuffmanCodingTest(string inputText, string expectedBinaryValue)
        {
            HuffmanTree huffmanTree = new HuffmanTree();

            foreach(char letter in inputText.ToCharArray())
            {
                huffmanTree.AddLetter(letter.ToString());
            }

            string encodedText = huffmanTree.GetEncodedString();
            Assert.AreEqual(expectedBinaryValue, encodedText);
        }
    }
}
