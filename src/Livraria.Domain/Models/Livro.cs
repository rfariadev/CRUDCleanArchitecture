namespace Livraria.Domain.Models;

public sealed class Livro {
  public int LivroId { get; set; }
  
  [Required, StringLength(80)]
  public string? Titulo { get; set; }
  
  [Required, StringLength(80)]
  public string? Autor { get; set; }
  
  public DateTime Lancamento { get; set; }
  
  [Required, StringLength(200)]
  public string? Capa { get; set; }
  
  [Required, EnumDataType(typeof(Editora))]
  public Editora Editora { get; set; }
  
  [Required, EnumDataType(typeof(Categoria))]
  public Categoria Categoria { get; set; }

  public Livro(int livroId, string titulo, string autor, DateTime lancamento, string capa, Editora editora, Categoria categoria) {
    LivroId = livroId;
    Titulo = titulo;
    Autor = autor;
    Lancamento = lancamento;
    Capa = capa;
    Editora = editora;
    Categoria = categoria;
  }
}

public enum Categoria {
  Informática = 1,
  Ficção,
  Drama,
  Humor,
  Religião,
  Aventura,
  Nenhuma
}

public enum Editora {
  Pearson = 1,
  Record,
  Bertelsmann,
  Rocco,
  Globo,
  Planeta,
  ThomsonReuters,
  Nenhuma
}