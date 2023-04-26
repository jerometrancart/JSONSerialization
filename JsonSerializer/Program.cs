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
    PropertyNameCaseInsensitive = false,
    ///PROFONDEUR, NE PAS TOUCHER SAUF SI AU DELA DE 64
    /// MaxDepth = 2,
    ///GESTION DES REF CYCLIQUES (A GERER A LA RECEPTION)
    ReferenceHandler = ReferenceHandler.Preserve,
    ///GESTION DES ACCENTS
    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
});

System.Console.WriteLine(json);

