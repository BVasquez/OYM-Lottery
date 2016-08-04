using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lottery
{
    public class LotteryClass
    {

        public void PrepareStage()
        {
            Directory.CreateDirectory("C:\\Lottery");
            StreamWriter ticket = new StreamWriter("C:\\Lottery\\ActualGame.txt");
            ticket.Close();

            StreamWriter manual = new StreamWriter("C:\\Lottery\\ReporteLoteriaManual.txt");
            manual.WriteLine(string.Format("     {0}", "Loteria LA SAQUE"));
            manual.WriteLine(string.Format("      {0}", "Reporte Manual"));
            manual.WriteLine("--------------------------");
            manual.Close();

            StreamWriter automatico = new StreamWriter("C:\\Lottery\\ReporteLoteriaAutomatico.txt");
            automatico.WriteLine(string.Format("     {0}", "Loteria LA SAQUE"));
            automatico.WriteLine(string.Format("    {0}", "Reporte Automatico"));
            automatico.WriteLine("--------------------------");
            automatico.Close();
        }


        public int[] AutomaticGame()
        {
            int[] LotNumber = new int[6];
            Random random = new Random();
            LotNumber[0] = random.Next(1, 38);
            LotNumber[1] = random.Next(1, 38);
            LotNumber[2] = random.Next(1, 38);
            LotNumber[3] = random.Next(1, 38);
            LotNumber[4] = random.Next(1, 38);
            LotNumber[5] = random.Next(1, 38);
            Ticket(LotNumber);
            Report(LotNumber, "Automatico");
            return LotNumber;
        }



        public void ManualGame(int[] numbers)
        {
            Ticket(numbers);
            Report(numbers, "Manual");
        }



        public void Ticket(int[] numbers)
        {
            int[] num = numbers;
            StreamWriter w = new StreamWriter("C:\\Lottery\\ActualGame.txt");
            w.WriteLine(string.Format("     {0}", "Loteria LA SAQUE"));
            w.WriteLine(string.Format("         {0}", "Ticket"));
            w.WriteLine(string.Format("   {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")));
            w.WriteLine("--------------------------");
            w.WriteLine(string.Format("  {0:00}  {1:00}  {2:00}  {3:00}  {4:00}  {5:00}", num[0], num[1], num[2], num[3], num[4], num[5]));
            w.WriteLine("--------------------------");
            w.Close();
        }



        public void Report(int[] numbers, string gameType)
        {
            int[] num = numbers;
            if(gameType == "Manual")
            {
                StreamWriter w = new StreamWriter("C:\\Lottery\\ReporteLoteriaManual.txt", true);
                w.WriteLine(string.Format("  {0:00}  {1:00}  {2:00}  {3:00}  {4:00}  {5:00}   | {6}", num[0], num[1], num[2], num[3], num[4], num[5], DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")));
                w.Close();
            }
            if (gameType == "Automatico")
            {
                StreamWriter w = new StreamWriter("C:\\Lottery\\ReporteLoteriaAutomatico.txt", true);
                w.WriteLine(string.Format("  {0:00}  {1:00}  {2:00}  {3:00}  {4:00}  {5:00}   | {6}", num[0], num[1], num[2], num[3], num[4], num[5], DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")));
                w.Close();
            }
        }

       

    }
}
