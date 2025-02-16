### Post-build event Command Line
``Copy "$(TargetDir)MySecondPlugin.dll" "$(AppData)\Autodesk\Revit\Addins\2021"``
``if exist "$(AppData)\Autodesk\Revit\Addins\2021" copy "$(ProjectDir)*.addin" "$(AppData)\Autodesk\Revit\Addins\2021"``

### Directory store Add-in
``C:\Users\ad\AppData\Roaming\Autodesk\Revit\Addins\2021``
