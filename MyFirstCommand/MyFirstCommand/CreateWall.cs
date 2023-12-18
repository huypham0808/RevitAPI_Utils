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
    public class CreateWall : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            //Find family
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            //IList<Element> symbols = collector.OfClass(typeof(FamilySymbol)).WhereElementIsElementType().ToElements(); // Lay danh sach family type trong Revit
            //Get level 1
            Level level = collector.OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .First(x => x.Name == "Level 1");
            //Create line
            XYZ p1 = new XYZ(0, 0, 0);
            XYZ p2 = new XYZ(10, 0, 0);

            XYZ p3 = new XYZ(100, 100, 0);
            XYZ p4 = new XYZ(200, 200, 0);
            Line line = Line.CreateBound(p1, p2);
            Line line2 = Line.CreateBound(p2, p3);
            try
            {
                //Phai dat qua trinh thay doi trong Transaction
                using (Transaction trans = new Transaction(doc, "Change Element"))
                {
                    trans.Start();
                    Wall.Create(doc, line, level.Id, false);
                    Wall.Create(doc, line2, level.Id, false);
                    trans.Commit();
                }
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }
        }
    }
}
