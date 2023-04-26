using System.Text;
using System.Text.Json;

///OUVRE UN FLUX MEMOIRE
using var memStream = new MemoryStream();
using var writer = new Utf8JsonWriter(memStream, new JsonWriterOptions
{
    Indented = true
});

writer.WriteStartObject();

writer.WritePropertyName("prenom");
writer.WriteStringValue("Jerome");

writer.WritePropertyName("nom");
writer.WriteStringValue("TRANCART");

writer.WritePropertyName("age");
writer.WriteNumberValue(33);

writer.WriteEndObject();

///ECRIT DANS LE FLUX MEMOIRE
writer.Flush();

///REPLACE LE CURSEUR EN POSITION 0 DANS LE FLUX MEMOIRE
memStream.Position = 0;
///CONVERTIT LES BYTES DU FLUX MEMOIRE EN TABLEAU DE BYTES PUIS EN STRING UTF8 DECODé
System.Console.WriteLine(Encoding.UTF8.GetString(memStream.ToArray()));

