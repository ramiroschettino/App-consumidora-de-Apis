using RYMApi.Controllers;
using RYMApi.Models;

namespace RYMApi
{
    public partial class Form1 : Form
    {
        private CharactersController CharactersController;
        private Characters characters;
        public Form1()
        {
            InitializeComponent();
            CharactersController = new CharactersController();
            characters = new Characters();
        }

        private async void GetCharacters() 
        {
            characters = await CharactersController.GetAllCharacters();
            if (characters != null)
            {
                foreach (var character in characters?.results!)
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
                MessageBox.Show("No se pudo obtener la petición.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            GetCharacters();
        }
    }
}
