using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamToDoList.ViewModels;
using XamToDoList.ViewModels.Services;

namespace XamToDoList.Utils
{
    public class Api
    {
        private IMessageService _messageService;
        private readonly string ApiUrl;
        private HttpClient _httpClient;

        public Api()
        {
            _messageService = DependencyService.Get<IMessageService>();
            ApiUrl = "http://todolist-lambda3.azurewebsites.net";
            _httpClient = new HttpClient() {BaseAddress = new Uri(ApiUrl)};
            _httpClient.MaxResponseContentBufferSize = 256000;
        }

        public async Task<IList<Tasks>> GetListTasksAsync(TodoListViewModel model)
        {
            try
            {
                model.IsLoading = true;
                var response =
                    await _httpClient.GetAsync("/api/todo");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    model.IsLoading = false;
                    return JsonConvert.DeserializeObject<IList<Tasks>>(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception ex)
            {
               await _messageService.DisplayAlert("Ocorreu um erro",
                    "Ocorreu um erro ao se conectar com o servidor, por favor, tente novamente.", "OK");
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<bool> SaveTaskAsync(Tasks task)
        {
            try
            {
                task.Done = false;
                var data = JsonConvert.SerializeObject(task);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync("/api/todo", content);
                return result.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await _messageService.DisplayAlert("Ocorreu um erro",
                    "Ocorreu um erro ao se conectar com o servidor, por favor, tente novamente.", "OK");
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
