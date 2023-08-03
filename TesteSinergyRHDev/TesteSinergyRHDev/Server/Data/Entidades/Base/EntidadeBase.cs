using System.ComponentModel.DataAnnotations;

namespace TesteSinergyRHDev.Server.Data.Entidades.Base
{
    public class EntidadeBase
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }        
        public DateTime? DataAlteracao { get; set; }
    }
}
