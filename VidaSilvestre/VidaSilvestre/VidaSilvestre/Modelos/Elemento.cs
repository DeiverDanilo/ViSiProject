using Newtonsoft.Json;
using System.Collections.Generic;

namespace VidaSilvestre.Modelos
{
    public class Elemento
    {
		[JsonProperty("SpeciesSightingsUrl")]
		public string SpeciesSightingsUrl { get; set; }

        [JsonProperty("Species")]
        public Species Species { get; set; }
         
     
    }

    public class Species
    {
        [JsonProperty("ScientificName")]
        public string ScientificName { get; set; }

        [JsonProperty("ClassCommonName")]
        public string ClassCommonName { get; set; }

        public string AcceptedCommonName { get; set; }
        public string KingdomName { get; set; }
        public string KingdomCommonName { get; set; }
        public string ClassName { get; set; } 
        public string FamilyName { get; set; }
        public string FamilyCommonName { get; set; }
        public string FamilyRank { get; set; }
        public string IsSuperseded { get; set; }

        public Profile Profile { get; set; }

    }

    public class Profile
    {
        public string Distribution { get; set; }
        public List<Image> Image { get; set; }

    }


    public class Image
    {
        public string Type { get; set; }
        public string Format { get; set; }
        public string URL { get; set; }
    }
}