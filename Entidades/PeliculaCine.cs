namespace PeliculasAPI.Entidades
{
    public class PeliculaCine
    {
        public int CineId { get; set; }
        public int PeliculaId { get; set; }
        public Cine cine { get; set; } = null!;
        public Pelicula Pelicula { get; set; } = null!;
    }
}
