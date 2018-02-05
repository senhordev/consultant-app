/*
	Script de criação das tabelas
	
	
	Sessão: Create tables
*/

CREATE TABLE Apontamentos (
  idApontamento INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idAtividade INTEGER UNSIGNED NOT NULL,
  idConsultor INTEGER UNSIGNED NULL,
  datInicio DATETIME NULL,
  datFim DATETIME NULL,
  datRegistro DATETIME NULL,
  desRegistro VARCHAR(200) NULL,
  PRIMARY KEY(idApontamento)
);
 
CREATE TABLE ApontamentosFatura (
  idApontamentoFatura INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idApontamento INTEGER UNSIGNED NOT NULL,
  idFatura INTEGER UNSIGNED NOT NULL,
  numValorApontamento DOUBLE NULL,
  datRegistro INTEGER UNSIGNED NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idApontamentoFatura) 
);

CREATE TABLE Atividades (
  idAtividade INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idProjeto INTEGER UNSIGNED NOT NULL,
  desTitulo VARCHAR(50) NULL,
  desAtividade VARCHAR(500) NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idAtividade)
 );

CREATE TABLE Avaliacao (
  idAvaliacao INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idConsultor INTEGER UNSIGNED NOT NULL,
  idCliente INTEGER UNSIGNED NULL,
  desAvaliacao VARCHAR(200) NULL,
  numRating INTEGER UNSIGNED NULL,
  datRegistro INTEGER UNSIGNED NULL,
  datAlteracao INTEGER UNSIGNED NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idAvaliacao)
);

CREATE TABLE Clientes (
  idCliente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  desCliente INTEGER UNSIGNED NULL,
  numCnpj INTEGER UNSIGNED NULL,
  datRegistro DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  datAlteracao DATETIME NULL,
  PRIMARY KEY(idCliente)
);

CREATE TABLE ClientesUsuarios (
  idCliente INTEGER UNSIGNED NOT NULL,
  idUsuarioCliente INTEGER UNSIGNED NOT NULL,
  datRegistro DATETIME NULL,
  idUsuarios INTEGER UNSIGNED NULL,
  PRIMARY KEY(idCliente, idUsuario)
 );


CREATE TABLE Consultores (
  idConsultor INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  desConsultor INTEGER UNSIGNED NULL,
  idUsuario INTEGER UNSIGNED NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  PRIMARY KEY(idConsultor)
);

CREATE TABLE ConsultoresHabilidades (
  idConsultor INTEGER UNSIGNED NOT NULL,
  idHabilidades INTEGER UNSIGNED NOT NULL,
  datRegistro DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idConsultor, idHabilidades)
);

CREATE TABLE ConsultoresUsuarios (
  idConsultor INTEGER UNSIGNED NOT NULL,
  idUsuarioConsultor INTEGER UNSIGNED NOT NULL,
  datRegistro DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idConsultor, idUsuario)
);

CREATE TABLE FATURAS (
  idFatura INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idConsultor INTEGER UNSIGNED NOT NULL,
  idProjeto INTEGER UNSIGNED NOT NULL,
  idCliente INTEGER UNSIGNED NOT NULL,
  numValorTotal DOUBLE NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  sitFatura VARCHAR(1) NULL
  PRIMARY KEY(idFatura)
 );

CREATE TABLE Gerentes (
  idGerente INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  desGerente VARCHAR(100) NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idGerente)
);

CREATE TABLE GerentesUsuarios (
  idGerente INTEGER UNSIGNED NOT NULL,
  idUsuarioGerente INTEGER UNSIGNED NOT NULL,
  datRegistro DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idGerente, idUsuario)
 );

CREATE TABLE Habilidades (
  idHabilidades INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  desHabilidade INTEGER UNSIGNED NULL,
  datRegistro DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idHabilidades)
);

CREATE TABLE Precos (
  idPreco INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idConsultor INTEGER UNSIGNED NOT NULL,
  numValorHora DOUBLE NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  PRIMARY KEY(idPreco)
);

CREATE TABLE Projetos (
  idProjeto INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  idConsultor INTEGER UNSIGNED NOT NULL,
  idGerente INTEGER UNSIGNED NOT NULL,
  idCliente INTEGER UNSIGNED NOT NULL,
  desProjeto INTEGER UNSIGNED NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  idUsuario INTEGER UNSIGNED NULL,
  datConclusao DATE NULL,
  numTempoTotal INTEGER UNSIGNED NULL,
  PRIMARY KEY(idProjeto)
);

CREATE TABLE Usuarios (
  idUsuario INTEGER UNSIGNED NOT NULL AUTO_INCREMENT,
  desUsuario VARCHAR(100) NULL,
  datRegistro DATETIME NULL,
  datAlteracao DATETIME NULL,
  desSenha VARCHAR(100) NULL,
  desEmail INTEGER UNSIGNED NULL,
  PRIMARY KEY(idUsuario)
);



/*
	Sessão de Alter Tables
*/

ALTER TABLE Apontamentos ADD CONSTRAINT Atividades_idAtividade_ap
FOREIGN KEY(idAtividade) REFERENCES Atividades(idAtividade);
 
ALTER TABLE ApontamentosFatura ADD CONSTRAINT FATURAS_idFatura_ap
FOREIGN KEY(idFatura) REFERENCES Faturas(idFatura);

ALTER TABLE ApontamentosFatura ADD CONSTRAINT Apontamentos_idApontamento_ap
FOREIGN KEY(idApontamento) REFERENCES Apontamentos(idApontamento);

ALTER TABLE Avaliacao ADD CONSTRAINT Consultores_idConsultor_ava
FOREIGN KEY(idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE Atividades ADD CONSTRAINT Projetos_idProjeto_at
FOREIGN KEY(idProjeto) REFERENCES Projetos(idProjeto);

ALTER TABLE Avaliacao ADD CONSTRAINT Consultor_idConsultor_ava
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE Avaliacao ADD CONSTRAINT Clientes_idCliente_ava
FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);

ALTER TABLE ClientesUsuarios ADD CONSTRAINT Clientes_idCliente_cusu
FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);
 
ALTER TABLE ClientesUsuarios ADD CONSTRAINT Usuario_idUsuario_cusu
FOREIGN KEY (idUsuarioCliente) REFERENCES Usuarios(idUsuario);
 
ALTER TABLE ConsultoresHabilidades ADD CONSTRAINT Consultores_idConsultor_ch
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE ConsultoresHabilidades ADD CONSTRAINT Habilidades_ch
FOREIGN KEY (idHabilidades) REFERENCES Habilidades(idHabilidades);

ALTER TABLE ConsultoresUsuarios ADD CONSTRAINT Usuario_idUsuario_cu
FOREIGN KEY (idUsuarioConsultor) REFERENCES Usuarios(idUsuario);

ALTER TABLE ConsultoresUsuarios ADD CONSTRAINT Consultores_idConsultor_cu
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE FATURAS ADD CONSTRAINT Consultores_idConsultor_fr
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE FATURAS ADD CONSTRAINT Projetos_idProjeto_fr
FOREIGN KEY (idProjeto) REFERENCES Projetos(idProjeto);

ALTER TABLE FATURAS ADD CONSTRAINT Clientes_idCliente_fr
FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);

ALTER TABLE GerentesUsuarios ADD CONSTRAINT Gerentes_idGerente
FOREIGN KEY (idGerente) REFERENCES Gerentes(idGerente);

ALTER TABLE GerentesUsuarios ADD CONSTRAINT Usuario_idUsuario_GU
FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario);

ALTER TABLE Precos ADD CONSTRAINT Consultores_idConsultor_pr
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);

ALTER TABLE Projetos ADD CONSTRAINT Clientes_idCliente_pr
FOREIGN KEY (idCliente) REFERENCES Clientes(idCliente);

ALTER TABLE Projetos ADD CONSTRAINT Gerentes_idGerente_pr
FOREIGN KEY (idGerente) REFERENCES Gerentes(idGerente);

ALTER TABLE Projetos ADD CONSTRAINT Consultores_idConsultor_pro
FOREIGN KEY (idConsultor) REFERENCES Consultores(idConsultor);