using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using B.DataClass;
using System.Windows.Forms;

namespace B
{
    public partial class Sudoku : Form
    {
        static Game game = new Game();
        static GameRepository gamerepository = new GameRepository();

        static Sector sectorA = new Sector();
        static Sector sectorB = new Sector();
        static Sector sectorC = new Sector();
        static Sector sectorD = new Sector();
        static Sector sectorF = new Sector();
        static Sector sectorG = new Sector();
        static Sector sectorH = new Sector();
        static Sector sectorI = new Sector();
        static Sector sectorJ = new Sector();
        public Sudoku()
        {
            InitializeComponent();         
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Controls.Add(sectorA);
            sectorA.Location = new Point(54, 10);
            Controls.Add(sectorB);
            sectorB.Location = new Point(120, 10);
            Controls.Add(sectorC);
            sectorC.Location = new Point(185, 10);
                        
            Controls.Add(sectorD);
            sectorD.Location = new Point(54, 73);
            Controls.Add(sectorF);
            sectorF.Location = new Point(120, 73);
            Controls.Add(sectorG);
            sectorG.Location = new Point(185, 73);

            Controls.Add(sectorH);
            sectorH.Location = new Point(54, 136);
            Controls.Add(sectorI);
            sectorI.Location = new Point(120, 136);
            Controls.Add(sectorJ);
            sectorJ.Location = new Point(185, 136);

            //GameRepository gamerepository = new GameRepository(); 
            Game oldgame = null;
            if (gamerepository.Select(AuthenticationService.LoggedUser.user_ID) == null)
            {
                Generator.Random(sectorA);
                Generator.Random(sectorB);
                Generator.Random(sectorC);
                Generator.Random(sectorD);
                Generator.Random(sectorF);
                Generator.Random(sectorG);
                Generator.Random(sectorH);
                Generator.Random(sectorI);
                Generator.Random(sectorJ);

                game.user_ID = AuthenticationService.LoggedUser.user_ID;
                game.A = Sector.ToDataField(sectorA);
                game.B = Sector.ToDataField(sectorB);
                game.C = Sector.ToDataField(sectorC);
                game.D = Sector.ToDataField(sectorD);
                game.F = Sector.ToDataField(sectorF);
                game.G = Sector.ToDataField(sectorG);
                game.H = Sector.ToDataField(sectorH);
                game.I = Sector.ToDataField(sectorI);
                game.J = Sector.ToDataField(sectorJ);
                gamerepository.SaveGame(game);
            }
            else
            {
                oldgame=gamerepository.Select(AuthenticationService.LoggedUser.user_ID);
                sectorA.GetOldGame(oldgame.A);
                sectorB.GetOldGame(oldgame.B);
                sectorC.GetOldGame(oldgame.C);
                sectorD.GetOldGame(oldgame.D);
                sectorF.GetOldGame(oldgame.F);
                sectorG.GetOldGame(oldgame.G);
                sectorH.GetOldGame(oldgame.H);
                sectorI.GetOldGame(oldgame.I);
                sectorJ.GetOldGame(oldgame.J);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            game.user_ID = AuthenticationService.LoggedUser.user_ID;
            game.A = Sector.ToDataField(sectorA);
            game.B = Sector.ToDataField(sectorB);
            game.C = Sector.ToDataField(sectorC);
            game.D = Sector.ToDataField(sectorD);
            game.F = Sector.ToDataField(sectorF);
            game.G = Sector.ToDataField(sectorG);
            game.H = Sector.ToDataField(sectorH);
            game.I = Sector.ToDataField(sectorI);
            game.J = Sector.ToDataField(sectorJ);

            gamerepository.UpdateGame(game);

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            gamerepository.Delete(AuthenticationService.LoggedUser.user_ID);

            Sector.ClearSector(sectorA);
            Sector.ClearSector(sectorB);
            Sector.ClearSector(sectorC);
            Sector.ClearSector(sectorD);
            Sector.ClearSector(sectorF);
            Sector.ClearSector(sectorG);
            Sector.ClearSector(sectorH);
            Sector.ClearSector(sectorI);
            Sector.ClearSector(sectorJ);

            Generator.Random(sectorA);
            Generator.Random(sectorB);
            Generator.Random(sectorC);
            Generator.Random(sectorD);
            Generator.Random(sectorF);
            Generator.Random(sectorG);
            Generator.Random(sectorH);
            Generator.Random(sectorI);
            Generator.Random(sectorJ);


            game.user_ID = AuthenticationService.LoggedUser.user_ID;
            game.A = Sector.ToDataField(sectorA);
            game.B = Sector.ToDataField(sectorB);
            game.C = Sector.ToDataField(sectorC);
            game.D = Sector.ToDataField(sectorD);
            game.F = Sector.ToDataField(sectorF);
            game.G = Sector.ToDataField(sectorG);
            game.H = Sector.ToDataField(sectorH);
            game.I = Sector.ToDataField(sectorI);
            game.J = Sector.ToDataField(sectorJ);
            gamerepository.SaveGame(game);
        }
    }
}
