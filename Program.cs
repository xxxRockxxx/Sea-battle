using System;

namespace Sea_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            bool start_game = true;
            while (start_game)
            {
                Computer skynet = new Computer();
                WorkMatrix matrix = new WorkMatrix();
                SendMessagescs message = new SendMessagescs();
                Playercs user = new Playercs();
                bool count_ship = true;
                skynet.StartComputer();
                user.startGame();
                while (count_ship)
                {
                    if (count_ship)
                    {
                        matrix.ConsoleClear();
                        skynet.DrawSecondMatrix();
                        user.AttackPlayer(skynet);
                        count_ship = user.CountShipComputer(skynet);
                    }
                    if (count_ship)
                    {
                        matrix.ConsoleClear();
                        skynet.DrawSecondMatrix();
                        skynet.AttackCompute(user);
                        user.DrawMainMatrix();
                    }
                }

            }
        }
    }
}
