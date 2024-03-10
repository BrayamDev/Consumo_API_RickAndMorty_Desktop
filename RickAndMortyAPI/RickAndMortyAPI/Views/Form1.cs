using RickAndMortyAPI.Controllers;
using RickAndMortyAPI.Models;

namespace RickAndMortyAPI
{
    public partial class Form1 : Form
    {
        private CharacterController characters_controller;
        private Characters Characters_model;


        public Form1()
        {
            InitializeComponent();
            characters_controller = new CharacterController();
            Characters_model = new Characters();
        }

        private async void GetCharacters() 
        {
            Characters_model = await
                characters_controller.getAllCharacters();

            if (Characters_model != null)
            {
                foreach (var character in Characters_model?.results!)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dgvCharacters);

                    row.Cells[0].Value = character.name;
                    row.Cells[1].Value = character.gender;
                    row.Cells[2].Value = character.species;
                    row.Cells[3].Value = character.origin.name;

                    dgvCharacters.Rows.Add(row);
                }
            }
            else 
            {
                MessageBox.Show("No se pudo procesar la peticion", "error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

        }
            

        private void button1_Click(object sender, EventArgs e)
        {
            GetCharacters();
        }
    }
}
