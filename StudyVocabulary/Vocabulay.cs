using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inglés
{
    class Vocabulay
    {
        private List<String> Meaning;
        private List<String> Word;
        public Vocabulay()
        {
            Meaning = new List<string>()
            { "Pelea",
              "Peleon",
              "Confabulacion",
              "Manada",
              "Desafiar",
              "Conclusion",
              "Desvio Brusco, Esguince",
              "Piripi",
              "Alacena",
              "Mochilero",
              "Acantilado",
              "Puerto",
              "Yate",
              "Bronceado",
              "Turismo",
              "Juventud",
              "Representante",
              "Moqueta",
              "Techo",
              "Molestar",
              "Desmayarse",
              "Mal de dinero",
              "Guión",
              "Adinerado",
              "Pico",
              "Intranquilo",
              "Aliviado",
              "sonreir, sonrisa",
              "Mientras",
              "Harto",
              "Instalaciones",
              "Tarifa",
              "Camping",
              "Salir de viaje,",
              "Equipaje",
              "Fruncir el ceño",
              "Además",
              "Folleto",
              "Tener invitados",
              "Considerar",
              "Tiempo libre",
              "Detestar",
              "Entusiasta",
              "Habilmente",
              "Rigidamente",
              "Gripe",
              "Humor",
              "Ropa, conjunto, traje",
              "Extremo, ridiculo",
              "Puesto, caseta",
              "Sudadera",
              "Paso, ritmo",
              "Bostezo",
              "Electrodomestico",
              "Desordenado",
              "Acercarse",
              "Mal humorado",
              "Raza, criar, reproducirse",
              "Brisa",
              "Firme, seguro, gradual",
              "Cotilleo",
              "Titular de periodico",
              "Pista",
              "Planta, piso",
              "Esforzase",
              "Presupuesto",
              "Creer, pensar, estimar",
              "Poco profundo",
              "Buena voluntad, disposicion",
              "Ruborizarse",
              "Testarudo",
              "Ingenioso",
              "Poco fiable",
              "Anuncio",
              "Atico",
              "Carrito de supermercado",
              "Vajilla",
              "Arcilla",
              "Cuberteria",
              "Idear, inventar",
              "Cumplir, llevar a cabo",
              "Comestibles, productos de hogar",
              "Blandengue, empapado",
              "Seco, rancio",
              "compromiso",
              "Ser despedido",
              "Turno",
              "Jefe",
              "Sueldo con enfermedad",
              "Dique, presa",
              "Ocupantes de una casa",
              "Embalse",
              "Abordar un problema",
              "Atractivo",
              "lacteo",
              "Gaseoso",
              "Sabor",
              "Maduro (fruta)",
              "Hacer frente a (exitosame)",
              "Dudoso",
              "Asentir con la cabeza",
              "Ribera del rio",
              "Huerto",
              "Cuesta abajo",
              "Manantial",
              "Senda",
              "Suelo, tierra",
              "Derecho, directamente",
              "Escarpado",
              "Carne magra"


            };

            Word = new List<string>()
            {
                "Quarrel",
                "Quarrelsome",
                "Collude",
                "Herd",
                "Defy",
                "Closures",
                "Swerve",
                "Tipsy",
                "Cupboard",
                "Backpacker",
                "Cliff",
                "Harbour",
                "Yacht",
                "Tan",
                "Sightseeing",
                "Youth",
                "Representative",
                "Carpet",
                "Ceiling",
                "Tease",
                "Faint",
                "Hard-up",
                "Hypen",
                "Well-off",
                "Beak",
                "Uneasy",
                "Relieved",
                "Grin",
                "Whereas",
                "Fed up",
                "Facilities",
                "Fare",
                "Campsite",
                "Jet Off",
                "Luggage",
                "Frown",
                "Besides",
                "Brochure",
                "Entertain",
                "Regard",
                "Leisure time",
                "Loathe",
                "Keen",
                "Skillfully",
                "Stiffy",
                "Flu",
                "Mood",
                "Outfit",
                "Outrangeous",
                "Stall",
                "Sweatshirt",
                "Pace",
                "Yawn",
                "Appliance",
                "Messy",
                "Approach",
                "Bad-tempered",
                "Breed",
                "Breez",
                "Steady",
                "Gossip",
                "Headline",
                "Pitch",
                "Storey",
                "Struggle",
                "Budget",
                "Reckon",
                "Shallow",
                "Willingness",
                "Blush",
                "Stubborn",
                "Witty",
                "Unreliable",
                "Advertise",
                "Attic",
                "Cart",
                "Crockery",
                "Clay",
                "Cutlery",
                "Devise",
                "Fulfil",
                "Groceries",
                "Soggy",
                "Stale",
                "Commitement",
                "Redundant",
                "Shift",
                "Employer",
                "Sick pay",
                "Dam",
                "Household",
                "Reservoir",
                "Tackle",
                "appealing",
                "Dairy",
                "Fizzy",
                "Flavour",
                "Ripe",
                "Cope",
                "Doubtfull",
                "Nod",
                "Bank",
                "Orchard",
                "Slope",
                "Spring",
                "Track",
                "Soil",
                "Straight",
                "Steep",
                "Lean meat"
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

        public String GetResponse(int num)
        {
            return Word[num];
        }

        public bool compareResult(int num,String given)
        {
            bool ret=(Word[num].ToLower().Equals(given.ToLower())) ?  true :  false;
            return ret;
        }

        public int getTotalVocabulary()
        {
            return Meaning.Count();
        }
    }
}
