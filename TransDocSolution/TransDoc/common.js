function ToLink(target){
	parent.document.getElementById('CONTENT').src=target;
	//reset top.aspx scroll top to zero
	document.body.scrollTop=0;
	return false;
}

function SearchToLink(e)
{
	ToLink(document.getElementById('lstSearch2').options[e.selectedIndex].innerText);
}

function ChangeTab(num)
{
	switch(num)
	{
		case "1":
			document.getElementById('btnA').disabled = true;
			document.getElementById('panel_A').style.display = '';
			document.getElementById('btnB').disabled = false;
			document.getElementById('panel_B').style.display = 'none';
			document.getElementById('hdnTabIndex').value = '1';
		break;
		case "2":
			document.getElementById('btnA').disabled = false;
			document.getElementById('panel_A').style.display = 'none';
			document.getElementById('btnB').disabled = true;
			document.getElementById('panel_B').style.display = '';
			document.getElementById('hdnTabIndex').value = '2';
		break;
	}
}