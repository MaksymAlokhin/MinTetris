using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Timers;


namespace MinTetris
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void InitializeTimer()
        {
            System.Timers.Timer DropTimer = new System.Timers.Timer();
            DropTimer.Interval = 3000;
            DropTimer.Enabled = true;
            DropTimer.Elapsed += OnDropTimerTick;
        }
        public void OnDropTimerTick(Object source, ElapsedEventArgs e)
        {
            Square.Paint(GlassPanel.g);
        }

        private void GlassPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = GlassPanel.CreateGraphics();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }
    }
}