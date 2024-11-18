using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VitApp_0._1._0.Otros_forms.Forms_Pantalla_principal
{
    public partial class FrmDietas : Form
    {
        private Dictionary<string, List<string>> dietas = new Dictionary<string, List<string>>();
        public FrmDietas()
        {
            InitializeComponent();
            InicializarComboBox();
            comboxnivel.SelectedIndexChanged += comboxnivel_SelectedIndexChanged;
            ComboBoxDias.SelectedIndexChanged += comboBoxDias_SelectedIndexChanged;
        }

        private void InicializarComboBox()
        {
         
            comboxnivel.Items.AddRange(new string[]
            {
                "Poco Activo", "Activo", "Muy Activo"
            });
            comboxnivel.SelectedIndex = 0; 

          
            for (int i = 1; i <= 7; i++)
            {
                ComboBoxDias.Items.Add($"Día {i}");
            }
            ComboBoxDias.SelectedIndex = 0; 
        }
        private string ObtenerComidaAleatoria(List<string> listaComidas)
        {
            var random = new Random();
            int index = random.Next(listaComidas.Count);
            return listaComidas[index];
        }


        private void btnDiaCompletado_Click(object sender, EventArgs e)
        {
            string nivelSeleccionado = comboxnivel.SelectedItem?.ToString();
            int diaSeleccionado = ComboBoxDias.SelectedIndex + 1;
            if (nivelSeleccionado != null)
            {
                MessageBox.Show($"¡Día {diaSeleccionado} completado para el nivel {nivelSeleccionado}!");
                
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un nivel de actividad y un día antes de marcar el día como completado.");
            }
        }

        private void comboBoxDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ComboBoxDias.SelectedIndex >= 0)
            {
                ActualizarDieta();
            }
        }

        private void comboxnivel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ActualizarDieta();
        }
        private void ActualizarDieta()
        {
           
            string nivelSeleccionado = comboxnivel.SelectedItem?.ToString();
            int diaSeleccionado = ComboBoxDias.SelectedIndex + 1; 

          
            if (string.IsNullOrEmpty(nivelSeleccionado) || diaSeleccionado < 1)
            {
                MessageBox.Show("Por favor, selecciona un nivel de actividad y un día válido.");
                return;
            }

           
            listBoxComidas.Items.Clear();

          
            List<string> comidasDelDia = CargarDietaPorNivelYDia(nivelSeleccionado, diaSeleccionado);

         
            if (comidasDelDia != null)
            {
                listBoxComidas.Items.AddRange(comidasDelDia.ToArray());
            }
        }
        private List<string> CargarDietaPorNivelYDia(string nivel, int dia)
        {
            string filePath = "";

           
            switch (nivel)
            {
                case "Poco Activo":
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "DietaPocoActivo.txt");
                    break;
                case "Activo":
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "DietaActivo.txt");
                    break;
                case "Muy Activo":
                    filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "DietaMuyActivo.txt");
                    break;
                default:
                    MessageBox.Show("Nivel de actividad no reconocido.");
                    return null;
            }

          
            if (File.Exists(filePath))
            {
                List<string> comidas = new List<string>();
                bool diaEncontrado = false;

                foreach (var linea in File.ReadAllLines(filePath))
                {
                    if (linea.StartsWith($"#ID{dia}"))
                    {
                        diaEncontrado = true;
                        continue;
                    }

                  
                    if (diaEncontrado)
                    {
                        if (linea.StartsWith("#ID"))
                            break; 
                        comidas.Add(linea);
                    }
                }

                if (comidas.Count > 0)
                    return comidas;
                else
                    MessageBox.Show($"No se encontró la dieta para el día {dia} en el archivo {filePath}.");
            }
            else
            {
                MessageBox.Show($"El archivo {filePath} no se encontró.");
            }

            return null;
        }

        private void FrmDietas_Load(object sender, EventArgs e)
        {

        }
    }
}
