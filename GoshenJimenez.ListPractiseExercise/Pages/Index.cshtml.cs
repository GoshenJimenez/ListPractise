using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GoshenJimenez.ListPractiseExercise.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Character> Characters { get; set; }

        public void OnGet(string? sortBy = null,string? sortAsc = "true")
        {
            List<Character>? characters = new List<Character>()
            {
                new Character () {
                    Name= "Jace Beleren",
                    Powers= "Telepathy,Illusion,Memory manipulation",
                    HomePlane= "Vryn",
                    Colors= "Blue"
                  },
                  new Character () {
                    Name= "Chandra Nalaar",
                    Powers= "Pyromancy,Fire manipulation",
                    HomePlane= "Kaladesh",
                    Colors= "Red"
                  },
                  new Character () {
                    Name= "Garruk Wildspeaker",
                    Powers= "Beast manipulation,Nature magic",
                    HomePlane= "Lorwyn",
                    Colors= "Green"
                  },
                  new Character () {
                    Name= "Liliana Vess",
                    Powers= "Necromancy,Death magic",
                    HomePlane= "Dominaria",
                    Colors= "Black"
                  },
                  new Character () {
                    Name= "Ajani Goldmane",
                    Powers= "Healing,Summoning leonin",
                    HomePlane= "Naya",
                    Colors= "White"
                  },
                  new Character () {
                    Name= "Nicol Bolas",
                    Powers= "Mind control,Telekinesis,Fire manipulation",
                    HomePlane= "Dominaria (originally), Amonkhet",
                    Colors= "Blue,Black,Red"
                  },
                  new Character () {
                    Name= "Elspeth Tirel",
                    Powers= "Swordsmanship,White magic",
                    HomePlane= "Bant",
                    Colors= "White"
                  },
                  new Character () {
                    Name= "Sorin Markov",
                    Powers= "Vampirism,Blood magic",
                    HomePlane= "Innistrad",
                    Colors= "Black,White"
                  },
                  new Character () {
                    Name= "Teferi, Timebender",
                    Powers= "Temporal manipulation,Time travel",
                    HomePlane= "Dominaria",
                    Colors= "Blue"
                  },
                  new Character () {
                    Name= "Nissa Revane",
                    Powers= "Elemental magic,Earth manipulation",
                    HomePlane= "Zendikar",
                    Colors= "Green"
                  },
                  new Character () {
                    Name= "Gideon Jura",
                    Powers= "Indestructibility,White magic",
                    HomePlane= "Theros",
                    Colors= "White"
                  },
                  new Character () {
                    Name= "Karn, Silver Golem",
                    Powers= "Artifice manipulation,Metal shaping",
                    HomePlane= "Argentum",
                    Colors= "Colorless"
                  },
                  new Character () {
                    Name= "Sarkhan Vol",
                    Powers= "Dragon summoning,Fire magic",
                    HomePlane= "Tarkir",
                    Colors= "Red"
                  },
                  new Character () {
                    Name= "Vraska the Unseen",
                    Powers= "Assassination,Deathtouch",
                    HomePlane= "Ravnica",
                    Colors= "Black,Green"
                  },
                  new Character () {
                    Name= "Tamiyo, the Moon Sage",
                    Powers= "Moon magic,Scroll mastery",
                    HomePlane= "Kamigawa",
                    Colors= "Blue"
                  },
                  new Character () {
                    Name= "Domri Rade",
                    Powers= "Beast summoning,Wild magic",
                    HomePlane= "Ravnica",
                    Colors= "Red,Green"
                  },
                  new Character () {
                    Name= "Kaya, Ghost Assassin",
                    Powers= "Ghost manipulation,Assassination",
                    HomePlane= "Unknown",
                    Colors= "White,Black"
                  },
                  new Character () {
                    Name= "Ashiok, Nightmare Weaver",
                    Powers= "Fear manipulation,Dream magic",
                    HomePlane= "Theros",
                    Colors= "Blue,Black"
                  },
                  new Character () {
                    Name= "Ral Zarek",
                    Powers= "Electrokinesis,Temporal magic",
                    HomePlane= "Ravnica",
                    Colors= "Blue,Red"
                  },
                  new Character () {
                    Name= "Serra the Benevolent",
                    Powers= "Angelic magic,Healing",
                    HomePlane= "Unknown",
                    Colors= "White"
                  },
                  new Character () {
                    Name= "Liliana of the Veil",
                    Powers= "Necromancy,Death magic",
                    HomePlane= "Dominaria",
                    Colors= "Black"
                  }
            };

            if(sortBy == null || sortAsc == null)
            {
                this.Characters = characters;
                return;
            }


            if(sortBy!.ToLower() == "name" && sortAsc!.ToLower() == "true")
            {
                this.Characters = characters.OrderBy(a => a.Name).ToList();
            }
            else if (sortBy!.ToLower() == "name" && sortAsc!.ToLower() == "false")
            {
                this.Characters = characters.OrderByDescending(a => a.Name).ToList();
            }
            else if (sortBy!.ToLower() == "powers" && sortAsc!.ToLower() == "true")
            {
                this.Characters = characters.OrderBy(a => a.Powers).ToList();
            }
            else if (sortBy!.ToLower() == "powers" && sortAsc!.ToLower() == "false")
            {
                this.Characters = characters.OrderByDescending(a => a.Powers).ToList();
            }
            else if (sortBy!.ToLower() == "homeplane" && sortAsc!.ToLower() == "true")
            {
                this.Characters = characters.OrderBy(a => a.HomePlane).ToList();
            }
            else if (sortBy!.ToLower() == "homeplane" && sortAsc!.ToLower() == "false")
            {
                this.Characters = characters.OrderByDescending(a => a.HomePlane).ToList();
            }
            else if (sortBy!.ToLower() == "powers" && sortAsc!.ToLower() == "false")
            {
                this.Characters = characters.OrderByDescending(a => a.Powers).ToList();
            }
            else if (sortBy!.ToLower() == "colors" && sortAsc!.ToLower() == "true")
            {
                this.Characters = characters.OrderBy(a => a.Colors).ToList();
            }
            else if (sortBy!.ToLower() == "colors" && sortAsc!.ToLower() == "false")
            {
                this.Characters = characters.OrderByDescending(a => a.Colors).ToList();
            }
            else
            {
                this.Characters = characters;
            }
        }

        public class Character
        {
            public string? Name { get; set; }
            public string? Powers { get; set; }
            public string? HomePlane { get; set; }
            public string? Colors { get; set; }

        }
    }
}
