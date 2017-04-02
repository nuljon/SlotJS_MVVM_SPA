using System.Web;
using System.Web.Mvc;

namespace SlotJS_MVVM_SPAS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
