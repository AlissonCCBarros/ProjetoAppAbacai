using Project.Core.Dto;
using Project.Core.Data.Model;

namespace Project.Core.Services.Config
{
    public class ModelToDtoCoreBase : AutoMapper.Profile
    {

        public ModelToDtoCoreBase()
        {
            CreateMap(typeof(Account), typeof(AccountDto)).ReverseMap();
            CreateMap(typeof(Account), typeof(AccountDtoSave)).ReverseMap();
            CreateMap(typeof(Account), typeof(AccountDtoResult)).ReverseMap();
            CreateMap(typeof(Account), typeof(AccountDtoDetail)).ReverseMap();
            CreateMap(typeof(Usuario), typeof(UsuarioDto)).ReverseMap();
            CreateMap(typeof(Usuario), typeof(UsuarioDtoSave)).ReverseMap();
            CreateMap(typeof(Usuario), typeof(UsuarioDtoResult)).ReverseMap();
            CreateMap(typeof(Usuario), typeof(UsuarioDtoDetail)).ReverseMap();
            CreateMap(typeof(Ods), typeof(OdsDto)).ReverseMap();
            CreateMap(typeof(Ods), typeof(OdsDtoSave)).ReverseMap();
            CreateMap(typeof(Ods), typeof(OdsDtoResult)).ReverseMap();
            CreateMap(typeof(Ods), typeof(OdsDtoDetail)).ReverseMap();
            CreateMap(typeof(Projeto), typeof(ProjetoDto)).ReverseMap();
            CreateMap(typeof(Projeto), typeof(ProjetoDtoSave)).ReverseMap();
            CreateMap(typeof(Projeto), typeof(ProjetoDtoResult)).ReverseMap();
            CreateMap(typeof(Projeto), typeof(ProjetoDtoDetail)).ReverseMap();
            CreateMap(typeof(Atividade), typeof(AtividadeDto)).ReverseMap();
            CreateMap(typeof(Atividade), typeof(AtividadeDtoSave)).ReverseMap();
            CreateMap(typeof(Atividade), typeof(AtividadeDtoResult)).ReverseMap();
            CreateMap(typeof(Atividade), typeof(AtividadeDtoDetail)).ReverseMap();
            CreateMap(typeof(ProjetoAtividade), typeof(ProjetoAtividadeDto)).ReverseMap();
            CreateMap(typeof(ProjetoAtividade), typeof(ProjetoAtividadeDtoSave)).ReverseMap();
            CreateMap(typeof(ProjetoAtividade), typeof(ProjetoAtividadeDtoResult)).ReverseMap();
            CreateMap(typeof(ProjetoAtividade), typeof(ProjetoAtividadeDtoDetail)).ReverseMap();
            CreateMap(typeof(UsuarioProjetoAtividade), typeof(UsuarioProjetoAtividadeDto)).ReverseMap();
            CreateMap(typeof(UsuarioProjetoAtividade), typeof(UsuarioProjetoAtividadeDtoSave)).ReverseMap();
            CreateMap(typeof(UsuarioProjetoAtividade), typeof(UsuarioProjetoAtividadeDtoResult)).ReverseMap();
            CreateMap(typeof(UsuarioProjetoAtividade), typeof(UsuarioProjetoAtividadeDtoDetail)).ReverseMap();
            CreateMap(typeof(Endereco), typeof(EnderecoDto)).ReverseMap();
            CreateMap(typeof(Endereco), typeof(EnderecoDtoSave)).ReverseMap();
            CreateMap(typeof(Endereco), typeof(EnderecoDtoResult)).ReverseMap();
            CreateMap(typeof(Endereco), typeof(EnderecoDtoDetail)).ReverseMap();
            CreateMap(typeof(Match), typeof(MatchDto)).ReverseMap();
            CreateMap(typeof(Match), typeof(MatchDtoSave)).ReverseMap();
            CreateMap(typeof(Match), typeof(MatchDtoResult)).ReverseMap();
            CreateMap(typeof(Match), typeof(MatchDtoDetail)).ReverseMap();
            CreateMap(typeof(Notificacao), typeof(NotificacaoDto)).ReverseMap();
            CreateMap(typeof(Notificacao), typeof(NotificacaoDtoSave)).ReverseMap();
            CreateMap(typeof(Notificacao), typeof(NotificacaoDtoResult)).ReverseMap();
            CreateMap(typeof(Notificacao), typeof(NotificacaoDtoDetail)).ReverseMap();
            CreateMap(typeof(Habilidade), typeof(HabilidadeDto)).ReverseMap();
            CreateMap(typeof(Habilidade), typeof(HabilidadeDtoSave)).ReverseMap();
            CreateMap(typeof(Habilidade), typeof(HabilidadeDtoResult)).ReverseMap();
            CreateMap(typeof(Habilidade), typeof(HabilidadeDtoDetail)).ReverseMap();
            CreateMap(typeof(UsuarioHabilidade), typeof(UsuarioHabilidadeDto)).ReverseMap();
            CreateMap(typeof(UsuarioHabilidade), typeof(UsuarioHabilidadeDtoSave)).ReverseMap();
            CreateMap(typeof(UsuarioHabilidade), typeof(UsuarioHabilidadeDtoResult)).ReverseMap();
            CreateMap(typeof(UsuarioHabilidade), typeof(UsuarioHabilidadeDtoDetail)).ReverseMap();

        }

    }
}
