using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class Playercs : Field
    {
        private static int shoot_x;
        private static int shoot_y;
        private static char symbolMiss;
        private static char symbolMove;
        private static char missShoot;
        private static char choiceMove;
        private static char lastShoot;
        private static int _shoot;
        private static int first_attack_x;
        private static int first_attack_y;
        private static int attack_x;
        private static int attack_y;

        public void startGame()
        {
            P = 1;
            S = 4;
            C = 3;
            I = 2;
            ActionPlayer();
        }
        private void ActionPlayer()
        {
            SendMessagescs message = new SendMessagescs();
            countShip = 0;
            WorkMatrix matrix = new WorkMatrix();
            while (countShip != 10)
            {
                string сhoice = message.ShowMessage(P, S, C, I);
                switch (сhoice)
                {
                    case "S":
                        string Coordinates = message.ShowMessage2(1);
                        TranslateCoordinates(Coordinates, 'S');
                        matrix.ConsoleClear();
                        matrix.DrawMatrix(_mainField, 2);
                        countShip++;
                        break;

                    case "P":
                        string Coordinates2 = message.ShowMessage2(2);
                        TranslateCoordinates(Coordinates2, 'P');
                        matrix.ConsoleClear();
                        matrix.DrawMatrix(_mainField, 2);
                        countShip++;
                        break;

                    case "C":
                        string Coordinates3 = message.ShowMessage2(2);
                        TranslateCoordinates(Coordinates3, 'C');
                        matrix.ConsoleClear();
                        matrix.DrawMatrix(_mainField, 2);
                        countShip++;
                        break;

                    case "I":
                        string Coordinates4 = message.ShowMessage2(2);
                        TranslateCoordinates(Coordinates4, 'I');
                        matrix.ConsoleClear();
                        matrix.DrawMatrix(_mainField, 2);
                        countShip++;
                        break;
                }

            }
        }

        public void DrawMainMatrix()
        {
            WorkMatrix draw = new WorkMatrix();
            draw.DrawMatrix(_mainField, 2);
        }
        public void AttackPlayer(Field computer)
        {
            WorkMatrix draw = new WorkMatrix();
            draw.DrawMatrix(_mainField, 2);
            SendMessagescs Attack = new SendMessagescs();
            string CoordinatesAttack = Attack.ShowMessageAttack();
            char Specialsymbol = 'A';//костыль??!?! :)
            TranslateCoordinates(CoordinatesAttack, Specialsymbol);
            attack(computer, shoot_x, shoot_y);
        }

        public  bool CountShipComputer(Field computer)
        {
            bool status=CountShip(computer);
            return status;
        }

        private void TranslateCoordinates(string Coordinates, char Ship)
        {
            int x = 0;
            int y = 0;
            int borderX = 0;
            int borderY = 0;
            bool Work = true;
            for (int j = 0; j < Coordinates.Length; j++)
            {
                if (Coordinates[j] == 'A')
                {
                    if (j > 1)
                    {
                        borderX = 0;
                    }
                    else
                    {
                        x = 0;
                    }
                }
                else if (Coordinates[j] == 'Б')
                {
                    if (j > 1)
                    {
                        borderX = 1;
                    }
                    else
                    {
                        x = 1;
                    }
                }
                else if (Coordinates[j] == 'В')
                {
                    if (j > 1)
                    {
                        borderX = 2;
                    }
                    else
                    {
                        x = 2;
                    }
                }
                else if (Coordinates[j] == 'Г')
                {
                    if (j > 1)
                    {
                        borderX = 3;
                    }
                    else
                    {
                        x = 3;
                    }
                }
                else if (Coordinates[j] == 'Д')
                {
                    if (j > 1)
                    {
                        borderX = 4;
                    }
                    else
                    {
                        x = 4;
                    }
                }
                else if (Coordinates[j] == 'Е')
                {
                    if (j > 1)
                    {
                        borderX = 5;
                    }
                    else
                    {
                        x = 5;
                    }
                }
                else if (Coordinates[j] == 'Ж')
                {
                    if (j > 1)
                    {
                        borderX = 6;
                    }
                    else
                    {
                        x = 6;
                    }
                }
                else if (Coordinates[j] == 'З')
                {
                    if (j > 1)
                    {
                        borderX = 7;
                    }
                    else
                    {
                        x = 7;
                    }
                }
                else if (Coordinates[j] == 'И')
                {
                    if (j > 1)
                    {
                        borderX = 8;
                    }
                    else
                    {
                        x = 8;
                    }
                }
                else if (Coordinates[j] == 'К')
                {
                    if (j > 1)
                    {
                        borderX = 9;
                    }
                    else
                    {
                        x = 9;
                    }
                }
                else
                {
                    if (j > 2)
                    {
                        borderY = Convert.ToInt32(Coordinates[j]);
                        borderY--;
                    }
                    else
                    {
                        y = Convert.ToInt32(Coordinates[j]);
                        y--;
                    }
                }
            }
            if ((borderX != 0 || borderY != 0) & Work & Ship!='A')
            {
                if (borderX == x)
                {
                    while (y != borderY + 1 & Work)
                    {
                        Work = CheckSpawn(x, y);
                        if (Work)
                        {
                            ArrangementShips(x, y, Ship);
                            y++;
                        }
                    }
                }
                else
                {
                    while (x != borderX + 1 & Work & Ship != 'A')
                    {
                        Work = CheckSpawn(x, y);
                        if (Work)
                        {
                            ArrangementShips(x, y, Ship);
                            x++;
                        }
                    }
                }
            }
            if (Ship == 'A')
            {
                shoot_x = x;
                shoot_y = y;
            }
            else
            {
                Work = CheckSpawn(x, y);
                if (Work)
                {
                    ArrangementShips(x, y, Ship);
                }
            }
            if (Ship != 'A')
            {
                int CountAction = 1;//Подумать что с этим сделать
                CopyField(Ship, CountAction);
                countNeighbirs = 0;
            }
        }

        protected override void shoot(int x, int y)
        {
            bool spin = true;
            if (_shoot == 0)
            {
                while (spin)
                {
                    Random rnd = new Random();
                    attack_x = rnd.Next(0, 10);
                    attack_y = rnd.Next(0, 10);
                    first_attack_x = attack_x;
                    first_attack_y = attack_y;
                    if (_FieldShootComputer[attack_y, attack_x] != '1')
                    {
                        spin = false;
                    }
                }
            }
            if (_mainField[attack_y, attack_x] == 'P' || lastShoot == 'P' || P != 0)
            {
                if (_mainField[attack_y, attack_x] == 'P')
                {
                    _mainField[attack_y, attack_x] = 'X';
                    lastShoot = 'P';
                    P = 3;
                    _shoot = 1;
                }
                else if (P != 3)
                {
                    if (choiceMove == 'X')
                    {
                        if (symbolMove == '+')
                        {
                            if (attack_x + 1 <= LengthX)
                            {
                                attack_x++;
                                if (_mainField[attack_y, attack_x] == 'P')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    P--;
                                }
                                else
                                {
                                    attack_x = first_attack_x;
                                    choiceMove = '-';
                                }
                            }
                            else
                            {
                                attack_x = first_attack_x;
                                symbolMove = '-';
                                attack_x--;
                                P--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                        else if (symbolMove == '-')
                        {
                            if (attack_x - 1 >= 0)
                            {
                                attack_x--;
                                if (_mainField[attack_y, attack_x] == 'P')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    P--;
                                }
                                else
                                {
                                    attack_x = first_attack_x;
                                    symbolMove = '+';
                                }
                            }
                            else
                            {
                                attack_x = first_attack_x;
                                symbolMove = '+';
                                attack_x++;
                                P--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }

                    }
                    else if (choiceMove == 'Y')
                    {
                        if (symbolMove == '+')
                        {
                            if (attack_y + 1 <= LengthY)
                            {
                                attack_y++;
                                if (_mainField[attack_y, attack_x] == 'P')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    P--;
                                }
                                else
                                {
                                    attack_y = first_attack_y;
                                    symbolMove = '-';
                                }
                            }
                            else
                            {
                                attack_y = first_attack_y;
                                symbolMove = '-';
                                attack_y--;
                                P--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                        else if (symbolMove == '-')
                        {
                            if (attack_y - 1 >= 0)
                            {
                                attack_y--;
                                if (_mainField[attack_y, attack_x] == 'P')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    P--;
                                }
                                else
                                {
                                    attack_y = first_attack_y;
                                    symbolMove = '+';
                                }
                            }
                            else
                            {
                                attack_y = first_attack_y;
                                symbolMove = '+';
                                attack_y++;
                                P--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                    }
                    if (P == 0)
                    {
                        _shoot = 0;
                        lastShoot = '0';
                        lastShoot = '0';
                        missShoot = '0';
                        symbolMiss = '0';
                        symbolMove = '0';
                    }
                }
                else
                {
                    if (missShoot != 'X')
                    {
                        if (symbolMiss != '+' & attack_x + 1 <= LengthX)
                        {
                            attack_x++;
                            if (_mainField[attack_y, attack_x] == 'P')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                P--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_x--;
                            if (_mainField[attack_y, attack_x] == 'P')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                P--;
                                symbolMove = '-';
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x++;
                                symbolMiss = '-';
                                missShoot = 'X';

                            }
                        }
                    }
                    else
                    {
                        if (symbolMiss != '+' & attack_y + 1 <= LengthY)
                        {
                            attack_y++;
                            if (_mainField[attack_y, attack_x] == 'P')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                P--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_y--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_y--;
                            if (_mainField[attack_y, attack_x] == 'P')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '-';
                                P--;
                            }
                        }

                    }
                }
            }
            else if (_mainField[attack_y, attack_x] == 'I' || lastShoot == 'I' || I != 0)
            {
                if (_mainField[attack_y, attack_x] == 'I')
                {
                    _mainField[attack_y, attack_x] = 'X';
                    lastShoot = 'I';
                    I = 2;
                    _shoot = 1;
                }
                else if (I != 2)
                {
                    if (choiceMove == 'X')
                    {
                        if (symbolMove == '+')
                        {
                            if (attack_x + 1 <= LengthX)
                            {
                                attack_x++;
                                if (_mainField[attack_y, attack_x] == 'I')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    I--;
                                }
                                else
                                {
                                    attack_x = first_attack_x;
                                    symbolMove = '-';
                                }
                            }
                            else
                            {
                                attack_x = first_attack_x;
                                symbolMove = '-';
                                attack_x--;
                                I--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                        else if (symbolMove == '-')
                        {
                            if (attack_x - 1 >= 0)
                            {
                                attack_x--;
                                if (_mainField[attack_y, attack_x] == 'I')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    I--;
                                }
                                else
                                {
                                    attack_x = first_attack_x;
                                    symbolMove = '+';
                                }
                            }
                            else
                            {
                                attack_x = first_attack_x;
                                symbolMove = '+';
                                attack_x++;
                                I--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }

                    }
                    else if (choiceMove == 'Y')
                    {
                        if (symbolMove == '+')
                        {
                            if (attack_y + 1 <= LengthY)
                            {
                                attack_y++;
                                if (_mainField[attack_y, attack_x] == 'I')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    I--;
                                }
                                else
                                {
                                    attack_y = first_attack_y;
                                    symbolMove = '-';
                                }
                            }
                            else
                            {
                                attack_y = first_attack_y;
                                symbolMove = '-';
                                attack_y--;
                                I--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                        else if (symbolMove == '-')
                        {
                            if (attack_y - 1 >= 0)
                            {
                                attack_y--;
                                if (_mainField[attack_y, attack_x] == 'I')
                                {
                                    _mainField[attack_y, attack_x] = 'X';
                                    I--;
                                }
                                else
                                {
                                    attack_y = first_attack_y;
                                    symbolMove = '+';
                                }
                            }
                            else
                            {
                                attack_y = first_attack_y;
                                symbolMove = '+';
                                attack_y++;
                                I--;
                                _mainField[attack_y, attack_x] = 'X';
                            }
                        }
                    }
                    if (I == 0)
                    {
                        _shoot = 0;
                        lastShoot = '0';
                        lastShoot = '0';
                        missShoot = '0';
                        symbolMiss = '0';
                    }
                }
                else
                {
                    if (missShoot != 'X')
                    {
                        if (symbolMiss != '+' & attack_x + 1 <= LengthX)
                        {
                            attack_x++;
                            if (_mainField[attack_y, attack_x] == 'I')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                I--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_x--;
                            if (_mainField[attack_y, attack_x] == 'I')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                I--;
                                symbolMove = '-';
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x++;
                                symbolMiss = '-';
                                missShoot = 'X';

                            }
                        }
                    }
                    else
                    {
                        if (symbolMiss != '+' & attack_y + 1 <= LengthY)
                        {
                            attack_y++;
                            if (_mainField[attack_y, attack_x] == 'I')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                I--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_y--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_y--;
                            if (_mainField[attack_y, attack_x] == 'I')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '-';
                                I--;
                            }
                        }

                    }
                }
            }
            else if (_mainField[attack_y, attack_x] == 'C' || lastShoot == 'C' || C != 0)
            {
                if (_mainField[attack_y, attack_x] == 'C')
                {
                    _mainField[attack_y, attack_x] = 'X';
                    lastShoot = 'C';
                    C = 1;
                    _shoot = 1;
                }
                else
                {
                    if (missShoot != 'X')
                    {
                        if (symbolMiss != '+' & attack_x + 1 <= LengthX)
                        {
                            attack_x++;
                            if (_mainField[attack_y, attack_x] == 'C')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                C--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_x--;
                            if (_mainField[attack_y, attack_x] == 'C')
                            {
                                choiceMove = 'X';
                                _mainField[attack_y, attack_x] = 'X';
                                C--;
                                symbolMove = '-';
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_x++;
                                symbolMiss = '-';
                                missShoot = 'X';

                            }
                        }

                    }
                    else
                    {
                        if (symbolMiss != '+' & attack_y + 1 <= LengthY)
                        {
                            attack_y++;
                            if (_mainField[attack_y, attack_x] == 'C')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '+';
                                C--;
                            }
                            else
                            {
                                //Компьютер промахнулся
                                attack_y--;
                                symbolMiss = '+';
                            }
                        }
                        else
                        {
                            attack_y--;
                            if (_mainField[attack_y, attack_x] == 'C')
                            {
                                choiceMove = 'Y';
                                _mainField[attack_y, attack_x] = 'X';
                                symbolMove = '-';
                                C--;
                            }
                        }

                    }
                    if (C == 0)
                    {
                        _shoot = 0;
                        lastShoot = '0';
                        lastShoot = '0';
                        missShoot = '0';
                        symbolMiss = '0';
                    }

                }
            }
            else if (_mainField[attack_y, attack_x] == 'S')
            {
                _mainField[attack_y, attack_x] = 'X';
            }
            _FieldShootComputer[attack_y, attack_x] = '1';
        }
    }
} 

