using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models
{
    /// <summary>
    /// Модель сообщения пользователя
    /// Считаем, что ключ Id
    /// </summary>
    public class MessageDataModel
    {
        [Key]
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public DateTime SendTime  { get; set; }
        public DateTime DeliveryTime { get; set; }
        public string Content { get; set; }
    }
}