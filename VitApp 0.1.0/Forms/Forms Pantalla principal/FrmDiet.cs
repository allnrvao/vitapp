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
    public partial class FrmDiet : Form
    {
        private Dictionary<string, (string Desayuno, string Almuerzo, string Cena)> dietaActual;
        private string nivelActividad;
        public FrmDiet(string nivelActividad)
        {
            InitializeComponent();
            this.nivelActividad = nivelActividad;
            CargarDietaPorNivel();
        }

        public FrmDiet()
        {
        }

        private void CargarDietaPorNivel()
        {
            try
            {
                string rutaArchivo = string.Empty;

                switch (nivelActividad)
                {
                    case "Poco Activo":
                        rutaArchivo = Path.Combine(Application.StartupPath, "Resources", "DietLittleActive.txt");
                        break;
                    case "Activo":
                        rutaArchivo = Path.Combine(Application.StartupPath, "Resources", "DietActive.txt");
                        break;
                    case "Muy Activo":
                        rutaArchivo = Path.Combine(Application.StartupPath, "Resources", "DietVeryActive.txt");
                        break;
                    default:
                        throw new Exception("Nivel de actividad desconocido.");
                }

                dietaActual = LeerArchivoDeDieta(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar dietas: {ex.Message}");
            }
        }
        private void CargarDieta(int puntaje)
        {
            string nivelActividad;

            // Determinar el nivel de actividad en función del puntaje
            if (puntaje <= 10)
                nivelActividad = "Poco Activo";
            else if (puntaje <= 20)
                nivelActividad = "Activo";
            else
                nivelActividad = "Muy Activo";

            // Mostrar el nivel de actividad
            MessageBox.Show($"Nivel de actividad: {nivelActividad}");

            // Actualizar las dietas según el nivel de actividad
            this.nivelActividad = nivelActividad;
            CargarDietaPorNivel();
        }
        private Dictionary<string, (string Desayuno, string Almuerzo, string Cena)> LeerArchivoDeDieta(string rutaArchivo)
        {
            var dieta = new Dictionary<string, (string Desayuno, string Almuerzo, string Cena)>();

            if (!File.Exists(rutaArchivo))
                throw new FileNotFoundException($"No se encontró el archivo: {rutaArchivo}");

            var lineas = File.ReadAllLines(rutaArchivo);
            string id = string.Empty;
            string desayuno = string.Empty, almuerzo = string.Empty, cena = string.Empty;

            foreach (var linea in lineas)
            {
                if (linea.StartsWith("#ID"))
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        dieta[id] = (desayuno, almuerzo, cena);
                    }

                    id = linea.Trim();
                    desayuno = almuerzo = cena = string.Empty;
                }
                else if (linea.StartsWith("Desayuno:"))
                {
                    desayuno = linea.Substring(9).Trim();
                }
                else if (linea.StartsWith("Almuerzo:"))
                {
                    almuerzo = linea.Substring(9).Trim();
                }
                else if (linea.StartsWith("Cena:"))
                {
                    cena = linea.Substring(5).Trim();
                }
            }

            if (!string.IsNullOrEmpty(id))
            {
                dieta[id] = (desayuno, almuerzo, cena);
            }

            return dieta;
        }

        private void MostrarDieta(TabPage tabPage, string dia)
        {
            try
            {
                if (dietaActual == null || dietaActual.Count == 0)
                {
                    MessageBox.Show("No se encontraron dietas disponibles.");
                    return;
                }

                // Obtener un ID de dieta aleatorio
                var ids = dietaActual.Keys.ToList();
                var random = new Random();
                var idRandom = ids[random.Next(ids.Count)];
                var dieta = dietaActual[idRandom];

                // Mostrar la dieta en el TabPage
                tabPage.Controls.Clear();

                Label lblDesayuno = new Label { Text = $"Desayuno: {dieta.Desayuno}", AutoSize = true, Top = 10, Left = 10 };
                Label lblAlmuerzo = new Label { Text = $"Almuerzo: {dieta.Almuerzo}", AutoSize = true, Top = 40, Left = 10 };
                Label lblCena = new Label { Text = $"Cena: {dieta.Cena}", AutoSize = true, Top = 70, Left = 10 };

                tabPage.Controls.Add(lblDesayuno);
                tabPage.Controls.Add(lblAlmuerzo);
                tabPage.Controls.Add(lblCena);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar dieta para {dia}: {ex.Message}");
            }
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PrincipalScreen principalScreen = new PrincipalScreen();
            principalScreen.ShowDialog();
            this.Close();
        }

        private void guna2GradientTileButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            // Aquí debes definir el nivel de actividad que quieres pasar
            string nivelActividad = "Activo"; // Cambia "Activo" según sea necesario

            FrmRoutine frmRoutine = new FrmRoutine(nivelActividad);
            frmRoutine.ShowDialog();

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

        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRecomendation frmRecomendation = new FrmRecomendation();
            frmRecomendation.ShowDialog();
            this.Close();
        }

        private void SaturdayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["SaturdayDiet"], "Sabado");
        }

        private void MondayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["MondayDiet"], "Lunes");
        }

        private void TuesdayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["TuesdayDiet"], "Martes");
        }

        private void WednesdayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["WednesdayDiet"], "Miercoles");
        }

        private void ThursdayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["ThursdayDiet"], "Jueves");
        }

        private void FridayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["FridayDiet"], "Viernes");
        }

        private void SundayDiet_Click(object sender, EventArgs e)
        {
            MostrarDieta(TabControlDiet.TabPages["SundayDiet"], "Domingo");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
