using System;

namespace ExoJsonSerializer
{
    public class VideoYoutube
    {
        public string Titre { get; set; }
        public int Duree { get; set; }
        public Youtubeur Youtubeur { get; set; }
        public List<string> Tags { get; set; }
    }
}
