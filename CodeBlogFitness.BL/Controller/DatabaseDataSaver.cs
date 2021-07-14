using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class DatabaseDataSaver<T> : IDataSaver
    {

#pragma warning disable CS0693 // Параметр типа имеет то же имя, что и параметр, указанный во внешнем типе
        public List<T> Load<T>() where T : class
#pragma warning restore CS0693 // Параметр типа имеет то же имя, что и параметр, указанный во внешнем типе
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

#pragma warning disable CS0693 // Параметр типа имеет то же имя, что и параметр, указанный во внешнем типе
        public void Save<T>(List<T> item) where T : class
#pragma warning restore CS0693 // Параметр типа имеет то же имя, что и параметр, указанный во внешнем типе
        {
            using(var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
