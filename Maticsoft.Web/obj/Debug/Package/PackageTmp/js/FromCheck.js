//返回checkbox已选择的值，值之间用,隔开

function CheckedValues(form,itemname)
{  
	var values="";
	var form=eval(form);
	for (var i=0;i<form.elements.length;i++)
	{
		var e = form.elements[i];
		if (e.name == itemname&&e.checked==true)
		{      
			if(values!="")
			{
				values+=","+e.value;
			}else{
				values=e.value;
			}   
		}
	}
	return values;
}

function CheckAll(form,itemname)
{
	CheckAllItem(form,itemname,form.chkall.checked);
}
function CheckAllItem(form,itemname,ischecked)
{
  for (var i=0;i<form.elements.length;i++)
  {
    var e = form.elements[i];
    if (e.name == itemname)
       e.checked = ischecked;
  }
}

function ItemIsRowChecked(form,itemname,rowindex)
{  
  b=false;
  var form=eval(form);
  j=0;
  for (var i=0;i<form.elements.length;i++)
  {
    var e = form.elements[i];
    if (e.name == itemname)
    {      
       if(j==rowindex)
       {
			b=e.checked;
			break;   
       }
       j++;   
    }
  }
  return b;
}

function ItemIsChecked(form,itemname,itemvalue)
{  
  b=false;
  var form=eval(form);
  for (var i=0;i<form.elements.length;i++)
  {
    var e = form.elements[i];
    if (e.name == itemname&&e.value==itemvalue)
    {      
       b=e.checked;
       break;       
    }
  }
  return b;
}

function CheckOperItem(form,itemname,itemvalue,ischecked)
{
	if(ischecked)
	{
		CheckedItem(form,itemname,itemvalue);
	}else{
		NoCheckedItem(form,itemname,itemvalue);
	}
}

function CheckedItem(form,itemname,itemvalue)
{  
  var form=eval(form);
  for (var i=0;i<form.elements.length;i++)
  {
    var e = form.elements[i];
    if (e.name == itemname&&e.value==itemvalue)
       e.checked = true;
  }
  return false;
}

function NoCheckedItem(form,itemname,itemvalue)
{  
  var form=eval(form);
  for (var i=0;i<form.elements.length;i++)
  {
    var e = form.elements[i];
    if (e.name == itemname&&e.value==itemvalue)
       e.checked = false;
  }
  return false;
}

function OnlyCheckedItem(form,itemname,itemvalue)
{
	var form=eval(form);
	for (var i=0;i<form.elements.length;i++)
	{
		var e = form.elements[i];
		if (e.name == itemname)
		{
			if(e.value==itemvalue)
			{
				e.checked = true;				
			}else{
				e.checked = false;	
			}
		}
	}
	return false;	
}

function ItemIsSelected(form,itemname,itemvalue)
{	
	b=false;	
	var formitem=eval(form+"."+itemname);	
	for(var si=0;si<formitem.length;si++)
	{
		if(formitem[si].value==itemvalue)
		{
			b=formitem[si].selected;
			break;
		}
	}
	return b;		
}
function SelectedItem(form,itemname,itemvalue)
{
	var formitem=eval(form+"."+itemname);	
	for(var si=0;si<formitem.length;si++)
	{
		if(formitem[si].value==itemvalue)
		{
			formitem[si].selected=true;
			break;
		}
	}		
}

function SelectedItemText(form,itemname,itemvalue)
{	
	var formitem=eval(form+"."+itemname);	
	for(var si=0;si<formitem.length;si++)
	{
		if(formitem[si].text==itemvalue)
		{
			document.write(formitem[si].text);
			formitem[si].selected=true;
			break;
		}
	}
		
}

function SelectedItemValue(form,itemname)
{
	var formitem=eval(form+"."+itemname);	
	var ItemValue;	
	for(var si=0;si<formitem.length;si++)
	{		
		if(formitem[si].selected==true)
		{
			ItemValue=formitem[si].value;			
			break;
		}
	}
	return ItemValue;
}

function InsertTheDownSelect(theDownobj,theIndex,theValue,theText)
{
	theDownobj.length=theDownobj.length+1;
	
	for(thei=(theDownobj.length-2);thei>=theIndex;thei--)
	{
		if(theDownobj[thei].selected==true)
		{
			theDownobj[thei+1].selected=true;		
		}
		theDownobj[thei+1].value=theDownobj[thei].value;
		theDownobj[thei+1].text=theDownobj[thei].text;
		
	}
	theDownobj[theIndex].value=theValue;
	theDownobj[theIndex].text=theText;	
}


