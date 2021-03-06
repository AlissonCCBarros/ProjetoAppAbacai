CREATE DATABASE [ProjectAbacai]

USE [ProjectAbacai]
GO

CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Admin] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atividade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[OdsId] [int] NOT NULL,
	[HabilidadeId] [int] NOT NULL,
 CONSTRAINT [PK__Atividad__3214EC07EC1DF416] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CEP] [varchar](9) NOT NULL,
	[Rua] [varchar](255) NOT NULL,
	[Numero] [int] NOT NULL,
	[Bairro] [varchar](255) NOT NULL,
	[Cidade] [varchar](255) NOT NULL,
	[Estado] [varchar](2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habilidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ProjetoAtividadeId] [int] NOT NULL,
	[Aceito] [bit] NOT NULL,
	[Ativo] [bit] NOT NULL,
	[EhNotificado] [bit] NOT NULL,
	[DataMatch] [datetime] NULL,
	[DataAceito] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notificacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](255) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[UsuarioId] [int] NULL,
	[EhNotificado] [bit] NOT NULL,
	[EhAceito] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[ImageName] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projeto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Descricao] [varchar](255) NOT NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NULL,
	[EnderecoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[Foto] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjetoAtividade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProjetoId] [int] NOT NULL,
	[AtividadeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Apelido] [varchar](255) NULL,
	[CPF_CNPJ] [varchar](14) NOT NULL,
	[IE_RG] [varchar](60) NULL,
	[Telefone] [varchar](20) NULL,
	[Celular] [varchar](20) NULL,
	[Email] [varchar](255) NOT NULL,
	[UserCreateDate] [datetime] NULL,
	[UserAlterDate] [datetime] NULL,
	[EnderecoId] [int] NULL,
	[EhInstituicao] [bit] NOT NULL,
	[Foto] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioHabilidade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[HabilidadeId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioProjetoAtividade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[ProjetoAtividadeId] [int] NOT NULL,
	[Avaliacao] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atividade]  WITH CHECK ADD  CONSTRAINT [FK_Atividade_Habilidade] FOREIGN KEY([HabilidadeId])
REFERENCES [dbo].[Habilidade] ([Id])
GO
ALTER TABLE [dbo].[Atividade] CHECK CONSTRAINT [FK_Atividade_Habilidade]
GO
ALTER TABLE [dbo].[Atividade]  WITH CHECK ADD  CONSTRAINT [FK_Atividade_Ods] FOREIGN KEY([OdsId])
REFERENCES [dbo].[Ods] ([Id])
GO
ALTER TABLE [dbo].[Atividade] CHECK CONSTRAINT [FK_Atividade_Ods]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_MatchProjetoAtividade] FOREIGN KEY([ProjetoAtividadeId])
REFERENCES [dbo].[ProjetoAtividade] ([Id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_MatchProjetoAtividade]
GO
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_MatchUsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_MatchUsuarioId]
GO
ALTER TABLE [dbo].[Notificacao]  WITH CHECK ADD  CONSTRAINT [FK_NotificacaoUsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Notificacao] CHECK CONSTRAINT [FK_NotificacaoUsuarioId]
GO
ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_ProjetoEnderecoId] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_ProjetoEnderecoId]
GO
ALTER TABLE [dbo].[Projeto]  WITH CHECK ADD  CONSTRAINT [FK_ProjetoUsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Projeto] CHECK CONSTRAINT [FK_ProjetoUsuarioId]
GO
ALTER TABLE [dbo].[ProjetoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_AtividadeProjetoId] FOREIGN KEY([ProjetoId])
REFERENCES [dbo].[Projeto] ([Id])
GO
ALTER TABLE [dbo].[ProjetoAtividade] CHECK CONSTRAINT [FK_AtividadeProjetoId]
GO
ALTER TABLE [dbo].[ProjetoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_ProjetoAtividadeId] FOREIGN KEY([AtividadeId])
REFERENCES [dbo].[Atividade] ([Id])
GO
ALTER TABLE [dbo].[ProjetoAtividade] CHECK CONSTRAINT [FK_ProjetoAtividadeId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_EnderecoId] FOREIGN KEY([EnderecoId])
REFERENCES [dbo].[Endereco] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_EnderecoId]
GO
ALTER TABLE [dbo].[UsuarioHabilidade]  WITH CHECK ADD  CONSTRAINT [FK_HabilidadeId] FOREIGN KEY([HabilidadeId])
REFERENCES [dbo].[Habilidade] ([Id])
GO
ALTER TABLE [dbo].[UsuarioHabilidade] CHECK CONSTRAINT [FK_HabilidadeId]
GO
ALTER TABLE [dbo].[UsuarioHabilidade]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioHabilidade] CHECK CONSTRAINT [FK_UsuarioId]
GO
ALTER TABLE [dbo].[UsuarioProjetoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProjetoAtividade_ProjetoAtividade] FOREIGN KEY([ProjetoAtividadeId])
REFERENCES [dbo].[ProjetoAtividade] ([Id])
GO
ALTER TABLE [dbo].[UsuarioProjetoAtividade] CHECK CONSTRAINT [FK_UsuarioProjetoAtividade_ProjetoAtividade]
GO
ALTER TABLE [dbo].[UsuarioProjetoAtividade]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioProjetoAtividadeUsuarioId] FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[UsuarioProjetoAtividade] CHECK CONSTRAINT [FK_UsuarioProjetoAtividadeUsuarioId]
GO
USE [master]
GO
ALTER DATABASE [ProjectAbacai] SET  READ_WRITE 
GO
