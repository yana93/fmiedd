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
        //Неговата функция е да генерира с готовия клас Random 
        //стойноста на случайна клетка от сектора и да провери със статичните 
        //методи от класа AllMatrices и методите на класа Cell

        static public void Random(Sector sector)
        {
            Random random = new Random();

            //В секи сектор клетките който 
            //ще се генерират имат различен брой

            int allNumbersInSector = 0;         

            while (allNumbersInSector < 3)
            {
                int cellIndex = random.Next(0, 8);
                int value = random.Next(0, 9);

                Cell cellRandom = null;
                cellRandom = sector.cells[cellIndex];

                int sectorIndex = АllМatrices.SectorIndex(cellRandom);

                cellRandom.CellValue = value;

                if (Cell.GeneratorCheck(cellRandom))            //Генератора може няколко пъти да повтори една и съща клетка
                {                                               //но със различна стойност заради това са изредени всички пропъртита
                    cellRandom.Enabled = false;
                    cellRandom.Generated = true;
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
                    АllМatrices.SetValueInArray(cellRandom, sectorIndex);
                }
            }

        }
    }
}
