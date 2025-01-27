namespace FluentMappingApi.Models
{
    public class Tecnico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public int StatusAtivoInativoId { get; set; }

        // Relação com a tabela StatusAtivoInativo
        public StatusAtivoInativo StatusAtivoInativo { get; set; }
    }
}
