using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Conexao
{
    public class MinhaConexao
    {
        private static MySqlConnection conn = new MySqlConnection();
        private static MySqlCommand cmm;
        private static MySqlDataReader dr;

        private static string _nomeServidor = "localhost";
        private static string _nomeBanco = "loja_fantasias";

        /// <summary>
        /// string de conn para o mysql
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                return "Server=" + _nomeServidor +
                        ";Port=3307" +
                        ";Database=" + _nomeBanco +
                        ";Uid=root" +
                        ";Pwd=2067" +
                        ";default command timeout=512";
            }
        }

        private static void Conectar()
        {


            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
            }
        }

        public static void Desconectar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public static MySqlDataReader getLista(string sql)
        {

            Conectar();
            cmm = new MySqlCommand(sql, conn);

            dr = cmm.ExecuteReader();

            return dr;
        }

        //Refatorei para trabalhar somente com o command passado.ficou melhor.
        public static void CommandPersist(MySqlCommand pCmm)
        {
            //Verifica se a conexão esta presente do command, se não, inclui
            if (pCmm.Connection == null)
            {
                Conectar();
                pCmm.Connection = conn;
            }

            pCmm.ExecuteNonQuery();
        }


    }
}