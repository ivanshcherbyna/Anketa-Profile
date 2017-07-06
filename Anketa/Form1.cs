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

namespace Anketa
{
    

    public partial class Form1 : Form
    {
        private SaveFileDialog save;
        private string filename;
        StreamWriter sw;
        private string anketText;
        string error = "Заполните все поля";
        public Form1()
        {
            string helloText = "Приветствую!\nХотите заполнить анкету?";
            if (MessageBox.Show(helloText, "Приветствие", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                InitializeComponent();
                lbSex.Items.Insert(0,"Мужщина");
                lbSex.Items.Insert(0,"Женщина");
            }
            else this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private string getAnket()
        {
            
            //if (!string.IsNullOrEmpty(lbSex.Text) || !string.IsNullOrEmpty(tbSurname.Text) || !string.IsNullOrEmpty(tbName.Text) || !string.IsNullOrEmpty(tbGoroskop.Text) || !string.IsNullOrEmpty(tbFathersName.Text))
            //{

                anketText = "Анкета: \n" + tbSurname.Text + " " + tbName.Text + " " + tbFathersName.Text + "\nПол: " + lbSex.SelectedItem + "\nВозраст: " + dtpBithDate.Value.Date + "\n" + tbGoroskop.Text + " знака по гороскопу.";
                return anketText;
            //}
            //else return error;
        }
        public void onSave(String texttoSave)
        {
            try
            {
                save = new SaveFileDialog();
                save.Filter = "Text files|*.txt|All files|*.*";
                save.ShowDialog();
                sw = new StreamWriter(save.FileName);
                this.filename = save.FileName;
                sw.Write(texttoSave);
                sw.Flush();
                sw.Close();

                                    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbSurname.Text = "";
            tbFathersName.Text = "";
            tbGoroskop.Text = "";
            dtpBithDate.Text = "";
            lbSex.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                onSave(getAnket());
            }
            catch (Exception ex) { MessageBox.Show(error);}
            }

        private void btnOk_Click(object sender, EventArgs e)
        {try
            {
                // if(!string.IsNullOrEmpty(lbSex.Text)|| !string.IsNullOrEmpty(tbSurname.Text)|| !string.IsNullOrEmpty(tbName.Text)|| !string.IsNullOrEmpty(tbGoroskop.Text)||!string.IsNullOrEmpty(tbFathersName.Text)) MessageBox.Show(getAnket());
                //else MessageBox.Show("Заполните все поля!");
                MessageBox.Show(getAnket());
            }
            catch (Exception ex) { MessageBox.Show(error);}
        }
    }
}

