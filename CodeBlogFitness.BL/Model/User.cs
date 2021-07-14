﻿using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }     //  т.е. без set менять имя не сможемv           //   Имя
        public Gender Gender { get; set; }                                          // Пол
        public DateTime BirthDate { get; set; }                                        // Дата рождения
        public double Weight { get; set; }                                     // Вес
        public double Height { get; set; }                                     // Рост

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        public User() { }

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост.</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка входных данных
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("Имя пользователя не может бытьпустым или null", nameof(name)); }
            if (gender == null) { throw new ArgumentNullException("Пол не может null", nameof(gender)); }
            if (birthDate  < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now) { throw new ArgumentNullException("Невозможная дата рождения", nameof(birthDate)); }
            if (weight <= 0) { throw new ArgumentNullException("Вес не может быть меньше либо равен нулю", nameof(weight)); }
            if (height <= 0) { throw new ArgumentNullException("Рост не может быть меньше либо равен нулю", nameof(height)); }
            # endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException("Имя пользователя не может бытьпустым или null", nameof(name)); }
            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
