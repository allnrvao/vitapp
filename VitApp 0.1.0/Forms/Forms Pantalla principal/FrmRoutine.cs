using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitApp_0._1._0.Otros_forms.Forms_Pantalla_principal
{
    public partial class FrmRoutine : Form
    {
        private Dictionary<string, string> rutinaActual;
        private string nivelActividad;

        public FrmRoutine(string nivelActividad)
        {
            InitializeComponent();
            this.nivelActividad = nivelActividad;
            CargarRutinasPorNivel();
            MostrarTodasLasRutinas(); // Mostrar todas las rutinas al cargar
        }


        private void CargarRutinasPorNivel()
        {
            try
            {
                string rutaArchivo = ObtenerRutaArchivo();

                if (string.IsNullOrEmpty(rutaArchivo) || !File.Exists(rutaArchivo))
                {
                    MessageBox.Show("No se encontró el archivo de rutinas correspondiente.");
                    return;
                }

                rutinaActual = LeerArchivoDeRutinas(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar rutinas: {ex.Message}");
            }
        }

        private string ObtenerRutaArchivo()
        {
            string carpetaRecursos = Path.Combine(Application.StartupPath, "Resources");
            string rutaArchivo = "";

            if (nivelActividad == "Poco Activo")
            {
                rutaArchivo = Path.Combine(carpetaRecursos, "RoutineLittleActive.txt");
            }
            else if (nivelActividad == "Activo")
            {
                rutaArchivo = Path.Combine(carpetaRecursos, "RoutineActive.txt");
            }
            else if (nivelActividad == "Muy Activo")
            {
                rutaArchivo = Path.Combine(carpetaRecursos, "RoutineVeryActive.txt");
            }

            return rutaArchivo;
        }

        private Dictionary<string, string> LeerArchivoDeRutinas(string rutaArchivo)
        {
            var rutinas = new Dictionary<string, string>();
            var lineas = File.ReadAllLines(rutaArchivo);
            string dia = string.Empty;
            string actividades = string.Empty;

            foreach (var linea in lineas)
            {
                if (linea.StartsWith("#"))
                {
                    if (!string.IsNullOrEmpty(dia))
                    {
                        rutinas[dia] = actividades.Trim();
                    }

                    dia = linea.Substring(1).Trim(); // Eliminar el "#" al inicio
                    actividades = string.Empty;
                }
                else
                {
                    actividades += linea + Environment.NewLine;
                }
            }

            if (!string.IsNullOrEmpty(dia))
            {
                rutinas[dia] = actividades.Trim();
            }

            return rutinas;
        }

        private void MostrarRutina(TabPage tabPage, string dia)
        {
            try
            {
                if (rutinaActual == null || !rutinaActual.ContainsKey(dia))
                {
                    tabPage.Controls.Clear();
                    Label lblNoRutina = new Label
                    {
                        Text = $"No se encontró una rutina para {dia}.",
                        AutoSize = true,
                        Top = 10,
                        Left = 10
                    };
                    tabPage.Controls.Add(lblNoRutina);
                    return;
                }

                string actividades = rutinaActual[dia];

                tabPage.Controls.Clear();
                Label lblRutina = new Label
                {
                    Text = actividades,
                    AutoSize = true,
                    Top = 10,
                    Left = 10
                };

                tabPage.Controls.Add(lblRutina);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar la rutina de {dia}: {ex.Message}");
            }
        }

        private void MostrarTodasLasRutinas()
        {
            MostrarRutina(TabControlRoutine.TabPages["MondayRoutine"], "Lunes");
            MostrarRutina(TabControlRoutine.TabPages["TuesdayRoutine"], "Martes");
            MostrarRutina(TabControlRoutine.TabPages["WednesdayRoutine"], "Miercoles");
            MostrarRutina(TabControlRoutine.TabPages["ThursdayRoutine"], "Jueves");
            MostrarRutina(TabControlRoutine.TabPages["FridayRoutine"], "Viernes");
            MostrarRutina(TabControlRoutine.TabPages["SaturdayRoutine"], "Sabado");
            MostrarRutina(TabControlRoutine.TabPages["SundayRoutine"], "Domingo");
        }
        private void guna2GradientTileButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
            string nivelActividad = "Activo"; // O el nivel dinámico calculado
            FrmDiet frmDietas = new FrmDiet(nivelActividad);
            frmDietas.ShowDialog();
            this.Close();
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalScreen principalScreen = new PrincipalScreen();
            principalScreen.ShowDialog();
            this.Close();
        }

        private void guna2GradientTileButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmProgress frmProgress = new FrmProgress();
            frmProgress.ShowDialog();
            this.Close();
        }

        private void guna2GradientTileButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmSetting frmConfiguration = new FrmSetting();
            frmConfiguration.ShowDialog();
            this.Close();
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogOut frmSesion1 = new FrmLogOut();
            frmSesion1.ShowDialog();
            this.Close();
        }
       
        private void FrmRoutine_Load(object sender, EventArgs e)
        {
            // Mostrar todas las rutinas al cargar el formulario
            MostrarTodasLasRutinas();

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["MondayRoutine"], "Lunes");
        }

        private void TuesdayRoutine_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["TuesdayRoutine"], "Martes");
        }

        private void WednesdayRoutine_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["WednesdayRoutine"], "Miercoles");
        }

        private void ThursdayRoutine_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["ThursdayRoutine"], "Jueves");
        }

        private void FridayRoutine_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["FridayRoutine"], "Viernes");
        }

        private void SaturdayRoutine_Click(object sender, EventArgs e)
        {
            MostrarRutina(TabControlRoutine.TabPages["SaturdayRoutine"], "Sabado");
        }

        private void SundayRoutine_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Descansa hoy y prepárate para la semana!", "Domingo");
        }
      

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
