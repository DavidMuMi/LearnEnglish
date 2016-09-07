using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    class irregularVerbs
    {
        private List<String> Meaning;
        private List<String> Verb;
        private List<String> pastSimple;
        private List<String> pastParticiple;
        public irregularVerbs()
        {
            Meaning = new List<string>()
            { "Alzarse",
              "Ser/Estar",
              "Golpear",
              "Convertirse, llegar a ser",
              "Empezar",
              "Doblar",
              "Morder",
              "Sangrar",
              "Soplar",
              "Romper",
              "Traer",
              "Retrasmitir",
              "Construir",
              "Quemar",
              "Explotar",
              "Comprar",
              "Coger",
              "Elegir",
              "Venir",
              "Costar"
            };

            Verb = new List<string>()
            {
                "Arise",
                "be",
                "Beat",
                "Become",
                "Begin",
                "Bend",
                "Bite",
                "Bleed",
                "Blow",
                "Break",
                "Bring",
                "Broadcast",
                "Build",
                "Burn",
                "Burst",
                "Buy",
                "Catch",
                "Choose",
                "Come",
                "Cost"
               };

            pastSimple = new List<string>()
            {
                "Arose",
                "Was",
                "Beat",
                "Became",
                "Began",
                "Bent",
                "Bit",
                "Bled",
                "Blew",
                "Broke",
                "Brought",
                "Broadcast",
                "Built",
                "Burnt",
                "Burst",
                "Bought",
                "Caught",
                "Chose",
                "Came",
                "Cost"
               };
            pastParticiple = new List<string>()
            {
                "Arisen",
                "Been",
                "Beaten",
                "Become",
                "Begun",
                "Bent",
                "Bitten",
                "Bled",
                "Blown",
                "Broken",
                "Brought",
                "Broadcast",
                "Built",
                "Burnt",
                "Burst",
                "Bought",
                "Caught",
                "Chosen",
                "Come",
                "Cost"
               };
        }

        //public List<String> getAllMeanings()
        //{
        //    return this.Meaning;
        //}

        //public List<String> getAllWords()
        //{
        //    return this.Word;
        //}

        public String getOneMeaning(int num)
        {
            return Meaning[num];
        }

        public String GetVerb(int num)
        {
            return Verb[num];
        }

        public String GetSimple(int num)
        {
            return this.pastSimple[num];
        }
        public String GetParticiple(int num)
        {
            return pastParticiple[num];
        }
        
        public bool compareResult(int num, String verb, String simple, String participle)
        {
            bool ret = (Verb[num].ToLower().Equals(verb.ToLower()) && pastParticiple[num].ToLower().Equals(participle.ToLower()) && pastSimple[num].ToLower().Equals(simple.ToLower())) ? true : false;
            return ret;
        }

        public int getTotalIrregularVerbs()
        {
            return Meaning.Count();
        }
    }
}
