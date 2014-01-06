using Parse;
using ParseStarterProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseStarterProject.Services
{
    public class ExternalDataService : IDataService
    {

        public Task<IEnumerable> GetUsers(string userID)
        {
            return this.GetUsersDataCore(userID);
        }

        private async Task<IEnumerable> GetUsersDataCore(string userID)
        {
            var data = await ParseUser.Query.Where(c=>c.ObjectId !=userID).FindAsync();

            return new ObservableCollection<UserModel>(from c in data select new UserModel(c));
        }

        private async Task<IEnumerable> GetToastsDataCore(string userID)
        {
            var data = await ParseObject.GetQuery("Toast").Include("Reciever").Include("Sender").FindAsync();

            return new ObservableCollection<ToastModel>(from c in data select new ToastModel(c));
        }


        private async Task<IEnumerable> GetUpdatesDataCore(string userID)
        {
            //Get all updates
            var updates = await ParseObject.GetQuery("Update").Include("User").FindAsync();

            var updatesModel = from c in updates select new UpdateModel(c);

            var groupedData = from u in updatesModel
                              group u by u.Date.Date into groupData
                              select new
                              {
                                  Name = groupData.Key,
                                  Items = groupData
                              };

            ObservableCollection<GroupedData<UpdateModel>> data = new ObservableCollection<GroupedData<UpdateModel>>();
            foreach (var item in groupedData)
            {
                GroupedData<UpdateModel> list = new GroupedData<UpdateModel>();
                list.Key = item.Name;
                foreach (var itemInGroup in item.Items)
                {
                    list.Add(itemInGroup);
                }
                data.Add(list);
            }

            return data;
        }

        public Task<IEnumerable> GetUpdates(string UserId)
        {
            return GetUpdatesDataCore(UserId);
        }

        public Task<IEnumerable> GetToasts(string UserId)
        {
            return GetToastsDataCore(UserId);
        }
    }
}
