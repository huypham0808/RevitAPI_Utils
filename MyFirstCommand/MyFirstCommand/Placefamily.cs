﻿using System;
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
    public class Placefamily : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            //Find family
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> symbols = collector.OfClass(typeof(FamilySymbol)).WhereElementIsElementType().ToElements(); // Lay danh sach family type trong Revit
            FamilySymbol symbol = null;
            foreach (FamilySymbol sym in symbols)
            {
                if (sym.Name == "1525 x 762mm")
                {
                    symbol = sym as FamilySymbol;
                    break;
                }
            }
            // Dat family vao project, su dung method Family Instance
            try
            {
                using (Transaction trans = new Transaction(doc, "Change Element"))
                {
                    trans.Start();
                    if(!symbol.IsActive)
                    {
                        symbol.Activate();
                    }
                    doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), symbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
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
