using LojaFantasias.Data;
using Conexao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class ExemplaresRepo
    {
        #region Atributos
        private static StringBuilder sql;
        #endregion

        #region Metodos Statics

        public static List<Exemplares> Get()
        {
            sql = new StringBuilder();
            List<Exemplares> lista = new List<Exemplares>();

            sql.Append("SELECT * ");
            sql.Append("FROM exemplares e ");
            sql.Append("INNER JOIN fantasias f ");
            sql.Append("ON e.id_fantasia = f.id_fantasia ");
            sql.Append("INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
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


        public static void Create(Exemplares pExemplar)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO exemplares (id_fantasia, tamanho) ");
            sql.Append("VALUES (@id_fantasia, @tamanho) ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fantasia", pExemplar.fantasia.id_fantasia);
            cmm.Parameters.AddWithValue("@tamanho", pExemplar.tamanho);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }


        public static void Edit(int pIdExemplar, Exemplares pExemplar)
        {
            sql = new StringBuilder();

            sql.Append("UPDATE exemplares SET id_fantasia=@id_fantasia, tamanho=@tamanho ");
            sql.Append("where id_exemplar=@id_exemplar ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_exemplar", pIdExemplar);
            cmm.Parameters.AddWithValue("@id_fantasia", pExemplar.fantasia.id_fantasia);
            cmm.Parameters.AddWithValue("@tamanho", pExemplar.tamanho);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }


        public static void Delete(int pIdExemplar)
        {
            sql = new StringBuilder();
            sql.Append("delete from exemplares ");
            sql.Append("where id_exemplar=@id_exemplar ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_exemplar", pIdExemplar);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static List<Exemplares> BuscarExemplar(string pNome)
        {
            sql = new StringBuilder();
            List<Exemplares> lista = new List<Exemplares>();

            sql.Append("SELECT * ");
            sql.Append("FROM exemplares e ");
            sql.Append("INNER JOIN fantasias f ");
            sql.Append("ON e.id_fantasia = f.id_fantasia ");
            sql.Append("INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
            sql.Append("WHERE descricao like '%" + pNome + "%' ");
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

        public static List<Exemplares> BuscarExemplarTamanho(string pTam)
        {
            sql = new StringBuilder();
            List<Exemplares> lista = new List<Exemplares>();

            sql.Append("SELECT * ");
            sql.Append("FROM exemplares e ");
            sql.Append("INNER JOIN fantasias f ");
            sql.Append("ON e.id_fantasia = f.id_fantasia ");
            sql.Append("INNER JOIN categorias c ");
            sql.Append("ON f.id_categoria = c.id_categoria ");
            sql.Append("WHERE tamanho = '" + pTam + "' ");
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

