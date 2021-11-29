using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_battle
{
    class SendMessagescs
    {
        public string ShowMessage(int P,int S, int C, int I)
        {
            Input_Info input = new Input_Info();
            Console.WriteLine("Выбирите корабль,который хотите разместить:\n(S-Однопалубный;Двухпалубный-C;Трёхпалубный-I;Четырёхпалубный-P (Англ. буквы и только большие)");
            Console.WriteLine("Однопалубный-" + S + "шт.\nДвухпалубный-" + C + "шт.\nТрёхпалубный-" + I + "шт.\nЧетырёхпалубный-" + P + "шт");
            string info=input.InputConosle();
            return info;
        }

        public string ShowMessage2(int Ship)
        {
            Input_Info input = new Input_Info();
            string ThisCoordinate="";
            Console.WriteLine("Чтобы разместить корабль на поле напишите кординаты размещения.");
            switch (Ship)
            {
                case 1:
                    Console.WriteLine("Введите сначалу букву,потом цифру(вводить без пробелов)-");
                    string coordinate = input.InputCoordinates();
                    ThisCoordinate = coordinate;
                    break;

                case 2:
                    Console.WriteLine("Введите сначалу букву,потом цифру(вводить без пробелов) начало корбля.Нажмите пробел,после того как вели первую координаут и введите также сначала букву потом цифру конца корабля." +
                        "Примре:A1 A2");
                    string coordinate2 = input.InputCoordinates();
                    ThisCoordinate = coordinate2;
                    break;


            }
            return ThisCoordinate;
        }

        public string ShowMessageAttack()
        {
            Input_Info input = new Input_Info();
            string ThisCoordinate = "";
            Console.WriteLine("Чтобы встрелить по полю протвиника,то введите сначалу букву,потом цифру(вводить без пробелов)-");
            string coordinate = input.InputCoordinates();
            ThisCoordinate = coordinate;
            return ThisCoordinate;
        }
        public void  ShowAction(int Answer)
        {
            if (Answer == 1)
            {
                Console.WriteLine("Бух Бах Бибих. Попал");
            }
            else
            {
                Console.WriteLine("Бух Бах Бибих. Но мимо :D");
            }
        }

    }
}
