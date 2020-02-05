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
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MinTetris
{
    //Settings windows
    //Вікно з налаштуваннями
    public partial class SettingsForm : Form
    {
        Main main;
        public String path = Environment.CurrentDirectory + @"\Settings.dat";
        Settings set;
        public SettingsForm(Main main)
        {
            InitializeComponent();
            this.main = main;
            //If there is no settings file, create one
            //Якщо немає файлу з налаштуваннями, то створити
            if (!File.Exists(path))
            {
                Reset();
            }
            else
            {
                Serializer load = new Serializer();
                //Load settings from file
                //інакше завантажити налаштування з файлу
                set = load.Deserialize(path) as Settings;
            }
            //Load fields with settings
            //завантаження полів з налаштуваннями
            settingsGrid.SelectedObject = set;
        }
        //Passing settings to the main program
        //Передача налаштувань до основної програми
        public Settings InitializeSettings()
        {
            return set;
        }
        //Settings to their defauls values
        //Встановлення налаштувань на значення за замовчуванням
        private void Reset()
        {
            set = new Settings();
            settingsGrid.SelectedObject = set;
            Serializer save = new Serializer();
            save.Serialize(path, set);
        }
        //'OK' button, save the changes, close the window
        //Кнопка "ОК", збереження налаштуваннь, закриття вікна
        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Serializer save = new Serializer();
            save.Serialize(path, set);
            Close();
            main.LoadSettings();
            main.ApplySize();
        }
        //'Cancel' button, close the window
        //Кнопка "Відміна", закриття вікна
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //'Reset' button, settings to their defauls values
        //Кнопка "Скинути", встановлення налаштувань на значення за замовчуванням
        private void resetBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure?", "Reset", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dr != DialogResult.Yes) return;
            Reset();
            settingsGrid.Refresh();
        }
    }
}