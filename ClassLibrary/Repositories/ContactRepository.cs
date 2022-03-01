using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly DBModel _dBModel;

        /// <summary>
        /// Конcтурктор
        /// </summary>
        /// <param name="dBModel">Инстанс обращения к БД</param>
        public ContactRepository(DBModel dBModel) : base()
        {
            _dBModel = dBModel;
        }
        
        /// <summary>
        /// Добавление нового контакта в список контактов пользователя 
        /// </summary>
        /// <param name="contactDataModel"></param>
        public bool AddContact(ContactDataModel contactDataModel)
        {
            try
            {
                _dBModel.ContactDataModel.Add(contactDataModel);
                return true;
            } catch
            {
                return false;
            }
        }

        /// <summary>
        /// Удаление контакта 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public bool DeleteContact(int userId, int contactId)
        {
            var entity = _dBModel.ContactDataModel
                .Where(item => item.UserId == userId && item.ContactId == contactId).FirstOrDefault();
            if (entity == null)
            {
                return false;
            }
            else
            {
                _dBModel.ContactDataModel.Remove(entity);
                return true;
            }
        }

        /// <summary>
        /// Получение контакта пользователя 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="contactId"></param>
        /// <returns></returns>
        public ContactDataModel GetUserContact(int userId, int contactId)
        {
            var result = _dBModel.ContactDataModel
                .Where(item => item.UserId == userId && item.ContactId == contactId).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Получение списка контактов пользователя 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IQueryable<ContactDataModel> GetUserContacts(int userId)
        {
            var result = _dBModel.ContactDataModel.Where(item => item.UserId == userId).AsQueryable();
            return result;
        }

        /// <summary>
        /// Поиск контакта по имени в списке контактов пользователя
        /// Получаем список контактов пользователя и их ID
        /// С помощью ID джойнимся к таблице с юзерами
        /// С условием where делаем поиск по определенному имени
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public ContactDataModel SearchUserContacts(int userId,  string name)
        {
            var result = (from contactUser in _dBModel.ContactDataModel
                          join user in _dBModel.UserDataModel on contactUser.UserId equals user.Id
                          where user.Name == name
                          select contactUser).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Обновление данных контакта 
        /// </summary>
        /// <param name="contactDataModel"></param>
        /// <returns></returns>
        public bool UpdateContact(ContactDataModel updateContactDataModel)
        {
            try
            {
                var originContact = GetUserContact(updateContactDataModel.UserId, updateContactDataModel.ContactId);
                _dBModel.Entry(originContact).CurrentValues.SetValues(updateContactDataModel);
                return true;
            }
            catch
            {
                return false;
            }
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