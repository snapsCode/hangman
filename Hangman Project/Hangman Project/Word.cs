using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman_Project
{
    class Word : IComparable<Word>
    {
        public string word;
        public List<char> msg;
        public List<char> lines = new List<char>();

        public Word(string word)
        {
            this.word = word.ToUpper();
            msg = this.word.ToCharArray().ToList();
            msg.ForEach(x => lines.Add('_'));
        }

        public int CompareTo(Word other)
        {
            if(word.Length < other.word.Length)
            {
                return -1;
            }
            if(word.Length == other.word.Length)
            {
                return 0;
            }

            return 1;
        }

        public override bool Equals(object obj)
        {
            return obj is Word word &&
                   this.word == word.word &&
                   EqualityComparer<List<char>>.Default.Equals(msg, word.msg) &&
                   EqualityComparer<List<char>>.Default.Equals(lines, word.lines);
        }

        public override int GetHashCode()
        {
            int hashCode = 672845787;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(word);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<char>>.Default.GetHashCode(msg);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<char>>.Default.GetHashCode(lines);
            return hashCode;
        }

        public override string ToString()
        {
            return this.word;
        }
    }
}
