﻿function expandDocumentation() {
    document.getElementById('docPlaceholder').style.width = '1200px';
    document.getElementById('docElementsPlaceholder').style.display = 'block';
}
function shortDocumentation() {
    document.getElementById('docPlaceholder').style.width = '0px';
    document.getElementById('docElementsPlaceholder').style.display = 'none';
}

function expandHome() {
    document.getElementById('homePlaceholder').style.width = '1200px';
    document.getElementById('homeElementsPlaceholder').style.display = 'block';
}
function shortHome() {
    document.getElementById('homePlaceholder').style.width = '0px';
    document.getElementById('homeElementsPlaceholder').style.display = 'none';
}
function cipherPage(titlu) {
    var asd = titlu;
    alert(asd);
   // window.location.href = '@Url.Content("~/{Home}/{Test}/{params}")';
}

function verifyRotor(text) {
    if(text == 'Rotor' || text == 'Enigma' || text == 'Lorenz cipher')
        document.getElementById('algoritm').innerHTML = 'Mechanism'
}
