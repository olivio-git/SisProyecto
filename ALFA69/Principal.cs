using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Entidad;
using Capa_Negocio;

namespace WindowsFormsAppVaidrollTeam
{
    public partial class Principal : Form
    {
        ClassEntidad obje = new ClassEntidad();
        ClassNegocio objn = new ClassNegocio();



        public static string totalalum,totalcur,totalsal;
        public Principal()
        {
            InitializeComponent();
        }

        int mov, movX, movY;
        private void boxmovform_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

            DataTable dtalum = objn.N_totalalumnos();
            DataTable dtacur = objn.N_totalcurso();
            DataTable dtasal = objn.N_totalsalones();

            lbltotalalum.Text = dtalum.Rows[0][0].ToString();
            lbltotalcurs.Text = dtacur.Rows[0][0].ToString();
            lbltotalsalon.Text = dtasal.Rows[0][0].ToString();


            lblusuario.Text = Login.usuario_nombre;
            if (Login.id_tipo == "T0001")  //Admin
            {
                usuariosToolStripMenuItem.Enabled = true;
                alumnosToolStripMenuItem.Enabled = true;
                salonesToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
                cursosToolStripMenuItem.Enabled = true;
            }
            else 
            if (Login.id_tipo == "T0002") //Asistente
                {
                    usuariosToolStripMenuItem.Enabled = false;
                    alumnosToolStripMenuItem.Enabled = false;
                    salonesToolStripMenuItem.Enabled = false;
                    reportesToolStripMenuItem.Enabled = true;
                cursosToolStripMenuItem.Enabled = false;
            }
            else
            if (Login.id_tipo == "T0003") //Secretaria
            {
                usuariosToolStripMenuItem.Enabled = false;
                alumnosToolStripMenuItem.Enabled = true;
                salonesToolStripMenuItem.Enabled = true;
                reportesToolStripMenuItem.Enabled = true;
                cursosToolStripMenuItem.Enabled = true;
            }

            timer1.Start();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());

           


        }

        public class MyColorTable : ProfessionalColorTable
        {



            public override Color MenuBorder
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemBorder
            {
                get
                {
                    return Color.Black;
                }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get
                {
                    return Color.Navy;
                }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get
                {
                    return Color.Navy;
                }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get
                {
                    return Color.Blue;
                }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get
                {
                    return Color.Blue;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblfecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Usuarios());
            /*Usuarios frmusu = new Usuarios();
            frmusu.ShowDialog();*/
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Alumnos());

           /* Alumnos frmalu = new Alumnos();
            frmalu.ShowDialog();*/
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Cursos());
           /* Cursos frmcur = new Cursos();
            frmcur.ShowDialog();*/
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
            DataTable dtalum = objn.N_totalalumnos();
            DataTable dtacur = objn.N_totalcurso();
            DataTable dtasal = objn.N_totalsalones();

            lbltotalalum.Text = dtalum.Rows[0][0].ToString();
            lbltotalcurs.Text = dtacur.Rows[0][0].ToString();
            lbltotalsalon.Text = dtasal.Rows[0][0].ToString();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Reportes());  
            /*Reportes frmreport = new Reportes();
            frmreport.ShowDialog();*/
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void salonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirFormHijo(new Salones());
            /*Salones frmsalones = new Salones();
            frmsalones.ShowDialog();*/
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            abrirFormHijo(new PassCambiar());
            /*PassCambiar frmpass = new PassCambiar();
            frmpass.ShowDialog();*/
        }

        private void boxmovform_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void boxmovform_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void abrirFormHijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
    }
}
