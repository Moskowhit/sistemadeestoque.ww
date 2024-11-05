CREATE DATABASE BD_Floricultura
GO


USE [BD_Floricultura]
GO

CREATE TABLE [dbo].[funcionarios](
	[id_func] [int] IDENTITY(1,1) NOT NULL,
	[nome_func] [varchar](50) NOT NULL,
	[rg_func] [varchar](14) NOT NULL,
	[cpf_func] [varchar](11) NOT NULL,
	[nome_user] [varchar](20) NOT NULL,
	[senha_user] [varchar](60) NOT NULL,
 CONSTRAINT [PK_funcionarios] PRIMARY KEY CLUSTERED 
(
	[id_func] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO funcionarios VALUES ('IRMÃO DO JOREL', '1234567','9876543-45','JOREL1', 'SENHA')

create table dbo.produto(
	[codbar_prod] [int] IDENTITY(1,1) NOT NULL,
	[nome_prod] [varchar](50) NOT NULL,
	[categoria] [varchar](14) NOT NULL,
	[preco] [float] NOT NULL,
	[medida] [varchar](20) NOT NULL,
	[quant] [int] NOT NULL,
 CONSTRAINT [PK_produtos] PRIMARY KEY CLUSTERED (
	[codbar_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


insert into produto (nome_prod,categoria,preco,medida,quant) values ('BOQUE DE ROSA AMARELA','ROSA',25.00,'DUZIA',2);

update produto set 	
				nome_prod = objProd.Nome_prod
				categoria = objProd.CATEGORIA
				preco = objProd.Preco
				medida = objProd.Medida
				quant = objProd.QUANT

				SELECT* FROM funcionarios
				SELECT* FROM produto


			 update dbo.produto set nome_prod = 'AMARELA'     
                                       WHERE codbar_prod = 1;