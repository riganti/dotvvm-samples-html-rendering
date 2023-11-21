using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Controls;
using HtmlRendering.Model;

namespace HtmlRendering.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        public GridViewDataSet<CustomerModel> Customers { get; set; } = new GridViewDataSet<CustomerModel>()
        {
            PagingOptions =
            {
                PageSize = 10
            }
        };

        public string Html { get; set; }

        public override Task PreRender()
        {
            if (Customers.IsRefreshRequired)
            {
                Customers.LoadFromQueryable(DataProvider.GetSampleCustomersQueryable());
            }

            return base.PreRender();
        }

        public string GenerateHtml()
        {
            // get the instance of GridView so we can render it
            var grid = Context.View!.FindControlByClientId<GridView>("grid");
            
            // make the gridview to render all the rows and not just the template for one row
            grid.SetProperty(RenderSettings.ModeProperty, RenderMode.Server);
            
            // render the gridview into a custom HtmlWriter
            var stringWriter = new StringWriter();
            var htmlWriter = new HtmlWriter(stringWriter, Context);
            grid.Render(htmlWriter, Context);

            return stringWriter.ToString();
        }
    }
}
