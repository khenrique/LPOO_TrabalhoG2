----------------------------------------------------------------------------------
-----------------------------INSERT TABELA CATEGORIAS-----------------------------
----------------------------------------------------------------------------------

INSERT INTO categorias (nome_cat) VALUES ('Masculino');
INSERT INTO categorias (nome_cat) VALUES('Feminino');
INSERT INTO categorias (nome_cat) VALUES('Infaltil');

----------------------------------------------------------------------------------
------------------------------INSERT TABELA CLIENTES------------------------------
----------------------------------------------------------------------------------

INSERT INTO clientes (nome_cli, telefone, endereco)
VALUES ('Mariana', '(51) 8215-2659', 'Av. Fernandes Bastos, 2767');
INSERT INTO clientes (nome_cli, telefone, endereco)
VALUES ('Pedro Victor', '(51) 9919-8475', 'Rua Castro Alves, 474');
INSERT INTO clientes (nome_cli, telefone, endereco)
VALUES ('Ana Luiza', '(11) 9457-5586', 'Rua Santa Maria, 4851');
INSERT INTO clientes (nome_cli, telefone, endereco)
VALUES ('Giovani', '(55) 8356-9562', 'Av. Paraguassu, 1168');
INSERT INTO clientes (nome_cli, telefone, endereco)
VALUES ('Thais', '(51) 8145-0545', 'Av. Fernandes Bastos, 1020');

----------------------------------------------------------------------------------
-----------------------------INSERT TABELA FORNECEDORES---------------------------
----------------------------------------------------------------------------------

INSERT INTO fornecedores(nome_forn, telefone) VAlUES ('Fornecedor 1', '(51) 9865 - 8526');
INSERT INTO fornecedores(nome_forn, telefone) VAlUES ('Fornecedor 2', '(51) 8214 - 6699');
INSERT INTO fornecedores(nome_forn, telefone) VAlUES ('Fornecedor 3', '(51) 9114 - 7548');

----------------------------------------------------------------------------------
------------------------------INSERT TABELA FANTASIAS-----------------------------
----------------------------------------------------------------------------------

INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (2, 'Fantasia de Fada', 1);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (1, 'Fantasia de Pirata', 3);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (3, 'Fantasia de Princesa', 2);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (1, 'Fantasia de Chapeleiro Maluco', 2);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (2, 'Fantasia de Rainha de Copas', 1);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (3, 'Fantasia de Sininho', 3);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (2, 'Fantasia de Caveira Mexicana', 3);
INSERT INTO fantasias (id_categoria, descricao, id_fornecedor)
VALUES (1, 'Fantasia de Cowboy', 1);

----------------------------------------------------------------------------------
------------------------------INSERT TABELA EXEMPLARES----------------------------
----------------------------------------------------------------------------------

INSERT INTO exemplares(id_fantasia) VALUES (1)
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (1, 'M');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (1, 'P');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (2, 'M');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (2, 'G');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (3, 'P');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (3, 'M');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (3, 'G');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (4, 'UN');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (5, 'M');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (5, 'G');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (6, 'UN');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (6, 'UN');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (7, 'UN');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (7, 'GG');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (8, 'P');
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (8, 'M'); 
INSERT INTO exemplares(id_fantasia, tamanho) VALUES (8, 'GG');

INSERT INTO alugueis (id_cliente, id_exemplar,data_retirada)
VALUES (1, 1, '2015-05-31');
INSERT INTO alugueis (id_cliente, id_exemplar,data_retirada)
VALUES (2, 16, '2015-05-31');
INSERT INTO alugueis (id_cliente, id_exemplar,data_retirada)
VALUES (3, 14, '2015-06-08');
INSERT INTO alugueis (id_cliente, id_exemplar,data_retirada)
VALUES (4, 5, '2015-06-10');
INSERT INTO alugueis (id_cliente, id_exemplar,data_retirada)
VALUES (5, 12, '2015-06-08');