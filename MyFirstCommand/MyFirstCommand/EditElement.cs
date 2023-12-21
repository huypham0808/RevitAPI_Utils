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
    public class EditElement : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            //Get Element Id
            
            try
            {
                Reference r1 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
                ElementId elementId = r1.ElementId;
                Element element = doc.GetElement(elementId);

                if (r1 != null)
                {

                    //Phai dat qua trinh thay doi trong Transaction
                    using (Transaction trans = new Transaction(doc, "Change Element"))
                    {
                        trans.Start();
                        //Move element
                        XYZ vectorMove = new XYZ(4, 4, 0);
                        ElementTransformUtils.MoveElement(doc, elementId, vectorMove);

                        //Rotate Element
                        LocationPoint locPoint = element.Location as LocationPoint;
                        XYZ p1 = locPoint.Point;
                        XYZ p2 = new XYZ(p1.X, p1.Y, p1.Z + 4);

                        Line axis = Line.CreateBound(p1, p2);
                        double angle = 30 * Math.PI / 180;
                        ElementTransformUtils.RotateElement(doc, elementId, axis, angle);

                        trans.Commit();
                    }                  
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
