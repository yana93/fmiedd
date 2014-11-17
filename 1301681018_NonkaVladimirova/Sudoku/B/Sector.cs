using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using System.Windows;
namespace B
{
    class Sector : GroupBox
    {       
        //Полета
        public List<Cell> cells = new List<Cell>();
        public  AllMatrices allMatrices = new AllMatrices();
        static char[] names = { 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I', 'J' };
        static int indexSectorName = 0;
        
        //Конструктор
        //Създават се 9 инстанции на клетки пазаят се в пропъртито cells за всеки сектор

        public Sector()
            : base()
        {
            allMatrices.AddArray();
                        
            Size = new Size(60, 60);
            
            int x = 0, y = 0;
            int column = 0, line = 0;

            for (int i = 0; i < 9; i++)
            {
                
                cells.Add(new Cell(names[indexSectorName], column, line));             
                cells[i].Location = new Point(x, y);                
                Controls.Add(cells[i]);
                
                x += 20;
                column++;

                if (i == 2) { x = 0; y = 20; column = 0; line = 1; };
                if (i == 5) { x = 0; y = 40; column = 0; line = 2; };
            }
            indexSectorName++;
        }

        //Метод който превръща стойностите на клетките от един сектор в низ
        //като на тези които са генерирани добава 20 а на другите 10

        static public string ToDataField(Sector sector)
        {
            string set = "";
            foreach (Cell cell in sector.cells)
            {
                int cellValue = cell.CellValue;
                if (cell.Generated)
                {
                    cellValue = cellValue + 20;
                    string newstring=Convert.ToString(cellValue);
                }
                else
                {
                    cellValue = cellValue + 10;
                }
                set += Convert.ToString(cellValue);
            }
            return set;
        }

        //този метод е обратният на ToDataField

        public void GetOldGame(string dataField)
        {
            int subIndexStart=0;
            foreach (Cell cell in this.cells)
            {
                string subStringCell = dataField.Substring(subIndexStart, 2);
                if (subStringCell.StartsWith("2"))
                {
                    cell.CellValue = Convert.ToInt32(subStringCell) - 20;
                    cell.Generated = true;
                    cell.Enabled = false;
                }
                else
                {
                    cell.CellValue = Convert.ToInt32(subStringCell) - 10;
                }
                if (cell.CellValue == 0)
                {
                    cell.Text = string.Empty;
                }
                else
                {
                   cell.Text = Convert.ToString(cell.CellValue);
                }
                subIndexStart = subIndexStart + 2;
                int indexSector = AllMatrices.SectorIndex(cell);
                AllMatrices.SetValueInArray(cell, indexSector);
            }
        }

        //Преди да се генерира нова игра трябва всеки сектор 
        //да се върне към първоначалните си настройки

        public static void ClearSector(Sector sector)
        {
            foreach (Cell cell in sector.cells)
            {
                cell.CellValue = 0;
                cell.Text = string.Empty;
                cell.Generated = false;
                cell.Enabled = true;

                int indexSector = AllMatrices.SectorIndex(cell);
                AllMatrices.SetValueInArray(cell, indexSector);
            }
        }
        
    }
}
