using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int pR, pG, pB, cc=0, cont=0;
        string nombre, varcR, varcG, varcB;
        string[] colores = new string[3];
        


        public Form1()
        {
            InitializeComponent();
            eliminarDatos();
            datosTabla();
            colores[0] = "rojo";
            colores[1] = "amarillo";
            colores[2] = "azul";
        }
        private void CargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos *.*|";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
            eliminarDatos();
            datosTabla();
            cc = 0;
            cont = 0;
        }
        private void Imagenclick(object sender, MouseEventArgs e)
        {
            Color c = new Color();
            pR = 0;
            pG = 0;
            pB = 0;
            for (int ki = e.X; ki < e.X + 10; ki++)
                for (int kj = e.Y; kj < e.Y + 10; kj++)
                {
                    c = bmp.GetPixel(ki, kj);
                    pR = pR + c.R;
                    pG = pG + c.G;
                    pB = pB + c.B;
                }
            pR = pR / 100;
            pG = pG / 100;
            pB = pB / 100;
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            cc =cc + 1;
            if(cc<4) {
                form2vista(cc, c.R.ToString(), c.G.ToString(), c.B.ToString());

            }

                
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int mR = 0, mG = 0, mB = 0;
            Color c = new Color();
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {
                    mR = 0;
                    mG = 0;
                    mB = 0;
                    for (int ki = i; ki < i + 10; ki++)
                        for (int kj = j; kj < j + 10; kj++)
                        {
                            c = bmp.GetPixel(ki, kj);
                            mR = mR + c.R;
                            mG = mG + c.G;
                            mB = mB + c.B;
                        }
                    mR = mR / 100;
                    mG = mG / 100;
                    mB = mB / 100;

                    c = bmp.GetPixel(i, j);
                    if ((pR - 5 <= mR && mR <= pR + 5) && (pG - 5 <= mG && mG <= pG + 5) && (pB - 5 <= mB && mB <= pB + 5))
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                                bmpR.SetPixel(ki, kj, Color.Fuchsia);
                    }
                    else
                    {
                        for (int ki = i; ki < i + 10; ki++)
                            for (int kj = j; kj < j + 10; kj++)
                            {
                                c = bmp.GetPixel(ki, kj);
                                bmpR.SetPixel(ki, kj, Color.FromArgb(c.R, c.G, c.B));
                            }

                    }
                }
            pictureBox2.Image = bmpR;
        }

        private void Boton_texturas_Click(object sender, EventArgs e)
        {
            encontrarTexturas();
        }

        public void datosTabla()
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);database=texturas;user=examen324;pwd=123456";
            con.Open();
            String com = "select nombre, puntoR, puntoG, puntoB, color from textura order by id";
            SqlCommand sql = new SqlCommand(com, con);
            SqlDataAdapter dt = new SqlDataAdapter(sql);
            DataTable tabla = new DataTable();
            dt.Fill(tabla);
            dataGridView1.DataSource = tabla;

        }
        public void form2vista(int cc, string cR, string cG, string cB)
        {
            Form2 form2 = new Form2();
            form2.Pasado += new Form2.guardarnombre(recibirnombre);
            form2.Pasado1 += new Form2.guardarnombre1(guardarnombrex);
            form2.Show();
            varcR = cR; varcG = cG; varcB = cB;
        }

        public void recibirnombre(string nom) {
            nombre = nom;
        }

        public void guardarnombrex() {
            guardarDatos(cc, varcR, varcG, varcB);
            datosTabla();
        }

        public void guardarDatos(int cc, string cR, string cG, string cB)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);database=texturas;user=examen324;pwd=123456";
            con.Open();
            String com = "insert into textura values('" + this.nombre + "'," + cR + "," + cG + "," + cB + ",'" + colores[cont] +"'," +cont+");";
            SqlCommand sql = new SqlCommand(com, con);
            sql.ExecuteNonQuery();
            cont++;
        }

        private void reiniciopuntos_Click(object sender, EventArgs e)
        {
            eliminarDatos();
            datosTabla();
            cc = 0;
            cont = 0;
        }

        public void eliminarDatos()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "server=(local);database=texturas;user=examen324;pwd=123456";
            con.Open();
            String com = "delete from textura";
            SqlCommand sql = new SqlCommand(com, con);
            sql.ExecuteNonQuery();

        }

        public void verdatos()
        {
            int[] pR = new int[3];
            int[] pG = new int[3];
            int[] pB = new int[3];
            string queryString = "SELECT * FROM textura;";
            using (SqlConnection connection = new SqlConnection(
                       "server=(local) ; database=texturas ; integrated security = true; user = examen324; pwd = 123456"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int cR = 1, cP = 0;
                    while (reader.Read())
                    {
                        pR[cP] = Int32.Parse(String.Format("{0}", reader[cR]));
                        pG[cP] = Int32.Parse(String.Format("{0}", reader[cR + 1]));
                        pB[cP] = Int32.Parse(String.Format("{0}", reader[cR + 2]));
                        cP++;
                    }
                }
            }

            for (int q = 0; q < 3; q++) {
                Console.WriteLine(pR[q] + " " + pG[q] + " " + pB[q] + " ");
            }

        }



        public void encontrarTexturas()
        {
            int[] pR = new int[3];
            int[] pG = new int[3];
            int[] pB = new int[3];

            string queryString = "SELECT * FROM textura order by id;";
            using (SqlConnection connection = new SqlConnection(
                       "server=(local) ; database=texturas ; integrated security = true; user = examen324; pwd = 123456"))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int cR = 1, cP=0;
                    while (reader.Read())
                    {
                        pR[cP] = Int32.Parse(String.Format("{0}", reader[cR]));
                        pG[cP] = Int32.Parse(String.Format("{0}", reader[cR+1]));
                        pB[cP] = Int32.Parse(String.Format("{0}", reader[cR+2]));
                        cP++;
                    }
                }
            }
            int mR, mG, mB;
            Bitmap bmpR = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 10; i = i + 10)
                for (int j = 0; j < bmp.Height - 10; j = j + 10)
                {
                    mR = 0;
                    mG = 0;
                    mB = 0;
                    for (int ki = i; ki < i + 10; ki++)
                        for (int kj = j; kj < j + 10; kj++)
                        {
                            c = bmp.GetPixel(ki, kj);
                            mR = mR + c.R;
                            mG = mG + c.G;
                            mB = mB + c.B;
                        }
                    mR = mR / 100;
                    mG = mG / 100;
                    mB = mB / 100;
                    c = bmp.GetPixel(i, j);
                    if (((pR[0] - 10) < mR) && (mR < (pR[0] + 10)) && 
                            ((pG[0] - 10) < mG) && (mG < (pG[0] + 10)) && 
                            ((pB[0] - 10) < mB) && (mB < (pB[0] + 10)))
                            for (int ki = i; ki < i + 10; ki++)
                                for (int kj = j; kj < j + 10; kj++)
                                    bmpR.SetPixel(ki, kj, Color.Red);
                        else if (((pR[1] - 10) < mR) && (mR < (pR[1] + 10)) &&
                            ((pG[1] - 10) < mG) && (mG < (pG[1] + 10)) &&
                            ((pB[1] - 10) < mB) && (mB < (pB[1] + 10)))
                            for (int ki = i; ki < i + 10; ki++)
                                for (int kj = j; kj < j + 10; kj++)
                                    bmpR.SetPixel(ki, kj, Color.Yellow);
                        else if (((pR[2] - 10) < mR) && (mR < (pR[2] + 10)) &&
                            ((pG[2] - 10) < mG) && (mG < (pG[2] + 10)) &&
                            ((pB[2] - 10) < mB) && (mB < (pB[2] + 10)))
                            for (int ki = i; ki < i + 10; ki++)
                                for (int kj = j; kj < j + 10; kj++)
                                    bmpR.SetPixel(ki, kj, Color.Blue);
                        else
                            for (int ki = i; ki < i + 10; ki++)
                                for (int kj = j; kj < j + 10; kj++)
                                {
                                    c = bmp.GetPixel(ki, kj); ;
                                    bmpR.SetPixel(ki, kj, c);
                                }
                }
            pictureBox2.Image = bmpR;
        }

    }
}
