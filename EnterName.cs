using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinTetris
{
    //Enter name if you got the top score
    //Клас для вводу імені при попаданні у список кращих гравців
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
        }
        //What happens when the form loads
        //Події при завантаженні форми
        private void EnterName_Load(object sender, EventArgs e)
        {
            //The field to enter the name becomes active
            //При завантаженні поле для вводу імені стає активним
            this.ActiveControl = playerName;
        }
        //'OK' button
        //Кнопка "ОК"
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        //When you enter the field to enter the name, the text becomes highlighted
        //При натисканні на полі вводу імені чи переході по клавіші "TAB" на це поле,
        //вміст поля виділяється (ім'я за замовчуванням)
        private void playerName_Enter(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(playerName.Text))
            {
                playerName.SelectionStart = 0;
                playerName.SelectionLength = playerName.Text.Length;
                //playerName.SelectAll();
            }
        }
        //'Cancel' button
        //Кнопка "Відміна" у діалоговому вікні
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
