namespace Library.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Services.ViewComponents;
    using System.Threading.Tasks;

    public class WorkTimeViewComponent : ViewComponent
    {
        private readonly IGeneralWorkSchedule workSchedule;

        public WorkTimeViewComponent(IGeneralWorkSchedule workSchedule)
        {
            this.workSchedule = workSchedule;
        }

        public async Task<IViewComponentResult> InvokeAsync()
            => View(await workSchedule.ByGenralNameAsync());
    }

}
