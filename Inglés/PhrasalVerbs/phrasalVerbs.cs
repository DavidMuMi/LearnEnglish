using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English
{
    class phrasalVerbs
    {
        private List<String> Meaning;
        private List<String> Word;
        public phrasalVerbs()
        {
            Meaning = new List<string>()
            { "Put something with something else",
              "To arrange for someone to stay at a hotel",
              "If a machine or vehicle stops working",
              "To end something suddenly",
              "To decide that a planned event will not happen",
              "To telephone someone",
              "To stop feeling upset, angry or exited",
              "To do something that you have not time to do earlier",
              "To go to the desk at a hotel in order to say you have arrived",
              "To leave a hotel after pay your bill",
              "To find something by chance",
              "To fall and land on the ground",
              "If a book, record, film... it becomes available",
              "To move towards someone",
              "To suggest or think an idea or plan",
              "To be formed or made from two or more thing",
              "To eat or drink less or reduce the amount of something",
              "To make a tree or other plant fall to the ground by cutting it near the ground",
              "To cause a person or place to become separate, or cause someone to be or feel alone",
              "To manage without having someone or something",
              "To put on formal clothes for a special occasion",
              "To finaly be in a particular place or situation",
              "To accept that a difficult situation exists",
              "To argue with someone an stop breing frienly",
              "To write necessary information on an official document",
              "To get information about something, or learn a fact for the first time",
              "If one thing ... another thing they look pleasant together or are suitable to each other",
              "To go somewhere to have a holiday, especialy because you need to rest",
              "To succed in not being criticised or punished for something",
              "To start doing something seriously and with lot of attention or efort",
              "If a train ir other vehicle ... a particular time, that is when it arrives",
              "To succeed in being chosen",
              "If two or more people ... they like each other and are friendly to each other",
              "To avoid doing something that you don't want to do, especially giving an excuse",
              "To get better after an illness or feel better after something or someone has made you unhappy",
              "To do or finish unpleasant but necessary piece of work or duty so that you do not have to worry about it in the future",
              "To use up or finish something",
              "Somthing that you say to allow them to do something",
              "To start to do something",
              "To return to a place where you were or where you have been before",
              "If times ... time passes",
              "To choose something",
              "If a bomb or a gun ..., it explodes or fires",
              "To stop liking or being interesred in someone or something",
              "To happen",
              "To leave a room or building, especially in order to do something for entertainment",
              "To talk or thing about something in order to explain it or make it or make certain that is correct",
              "To experience a diffucult or unpleasant situation",
              "To become higher in level",
              "To spend time with someone",
              "To not go somewhere or near something, or to prevent someone from going somewhere or noar something. Mantener la distancia",
              "To continue to do something, or to do something again and again. Continuar, seguir",
              "To make a child stay inside as a punishment, or to make someone stay in hospital",
              "to stop the number, level or size of something from increase",
              "To do what you have promised or planned to do",
              "To be able to understand or deal with something that is happening or changing very fast",
              "To move at the same speed as someone or something that is movind forward so that you stay level with them",
              "To put information into a computer or a machine using a keyboard",
              "To not punish someone who has commited a crime or done something wrong, or to not punish them severely",
              "To be as good as someone hopes",
              "To stop a computer being conected to a computer system",
              "To take care of or be in charge of something ore someone",
              "If someone, usually an expert ... something, they examine it",
              "To try to find someone or something",
              "To feel happy and exited about something that is goinf to happen",
              "To examine the facts about a problem or situation",
              "To try to find a piece of information by looking in a book or on a computer",
              "To respect and admire someone",
              "To move towards a place",
              "To reduce the bad effect of something or make something bad become something good",
              "To see, hear or understand something or something with difficulty",
              "To fail to use an opportinity to enjoy or get an advantage of something",
              "Lo learn a new skill or languages by practising it rather than being taught in it",
              "If a vehicle ... it starts moving",
              "To put on clothes quickly",
              "If a vehicle ..  it stops often for a short time",
              "put something taht you are holding onto another surface",
              "To make someone dislike something or someone or to discourage someone from doing something",
              "To make something that is burning such a fire or cigattere stop burning",
              "To create something by combining different thing"
               

            };

            Word = new List<string>()
            {
                "Add to",
                "Book into",
                "Break down",
                "Break off",
                "Call off",
                "Call up",
                "Calm down",
                "Catch up on",
                "Check in",
                "Check out",
                "Come across",
                "Come down",
                "Come out",
                "Come up",
                "Come up with",
                "Consist of",
                "Cut down",
                "Cut down",
                "Cut off",
                "Do without",
                "Dress up",
                "End up",
                "Face up to",
                "Fall out",
                "Fill in",
                "Find out",
                "Fit in with",
                "Get away",
                "Get away with",
                "Get down to",
                "Get in",
                "Get into",
                "Get on",
                "Get out of",
                "Get over",
                "Get over with",
                "Get through",
                "Go ahead",
                "Go ahead",
                "Go back",
                "Go by",
                "Go for",
                "Go off",
                "Go off",
                "Go on",
                "Go out",
                "Go over",
                "Go through",
                "Go up",
                "Hang around",
                "Keep away",
                "Keep on doing",
                "Keep in",
                "Keep down",
                "Keep to",
                "Keep up",
                "Keep up",
                "Key in",
                "Let off",
                "Live up",
                "Log off",
                "Look after",
                "Look at",
                "Look for",
                "Look forward",
                "Look into",
                "Look up",
                "Look up to",
                "Make for",
                "Make up for",
                "Make out",
                "Miss out on",
                "Pick up",
                "Pull away",
                "Pull on",
                "Pull up",
                "Put down",
                "Put off",
                "Put out",
                "Put together"

            };
        }

        public List<String> getAllMeanings()
        {
            return this.Meaning;
        }

        public List<String> getAllWords()
        {
            return this.Word;
        }

        public String getOneMeaning(int num)
        {
            return Meaning[num];
        }

        public String GetResponse (int num)
        {
            return Word[num];
        }


        public bool compareResult(int num, String given)
        {
            bool ret = (Word[num].ToLower().Equals(given.ToLower())) ? true : false;
            return ret;
        }

        public int getTotalPhrasalVerbs()
        {
            return Meaning.Count();
        }
    }
}
