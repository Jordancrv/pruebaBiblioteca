using System;
using System.Collections.Generic;

namespace pruebaBiblioteca.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string Titulo { get; set; } = null!;

    public int AutorId { get; set; }

    public virtual Autor Autor { get; set; } = null!;

    public virtual ICollection<Editorial> Editorials { get; set; } = new List<Editorial>();

    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();
}
