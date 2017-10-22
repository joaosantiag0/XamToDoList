using System.Threading.Tasks;

namespace XamToDoList.ViewModels.Services
{
    public interface INavigationService
    {
        Task GoToHome();
        Task GoToAdd();
    }
}