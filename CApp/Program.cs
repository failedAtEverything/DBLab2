using TVChannelProject.LabsStaff;
using TVChannelProject.Models;

namespace TVChannelProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lab = new SecondLab();
            var key = -1;

            using (var context = new TvChannelContext()) {
                //DBMaster.GenerateTablesData(context);
                while (key != 0)
                {
                    Console.WriteLine("Введите номер задания или 0 для выхода:");
                    key = int.Parse(Console.ReadLine());

                    switch (key)
                    {
                        case 0:
                            Console.WriteLine("До свидания");
                            break;
                        case 1:
                            Console.WriteLine(lab.SolveFirst(context));
                            break;
                        case 2:
                            Console.WriteLine(lab.SolveSecond(context));
                            break;
                        case 3:
                            Console.WriteLine(lab.SolveThird(context));
                            break;
                        case 4:
                            Console.WriteLine(lab.SolveFourth(context));
                            break;
                        case 5:
                            Console.WriteLine(lab.SolveFifth(context));
                            break;
                        case 6:
                            Console.WriteLine(lab.SolveSixth(context));
                            break;
                        case 7:
                            Console.WriteLine(lab.SolveSeventh(context));
                            break;
                        case 8:
                            Console.WriteLine(lab.SolveEighth(context));
                            break;
                        case 9:
                            Console.WriteLine(lab.SolveNinth(context));
                            break;
                        case 10:
                            Console.WriteLine(lab.SolveTenth(context));
                            break;
                    }
                }
            }
        }
    }
}