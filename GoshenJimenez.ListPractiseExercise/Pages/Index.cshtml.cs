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

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }


        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true")
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword
                };
            }

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

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                this.Characters = characters;
                return;
            }

            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {

                if (SearchParams.SearchBy.ToLower() == "name")
                {
                    characters = characters.Where(a => a.Name != null && a.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "powers")
                {
                    characters = characters.Where(a => a.Powers != null && a.Powers.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "homeplane")
                {
                    characters = characters.Where(a => a.HomePlane != null && a.HomePlane.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "colors")
                {
                    characters = characters.Where(a => a.Colors != null && a.Colors.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
            }
            else if ((string.IsNullOrEmpty(SearchParams.SearchBy) || SearchParams.SearchBy == "") && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                characters = characters.Where(a => a.Name != null && a.Name.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if(SearchParams.SortBy!.ToLower() == "name" && SearchParams.SortAsc == true)
            {
                this.Characters = characters.OrderBy(a => a.Name).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "name" && SearchParams.SortAsc == false)
            {
                this.Characters = characters.OrderByDescending(a => a.Name).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "powers" && SearchParams.SortAsc == true)
            {
                this.Characters = characters.OrderBy(a => a.Powers).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "powers" && SearchParams.SortAsc == false)
            {
                this.Characters = characters.OrderByDescending(a => a.Powers).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "homeplane" && SearchParams.SortAsc == true)
            {
                this.Characters = characters.OrderBy(a => a.HomePlane).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "homeplane" && SearchParams.SortAsc == false)
            {
                this.Characters = characters.OrderByDescending(a => a.HomePlane).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "powers" && SearchParams.SortAsc == false)
            {
                this.Characters = characters.OrderByDescending(a => a.Powers).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "colors" && SearchParams.SortAsc == true)
            {
                this.Characters = characters.OrderBy(a => a.Colors).ToList();
            }
            else if (SearchParams.SortBy!.ToLower() == "colors" && SearchParams.SortAsc == false)
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


        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }            
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; } 
        }
    }
}
