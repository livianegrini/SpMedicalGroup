--Utilizando Banco de Dados SPMEDICALGROUP_Livia
USE SPMEDICALGROUP_Livia;
GO


--Selecionando Tabelas para Visualização.
SELECT * FROM TipoUsuario
SELECT * FROM Usuario
SELECT * FROM Paciente
SELECT * FROM Medico
SELECT * FROM Endereco
SELECT * FROM Especialidade
SELECT * FROM Clinica
SELECT * FROM Situacao
SELECT * FROM Consulta


--Inserindo Valores na Tabela TipoUsuario e Selecionando para Visualização.
INSERT INTO TipoUsuario(TipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente')
SELECT * FROM TipoUsuario

--Inserindo Valores na Tabela Usuario e Selecionando para Visualização.
INSERT INTO Usuario(IdTipoUsuario,Email,Senha)
VALUES (1,'adm@gmail.com',123),
       (1,'admn@gmail.com',345),
	   (2,'ricardo.lemos@spmedicalgroup.com.br',567),
	   (2,'roberto.possarle@spmedicalgroup.com.br',789),
	   (2,'helena.souza@spmedicalgroup.com.br',910),
	   (3,'ligia@gmail.com',101),
	   (3,'alexandre@gmail.com',102),
	   (3,'fernando@gmail.com',103),
	   (3,'henrique@gmail.com',104),
	   (3,'joao@hotmail.com',105),
	   (3,'bruno@gmail.com',106),
	   (3,'mariana@outlook.com',107)

SELECT * FROM Usuario


--Inserindo Valores na Tabela Endereco e Selecionando para Visualização.
INSERT INTO Endereco(Logadouro,Numero,Bairro,Municipio,Estado,Cep)
VALUES ('Av. Barão Limeira',532,'Campos Elíseos','São Paulo', 'São Paulo',01202001),
       ('Rua Estado de Israel',240,'Vila Mariana','São Paulo','São Paulo',04022000),
	   ('Av. Paulista',1578,'Bela Vista','São Paulo','São Paulo',01310200),
	   ('Av. Ibirapuera',2927,'Indianópolis','São Paulo','São Paulo',04029200),
	   ('Rua Vitória',120,'Vila Sao Jorge','Barueri','São Paulo',06402030),
	   ('Rua Ver. Geraldo de Camargo',66,'Santa Luzia','Ribeirão Pires','São Paulo',09405380),
	   ('Alameda dos Arapanés',945,'Indianópolis','São Paulo','São Paulo',04524001),
	   ('Rua Sao Antonio',232,'Vila Universal','Barueri','São Paulo',06407140)
SELECT * FROM Endereco


--Inserindo Valores na Tabela Clinica e Selecionando para Visualização.
INSERT INTO Clinica(IdEndereco,HorarioInicio,HorarioFim,Cnpj,NomeFantasia,RazaoSocial)
VALUES (1,'08:00','19:00','86400902000130','Clinica Possarle','SP Medical Group')
SELECT * FROM Clinica


--Inserindo Valores na Tabela Especialidade e Selecionando para Visualização.
INSERT INTO Especialidade(Especialidade)
VALUES ('Acupuntura'),
       ('Anestesiologia'),
	   ('Angiologia'),
	   ('Cardiologia'),
	   ('Cirurgia Cardiovascular'),
	   ('Cirurgia da Mão'),
	   ('Cirurgia do Aparelho Digestivo'),
	   ('Cirurgia Geral'),
	   ('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'),
	   ('Cirurgia Torácica'),
	   ('Cirurgia Vascular'),
	   ('Dermatologia'),
	   ('Radioterapia'),
	   ('Urologia'),
	   ('Pediatria'),
	   ('Psiquiatria')
SELECT * FROM Especialidade

--Selecionando Tabelas para Visualização.
SELECT * FROM Usuario
SELECT * FROM Endereco

--Inserindo Valores na Tabela Paciente e Selecionando para Visualização.
INSERT INTO Paciente(IdUsuario,IdEndereco,Nome,DataNascimento,Telefone,Rg,Cpf)
VALUES (6,2,'Ligia','13/10/1983','1134567654',432124576,94839859000),
       (7,3,'Alexandre','23/07/2001','11987656543',326543457,'73556944057'),
	   (8,4,'Fernando','10/10/1978','11972084453',546365253,'16839338002'),
	   (9,5,'Henrique','13/10/1985','1134566543',543663625,'14332654765'),
	   (10,6,'João','27/08/1975','1176566377',532544441,'91305348010'),
	   (11,7,'Bruno','21/03/1972','11954368769',545662667,'79799299004'),
	   (12,8,'Mariana','05/03/2018',NULL,545662668,'13771913039')
SELECT * FROM Paciente

--Selecionando Tabelas para Visualização.
SELECT * FROM Usuario
SELECT * FROM Endereco
SELECT * FROM Especialidade
SELECT * FROM Clinica

--Inserindo Valores na Tabela Medico e Selecionando para Visualização.
INSERT INTO Medico(IdUsuario,IdClinica,IdEspecialidade,Crm,Nome)
VALUES (3,1,2,'54356-SP','Ricardo Lemos'),
       (4,1,17,'53452-SP','Roberto Possarle'),
	   (5,1,16,'65463-SP','Helena Strada')
SELECT * FROM Medico


--Inserindo Valores na Tabela Situacao e Selecionando para Visualização.
INSERT INTO Situacao(TipoSituacao)
VALUES ('Realizada'),
       ('Agendada'),
       ('Cancelada')
SELECT * FROM Situacao

--Selecionando Tabelas para Visualização.
SELECT * FROM Paciente
SELECT * FROM Medico
SELECT * FROM Situacao

--Inserindo Valores na Tabela Consulta e Selecionando para Visualização.
INSERT INTO Consulta(IdPaciente,IdMedico,IdSituacao,DataCon,Hora)
VALUES (1,3,1,'20/01/2020','15:00'),
       (2,2,3,'06/01/2020 ','10:00'),
	   (3,2,1,'07/02/2020','11:00'),
	   (4,2,1,'06/02/2018','10:00'),
	   (5,1,3,'07/02/2019','11:00'),
	   (6,3,2,'08/03/2020','15:00'),
	   (7,1,2,'09/03/2020','11:00')
SELECT * FROM Consulta