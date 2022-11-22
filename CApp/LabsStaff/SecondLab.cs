using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVChannelProject.Models;

namespace TVChannelProject.LabsStaff
{
    internal class SecondLab
    {
        //Вывод записей из таблицы Genres
        internal string SolveFirst(TvChannelContext context)
        {
            var result = String.Empty;

            result += "ID | Name | Description\n";

            var genres = from elem in context.Genres select new {Id = elem.Id, Name = elem.Name, Description = elem.Description};

            foreach (var elem in genres)
            {
                result += elem.Id + " | " + elem.Name + " | " + elem.Description + "\n";
            };

            return result;
        }

        //Вывод записей из таблицы Genres, где id - чётное значение
        internal string SolveSecond(TvChannelContext context)
        {
            var result = String.Empty;

            result += "ID | Name | Description\n";

            var genres = from elem in context.Genres select new { Id = elem.Id, Name = elem.Name, Description = elem.Description };

            foreach (var elem in genres)
            {
                if (elem.Id % 2 == 0)
                {
                    result += elem.Id + " | " + elem.Name + " | " + elem.Description + "\n";
                }
            };

            return result;
        }

        // Вывод среднего рейтинга передач
        internal string SolveThird(TvChannelContext context)
        {
            var result = String.Empty;

            result += "Average rating: ";

            result += (from elems in context.Programs select elems.Rating).Average();

            return result;
        }

        // Вывод программ с соответствующим жанром
        internal string SolveFourth(TvChannelContext context)
        {
            var result = String.Empty;

            result += "Program | Genre\n";

            var progen = from programs in context.Programs
                         join genres in context.Genres on programs.GenreId equals genres.Id
                         where programs.Id < 100
                         select new { Prog = programs.Name, Gen = genres.Name };

            foreach (var elem in progen)
            {
                result += elem.Prog + " | " + elem.Gen + "\n";
            }

            return result;
        }

        // Вывод программ с соответствующим жанром, где рейтинг выше, чем 0.6
        internal string SolveFifth(TvChannelContext context)
        {
            var result = String.Empty;

            result += "Program | Genre\n";

            var progen = from programs in context.Programs
                         join genres in context.Genres on programs.GenreId equals genres.Id
                         where programs.Id < 100 && programs.Rating > 0.6
                         select new { Prog = programs.Name, Gen = genres.Name };

            foreach (var elem in progen)
            {
                result += elem.Prog + " | " + elem.Gen + "\n";
            }

            return result;
        }

        //Добавление записи в таблицу Genres
        internal string SolveSixth(TvChannelContext context)
        {
            var result = String.Empty;

            context.Genres.Add(new Genre()
            {
                Id = context.Genres.Select(e => e.Id).Max() + 1,
                Name = "TestName",
                Description = "TestDescription"
            });

            context.SaveChanges();

            result += " Вставка успешна!";

            return result;
        }

        //Добавление записи в таблицу Programs
        internal string SolveSeventh(TvChannelContext context)
        {
            var result = String.Empty;

            var gId = context.Genres.Select(e => e.Id).Max();

            context.Programs.Add(new Models.Program() { 
                Id = context.Programs.Select(e => e.Id).Max() + 1,
                Name = "TestName",
                Length = "TL",
                Rating = 1,
                GenreId = gId,
                Description = "This is testing sample"
            });

            context.SaveChanges();

            result += " Вставка успешна!";

            return result;
        }

        //Удаление записей из таблицы Genres
        internal string SolveEighth(TvChannelContext context)
        {
            var result = String.Empty;

            var testSamples = context.Genres.Where(e => e.Name == "TestName");

            context.Genres.RemoveRange(testSamples);
            context.SaveChanges();

            result += "Удаление успешно!";

            return result;
        }

        //Удаление записей из таблицы Programs
        internal string SolveNinth(TvChannelContext context)
        {
            var result = String.Empty;

            var testSamples = context.Programs.Where(e => e.Name == "TestName");

            context.Programs.RemoveRange(testSamples);
            context.SaveChanges();

            result += "Удаление успешно!";

            return result;
        }

        //Обнвление имени первого жанра в таблице
        internal string SolveTenth(TvChannelContext context)
        {
            var result = String.Empty;

            Genre client = context.Genres.FirstOrDefault();
            client.Name = "ItWasUpdated";
            context.SaveChanges();

            result += "Изменено!";

            return result;
        }
    }
}
