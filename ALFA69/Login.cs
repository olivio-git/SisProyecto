using Capa_Entidad;
using Capa_Negocio;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace WindowsFormsAppVaidrollTeam
{
    public partial class Login : Form
    {

        //No te olvides de dejar tu like en el vídeo, eso me motivará a crear más proyectos. :)

        ClassEntidad objeuser = new ClassEntidad();
        ClassNegocio objnuser = new ClassNegocio();
        public static string usuario_nombre;
        public static string id_tipo;
        public static string usuario_nick;
        public static string usuario_codigo;

        Principal frm1 = new Principal();
        public Login()
        {
            InitializeComponent();
        }
        //Para mover el formulario.
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wmsg, int wParam, int lParam);
        int mov, movX, movY;
        private void Login_Load(object sender, EventArgs e)
        {

            timer1.Start();

        }
        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Para mover el formulario.
        private void boxmovform_MouseDown(object sender, MouseEventArgs e)
        {

            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {




        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnentrar_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            objeuser.usuario = textBox1.Text;
            objeuser.clave = textBox2.Text;

            dt = objnuser.N_login(objeuser);



            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido " + dt.Rows[0][0].ToString(), "Mensaje",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                usuario_nombre = dt.Rows[0][0].ToString();
                id_tipo = dt.Rows[0][3].ToString();
                usuario_nick = dt.Rows[0][1].ToString();
                usuario_codigo = dt.Rows[0][4].ToString();
                frm1.ShowDialog();

                textBox1.Clear();
                textBox2.Clear();

                //    Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Mensaje",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "USUARIO")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "USUARIO";
                textBox1.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "CONTRASEÑA")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.LightGray;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "CONTRASEÑA";
                textBox2.ForeColor = Color.DimGray;
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Para mover el formulario.
        private void boxmovform_MouseMove(object sender, MouseEventArgs e)
        {

            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        //Para mover el formulario.
        private void boxmovform_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
