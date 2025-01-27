using System.ComponentModel.DataAnnotations.Schema;

namespace FluentMappingApi.Models
{
    [Table("StatusAtivoInativo")]
    public class StatusAtivoInativo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public IList<Tecnico> Tecnico { get; set; }
    }
}
                            