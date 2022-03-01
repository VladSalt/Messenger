using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DBModel _dBModel;

        /// <summary>
        /// Коснтурктор
        /// </summary>
        /// <param name="dBModel">Инстанс обращения к БД</param>
        public UserRepository(DBModel dBModel)
        {
            _dBModel = dBModel;
        }

        /// <summary>
        /// Добавление нового пользователя и возврат его ИД 
        /// </summary>
        /// <param name="userDataModel"></param>
        /// <returns></returns>
        public int AddUser(UserDataModel userDataModel)
        {
            try
            {
                // TODO: Переделать костыль поиска нового ключа. 
                // Он должен возвращаться после вставки данных, если ключ в базе инкремент
                // Но т.к. в задание стоит вернуть новый ключ, а про инкремент ничего не известно, то пусть будет так
                var newId = _dBModel.UserDataModel.Max(item => item.Id);
                userDataModel.Id = newId;
                _dBModel.UserDataModel.Add(userDataModel);

                return newId;
            }
            catch
            {
                // Костыль. 0, если вставка прошла с ошибкой. Лучше выкинуть ошибку
                return 0;
            }
        }

        /// <summary>
        /// Получения пользователя по ИД 
        /// </summary>
        /// <param name="useId"></param>
        /// <returns></returns>
        public UserDataModel GetUserById(int useId)
        {
            var result = _dBModel.UserDataModel.Find(useId);
            return result;
        }

        /// <summary>
        /// Получение пользователя по имени 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserDataModel GetUserByName(string username)
        {
            var result = _dBModel.UserDataModel.Where(item => item.Name == username).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Поиск пользователей по имени 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public IQueryable<UserDataModel> SearchUserByName(string query)
        {
            var result = _dBModel.UserDataModel.Where(item => item.Name == query).AsQueryable();
            return result;
        }

        /// <summary>
        /// Обновление данных пользователя 
        /// </summary>
        /// <param name="userDataModel"></param>
        /// <returns></returns>
        public bool UpdateUser(UserDataModel updateUserDataModel)
        {
            try
            {
                var originUser = GetUserById(updateUserDataModel.Id);
                _dBModel.Entry(originUser).CurrentValues.SetValues(updateUserDataModel);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateUserState(int userId, bool userState)
        {
            try
            {
                var originUser = GetUserById(userId);
                var resultUser = originUser;
                resultUser.State = userState;
                _dBModel.Entry(originUser).CurrentValues.SetValues(resultUser);
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