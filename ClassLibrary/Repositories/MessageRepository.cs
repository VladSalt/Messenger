using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DBModel _dBModel;

        /// <summary>
        /// Конcтурктор
        /// </summary>
        /// <param name="dBModel">Инстанс обращения к БД</param>
        public MessageRepository(DBModel dBModel)
        {
            _dBModel = dBModel;
        }

        /// <summary>
        /// Добавление нового сообщения 
        /// </summary>
        /// <param name="messageDataModel"></param>
        /// <returns></returns>
        public bool AddMessage(MessageDataModel messageDataModel)
        {
            try
            {
                _dBModel.MessageDataModel.Add(messageDataModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Получение списка сообщение пользователя 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<MessageDataModel> GetUserMessages(int userId)
        {
            var result = _dBModel.MessageDataModel.Where(item => item.UserId == userId).AsQueryable();
            return result;
        }

        /// <summary>
        /// Поиск сообщения по строке в списке сообщений пользователя 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public MessageDataModel SearchUserMessages(int userId, int contactId, string query)
        {
            var result = _dBModel.MessageDataModel
                .Where(item => item.UserId == userId && item.ContactId == contactId && item.Content == query).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Сохраним изменения
        /// </summary>
        /// <returns></returns>
        public bool SaveAll()
        {
            if (_dBModel.ChangeTracker.HasChanges())
                return _dBModel.SaveChanges() > 0;
            else return true;
        }
    }
}