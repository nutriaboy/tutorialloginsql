using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace TutorialLogin
{
    public class Login
    {

        #region"atributos"
        string usuario;
        string contraseña;
        #endregion
            

        #region"propiedades"

        public string Usuario
        {
            set { usuario = value; }
            get { return usuario; }

        }


        public string Contraseña
        {
            set { contraseña = value; }
            get { return contraseña; }
        }

        #endregion

        #region"funciones"

        public bool ValidarLogin(string u, string c)
        {
            string cdncn = "Server=localhost;Database=bdtutorial; Uid=root;Pwd=;port=3306;";
            MySqlConnection cn = new MySqlConnection(cdncn);
            cn.Open();
            MySqlCommand cmd;
            MySqlDataReader dr;

            string sql = "SELECT * FROM tbllogin WHERE usuario = '" +u+ "' and contraseña ='"+c+"' ";
            cmd = new MySqlCommand(sql, cn);
            dr = cmd.ExecuteReader();

            dr.Read();

            if (dr.HasRows)
            {

                return true;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrecto");
                return false;
            }
            cn.Close();
        }
    }
    #endregion
}
