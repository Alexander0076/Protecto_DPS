using System.Web;
using System.Web.Mvc;

namespace Vaterinaria
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new filtres.VerifySession());
        }
    }
}
