using System.Windows.Forms;

namespace Wordpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void boldButton_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Bold;
            wordPad.Font = new Font(wordPad.Font.FontFamily, wordPad.Font.Size, style);
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Italic;
            wordPad.Font = new Font(wordPad.Font.FontFamily, wordPad.Font.Size, style);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            FontStyle style = FontStyle.Underline;
            wordPad.Font = new Font(wordPad.Font.FontFamily, wordPad.Font.Size, style);
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            wordPad.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerButton_Click(object sender, EventArgs e)
        {
            wordPad.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            wordPad.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void sizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wordPad.Font = new Font(wordPad.Font.FontFamily, Convert.ToInt32(sizeComboBox.SelectedItem));
        }

        private void colorComboBox_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                wordPad.ForeColor = colorDialog.Color;
            }
        }

        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily font = new FontFamily(fontComboBox.SelectedItem.ToString());
            wordPad.Font = new Font(font, wordPad.Font.Size, wordPad.Font.Style);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (saveTextBox.Text.Length != 0)
            {
                if (wordPad.Text.Length != 0)
                {
                    File.WriteAllText($"{saveTextBox.Text}.txt", wordPad.Text);
                    MessageBox.Show("Your notes have been successfully saved.", "Successful!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("H-mm, the note section looks blank.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("You have to type the file name to save your notes.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            if (loadTextBox.Text.Length != 0)
            {
                if (File.Exists($"{loadTextBox.Text}.txt"))
                {
                    string readText = File.ReadAllText($"{loadTextBox.Text}.txt");
                    wordPad.Text = readText;
                }

                else
                {
                    MessageBox.Show("No such note file was found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("File name section looks blank.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}