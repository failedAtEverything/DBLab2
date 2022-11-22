using TVChannelProject.Models;

namespace TVChannelProject
{
    internal class DBMaster
    {
        static Random random = new Random();

        internal static void GenerateTablesData(TvChannelContext context)
        {
            GenerateGenre(context);
            GenerateProgram(context);
            GenerateEmployee(context);
            GenerateWeeklyProgramList(context);
            GenerateAppeal(context);
        }

        internal static void GenerateAppeal(TvChannelContext context)
        {
            for (int i = 0; i < 10000; i++)
            {
                var appeal = new Appeal() {
                    Id = i,
                    FullName = "Name" + i,
                    Organization = "Organization" + i,
                    AppealPurpose = "Purp" + i,
                    ProgramId = random.Next(299)
                };
                context.Appeals.Add(appeal);
            }

            context.SaveChanges();
        }

        internal static void GenerateProgram(TvChannelContext context)
        {
            for (int i = 0; i < 300; i++)
            {
                var program = new Models.Program() { 
                    Id=i,
                    Name="Name"+i,
                    Length="L"+i,
                    Rating=random.NextDouble(),
                    GenreId=random.Next(99),
                    Description="Desc"+i,
                };
                context.Programs.Add(program);
            }

            context.SaveChanges();
        }

        internal static void GenerateGenre(TvChannelContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                var genre = new Genre() { 
                    Id = i, 
                    Name = "Genre" + i, 
                    Description = "desc" + i 
                };
                context.Genres.Add(genre);
            }

            context.SaveChanges();
        }

        internal static void GenerateEmployee(TvChannelContext context)
        {
            for (int i = 0; i < 300; i++)
            {
                var employee = new Employee() {
                    Id=i,
                    FullName="Name"+i,
                    Position="Pos"+i
                };
                context.Employees.Add(employee);
            }

            context.SaveChanges();
        }

        internal static void GenerateWeeklyProgramList(TvChannelContext context)
        {
            for (int i = 0; i < 500; i++)
            {
                var programList = new WeeklyProgramList() { 
                    Id=i,
                    WeekNumber=random.Next(37),
                    WeekMonth=random.Next(12),
                    WeekYear=random.Next(2000, 2022),
                    StartTime = new TimeSpan(),
                    EndTime = new TimeSpan(),
                    ProgramId = random.Next(299),
                    EmployeesId = random.Next(299),
                    Guests = "Guests"+i
                };
                context.WeeklyProgramLists.Add(programList);
            }

            context.SaveChanges();
        }
    }
}
