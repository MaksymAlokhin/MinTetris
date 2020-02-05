using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;
using System.ComponentModel;


namespace MinTetris
{
    //Program settings
    //Клас з налаштуваннями програми
    [Serializable]
    public class Settings
    {
        private Color iColor;
        private Color jColor;
        private Color lColor;
        private Color oColor;
        private Color sColor;
        private Color tColor;
        private Color zColor;
        private Color pFColor;
        private Color pFmColor;
        private Color pIColor;
        private Color pLColor;
        private Color pLmColor;
        private Color pNColor;
        private Color pNmColor;
        private Color pPColor;
        private Color pPmColor;
        private Color pTColor;
        private Color pUColor;
        private Color pVColor;
        private Color pWColor;
        private Color pXColor;
        private Color pYColor;
        private Color pYmColor;
        private Color pZColor;
        private Color pZmColor;
        private Color pHelperColor;
        private Color backColor;

        private int rows;
        private int columns;
        private int squareDimensions;
        
        private Keys moveDownKey;
        private Keys moveRightKey;
        private Keys moveLeftKey;
        private Keys rotateKey;
        private Keys pauseKey;
        
        private RotationDirection rotationDirection;
        private bool enabledGrid;
        private int startingLevel;
        private int startingSpeed;
        private int speedIncrease;
        private int newLevelThreshold;
        private int bonus1;
        private int bonus2;
        private int bonus3;
        private int bonus4;
        private int pentoHelper;
        #region Properties
        [Category("Colors")]
        [DefaultValue(typeof(Color), "RoyalBlue")]
        public Color IColor
        {
            get { return iColor; }
            set { iColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkBlue")]
        public Color JColor
        {
            get { return jColor; }
            set { jColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkOrange")]
        public Color LColor
        {
            get { return lColor; }
            set { lColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Gold")]
        public Color OColor
        {
            get { return oColor; }
            set { oColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "SeaGreen")]
        public Color SColor
        {
            get { return sColor; }
            set { sColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkViolet")]
        public Color TColor
        {
            get { return tColor; }
            set { tColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkRed")]
        public Color ZColor
        {
            get { return zColor; }
            set { zColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkSalmon")]
        public Color PFColor
        {
            get { return pFColor; }
            set { pFColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkSlateBlue")]
        public Color PFmColor
        {
            get { return pFmColor; }
            set { pFmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Coral")]
        public Color PIColor
        {
            get { return pIColor; }
            set { pIColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "CornflowerBlue")]
        public Color PLColor
        {
            get { return pLColor; }
            set { pLColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkGoldenrod")]
        public Color PLmColor
        {
            get { return pLmColor; }
            set { pLmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkGreen")]
        public Color PNColor
        {
            get { return pNColor; }
            set { pNColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Crimson")]
        public Color PNmColor
        {
            get {  return pNmColor; }
            set { pNmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DarkOrchid")]
        public Color PPColor
        {
            get { return pPColor; }
            set { pPColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Firebrick")]
        public Color PPmColor
        {
            get { return pPmColor; }
            set { pPmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Peru")]
        public Color PTColor
        {
            get { return pTColor; }
            set { pTColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "DodgerBlue")]
        public Color PUColor
        {
            get { return pUColor; }
            set { pUColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "IndianRed")]
        public Color PVColor
        {
            get { return pVColor; }
            set { pVColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "ForestGreen")]
        public Color PWColor
        {
            get { return pWColor; }
            set { pWColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "OrangeRed")]
        public Color PXColor
        {
            get { return pXColor; }
            set { pXColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "MediumVioletRed")]
        public Color PYColor
        {
            get { return pYColor; }
            set { pYColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Maroon")]
        public Color PYmColor
        {
            get { return pYmColor; }
            set { pYmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "SteelBlue")]
        public Color PZColor
        {
            get { return pZColor; }
            set { pZColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "LightSeaGreen")]
        public Color PZmColor
        {
            get { return pZmColor; }
            set { pZmColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Teal")]
        public Color PHelperColor
        {
            get { return pHelperColor; }
            set { pHelperColor = value; }
        }
        [Category("Colors")]
        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color BackgroundColor
        {
            get { return backColor; }
            set { backColor = value; }
        }
        [Category("Dimensions")]
        [Description("20 - 30")]
        [DefaultValue(20)]
        public int Rows
        {
            get { return rows; }
            set
            {
                if (value > 30 || value < 20) return;
                if (rows == value) return;
                rows = value;
            }
        }
        [Category("Dimensions")]
        [Description("10 - 20")]
        [DefaultValue(10)]
        public int Columns
        {
            get {return columns; }
            set
            {
                if (value > 20 || value < 10) return;
                if (columns == value) return;
                columns = value;
            }
        }
        [Category("Dimensions")]
        [Description("15 - 40")]
        [DefaultValue(30)]
        public int SquareDimensions
        {
            get { return squareDimensions; }
            set
            {
                if (value > 40 || value < 15) return;
                if (squareDimensions == value) return;
                squareDimensions = value;
            }
        }
        [Category("Keys")]
        [DefaultValue(typeof(Keys), "Down")]

        public Keys MoveDownKey
        {
            get { return moveDownKey; }
            set { moveDownKey = value; }
        }
        [Category("Keys")]
        [DefaultValue(typeof(Keys), "Right")]
        public Keys MoveRightKey
        {
            get { return moveRightKey; }
            set { moveRightKey = value; }
        }
        [Category("Keys")]
        [DefaultValue(typeof(Keys), "Left")]
        public Keys MoveLeftKey
        {
            get { return moveLeftKey; }
            set { moveLeftKey = value; }
        }
        [Category("Keys")]
        [DefaultValue(typeof(Keys), "Up")]
        public Keys RotateKey
        {
            get { return rotateKey; }
            set { rotateKey = value; }
        }
        [Category("Keys")]
        [DefaultValue(typeof(Keys), "P")]
        public Keys PauseKey
        {
            get { return pauseKey; }
            set { pauseKey = value; }
        }
        [Category("Misc")]
        [DefaultValue(RotationDirection.Clockwise)]
        public RotationDirection RotationDir
        {
            get { return rotationDirection; }
            set { rotationDirection = value; }
        }
        [Category("Misc")]
        [DefaultValue(true)]
        public bool GridEnabled
        {
            get { return enabledGrid; }
            set { enabledGrid = value; }
        }
        [Category("Misc")]
        [Description("0-20")]
        [DefaultValue(0)]
        public int StartingLevel
        {
            get { return startingLevel; }
            set
            {
                if (value < 0 || value > 20) return;
                if (value == startingLevel) return;
                startingLevel = value;
            }
        }
        [Category("Misc")]
        [Description("150-750\nIn miliseconds")]
        [DefaultValue(750)]
        public int StartingSpeed
        {
            get { return startingSpeed; }
            set
            {
                if (value > 750 || value < 150) return;
                if (value == startingSpeed) return;
                startingSpeed = value;
            }
        }
        [Category("Misc")]
        [Description("0-100\nEvery level. In miliseconds")]
        [DefaultValue(30)]
        public int SpeedIncrease
        {
            get { return speedIncrease; }
            set
            {
                if (value > 100 || value < 0) return;
                if (value == speedIncrease) return;
                speedIncrease = value;
            }
        }
        [Category("Misc")]
        [Description("1-10\nNew level every n lines")]
        [DefaultValue(10)]
        public int NewLevelThreshold
        {
            get { return newLevelThreshold; }
            set
            {
                if (value < 1 || value > 10) return;
                if (value == newLevelThreshold) return;
                newLevelThreshold = value;
            }
        }
        [Category("Misc")]
        [Description("0-100\nScore for 1 line")]
        [DefaultValue(100)]
        public int Bonus1
        {
            get { return bonus1; }
            set
            {
                if (value < 0 || value > 100) return;
                if (value == bonus1) return;
                bonus1 = value;
            }
        }
        [Category("Misc")]
        [Description("0-250\nScore for 2 lines")]
        [DefaultValue(250)]
        public int Bonus2
        {
            get { return bonus2; }
            set
            {
                if (value < 0 || value > 250) return;
                if (value == bonus2) return;
                bonus2 = value;
            }
        }
        [Category("Misc")]
        [Description("0-525\nScore for 3 lines")]
        [DefaultValue(525)]
        public int Bonus3
        {
            get { return bonus3; }
            set
            {
                if (value < 0 || value > 525) return;
                if (value == bonus3) return;
                bonus3 = value;
            }
        }
        [Category("Misc")]
        [Description("0-800\nScore for 4 lines")]
        [DefaultValue(800)]
        public int Bonus4
        {
            get { return bonus4; }
            set
            {
                if (value < 0 || value > 800) return;
                if (value == bonus4) return;
                bonus4 = value;
            }
        }
        [Category("Misc")]
        [Description("3-10\nEvery n-th Pentomino, help with a good piece")]
        [DefaultValue(3)]
        public int PentoHelper
        {
            get { return pentoHelper; }
            set
            {
                if (value < 3 || value > 10) return;
                if (value == pentoHelper) return;
                pentoHelper = value;
            }
        }
        #endregion
        public Settings()
        {
            Default();
        }
        //Initialize default settings
        //Ініціалізація значень за замовчуванням
        private void Default()
        {
            iColor = Color.RoyalBlue;
            jColor = Color.DarkBlue;
            lColor = Color.DarkOrange;
            oColor = Color.Gold;
            sColor = Color.SeaGreen;
            tColor = Color.DarkViolet;
            zColor = Color.DarkRed;
            pFColor = Color.DarkSalmon;
            pFmColor = Color.DarkSlateBlue;
            pIColor = Color.Coral;
            pLColor = Color.CornflowerBlue;
            pLmColor = Color.DarkGoldenrod;
            pNColor = Color.DarkGreen;
            pNmColor = Color.Crimson;
            pPColor = Color.DarkOrchid;
            pPmColor = Color.Firebrick;
            pTColor = Color.Peru;
            pUColor = Color.DodgerBlue;
            pVColor = Color.IndianRed;
            pWColor = Color.ForestGreen;
            pXColor = Color.OrangeRed;
            pYColor = Color.MediumVioletRed;
            pYmColor = Color.Maroon;
            pZColor = Color.SteelBlue;
            pZmColor = Color.LightSeaGreen;
            pHelperColor = Color.Teal;
            backColor = Color.Gainsboro;

            rows = 20;
            columns = 10;
            squareDimensions = 30;

            moveDownKey = Keys.Down;
            moveRightKey = Keys.Right;
            moveLeftKey = Keys.Left;
            rotateKey = Keys.Up;
            pauseKey = Keys.P;

            rotationDirection = RotationDirection.Clockwise;
            enabledGrid = true;
            startingLevel = 0;
            startingSpeed = 750;
            speedIncrease = 30;
            newLevelThreshold = 10;
            bonus1 = 100;
            bonus2 = 250;
            bonus3 = 525;
            bonus4 = 800;
            pentoHelper = 3;
        }
    }
}
