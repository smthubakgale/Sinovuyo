rem exit 

echo Enter Drive Path e.g 'H:' or 'F:'
set/p "Pt=Drive Path:"

if not exist %Pt%":\3. Project\WebApp\Content\Design" mkdir %Pt%":\3. Project\WebApp\Content\Design"

if not exist %Pt%":\3. Project\WebApp\Content\Design\Layout" mkdir %Pt%":\3. Project\WebApp\Content\Design\Layout"
if not exist %Pt%":\3. Project\WebApp\Content\Design\Pages" mkdir %Pt%":\3. Project\WebApp\Content\Design\Pages"

if not exist %Pt%":\3. Project\WebApp\Content\Design\Layout\asset" mkdir %Pt%":\3. Project\WebApp\Content\Design\Layout\asset"
if not exist %Pt%":\3. Project\WebApp\Content\Design\Pages\assets" mkdir %Pt%":\3. Project\WebApp\Content\Design\Pages\assets"


robocopy %Pt%":\3. Project\MobileApp\Design.Android\Assets\Content\asset" %Pt%":\3. Project\WebApp\Content\Design\Layout\asset" /MIR /XX /XF "loader.js"
robocopy %Pt%":\3. Project\MobileApp\Design.Android\Assets\Content\assets" %Pt%":\3. Project\WebApp\Content\Design\Pages\assets" /MIR /XX 

robocopy %Pt%":\3. Project\MobileApp\Design.Android\Assets\Content" %Pt%":\3. Project\WebApp\Content\Design\Layout" "layout.html" /XO   
robocopy %Pt%":\3. Project\MobileApp\Design.Android\Assets\Content" %Pt%":\3. Project\WebApp\Content\Design\Layout" "build.bat" /XO   
robocopy %Pt%":\3. Project\MobileApp\Design.Android\Assets\Content" %Pt%":\3. Project\WebApp\Content\Design\Pages" /MIR /XO /XF "build.bat" "layout.html" /XD *  

exit 
  