using System.ComponentModel.DataAnnotations.Schema;

namespace FluentMappingApi.Models
{
    [Table("Tipo")]
    public class Tipo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}
