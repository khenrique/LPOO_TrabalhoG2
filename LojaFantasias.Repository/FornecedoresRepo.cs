using Conexao;
using LojaFantasias.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaFantasias.Repository
{
    public class FornecedoresRepo
    {
       
        #region Atributos
        private static StringBuilder sql;
        #endregion

        #region Metodos Statics

        public static List<Fornecedores> Get()
        {
            sql = new StringBuilder();
            List<Fornecedores> lista = new List<Fornecedores>();

            sql.Append("SELECT * ");
            sql.Append("FROM fornecedores ");
            sql.Append("ORDER BY nome_forn ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Fornecedores
                            {
                                id_fornecedor = (int)dr["id_fornecedor"],
                                nome_forn = (string)dr["nome_forn"],
                                telefone = (string)dr["telefone"],
                                qtd_fantasias_fornecidas = (int)dr["qtd_fantasias_fornecidas"]
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Fornecedores pFornecedor)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO fornecedores (nome_forn, telefone) ");
            sql.Append("VALUES (@nome_forn, @telefone) ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nome_forn", pFornecedor.nome_forn);
            cmm.Parameters.AddWithValue("@telefone", pFornecedor.telefone);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static void Edit(int pIdFornecedor, Fornecedores pFornecedor)
        {
            sql = new StringBuilder();

            sql.Append("UPDATE Fornecedores SET nome_forn=@nome_forn, telefone=@telefone ");
            sql.Append("WHERE id_fornecedor=@id_fornecedor ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fornecedor", pIdFornecedor);
            cmm.Parameters.AddWithValue("@nome_forn", pFornecedor.nome_forn);
            cmm.Parameters.AddWithValue("@telefone", pFornecedor.telefone);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }


        public static void Delete(int pIdFornecedor)
        {
            sql = new StringBuilder();
            sql.Append("DELETE FROM Fornecedores ");
            sql.Append("WHERE id_fornecedor=@id_fornecedor");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_fornecedor", pIdFornecedor);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static List<Fantasias> FantasiasDoFornecedor(int pIdFornecedor)
        {
            sql = new StringBuilder();
            List<Fantasias> lista = new List<Fantasias>();

            sql.Append("SELECT * ");
            sql.Append("FROM fantasias f INNER JOIN fornecedores fr ");
            sql.Append("ON f.id_fornecedor = fr.id_fornecedor WHERE fr.id_fornecedor= " + pIdFornecedor + " ");
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

       
        public static List<Fornecedores> BuscarFornecedor(string pNome)
        {
            sql = new StringBuilder();
            List<Fornecedores> lista = new List<Fornecedores>();

            sql.Append("SELECT * ");
            sql.Append("FROM fornecedores ");
            sql.Append("WHERE nome_forn like '%" + pNome + "%' ");
            sql.Append("ORDER BY nome_forn ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Fornecedores
                            {
                                id_fornecedor = (int)dr["id_fornecedor"],
                                nome_forn = (string)dr["nome_forn"],
                                telefone = (string)dr["telefone"],
                                qtd_fantasias_fornecidas = (int)dr["qtd_fantasias_fornecidas"]
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }
        #endregion

    }
}
