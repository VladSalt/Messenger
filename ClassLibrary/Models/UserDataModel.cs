using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    /// <summary>
    /// Модель с данными пользователя, получаемая из репозитория
    /// Считаем, что ключ Id
    /// </summary>
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool State { get; set; }
    }
}