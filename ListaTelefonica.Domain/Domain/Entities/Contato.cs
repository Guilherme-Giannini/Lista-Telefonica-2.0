namespace ListaTelefonica.Domain.Entities;

public class Contato
{
    public string? Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Telefone { get; set; } = default!;
    public string? Email { get; set; }
    public DateTime? DataNascimento { get; set; }
    public IEnumerable<string>? Enderecos { get; set; }
}