function displayHelp1(elem) {
    elem.style.display = 'block';
    
}
function displayHelp2(elem) {
    elem.style.display = 'block';
}
function verifyResult(res,text,correct,gresit){
    
    if (res == text) {      
        correctF(correct, gresit);
    }
    else {
        gresitF(gresit, correct);
    }
    
}
function correctF(correct, gresit) {
    correct.style.display = "block";
    gresit.style.display = "none";
}
function gresitF(gresit, correct) {
    gresit.style.display = "block";
    correct.style.display = "none";
}