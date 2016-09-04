using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inglés
{
    class VocabularyWord : IEquatable<VocabularyWord>
    {
        public String word;
        public String meaning;
        public int tries=0;
        public int success=0;
        public int successPercent = 0;
        public VocabularyWord(String word, String meaning)
        {
            this.word = word;
            this.meaning = meaning;
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

