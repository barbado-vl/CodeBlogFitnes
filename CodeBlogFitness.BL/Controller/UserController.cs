using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController : ControllerBase
    {

        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User> Users { get; }                                                                         //                      !!!!!!!!!!!!!!  НЕ БЕЗОПАСНО
        
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;
        
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if(string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
                                 
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns> Пользователь приложения </returns>private List<User> GetUsersData()
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }
        
        public void SetNewUserData(string genderName, DateTime birthDate, double weigth = 1, double heigth = 1)
        {
            // проверка

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weigth;
            CurrentUser.Height = heigth;
            Save();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save(Users);
        }

 
    }
}
