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

namespace Estudiantes
{
    public partial class Form1 : Form
    {
        private object da;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("conexión exitosa");
            dataGridView1.DataSource = llenar_grid();
            Conexion.Desconectar();
        }


        public DataTable llenar_grid() 
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT* FROM ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (IDENTIFICACION,NOMBRE,APELLIDO,EDAD) VALUES (@ID,@NOMBRE,@APELLIDO,@EDAD)";
            SqlCommand cmd1 = new SqlCommand(insertar,Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@ID", txtIdentificacion.Text);
            cmd1.Parameters.AddWithValue("@NOMBRE", txtNombre.Text);
            cmd1.Parameters.AddWithValue("@APELLIDO", txtApellido.Text);
            cmd1.Parameters.AddWithValue("@EDAD", txtEdad.Text);

            cmd1.ExecuteNonQuery();
            

            MessageBox.Show("Los datos fueron insertados con exito");
            MessageBox.Show("siguiente página");
            
            dataGridView1.DataSource=llenar_grid();
            Conexion.Desconectar();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtIdentificacion.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtEdad.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Conexion.Desconectar();
            }
            catch 
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNO SET IDENTIFICACION=@ID,NOMBRE=@NOMBRE,APELLIDO=@APELLIDO,EDAD=@EDAD WHERE IDENTIFICACION=@ID";
            SqlCommand cmd2 =new SqlCommand(actualizar,Conexion.Conectar());


            cmd2.Parameters.AddWithValue("@ID", txtIdentificacion.Text);
            cmd2.Parameters.AddWithValue("@NOMBRE",txtNombre.Text);
            cmd2.Parameters.AddWithValue("@APELLIDO", txtApellido.Text);
            cmd2.Parameters.AddWithValue("@EDAD", txtEdad.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos se actualizaron con exito");
            dataGridView1.DataSource = llenar_grid();
            Conexion.Desconectar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM ALUMNO WHERE IDENTIFICACION = @ID ";
            SqlCommand cmd3 = new SqlCommand(eliminar,Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@ID", txtIdentificacion.Text);

            cmd3.ExecuteNonQuery();


            MessageBox.Show("Se ha eliminado el estudiante");
            dataGridView1.DataSource=llenar_grid();
            Conexion.Desconectar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtIdentificacion.Clear();
            txtNombre.Clear();  
            txtApellido.Clear();
            txtEdad.Clear();
            txtIdentificacion.Focus();  

        }
    }
}
