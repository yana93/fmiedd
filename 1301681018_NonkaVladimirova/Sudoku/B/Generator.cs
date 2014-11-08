using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace B
{
    class Generator
    {
        //Този клас се дефинира в кода на формата. Има само една стасична
        //функция с име Random приемаща 1 параметър от клас Sector.
        //Неговата функционалност е да генерира с готовия клас Random 
        //стойноста на случайна клетка от сектора и да провери със статичните 
        //методи от класа GameArrays и методите на класа Cell

        static public void Random(Sector sector)
        {
            Random random = new Random();

            int allNumbersInSector = 0;

            while (allNumbersInSector < 3)
            {
                int cellIndex = random.Next(0, 8);
                int value = random.Next(0, 9);

                Cell cellRandom = null;
                cellRandom = sector.cells[cellIndex];

                int sectorIndex = GameArrays.SectorIndex(cellRandom);

                cellRandom.CellValue = value;

                if (Cell.GeneratorCheck(cellRandom))
                {
                    cellRandom.Enabled = false;
                    cellRandom.Generated = true;
                    //cellRandom.ForeColor = Color.DarkSlateBlue;
                    cellRandom.Text = Convert.ToString(value);
                    allNumbersInSector++;
                }
                else
                {
                    cellRandom.Enabled = true;
                    cellRandom.Generated = false;
                    allNumbersInSector=0;
                    cellRandom.Text = "";
                    cellRandom.CellValue = 0;
                    GameArrays.SetValueInArray(cellRandom, sectorIndex);
                }
            }

        }
    }
}
