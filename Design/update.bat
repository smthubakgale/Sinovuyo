rem exit 

echo Enter Drive Path e.g 'H:' or 'F:'
set/p "Pt=Drive Path:"

rem Database Structure
robocopy %Pt%":\3. Project\MobileApp\Design\Database\tables" %Pt%":\3. Project\WebApp\Database\tables" /MIR /XX   
rem Database Methods 
robocopy %Pt%":\3. Project\MobileApp\Design\Models" %Pt%":\3. Project\WebApp\Models" /MIR /XX  /XF "DBModel.cs"       
rem Database Access 
robocopy %Pt%":\3. Project\MobileApp\Design\Controllers\Systems" %Pt%":\3. Project\WebApp\Controllers\Systems" /MIR /XX /XF "MapController.cs" 
rem ----------------- 
exit 