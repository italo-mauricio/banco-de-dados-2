 
 #criação o banco

 CREATE DATABASE atividade_db
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;


-- Criação das Tabelas

CREATE TABLE funcionario (
	codigo serial,
	nome varchar(150),
	sexo char(1),
	dt_nasc date,
	salario money,
	supervisor int,
	depto int,
	PRIMARY KEY (codigo),
	FOREIGN KEY (supervisor) REFERENCES funcionario(codigo) on delete set null on update cascade
);

CREATE TABLE departamento (
	codigo serial,
    nome varchar(100),
	sigla varchar(10) unique,
	descricao varchar(250),
	gerente int,
	PRIMARY KEY (codigo),
	FOREIGN KEY (gerente) REFERENCES funcionario(codigo) on delete set null on update cascade
);

-- add foreign key de funcionario
alter table funcionario ADD CONSTRAINT funcDeptoFK FOREIGN KEY (depto) REFERENCES departamento(codigo) on delete set null on update cascade;

CREATE TABLE projeto (
	codigo serial,
	nome varchar(50) unique,
	descricao varchar(250),
	responsavel int,
	depto int,
	data_inicio date,
	data_fim date,
	PRIMARY KEY (codigo),
	FOREIGN KEY (responsavel) REFERENCES funcionario(codigo) on delete set null on update cascade,
	FOREIGN KEY (depto) REFERENCES departamento(codigo) on delete set null on update cascade
);

CREATE TABLE atividade (
	codigo serial,
	descricao varchar(250),
	projeto int,
	data_inicio date,
	data_fim date,
	PRIMARY KEY (codigo),
	FOREIGN KEY (projeto) REFERENCES projeto(codigo) on delete set null on update cascade
);