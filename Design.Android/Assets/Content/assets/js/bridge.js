
// Client 
function page(func, param) {
    $("#frm")[0].contentWindow.postMessage(func + "(" + JSON.stringify(param) + ")", "*");
}
function layout(func, param) {
    window.top.postMessage(func + "(" + JSON.stringify(param) + ")", "*");
}

window.onmessage = function (e) {
    $.globalEval(e.data);
}
// Sever
function hGet(ctrl, funct, paramt) {
    var res = jsBridge.invokeGet(paramt, ctrl + 'Controller/' + funct);

    return res;
}
function hPost(ctrl, funct, paramt) {

    var resp = jsBridge.invokePost(paramt, ctrl + 'Controller/' + funct);

    return resp;
}
function hAlert(title, msg) {
    jsBridge.invokeAlert(msg, title);
}
// 