CREATE DATABASE loja_fantasias;

CREATE TABLE IF NOT EXISTS loja_fantasias.clientes (
    id_cliente INT(11) NOT NULL AUTO_INCREMENT,
    nome_cli VARCHAR(45) NOT NULL,
    telefone VARCHAR(45) NOT NULL,
    endereco VARCHAR(45) NOT NULL,
    qtd_alugueis INT(11) NULL DEFAULT 0,
    PRIMARY KEY (id_cliente)
);

CREATE TABLE IF NOT EXISTS loja_fantasias.categorias (
    id_categoria INT(11) NOT NULL AUTO_INCREMENT,
    nome_cat VARCHAR(45) NOT NULL,
    PRIMARY KEY (id_categoria)
);

CREATE TABLE IF NOT EXISTS loja_fantasias.fornecedores (
    id_fornecedor INT(11) NOT NULL AUTO_INCREMENT,
    nome_forn VARCHAR(45) NULL DEFAULT NULL,
    telefone VARCHAR(45) NOT NULL,
	qtd_fantasias_fornecidas INT NULL DEFAULT 0 ;
    PRIMARY KEY (id_fornecedor)
);

CREATE TABLE IF NOT EXISTS loja_fantasias.fantasias (
    id_fantasia INT(11) NOT NULL AUTO_INCREMENT,
    id_categoria INT(11) NOT NULL,
    descricao VARCHAR(45) NOT NULL,
	id_fornecedor INT(11) NOT NULL,
    PRIMARY KEY (id_fantasia),
    FOREIGN KEY (id_categoria)
        REFERENCES loja_fantasias.categorias (id_categoria)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
	FOREIGN KEY (id_fornecedor)
        REFERENCES loja_fantasias.fornecedores (id_fornecedor)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS loja_fantasias.exemplares (
    id_exemplar INT(11) NOT NULL AUTO_INCREMENT,
    id_fantasia INT(11) NOT NULL,
    tamanho CHAR(2) NULL DEFAULT 'UN',
    PRIMARY KEY (id_exemplar),
    FOREIGN KEY (id_fantasia)
        REFERENCES loja_fantasias.fantasias (id_fantasia)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS loja_fantasias.alugueis (
    id_aluguel INT(11) NOT NULL AUTO_INCREMENT,
    id_cliente INT(11) NOT NULL,
    id_exemplar INT(11) NOT NULL,
    data_retirada DATE NOT NULL,
    data_entrega DATE NULL DEFAULT '0000-00-00',
    PRIMARY KEY (id_aluguel),
    FOREIGN KEY (id_cliente)
        REFERENCES loja_fantasias.clientes (id_cliente)
        ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_exemplar)
        REFERENCES loja_fantasias.exemplares (id_exemplar)
        ON DELETE NO ACTION ON UPDATE NO ACTION
);


------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------ALTERAÇOES NO BANCO DEPOIS DO DIA 16/06/2015-----------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------


ALTER TABLE loja_fantasias.fantasias 
ADD COLUMN qtd_exemplares INT NULL DEFAULT 0 AFTER descricao;

ALTER TABLE loja_fantasias.exemplares
ADD COLUMN status_exemplar CHAR(3) NULL DEFAULT 'DIS' AFTER tamanho;

ALTER TABLE loja_fantasias.fornecedores
ADD coLUMN telefone VARCHAR(45) NOT NULL AFTER qtd_fantacias_fornecidas;