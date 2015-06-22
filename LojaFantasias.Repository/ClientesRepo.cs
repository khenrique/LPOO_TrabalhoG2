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
    public class ClientesRepo
    {
        #region Atributos
        private static StringBuilder sql;
        #endregion

        #region Metodos Statics

        public static List<Clientes> Get()
        {
            sql = new StringBuilder();
            List<Clientes> lista = new List<Clientes>();

            sql.Append("SELECT * ");
            sql.Append("FROM clientes ");
            sql.Append("ORDER BY nome_cli ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Clientes
                            {
                                id_cliente = (int)dr["id_cliente"],
                                nome_cli = (string)dr["nome_cli"],
                                telefone = (string)dr["telefone"],
                                endereco = (string)dr["endereco"],
                                qtd_alugueis = (int)dr["qtd_alugueis"]
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }

        public static void Create(Clientes pCliente)
        {
            sql = new StringBuilder();
            sql.Append("INSERT INTO clientes (nome_cli, telefone, endereco) ");
            sql.Append("VALUES (@nome_cli, @telefone, @endereco) ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@nome_cli", pCliente.nome_cli);
            cmm.Parameters.AddWithValue("@telefone", pCliente.telefone);
            cmm.Parameters.AddWithValue("@endereco", pCliente.endereco);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static void Edit(int pIdCliente, Clientes pCliente)
        {
            sql = new StringBuilder();

            sql.Append("update clientes set nome_cli=@nome_cli, telefone=@telefone, endereco=@endereco ");
            sql.Append("where id_cliente=@id_cliente ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_cliente", pIdCliente);
            cmm.Parameters.AddWithValue("@nome_cli", pCliente.nome_cli);
            cmm.Parameters.AddWithValue("@telefone", pCliente.telefone);
            cmm.Parameters.AddWithValue("@endereco", pCliente.endereco);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }


        public static void Delete(int pIdCliente)
        {
            sql = new StringBuilder();
            sql.Append("delete from clientes ");
            sql.Append("where id_cliente=@id_cliente ");

            MySqlCommand cmm = new MySqlCommand();
            cmm.Parameters.AddWithValue("@id_cliente", pIdCliente);

            cmm.CommandText = sql.ToString();
            MinhaConexao.CommandPersist(cmm);
        }

        public static List<Clientes> BuscarCliente(string pNome)
        {
            sql = new StringBuilder();
            List<Clientes> lista = new List<Clientes>();

            sql.Append("SELECT * ");
            sql.Append("FROM clientes ");
            sql.Append("WHERE nome_cli like '%" + pNome + "%' ");
            sql.Append("ORDER BY nome_cli ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Clientes
                            {
                                id_cliente = (int)dr["id_cliente"],
                                nome_cli = (string)dr["nome_cli"],
                                telefone = (string)dr["telefone"],
                                endereco = (string)dr["endereco"],
                                qtd_alugueis = (int)dr["qtd_alugueis"]
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }
        #endregion
    }
}