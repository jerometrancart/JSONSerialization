using System;

namespace ExoJsonSerializer
{
    public class Livre
    {

        ///ATTRIBUTS POSSIBLES POUR INCLURE UNE PROP OU UN MEMBRE OU L'IGNORER DANS LE JSON. PAR DEFAUT, SEULS LES PROP PUBLIQUES SERONT SERIALISEES
        // [JsonInclude]
        // [JsonIgnore]
        // ///DEFINIT LE NOM DE LA PROP DANS LE FLUX JSON
        // [JsonPropertyName("Nom")]
        // ///INFO SUPPLEMENTAIRES
        // [JsonExtensionData] 
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public int NbPages { get; set; }
        public string ISBN { get; set; }
    }
}

