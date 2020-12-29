using System;

namespace Project.Core.Filters
{
    public class ProjetoFilterBase : Common.Domain.Base.FilterBase
    {
        public int ProjetoId { get; set; } 
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public DateTime DataInicioStart { get; set; } 
        public DateTime DataInicioEnd { get; set; } 
        public DateTime DataInicio { get; set; } 
        public DateTime? DataFimStart { get; set; } 
        public DateTime? DataFimEnd { get; set; } 
        public DateTime? DataFim { get; set; } 
        public int EnderecoId { get; set; } 
        public int UsuarioId { get; set; } 
        public string Foto { get; set; } 

    }
}
