function checkMail(newMail, retype)
{
    if(newMail != retype)
    {
        document.getElementById('wrongMail').style.display = "inline";
    }
    else 
        document.getElementById('wrongMail').style.display = "none";
}

