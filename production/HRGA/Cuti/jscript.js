function printit(){  
	var WebBrowser = '<OBJECT ID="WebBrowser1" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
	document.body.insertAdjacentHTML('beforeEnd', WebBrowser);
    WebBrowser1.ExecWB(6, 2);//Use a 1 vs. a 2 for a prompting dialog box    
    WebBrowser1.outerHTML = "";  
}

function previewit(){  
	var WebBrowser = '<OBJECT ID="WebBrowser2" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
	document.body.insertAdjacentHTML('beforeEnd', WebBrowser);
   WebBrowser2.ExecWB(7, 2);
   WebBrowser2.outerHTML = ""; 
}

function pagesetup(){  
	var WebBrowser = '<OBJECT ID="WebBrowser3" WIDTH=0 HEIGHT=0 CLASSID="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2"></OBJECT>';
	document.body.insertAdjacentHTML('beforeEnd', WebBrowser);
   	WebBrowser3.ExecWB(8, 2); 
   	WebBrowser3.outerHTML = ""; 
}
