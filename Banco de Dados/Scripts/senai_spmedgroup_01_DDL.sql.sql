--Criação Banco de Dados SPMEDICALGROUP_Livia
CREATE DATABASE SPMEDICALGROUP_Livia;
GO

--Utilizando Banco de Dados SPMEDICALGROUP_Livia
USE SPMEDICALGROUP_Livia;
GO

--Criação Tabela Tipo de Usuário
CREATE TABLE TipoUsuario(
   IdTipoUsuario INT PRIMARY KEY IDENTITY(1,1),
   TipoUsuario VARCHAR(20) NOT NULL UNIQUE
);
GO

--Criação Tabela Usuário
CREATE TABLE Usuario(
   IdUsuario INT PRIMARY KEY IDENTITY(1,1),
   IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
   Email VARCHAR(200) NOT NULL UNIQUE,
   Senha VARCHAR(20) NOT NULL 
);
GO

--Criação Tabela Endereco
CREATE TABLE Endereco(
   IdEndereco INT PRIMARY KEY IDENTITY(1,1),
   Logadouro VARCHAR(70) NOT NULL,
   Numero SMALLINT NOT NULL,
   Bairro VARCHAR(50) NOT NULL,
   Municipio VARCHAR(50) NOT NULL,
   Estado VARCHAR(50) NOT NULL,
   Cep INT NOT NULL
);
GO

--Criação Tabela Clinica
CREATE TABLE Clinica(
   IdClinica INT PRIMARY KEY IDENTITY(1,1),
   IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco),
   HorarioFuncionamento TIME NOT NULL,
   Cnpj INT NOT NULL UNIQUE,
   NomeFantasia VARCHAR(70) NOT NULL,
   RazaoSocial  VARCHAR(70) NOT NULL
);
GO

--Criação Tabela Especialidade
CREATE TABLE Especialidade(
   IdEspecialidade INT PRIMARY KEY IDENTITY(1,1),
   Especialidade VARCHAR(50) NOT NULL
);
GO

--Criação Tabela Paciente
CREATE TABLE Paciente(
   IdPaciente INT PRIMARY KEY IDENTITY(1,1),
   IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
   IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco),
   Nome VARCHAR(70) NOT NULL,
   DataNascimento DATE NOT NULL,
   Telefone INT,
   Rg INT NOT NULL UNIQUE,
   Cpf INT NOT NULL UNIQUE
);
GO

--Criação Tabela Medico
CREATE TABLE Medico(
   IdMedico INT PRIMARY KEY IDENTITY(1,1),
   IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
   IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
   IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
   Crm INT NOT NULL UNIQUE,
   Nome VARCHAR(70) NOT NULL
);
GO

--Criação Tabela Situacao
CREATE TABLE Situacao(
   IdSituacao INT PRIMARY KEY IDENTITY(1,1),
   TipoSituacao VARCHAR(30) NOT NULL
);
GO

--Criação Tabela Consulta
CREATE TABLE Consulta(
   IdConsulta INT PRIMARY KEY IDENTITY(1,1),
   IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
   IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
   IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
   [Data] DATE NOT NULL,
   Hora TIME NOT NULL
);
GO



-----------Arrumando Erros-----------

--Excluindo Tabelas
DROP TABLE Medico;
DROP TABLE Consulta;
DROP TABLE Clinica;
DROP TABLE Paciente;

--Criação Tabela Clinica Arrumada
CREATE TABLE Clinica(
   IdClinica INT PRIMARY KEY IDENTITY(1,1),
   IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco),
   HorarioInicio TIME NOT NULL,
   HorarioFim TIME NOT NULL,
   Cnpj CHAR(60) NOT NULL UNIQUE,
   NomeFantasia VARCHAR(70) NOT NULL,
   RazaoSocial  VARCHAR(70) NOT NULL
);
GO

--Criação Tabela Medico Arrumada
CREATE TABLE Medico(
   IdMedico INT PRIMARY KEY IDENTITY(1,1),
   IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
   IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
   IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
   Crm VARCHAR(50) NOT NULL UNIQUE,
   Nome VARCHAR(70) NOT NULL
);
GO

--Criação Tabela Consulta Arrumada
CREATE TABLE Consulta(
   IdConsulta INT PRIMARY KEY IDENTITY(1,1),
   IdPaciente INT FOREIGN KEY REFERENCES Paciente(IdPaciente),
   IdMedico INT FOREIGN KEY REFERENCES Medico(IdMedico),
   IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
   DataCon DATE NOT NULL,
   Hora TIME NOT NULL
);
GO

--Criação Tabela Paciente Arrumada
CREATE TABLE Paciente(
   IdPaciente INT PRIMARY KEY IDENTITY(1,1),
   IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
   IdEndereco INT FOREIGN KEY REFERENCES Endereco(IdEndereco),
   Nome VARCHAR(70) NOT NULL,
   DataNascimento DATE NOT NULL,
   Telefone CHAR(11) DEFAULT 'NÃO IDENTIFICADO',
   Rg INT NOT NULL UNIQUE,
   Cpf CHAR(11) NOT NULL UNIQUE
);
GO




