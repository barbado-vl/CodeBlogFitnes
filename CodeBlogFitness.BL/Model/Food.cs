using System;

namespace CodeBlogFitness.BL.Controller
{
    [Serializable]
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы
        /// </summary>
        public double Carbohydrates { get; set; }
        /// <summary>
        /// Калории за 100гр продукта
        /// </summary>
        public double Calories { get; set; }

        public Food() { }

        public Food(string name) : this(name, 0, 0, 0, 0) { }    //  пустой конструктор только для имени


        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: проверка
            
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
