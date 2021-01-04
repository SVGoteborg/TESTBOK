// Variables

// store the loaded scripts to avoid re-loading.
//var loadedScripts = new Array();

// DOM ready functions.
$(document).ready(function () {
//    addAjaxLoadButtons('.button');

//    $('#cmd-btn-1').click(function(){
//        clearContent("#content-1");
//    }).text('Clr 1');
//    $('#cmd-btn-2').click(function(){
//        clearContent("#content-2");
//    }).text('Clr 2');
//    $('#cmd-btn-3').click(function(){
//        clearContent("#content-3");
//    }).text('Clr 3');


    $('#popup')
        .dialog({
            autoOpen:false,
            title:'Info:',
            modal:true,
            draggable:false,
            buttons:{
                Ok:function () {
                    $(this).dialog('close');
                }
            }
        });

    $('#edit_dlg')
        .dialog({
            autoOpen:false,
            title:'placeholder title',
            modal:true,
            width:'440px'
        });

    $.datepicker.setDefaults($.datepicker.regional['sv']);

    $.datepicker.setDefaults({
        changeYear:true,
        changeMonth:true
    });


}); // doc ready end.

// ---------------------------------------------------------------------------------------
//
//
//function cluetipTest(){
//    $('#cmd-btn-1').cluetip({
//        local: true,
//        titleAttribute: 'id',
//        cluetipClass: 'rounded',
//        attribute: 'data-ref'
//    });
//    $('#cmd-btn-2').cluetip({
//        local: true,
//        titleAttribute: 'id',
//        cluetipClass: 'jtip',
//        attribute: 'data-ref'
//    });
//    $('#cmd-btn-3').cluetip({
//        local: true,
//        titleAttribute: 'id',
//        cluetipClass: 'default',
//        attribute: 'data-ref'
//    });
//}
//function dlgTest(){
//    var $dialog = $('<div></div>')
//        .html('This dialog will show every time!')
//        .dialog({
//            autoOpen: false,
//            title: 'Basic Dialog'
//        });
//
//    $('#cmd-btn-6').click(function() {
//            $dialog.dialog('open');
//    });
//}
//function test(){
//    $('#content-3')
//        .append('<p id="test">'+(et('a','b'))+'</p>');
//    $('p#test')
//        .hide()
//        .delay(1000)
//        .fadeIn('slow');
//    $('#content-1')
//        .hide()
//        .load("test/spam.php",contentFadeIn('#content-1',3000));
//}
//function clk(){
//    var t = $(this);
//    var str = t.attr('id')+" : "+t.attr('data-ref')+" : "+t.attr('data-target');
//    $("#system-message").hide()
//        .html(str)
//        .fadeIn('slow');
//}
//function et(a,b){
//    return 'a='+a+'|b='+b;
//}
//function contentFadeIn(d,x){
//    $(d).fadeIn(x);
//}

// ---------------------------------------------------------------------------------------
//
//function sysMsg(msg){
//    $("#system-message").hide()
//        .html(msg)
//        .fadeIn('slow');
//}

function clearContent(targetID) {
    $(targetID).html("");
}

//function loadScriptOnce(fileName, callbackFunctionName ){
//    if(loadedScripts.indexOf(fileName, 0) >= 0){
//        // Script file is loaded, call function if defined
//        if ( typeof callbackFunctionName != 'undefined' ){
//            window[callbackFunctionName]();
//        }
//    } else { // Script file is not yet loaded.
//        if ( typeof callbackFunctionName == 'undefined' ){
//            // load script without callback function
//            jQuery.getScript(fileName);
//        } else {// load script and run callback function on completion
//            jQuery.getScript(fileName, function(){
//                window[callbackFunctionName]();
//            });
//        }// set file as loaded.
//        loadedScripts.push(fileName);
//    }
//};

function updateUser() {
    $('div#logged-in-as').load('part/login/getusername.php');
}

function updateMenu() {
    $('div#box-menu').load('menu/showmenu.php');
}

function addAjaxLoadButtons(btn) {
    $(btn).unbind('click'); // prevent double binding.
    $(btn).click(function () {
        var t = $(this);
        var ref = t.attr('data-ref'); // file to load
        var tgt = t.attr('data-target'); // where to display it.
        var str = "ID: " + t.attr('id') + "<br />ref: " + t.attr('data-ref');
        $(tgt).load(ref);
//        $(tgt).load(ref,sysMsg(str));
    });
}

function addAjaxPostButtons(btn, attribs) {
    $(btn).unbind('click'); // prevent double binding.
    $(btn).click(function () {
        var t = $(this);
        var ref = t.attr('data-ref');
        var tgt = t.attr('data-target');
        var pStr = "";
        var and = false;
        for (var i in attribs) {
            if (and) pStr += '&';
            pStr += attribs[i] + "=" + t.attr(attribs[i]);
            and = true;
        }
        var str = "ID: " + t.attr('id') + "<br />ref: " + t.attr('data-ref') + " : " + pStr;
        $.post(ref, pStr,
            function (data) {
//                sysMsg(str);
                $(tgt).html(data);
            });
        return false;
    });
}

function makeOverview() {
    $('.dblock').each(function () {
        var t = $(this);
        var start = t.attr('data-tstart');
        var stop = t.attr('data-tstop');
        var steps = stop - start;
        t.css({'left':start + "px", 'width':steps + "px"});
    });
}
function makeDayOverview() {
    $('.sdblock').each(function () {
        var t = $(this);
        var start = t.attr('data-tstart');
        var stop = t.attr('data-tstop');
        var steps = stop - start;
        t.css({'top':start + "px", 'height':(steps - 1) + "px"});
    });
}


