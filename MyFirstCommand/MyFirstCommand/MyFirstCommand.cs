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
    public class MyFirstCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            try
            {
                Reference r1 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                ElementId elementId = r1.ElementId;
                Element element = doc.GetElement(elementId);

                //Get information of element
                ElementId elementIdType = element.GetTypeId();
                ElementType elementType = doc.GetElement(elementIdType) as ElementType;
                if (r1 != null)
                {
                    //TaskDialog.Show("Show result", r1.ElementId.ToString());
                    TaskDialog.Show("Element Infor", "Category: " + element.Category.Name + 
                        Environment.NewLine + "Name of ele: " + element.Name + 
                        Environment.NewLine + "Name of family type: " + elementType.FamilyName + 
                        Environment.NewLine + "Name of type - symbol: " + elementType.Name);
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
