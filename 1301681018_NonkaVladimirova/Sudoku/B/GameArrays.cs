using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace B
{

    class GameArrays
    {
        //В класа GameArrays се съдържат 9-те матрици на судокуто подредени в списък
        //Списука е статичен за да може при всяка нова инстанция на класа Sector
        //Да се добави съответния масив. чрез метода AddArray()

        //Метода SetValueInArray приема 2 параметъра (един от класа Cell и един int)
        //чрез него добавяме в статичния масив стойност в сътветстващата позиция на
        //масива който на на index позиция

        //Метода CheckSector приема 2 параметъра (един от класа Cell и един int)
        //Неговата функционалност е да провери на съответцтващия статичен масив в
        //списъка да ли има вече такава стойност. Тъй като е от тип bool връща true или false


        //метода CheakAllArray приема само един параметър от клас Cell
        //Той има  switch  клауза с която взависимо от това в за кой сектор има 
        //въведена стойност проверева съседните с функциите CheckLine() и CheckColumn 
        //и връша false ако намери повторение.

        //метода CheckLine риема 2 параметъра (един от класа Cell и един int)
        //Спрямо пропуртито Line на Cell обектите разбираме в кой ред да направим 
        //проверка в подадения от CheakAllArray() съседен сектор

        //метода CheckColumn риема 2 параметъра (един от класа Cell и един int)
        //Спрямо пропуртито Column на Cell обектите разбираме в коя колона да направим 
        //проверка в подадения от CheakAllArray() съседен сектор


        //???? SectorIndex()
        static public List<int[,]> allArray = new List<int[,]>();

        public GameArrays()
        { 
        } 

        public void AddArray()
        {
            int[,] empty=new int [3,3];
            allArray.Add(empty);
        }

        static public void SetValueInArray(Cell cell,int index)
        {
            int line = cell.Line;
            int column = cell.Column;
            
            allArray[index][line, column] = cell.CellValue;             
        }
        
        public bool CheckSector(Cell cell)
        {
            int index = SectorIndex(cell);
            foreach (int i in allArray[index])
            {
                if (i == cell.CellValue)
                {
                    SetValueInArray(cell, index);
                    return false;
                }
            }
            SetValueInArray(cell, index);
            return true;
        }
       
        public bool CneckAllArray(Cell cell)
        {
            int index = SectorIndex(cell);
            switch (index)
            {
                case 0:
                    {
                        if (CheckLine(cell, 1))
                        {
                            if (CheckLine(cell, 2))
                            {
                                if (CheckColumn(cell, 3))
                                {
                                    if (CheckColumn(cell, 6))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        } 
                        return false;
                    }
                case 1:
                   {
                       if (CheckLine(cell, 0))
                        {
                            if (CheckLine(cell, 2))
                            {
                                if (CheckColumn(cell, 4))
                                {
                                    if (CheckColumn(cell, 7))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                       return false;
                    }
                case 2:
                    {
                        if (CheckLine(cell, 0))
                        {
                            if (CheckLine(cell, 1))
                            {
                                if (CheckColumn(cell, 5))
                                {
                                    if (CheckColumn(cell, 8))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        } 
                        return false;
                    }
                case 3:
                    {
                        if (CheckLine(cell, 4))
                        {
                            if (CheckLine(cell, 5))
                            {
                                if (CheckColumn(cell, 0))
                                {
                                    if (CheckColumn(cell, 6))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        } 
                        return false;
                    }
                case 4:
                    {
                        if (CheckLine(cell, 3))
                        {
                            if (CheckLine(cell, 5))
                            {
                                if (CheckColumn(cell, 1))
                                {
                                    if (CheckColumn(cell, 7))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                case 5:
                    {
                        if (CheckLine(cell, 4))
                        {
                            if (CheckLine(cell, 3))
                            {
                                if (CheckColumn(cell, 2))
                                {
                                    if (CheckColumn(cell, 8))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                case 6:
                    {
                        if (CheckLine(cell, 7))
                        {
                            if (CheckLine(cell, 8))
                            {
                                if (CheckColumn(cell, 0))
                                {
                                    if (CheckColumn(cell, 3))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                case 7:
                    {
                        if (CheckLine(cell, 6))
                        {
                            if (CheckLine(cell, 8))
                            {
                                if (CheckColumn(cell, 1))
                                {
                                    if (CheckColumn(cell, 4))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                case 8:
                    {
                        if (CheckLine(cell, 6))
                        {
                            if (CheckLine(cell, 7))
                            {
                                if (CheckColumn(cell, 2))
                                {
                                    if (CheckColumn(cell, 5))
                                        return true;
                                    return false;
                                }
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        public bool CheckLine(Cell cell,int index)
        {
            int line=cell.Line;
            for (int i=0; i < 3;i++ )
            {
                int k = allArray[index][line, i];
                if (k == cell.CellValue)
                {
                    return false; 
                }                
            }
            return true;
        }

        public bool CheckColumn(Cell cell, int index)
        {
            int column = cell.Column;
            for (int i = 0; i < 3; i++)
            {
                int k = allArray[index][i,column];
                if (k == cell.CellValue)
                {                   
                    return false;
                }
            }
            return true;
        }       

        static public int SectorIndex(Cell cell)
        {
            switch (cell.Sector)
            {
                case 'A':
                    {
                        return 0;
                    }
                case 'B':
                    {
                        return 1;
                    }
                case 'C':
                    {
                        return 2;
                    }
                case 'D':
                    {
                        return 3;
                    }
                case 'F':
                    {
                        return 4;
                    }
                case 'G':
                    {
                        return 5;
                    }
                case 'H':
                    {
                        return 6;
                    }
                case 'I':
                    {
                        return 7;
                    }
                case 'J':
                    {
                        return 8;
                    }
                default:
                    {
                        return 9;
                    }

            }
        }

        //static public string ToString()
        //{
        //    string result="";
        //    foreach (Array a in allArray)
        //    {
        //        foreach (int i in a)
        //        {
        //            result=result+Convert.ToString(i);
        //        }
        //    }
        //    return result;
        //}
    }
}
