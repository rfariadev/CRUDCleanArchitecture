namespace Livraria.Infra.Repositories;

public class LivroRepository : ILivroRepository {

  private readonly AppDbContext _context;

  public LivroRepository(AppDbContext context) {
    _context = context;
  }

  public async Task<IEnumerable<Livro>> ObterLivros() {
    if (_context.Livros != null) {
      var livros = await _context.Livros.ToListAsync();
      return livros;
    } else {
      return new List<Livro>();
    }
  }

  public async Task<Livro?> ObterLivro(int id) {
    var livro = await _context.Livros.FirstOrDefaultAsync();
    if (livro is null)
      throw new InvalidOperationException($"Livro com ID {id} não encontrado!");

    return livro;
  }

  public async Task<Livro> AdicionarLivro(Livro livro) {
    _context.Livros?.Add(livro);
    await _context.SaveChangesAsync();

    return livro;
  }

  public async Task AtualizarLivro(Livro livro) {
    if (livro != null) {
      _context.Entry(livro).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    } else {
      throw new ArgumentNullException("Dados inválidos...");
    }
  }

  public async Task DeletarLivro(int id) {
    var livro = await ObterLivro(id);
    if (livro != null) {
      _context.Livros.Remove(livro);
      await _context.SaveChangesAsync();
    } else {
      throw new InvalidOperationException("Dados inválidos...");
    }
  }
}