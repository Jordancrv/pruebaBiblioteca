using System;
using System.Collections.Generic;

namespace pruebaBiblioteca.Models;

public partial class Editorial
{
    public int EditorialId { get; set; }

    public string Nombre { get; set; } = null!;

    public int LibroId { get; set; }

    public virtual Libro Libro { get; set; } = null!;
}
