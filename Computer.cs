using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class Computer:Field
    {
        public void StartComputer()
        {
            GenetarionField();
            P = 1;
            S = 4;
            C = 3;
            I = 2;
            GenerationCompFiled();
        }

        private void GenerationCompFiled()
        {
            Random rnd = new Random();
            int x ;
            int y ;
            while (P !=0)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
                bool check = CheckSpawn(x, y);
                if (check)
                {
                    CheckPlace(4, x, y,'P',P);
                }
            }
            while (I != 0)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
                bool check = CheckSpawn(x, y);
                if (check)
                {
                    CheckPlace(3, x, y, 'I', I);
                }

            }
            while (C != 0)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
                bool check = CheckSpawn(x, y);
                if (check)
                {
                    CheckPlace(2, x, y, 'C', C);
                }
            }
            while (S != 0)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
                bool check = CheckSpawn(x, y);
                if (check)
                {
                    CheckPlace(1, x, y, 'S', S);
                }

            }
        }
        public void DrawSecondMatrix()
        {
            WorkMatrix draw = new WorkMatrix();
            draw.DrawMatrix(_secondField, 1);
        }
        public void AttackCompute(Field user)
        {
            attack(user, 0, 0);
        }
        private void CheckPlace(int SizeShip,int x,int y, char Ship,int NameShip)
        {
            Random rnd2 = new Random();
            int ChoiceMove = rnd2.Next(0, 2);
            int CountAction=0;
            switch (ChoiceMove)
            {
                case 0:
                    if ((x + SizeShip) <= LengthX)
                    {
                        int count = 0;
                        while(count!=SizeShip)
                        {
                            ArrangementShips(x, y, Ship);
                            x++;
                            count++;
                            CountAction++;
                        }
                    }
               break;

                case 1:
                    if ((y + SizeShip) <= LengthY)
                    {
                        int count = 0;
                        while (count != SizeShip)
                        {
                            ArrangementShips(x, y, Ship);
                            y++;
                            count++;
                            CountAction++;
                        }
                    }
                    break;
            }
            CopyField(Ship, CountAction);
            countNeighbirs = 0;

        }
    }
}
