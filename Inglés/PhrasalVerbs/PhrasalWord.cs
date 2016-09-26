using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inglés.PhrasalVerbs
{
    class PhrasalWord :IEquatable<PhrasalWord>
    {
        public string word { get; set; }
        public string meaning { get; set; }
        public string example { get; set; }
        public double tries = 0;
        public double success = 0;
        public double successPercent = 0;

        public PhrasalWord(String word, String meaning, String example)
        {
            this.word = word;
            this.meaning = meaning;
            this.example = example;
        }
        public bool Equals(PhrasalWord other)
        {
            if (this.word == other.word && this.example == other.example && this.meaning == other.meaning)
            {
                return true;
            }
            return false;
        }
        public void updateSuccess(bool success)
        {
            this.tries++;
            if (success)
                this.success++;
            if (this.success != 0)
                this.successPercent = this.success / tries;
        }
    }
}
