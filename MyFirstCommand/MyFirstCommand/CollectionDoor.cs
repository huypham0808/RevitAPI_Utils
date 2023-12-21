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
    [TransactionAttribute(TransactionMode.ReadOnly)]
    public class CollectionDoor : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            //Create Filter
            FilteredElementCollector collection = new FilteredElementCollector(doc);
            ElementCategoryFilter filterDoor = new ElementCategoryFilter(BuiltInCategory.OST_Doors);

            //Apply Filter to collection
            IList<Element> doors=  collection.WherePasses(filterDoor).WhereElementIsNotElementType().ToElements();
            TaskDialog.Show("Count Door", doors.Count + "");

            return Result.Succeeded;
        }
    }
}
