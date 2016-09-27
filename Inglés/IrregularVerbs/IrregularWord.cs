using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inglés.IrregularVerbs
{
    class IrregularWord
    {
        public string infinitive { get; set; }
        public string psimple { get; set; }
        public string pparticiple { get; set; }
        public string meaning { get; set; }
        public double tries = 0;
        public double success = 0;
        public double successPercent = 0;

        public IrregularWord(String word, String meaning, String example)
        {
            this.infinitive = word;
            this.psimple = meaning;
            this.pparticiple = example;
        }
        public bool Equals(IrregularWord other)
        {
            if (this.infinitive == other.infinitive && this.pparticiple == other.pparticiple && this.psimple == other.psimple)
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
