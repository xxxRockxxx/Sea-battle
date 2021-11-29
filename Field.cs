using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class Field
    {
        protected static int countShip;
        protected static int countNeighbirs;
        protected int LengthY = 9;
        protected int LengthX = 9;
        protected static int P;
        protected static int S;
        protected static int C;
        protected static int I;
        protected static char[,] _DuplicatemainField;
        protected static char[,] _mainField;
        protected static char[,] _secondField;
        protected static char[,] _FieldShootComputer;

        protected void GenetarionField()
        {
            _mainField = new char[10, 10];
            _secondField = new char[10, 10];
            _DuplicatemainField = new char[10, 10];
            _FieldShootComputer = new char[10, 10];
        }

        protected virtual void ArrangementShips(int x, int y, char Ship)
        {
            switch (Ship)
            {
                case 'S':
                    _DuplicatemainField[y, x] = 'S';
                    CheckNeighbors(x, y);
                    break;

                case 'P':
                    _DuplicatemainField[y, x] = 'P';
                    CheckNeighbors(x, y);
                    break;

                case 'C':
                    _DuplicatemainField[y, x] = 'C';
                    CheckNeighbors(x, y);
                    break;

                case 'I':
                    _DuplicatemainField[y, x] = 'I';
                    CheckNeighbors(x, y);
                    break;
            }
        }
        protected void attack(Field player, int x, int y)
        {
            player.shoot(x, y);
        }

        protected virtual void shoot(int x, int y)
        {
            if (_mainField[y, x] == 'S' || _mainField[y, x] == 'P' || _mainField[y, x] == 'C' || _mainField[y, x] == 'I')
            {
                _mainField[y, x] = 'X';
                ChangeSecondMatrixAndMasage(x, y, 1);
            }
            else
            {
                ChangeSecondMatrixAndMasage(x, y, 0);
            }
        }

        protected void ChangeSecondMatrixAndMasage(int x, int y, int Answer)
        {
            SendMessagescs Action = new SendMessagescs();
            if (Answer == 1)
            {
                _secondField[y, x] = 'X';

                Action.ShowAction(1);
            }
            else
            {
                _secondField[y, x] = '1';
                Action.ShowAction(0);
            }
        }

        protected void CheckNeighbors(int x, int y)
        {
            if (y == 0)
            {
                if (x == 0)
                {
                    if (_mainField[y, x + 1] != 0 || _mainField[y + 1, x] != 0 || _mainField[y + 1, x + 1] != 0)
                    {
                        countNeighbirs++;
                    }
                }

                else if (x != 0 & x != LengthX)
                {
                    if (_mainField[y, x + 1] != 0 || _mainField[y + 1, x + 1] != 0 || _mainField[y + 1, x - 1] != 0 || _mainField[y, x - 1] != 0 || _mainField[y + 1, x] != 0)
                    {
                        countNeighbirs++;
                    }
                }
                else if (x == LengthX)
                {
                    if (_mainField[y, x - 1] != 0 || _mainField[y + 1, x - 1] != 0 || _mainField[y + 1, x] != 0)
                    {
                        countNeighbirs++;
                    }
                }
            }
            else if (y != LengthY & y != 0)
            {
                if (x == 0)
                {
                    if (_mainField[y + 1, x] != 0 || _mainField[y + 1, x + 1] != 0 || _mainField[y, x + 1] != 0 || _mainField[y - 1, x + 1] != 0 || _mainField[y - 1, x] != 0)
                    {
                        countNeighbirs++;
                    }
                }
                else if (x == LengthX)
                {
                    if (_mainField[y + 1, x] != 0 || _mainField[y + 1, x - 1] != 0 || _mainField[y, x - 1] != 0 || _mainField[y - 1, x - 1] != 0 || _mainField[y - 1, x] != 0)
                    {
                        countNeighbirs++;
                    }
                }
                else
                {
                    if (_mainField[y + 1, x] != 0 || _mainField[y + 1, x - 1] != 0 || _mainField[y, x - 1] != 0 || _mainField[y - 1, x - 1] != 0 || _mainField[y - 1, x] != 0
                        || _mainField[y - 1, x + 1] != 0 || _mainField[y, x + 1] != 0 || _mainField[y + 1, x + 1] != 0)
                    {
                        countNeighbirs++;
                    }
                }
            }
            else if (y == LengthY)
            {
                if (x == 0)
                {
                    if (_mainField[y - 1, x] != 0 || _mainField[y - 1, x + 1] != 0 || _mainField[y, x + 1] != 0)
                    {
                        countNeighbirs++;
                    }
                }
                else if (x == LengthX)
                {
                    if (_mainField[y - 1, x] != 0 || _mainField[y - 1, x - 1] != 0 || _mainField[y, x - 1] != 0)
                    {
                        countNeighbirs++;
                    }
                }
                else if (x != 0 & x != LengthX)
                {
                    if (_mainField[y - 1, x] != 0 || _mainField[y - 1, x - 1] != 0 || _mainField[y, x - 1] != 0 || _mainField[y - 1, x + 1] != 0 || _mainField[y, x + 1] != 0)
                    {
                        countNeighbirs++;
                    }

                }
            }
        }

        protected void CopyField(char Ship, int CountAction)
        {
            if (countNeighbirs == 0 & CountAction != 0)
            {
                for (int i = 0; i < _mainField.GetLength(0); i++)
                {
                    for (int j = 0; j < _mainField.GetLength(1); j++)
                    {
                        _mainField[i, j] = _DuplicatemainField[i, j];
                    }
                }
                switch (Ship)
                {
                    case 'P':
                        P--;
                        break;
                    case 'C':
                        C--;
                        break;
                    case 'I':
                        I--;
                        break;
                    case 'S':
                        S--;
                        break;
                }
                countShip++;
            }
            else
            {
                for (int i = 0; i < _mainField.GetLength(0); i++)
                {
                    for (int j = 0; j < _mainField.GetLength(1); j++)
                    {
                        _DuplicatemainField[i, j] = _mainField[i, j];
                    }
                }
            }
        }

        protected bool CheckSpawn(int x, int y)
        {
            if (_DuplicatemainField[y, x] == 0)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        protected bool CountShip(Field User)
        {
            bool workGame = User.Account();
            return workGame;
        }
        protected bool Account()
        {
            int count=0;
            for (int i = 0; i < _mainField.GetLength(0); i++)
            {
                for (int j = 0; j < _mainField.GetLength(1); j++)
                {
                    if (_mainField[i, j] == 'S' || _mainField[i, j] == 'P' || _mainField[i, j] == 'C' || _mainField[i, j] == 'I')
                    {
                        count++;
                    }
                }
            }
            if (count == 0)
            {
                bool work = false;
                return work;
            }
            else
            {
                bool work = true;
                return work;
            }
        }
    }
}