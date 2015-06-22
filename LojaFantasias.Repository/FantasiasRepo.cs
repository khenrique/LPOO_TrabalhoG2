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
            sql.Append("FROM fantasias f INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
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
            sql.Append("INSERT INTO fantasias (descricao, id_categoria) ");
            sql.Append("VALUES (@descricao, @id_categoria) ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@descricao", pFantasia.descricao);
            cmm.Parameters.AddWithValue("@id_categoria", pFantasia.categoria.id_categoria);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static void Edit(int pIdFantasia, Fantasias pFantasia)
        {
            sql = new StringBuilder();

            sql.Append("UPDATE fantasias SET descricao=@descricao, id_categoria=@id_categoria ");
            sql.Append("WHERE id_fantasia=@id_fantasia ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fantasia", pIdFantasia);
            cmm.Parameters.AddWithValue("@descricao", pFantasia.descricao);
            cmm.Parameters.AddWithValue("@id_categoria", pFantasia.categoria.id_categoria);

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
            sql.Append("FROM fantasias f INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
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
            sql.Append("FROM fantasias f INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
            sql.Append("WHERE f.id_categoria = " + id + " ");
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

