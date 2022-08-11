using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TesteConexao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbxTipoBanco.Items.Add("SQL Server");
            cbxTipoBanco.Items.Add("Oracle");
            cbxTipoBanco.Items.Add("Firebird");
            cbxTipoBanco.Items.Add("MySQL");
        }

        private void cbxTipoBanco_SelectedValueChanged(object sender, EventArgs e)
        {
            string tipoBanco = cbxTipoBanco.SelectedItem.ToString();
            if(tipoBanco.Equals("SQL Server"))
            {
                chkWindowsAutenticator.Visible = true;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipoBanco = cbxTipoBanco.SelectedItem.ToString();
            string conectionstring = "";
            switch (tipoBanco)
            {
                case "SQL Server":
                {

                        string strConn = ("Data Source=GAMEJR\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true");
                        strConn = ("Data Source=GAMEJR\\SQLEXPRESS;Initial Catalog=master;Integrated Security=true;User Id=YOURSQLUSERNAME;Password=YOURSQLUSERPASSWORD");


                        if (chkWindowsAutenticator.Checked)
                        {
                            conectionstring = "<connectionStrings>< add name = 'bancoConectionsString' connectionString = 'Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtBaseDados.Text + ";Integrated Security=True' providerName = 'System.Data.SqlClient' /></ connectionStrings >";
                            strConn = ("Data Source="+txtServidor.Text+";Initial Catalog="+txtBaseDados.Text+";Integrated Security=true");
                        }
                        else
                        {
                            conectionstring = "<connectionStrings><add name = 'bancoConectionsString' connectionString = 'Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtBaseDados.Text + ";User ID="+txtUsuario.Text+";Password="+txtSenha.Text+"' providerName = 'System.Data.SqlClient'/></connectionStrings>";
                            strConn = ("Data Source=" + txtServidor.Text + ";Initial Catalog=" + txtBaseDados.Text + ";User Id=" + txtUsuario.Text + ";Password=" + txtSenha.Text);
                        }

                       
                        SqlConnection con = new SqlConnection(strConn);
                        string resultado = "Banco Selecionado : " + tipoBanco;
                        try
                        {
                            con.Open();
                            if (con.State == ConnectionState.Open)
                            {
                                txtResultado.Text = resultado + " OK: Conexao aberta";
                                txtConnectString.Text = conectionstring;
                            }
                        }
                        catch (Exception erro)
                        {

                            txtResultado.Text = resultado + erro.Message;
                        }
                        finally
                        {
                            con.Close();
                        }
                    break;
                }
                case "Oracle":
                {
                        txtResultado.Text = "Banco Selecionado : " + tipoBanco;
                        break;
                }
                case "Firebird":
                {
                        txtResultado.Text = "Banco Selecionado : " + tipoBanco;
                        string server = txtServidor.Text;
                        string database = txtBaseDados.Text;
                        string user = txtUsuario.Text;
                        string password = txtSenha.Text;

                        string strConn = @"DataSource="+server+"; Database="+database+"; username= "+user+"; password ="+password;
                        conectionstring = "<connectionStrings >< add name = 'bancoMYSQLConnection'  connectionString = 'DataSource=" + server + ";Database=" + database + ";username=" + txtUsuario.Text + ";password=" + txtSenha.Text + ";' /> </ connectionStrings >";
                        FbConnection conn = new FbConnection(strConn);
                        try
                        {
                            conn.Open();
                            txtResultado.Text = txtResultado.Text + " OK: Conexao aberta";
                            txtConnectString.Text = conectionstring;
                        }
                        catch (MySqlException erro)
                        {
                            txtResultado.Text = txtResultado.Text + erro.Message;
                        }
                        finally
                        {
                            conn.Close();
                        }
                        break;
                }
                case "MySQL":
                {       
                        string resultado = "Banco Selecionado : " + tipoBanco;
                        string server = txtServidor.Text;
                        string database = txtBaseDados.Text;
                        string user = txtUsuario.Text;
                        string password = txtSenha.Text;
                        string port = "3306";
                        string sslM = "none";
                        conectionstring = "<connectionStrings >< add name = 'bancoMYSQLConnection' connectionString = 'server="+txtServidor.Text+";user="+txtUsuario.Text+";database="+database+ ";port=3306;password=" + txtSenha.Text+";' /> </ connectionStrings >";
                        string connString = String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", server, port, user, password, database, sslM);
                        var conn = new MySqlConnection(connString);
                        try
                        {
                            conn.Open();
                            txtResultado.Text = resultado + " OK: Conexao aberta";
                            txtConnectString.Text = conectionstring;  
                        }
                        catch (MySqlException erro)
                        {
                            txtResultado.Text = resultado + erro.Message;
                        }
                        finally
                        {
                            conn.Close();
                        }

                        break;
                }
                default:  { break; } 
            }
        }


    }
}
