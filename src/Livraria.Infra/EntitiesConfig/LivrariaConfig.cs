namespace Livraria.Infra.EntitiesConfig;

public class LivrariaConfig : IEntityTypeConfiguration<Livro> {
  public void Configure(EntityTypeBuilder<Livro> builder) {
    builder.HasKey(t => t.LivroId);
    builder.Property(p => p.Titulo).HasMaxLength(150).IsRequired();
    builder.Property(p => p.Autor).HasMaxLength(200).IsRequired();
    builder.Property(p => p.Lancamento).IsRequired();
    builder.Property(p => p.Capa).HasMaxLength(200);
  }
}