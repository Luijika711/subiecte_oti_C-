using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
namespace JocEducativ
{
    public partial class Form1 : Form
    {
        public void LoadDatabase()
        {
            using (SqlConnection Conn = new SqlConnection(Program.ConnectionString))
            {
                Conn.Open();
                foreach(var Line in File.ReadAllLines("Utilizatori.txt"))
                {
                    var Cols = Line.Split(';');
                    string QueryString = string.Format("SELECT * FROM Utilizatori WHERE EmailUtilizator = '{0}'", Cols[0].ToString());
                    SqlCommand Cmd = new SqlCommand(QueryString, Conn);
                    //SqlDataReader Reader = Cmd.ExecuteReader();
                    Cmd = new SqlCommand("INSERT INTO Utilizatori VALUES('aoleu','aoleu','aoleu')",Conn);
                    Cmd.ExecuteNonQuery();
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDatabase();
        }
    }
}
