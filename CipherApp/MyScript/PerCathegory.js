function displayDiv(titlu) {
    closeAll();
    document.getElementById(titlu + 'P').style.display = "block";   
}
function closeDiv(titlu) {
    document.getElementById(titlu).style.display = "none";
}
function closeAll()
{
    document.getElementById('TranspositionP').style.display = "none";
    document.getElementById('PolygramP').style.display = "none";
    document.getElementById('PolyalphabeticP').style.display = "none";
    document.getElementById('HomophonicP').style.display = "none";
    document.getElementById('MonoalphabeticP').style.display = "none";
    document.getElementById('RotorP').style.display = "none";
}