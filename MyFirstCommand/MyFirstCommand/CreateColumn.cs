using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace MyFirstCommand
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class CreateColumn : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            List<string> listFamily = new List<string>() { "Cot vuong", "Cot tron", "Cot thep I" };
            List<string> listLevel = new List<string>() { "Level 1", "Level 2", "Level 3" };



            WPFCreateColumn creatColumnWindow = new WPFCreateColumn(listFamily, listLevel);
            creatColumnWindow.Show();
            try
            {
                //Phai dat qua trinh thay doi trong Transaction
                using (Transaction trans = new Transaction(doc, "Change Element"))
                {
                    trans.Start();

                    trans.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                return Result.Failed;
            }
        }
    }
}
