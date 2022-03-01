using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    /// <summary>
    /// Модель с данными о контактах пользователя
    /// Считаем, что ключ Id
    /// </summary>
    public class ContactDataModel
    {
        [Key]
        public int UserId { get; set; }
        public int ContactId  { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}