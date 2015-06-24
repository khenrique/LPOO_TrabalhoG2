using Conexao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaFantasias.Data;

namespace LojaFantasias.Repository
{
    public class FantasiasRepo
    {
        #region Atributos
        private static StringBuilder sql;
        #endregion

        #region Metodos Statics

        public static List<Fantasias> Get()
        {
            sql = new StringBuilder();
            List<Fantasias> lista = new List<Fantasias>();

            sql.Append("SELECT * ");
            sql.Append("FROM fantasias fa INNER JOIN categorias c ");
            sql.Append("ON fa.id_categoria = c.id_categoria ");
            sql.Append("INNER JOIN fornecedores fo ");
            sql.Append("ON fa.id_fornecedor = fo.id_fornecedor ");
            sql.Append("ORDER BY descricao ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Fantasias
                            {
                                id_fantasia = (int)dr["id_fantasia"],
                                descricao = (string)dr["descricao"],
                                qtd_exemplares = (int)dr["qtd_exemplares"],
                                categoria = new Categorias
                                {
                                    id_categoria = dr.GetInt16(dr.GetOrdinal("id_categoria")),
                                    nome_cat = dr.GetString(dr.GetOrdinal("nome_cat"))
                                },
                                fornecedor = new Fornecedores
                                {
                                    id_fornecedor = (int)dr["id_fornecedor"],
                                    nome_forn = (string)dr["nome_forn"],
                                    telefone = (string)dr["telefone"],
                                    qtd_fantasias_fornecidas = (int)dr["qtd_fantasias_fornecidas"]
                                }
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Fantasias pFantasia)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO fantasias (descricao, id_categoria, id_fornecedor) ");
            sql.Append("VALUES (@descricao, @id_categoria, @id_fornecedor) ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@descricao", pFantasia.descricao);
            cmm.Parameters.AddWithValue("@id_categoria", pFantasia.categoria.id_categoria);
            cmm.Parameters.AddWithValue("@id_fornecedor", pFantasia.fornecedor.id_fornecedor);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static void Edit(int pIdFantasia, Fantasias pFantasia)
        {
            sql = new StringBuilder();

            sql.Append("UPDATE fantasias SET descricao=@descricao, id_categoria=@id_categoria, id_fornecedor=@id_fornecedor ");
            sql.Append("WHERE id_fantasia=@id_fantasia ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fantasia", pIdFantasia);
            cmm.Parameters.AddWithValue("@descricao", pFantasia.descricao);
            cmm.Parameters.AddWithValue("@id_categoria", pFantasia.categoria.id_categoria);
            cmm.Parameters.AddWithValue("@id_fornecedor", pFantasia.fornecedor.id_fornecedor);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }


        public static void Delete(int pIdFantasia)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM fantasias ");
            sql.Append("WHERE id_fantasia=@id_fantasia ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fantasia", pIdFantasia);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static List<Fantasias> BuscarFantasiaNome(string pNome)
        {
            sql = new StringBuilder();
            List<Fantasias> lista = new List<Fantasias>();

            sql.Append("SELECT * ");
            sql.Append("FROM fantasias fa INNER JOIN categorias c ");
            sql.Append("ON fa.id_categoria = c.id_categoria ");
            sql.Append("INNER JOIN fornecedores fo ");
            sql.Append("ON fa.id_fornecedor = fo.id_fornecedor ");
            sql.Append("WHERE descricao like '%" + pNome + "%' ");
            sql.Append("ORDER BY descricao ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Fantasias
                            {
                                id_fantasia = (int)dr["id_fantasia"],
                                descricao = (string)dr["descricao"],
                                qtd_exemplares = (int)dr["qtd_exemplares"],
                                categoria = new Categorias
                                {
                                    id_categoria = dr.GetInt16(dr.GetOrdinal("id_categoria")),
                                    nome_cat = dr.GetString(dr.GetOrdinal("nome_cat"))
                                },
                                fornecedor = new Fornecedores
                                {
                                    id_fornecedor = (int)dr["id_fornecedor"],
                                    nome_forn = (string)dr["nome_forn"],
                                    telefone = (string)dr["telefone"],
                                    qtd_fantasias_fornecidas = (int)dr["qtd_fantasias_fornecidas"]
                                }
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }

        public static List<Fantasias> BuscarFantasiaCategoria(int id)
        {
            sql = new StringBuilder();
            List<Fantasias> lista = new List<Fantasias>();

            sql.Append("SELECT * ");
            sql.Append("FROM fantasias fa INNER JOIN categorias c ");
            sql.Append("ON fa.id_categoria = c.id_categoria ");
            sql.Append("INNER JOIN fornecedores fo ");
            sql.Append("ON fa.id_fornecedor = fo.id_fornecedor ");
            sql.Append("WHERE fa.id_categoria = " + id + " ");
            sql.Append("ORDER BY descricao ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Fantasias
                            {
                                id_fantasia = (int)dr["id_fantasia"],
                                descricao = (string)dr["descricao"],
                                qtd_exemplares = (int)dr["qtd_exemplares"],
                                categoria = new Categorias
                                {
                                    id_categoria = dr.GetInt16(dr.GetOrdinal("id_categoria")),
                                    nome_cat = dr.GetString(dr.GetOrdinal("nome_cat"))
                                },
                                fornecedor = new Fornecedores
                                {
                                    id_fornecedor = (int)dr["id_fornecedor"],
                                    nome_forn = (string)dr["nome_forn"],
                                    telefone = (string)dr["telefone"],
                                    qtd_fantasias_fornecidas = (int)dr["qtd_fantasias_fornecidas"]
                                }
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }

            public static List<Exemplares> ExemplaresDaFantasia(int pIdFantasia)
        {
            sql = new StringBuilder();
            List<Exemplares> lista = new List<Exemplares>();

            sql.Append("SELECT * ");
            sql.Append("FROM exemplares e ");
            sql.Append("INNER JOIN fantasias f ");
            sql.Append("ON e.id_fantasia = f.id_fantasia ");
            sql.Append("INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
            sql.Append("WHERE e.id_fantasia = " + pIdFantasia + " ");
            sql.Append("ORDER BY f.descricao ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Exemplares
                            {
                                id_exemplar = (int)dr["id_exemplar"],
                                tamanho = (string)dr["tamanho"],
                                status_exemplar = (string)dr["status_exemplar"],
                                fantasia = new Fantasias
                                {
                                    id_fantasia = dr.GetInt16(dr.GetOrdinal("id_fantasia")),
                                    descricao = dr.GetString(dr.GetOrdinal("descricao")),
                                    qtd_exemplares = dr.GetInt16(dr.GetOrdinal("qtd_exemplares")),
                                    categoria = new Categorias
                                    {
                                        id_categoria = dr.GetInt16(dr.GetOrdinal("id_categoria")),
                                        nome_cat = dr.GetString(dr.GetOrdinal("nome_cat"))
                                    }
                                }
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }
        #endregion
    }
}

