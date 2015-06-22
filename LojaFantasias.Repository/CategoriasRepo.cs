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
    public class CategoriasRepo
    {
        #region Atributos
        private static StringBuilder sql;
        #endregion

        #region Metodos Statics

        public static List<Categorias> Get()
        {
            sql = new StringBuilder();
            List<Categorias> lista = new List<Categorias>();

            sql.Append("SELECT * ");
            sql.Append("FROM categorias ");
            sql.Append("ORDER BY nome_cat ");

            MySqlDataReader dr = MinhaConexao.getLista(sql.ToString());
            {

                while (dr.Read())
                    lista.Add
                        (
                            new Categorias
                            {
                                id_categoria = (int)dr["id_categoria"],
                                nome_cat = (string)dr["nome_cat"]
                            }
                        );
            }
            dr.Dispose();
            return lista;
        }
        #endregion
    }
}

