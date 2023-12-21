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
    public class ChangeElements : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;
            try
            {
                Reference r1 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
             
                if (r1 != null)
                {
                    using (Transaction trans = new Transaction(doc, "Change Element"))
                    {
                        trans.Start();
                        doc.Delete(r1.ElementId);
                        //Hien thi Dialog Yes/No to delete
                        TaskDialog tDialog = new TaskDialog("Delete Element");
                        tDialog.MainContent = "Are you sure";
                        tDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
                        if(tDialog.Show() == TaskDialogResult.Ok)
                        {
                            //Dong y Xoa
                            trans.Commit();
                            TaskDialog.Show("Delete Element", "Ban da xoa phan tu " + r1.ElementId.ToString());

                        } 
                        else
                        {
                            //Method Rollback cancel tat ca thao tac khi user muon cancel, khong thuc hien gi
                            trans.RollBack();
                            TaskDialog.Show("Delete Element", "Phan tu " + r1.ElementId.ToString() + " chua duoc xoa");
                        }                     
                        //Ket thuc thay doi
                        //trans.Commit();
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
