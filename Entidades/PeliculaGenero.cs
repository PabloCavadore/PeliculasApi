﻿namespace PeliculasAPI.Entidades
{
    public class PeliculaGenero
    {
        public int PeliculaId { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; } = null!;
        public Pelicula Pelicula { get; set; } = null!;
    }
}
