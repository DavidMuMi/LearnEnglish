using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    class VocabularyWord : IEquatable<VocabularyWord>
    {
        public string word { get; set; }
        public string meaning { get; set; }
        public string example { get; set; }
        public double tries=0;
        public double success=0;
        public double successPercent = 0;


        public VocabularyWord(String word, String meaning, String example)
        {
            this.word = word;
            this.meaning = meaning;
            this.example = example;
        }
        public bool Equals(VocabularyWord other)
        {
            if (other == null)
                return false;
            return (this.word.Equals(other.word));
        }
        public void updateSuccess(bool success )
        {
            this.tries++;
            if (success)
                this.success++;
            if (this.success != 0)
                this.successPercent = this.success / tries;
        }
    }
}

