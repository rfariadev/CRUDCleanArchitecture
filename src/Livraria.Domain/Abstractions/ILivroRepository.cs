namespace Livraria.Domain;

public interface ILivroRepository {
  Task<IEnumerable<Livro>> ObterLivros();
  Task<Livro?> ObterLivro(int id);
  Task<Livro> AdicionarLivro(Livro livro);
  Task AtualizarLivro(Livro livro);
  Task DeletarLivro(int id);
}
