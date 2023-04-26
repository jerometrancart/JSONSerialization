using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using ExoJsonSerializer;

var youtubeur = new Youtubeur
{
    Nom = "OLivry",
    Prenom = "Germain",
    TitreChaine = "Dr Nozman",
};
var videos = new List<VideoYoutube>
    {
        new VideoYoutube { Titre = "Voyage à St Malo", Duree = 467, Tags = new List<string>{ "Voyage", "France"}, Youtubeur = youtubeur },
        new VideoYoutube { Titre = "Ma nouvelle voiture !!!", Duree = 235, Tags = new List<string>{ "Voiture"}, Youtubeur = youtubeur },
        new VideoYoutube { Titre = "Ma recette de la crème au chocolat", Duree = 665, Youtubeur = youtubeur },
    };

youtubeur.Videos = videos;


var json = JsonSerializer.Serialize(youtubeur, new JsonSerializerOptions

{
    ///INDENTATION
    WriteIndented = true,
    ///SENSIBILITE A LA CASSE
    PropertyNameCaseInsensitive = true,
    ///PROFONDEUR, NE PAS TOUCHER SAUF SI AU DELA DE 64
    /// MaxDepth = 2,
    ///GESTION DES REF CYCLIQUES (A GERER A LA RECEPTION)
    ReferenceHandler = ReferenceHandler.Preserve,
    ///GESTION DES ACCENTS
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
});

/// System.Console.WriteLine(json);

///ATTENTION AUX COLLECTIONS!
string jsonData = @"
[
    {
        ""titre"": ""Harry Potter, I : Harry Potter à l'école des sorciers"",
        ""auteur"": ""J.K. Rowling"",
        ""nbPages"": 320,
        ""ISBN"": ""2070584623""
    },
    {
        ""titre"": ""Harry Potter, II : Harry Potter et la Chambre des Secrets"",
        ""auteur"": ""J.K. Rowling"",
        ""nbPages"": 368,
        ""ISBN"": ""207058464X""
    },
    {
        ""titre"": ""Harry Potter, III : Harry Potter et le prisonnier d'Azkaban"",
        ""auteur"": ""J.K. Rowling"",
        ""nbPages"": 448,
        ""ISBN"": ""2070584925""
    }
]
";
 
List<Livre>? livres = JsonSerializer.Deserialize<List<Livre>>(jsonData, new JsonSerializerOptions
{
    ///ATTENTION A LA CASSE POUR LES PROPS
    PropertyNameCaseInsensitive = true
});

if(livres is not null)
{
    foreach(var livre in livres)
    {
        System.Console.WriteLine($"Ce livre s'appelle {livre.Titre}, il a été écrit par {livre.Auteur} et contient {livre.NbPages} pages, son numéro de série est le {livre.ISBN}.");
    }
}
