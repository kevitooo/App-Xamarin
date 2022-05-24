using System.Threading.Tasks;

namespace PruebaFail.Web.Helpers
{
    public interface IAgendaHelper
    {
        Task AddDaysAsync(int days);
    }
}
