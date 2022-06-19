


function call()
{
    page("p_bridge", "Samuel");
}
// Layout Bridge 
function redirect2(page)
{ 
    if (isMobile())
    {

        if ($("#frm").length > 0)  // Layout
        {
            jsBridge.invokeNext(page)

            $("#frm").attr("src", page);
            adj();
            remPop('mnu_src', 'left');
        }
        else {                     // Page 

        }
    }
    else {

        $("#frm").attr("src", page);
        adj(); 
    }
}