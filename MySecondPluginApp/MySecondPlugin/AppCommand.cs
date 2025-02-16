using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
namespace MySecondPlugin
{
    public class AppCommand : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            var tabName = "Huy Tool";
            var panelName = "My tool";
            RibbonPanel ribbonPanel = null;
            try
            {
                application.CreateRibbonTab(tabName);

            }
            catch (Exception ex)
            {
                TaskDialog.Show("Revit Warning", ex.Message.ToString());
            }
            try
            {
                application.CreateRibbonPanel(tabName, panelName);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Revit Warning", ex.Message.ToString());
            }
            if(ribbonPanel == null)
            {
                ribbonPanel = application.GetRibbonPanels(tabName).FirstOrDefault(p => p.Name == panelName);
            }
            if(ribbonPanel != null)
            {
                var assemblyPath = Assembly.GetExecutingAssembly().Location;
                var buttonName = "First Button";
                var buttonText = "Button text";
                var className = "MySecondPlugin.Command";

                var buttonData = new PushButtonData(buttonName, buttonText, assemblyPath, className)
                {
                    ToolTip = "Click on me.",
                    LargeImage = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(assemblyPath), "Resources", "button.png")))
                };
                ribbonPanel.AddItem(buttonData);
            }
            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
