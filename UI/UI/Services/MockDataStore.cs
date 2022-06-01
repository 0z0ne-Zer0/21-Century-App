using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using Xamarin.Essentials;

namespace UI.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> items;
        private readonly PGRSQLWorker worker;

        public MockDataStore()
        {
            worker = new PGRSQLWorker(IP: SecureStorage.GetAsync("IPAdr").Result);
            var temp = worker.Read<int, string, string>("SELECT scid,name,url FROM subcat");
            foreach (var item in temp)
                items.Add(new Item { Id = item.Item1.ToString(), Name = item.Item2, Description = item.Item3 });
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}