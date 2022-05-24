using System;
using System.Linq;
using System.Threading.Tasks;
using PruebaFail.Web.Data;
using PruebaFail.Web.Data.Entities;

namespace PruebaFail.Web.Helpers
{
    public class AgendaHelper : IAgendaHelper
    {
        private readonly DataContext _dataContext;

        public AgendaHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddDaysAsync(int days)
        {
            DateTime initialDate;

            if (!_dataContext.Orders.Any())
            {
                initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            }
            else
            {
                var agenda = _dataContext.Orders.LastOrDefault();
                initialDate = new DateTime(agenda.Date.Year, agenda.Date.Month, agenda.Date.AddDays(1).Day, 8, 0, 0);
            }

            var finalDate = initialDate.AddDays(days);
            while (initialDate < finalDate)
            {
                if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var finalDate2 = initialDate.AddHours(10);
                    while (initialDate < finalDate2)
                    {
                        _dataContext.Orders.Add(new Order
                        {
                            Date = initialDate.ToUniversalTime(),
                            IsAvailable = true
                        });

                        initialDate = initialDate.AddMinutes(30);
                    }

                    initialDate = initialDate.AddHours(14);
                }
                else
                {
                    initialDate = initialDate.AddDays(1);
                }
            }

            await _dataContext.SaveChangesAsync();
        }
    }
}
