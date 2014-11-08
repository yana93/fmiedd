using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B
{
    // класа наследява TextBox
    class Cell : TextBox
    {
        // Полета на класа

        protected int column;       //позицията на клетката по колона
        protected int line;         //позицията на клетката по линия
        protected char sector;      //в кой сектор е клетката
        protected int value_cell;   //каква стйност има
        protected bool generated;   //да ли стойноста на клетката е зададена от генератора

        //Конструктор с и без параметри
        //Пропъртита на класа

        #region constructor and property

        public bool Generated
        {
            get { return generated; }
            set { generated = value; }
        }
        public int Column
        {
            get { return column; }
            private set { column = value; }
        }

        public int Line
        {
            get { return line; }
            private set { line = value; }
        }
        public char Sector
        {
            get { return sector; }
            private set { sector = value; }
        }
        public int CellValue
        {
            get { return value_cell; }
            set { value_cell = value; }
        }

        public Cell(char sector, int column, int line)
            : base()
        {
            this.sector = sector;
            this.column = column;
            this.line = line;
            this.value_cell = 0;
            this.generated = false;

            Size = new Size(20, 20);
            MaxLength = 1;

        }
        public Cell()
            : base()
        {
            this.column = 0;
            this.line = 0;
            this.sector='O';
            this.generated = false;

            Size = new Size(20, 20);
            MaxLength = 1;
        }
        #endregion

        //Събития който са  override от TextBox

        //При въвеждане на стойнот от клавиатурата тярбва 
        //да не се прихваща нищо друго освен цифри и backspace

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            int i = e.KeyChar;
            if (i >= 48 && i <= 57)
            {
                
            }
            else if (e.KeyChar == 8 )
            {
                if (Text.Length > 0) { Text = string.Empty; }
            }
            else e.Handled = true;
        }

        //При вече въведена стоийност трябва да проверим да ли се пофтаря
        //За да не ни се счупи кода ако полето е празно има  try и catch
        //В catch се задава стйност 0 на пропъртито CellValue.
        //след това имаме проверка за повторение в сектора ако имаме фоновия
        //цвят става червен.
        //По същия начин и за съседните сектори
        //Използваме методите от класа AllMatrices

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);                            
            BackColor = Color.White;
            try
            {
                CellValue = Convert.ToInt32(Text);
            }
            catch (Exception )
            {
                CellValue = 0;
                АllМatrices.SetValueInArray(this, АllМatrices.SectorIndex(this));
                return;
            }          
            
            АllМatrices gameArraysCheaks = new АllМatrices();

            if (!gameArraysCheaks.CheckSector(this))
            {                
                BackColor = Color.Red;
            }

            else if (!gameArraysCheaks.CneckInAllMatrices(this))
            {
                BackColor = Color.Red;
            }              
        }

        //Статичен метод който се използва от класа Generator 
        //Подобен е на кода в тялото на OnLeave но е статичен и
        //връща true или false

        static public bool GeneratorCheck(Cell cell)
        {
            АllМatrices gameArraysCheaks = new АllМatrices();
            if (!gameArraysCheaks.CheckSector(cell))
            {
                return false;
            }
            else if (!gameArraysCheaks.CneckInAllMatrices(cell))
            {
                return false;
            }
            else return true;
        }
 
    }
}
