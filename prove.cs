using System;
using System.Collections.Generic;

namespace ScriptureMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
            scripture.Display();
            while (!scripture.IsMemorized())
            {
                Console.WriteLine("Press Enter to hide another word, or type 'quit' to end the program.");
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                scripture.HideWord();
                scripture.Display();
            }
            Console.WriteLine("You have memorized the scripture!");
        }
    }

    class Scripture
    {
        private string reference;
        private string text;
        private List<int> hiddenWords;

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            this.hiddenWords = new List<int>();
        }

        public void Display()
        {
            Console.Clear();
            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (hiddenWords.Contains(i))
                {
                    Console.Write("____ ");
                }
                else
                {
                    Console.Write(words[i] + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine(reference);
        }

        public void HideWord()
        {
            Random rand = new Random();
            int index = rand.Next(0, text.Split(' ').Length);
            hiddenWords.Add(index);
        }

        public bool IsMemorized()
        {
            return hiddenWords.Count == text.Split(' ').Length;
        }
    }
}
