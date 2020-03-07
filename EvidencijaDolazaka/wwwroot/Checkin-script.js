
// let dateVal;
let date = document.getElementById("date");
let dateObj = new Date();
let dd = dateObj.getDate();
let mm = dateObj.getMonth() + 1;
let yyyy = dateObj.getFullYear();

if (mm < 10) {
    mm = '0' + mm
}
let Datum = dd + '.' + mm + '.' + yyyy;
date.value = dd + '.' + mm + '.' + yyyy;

var VremeDolaska;
function startTime() {
    timeObj = new Date();
    let hour = timeObj.getHours();
    let min = timeObj.getMinutes();
    let sec = timeObj.getSeconds();
    min = checkTime(min);
    sec = checkTime(sec);
    VremeDolaska = `${hour}:${min}:${sec}`;
    document.getElementById('time').value = hour + ":" + min + ":" + sec;
    let t = setTimeout(startTime, 500);
}
function checkTime(i) {
if (i < 10) {i = "0" + i};  // add zero in front of numbers < 10
    return i;
}

let display = document.getElementById("display");
let PIN = '';

document.getElementById("btn1").addEventListener("click", function () {
    input(document.getElementById("btn1").value)
});

document.getElementById("btn2").addEventListener("click", function () {
    input(document.getElementById("btn2").value)
});

document.getElementById("btn3").addEventListener("click", function () {
    input(document.getElementById("btn3").value)
});

document.getElementById("btn4").addEventListener("click", function () {
    input(document.getElementById("btn4").value)
});

document.getElementById("btn5").addEventListener("click", function () {
    input(document.getElementById("btn5").value)
});

document.getElementById("btn6").addEventListener("click", function () {
    input(document.getElementById("btn6").value)
});

document.getElementById("btn7").addEventListener("click", function () {
    input(document.getElementById("btn7").value)
});

document.getElementById("btn8").addEventListener("click", function () {
    input(document.getElementById("btn8").value)
});

document.getElementById("btn9").addEventListener("click", function () {
    input(document.getElementById("btn9").value)
});

document.getElementById("btn0").addEventListener("click", function () {
    input(document.getElementById("btn0").value)
});

function input(value){
    display.value += value;
    PIN += value;
    console.log("PIN " + PIN);
    
}

document.getElementById("reset").addEventListener("click", reset);

function reset(){
    display.value = '';
    PIN = '';
    console.log("PIN " + PIN);
}
  

//var pom; 
function CheckChar(){
    //pom = document.getElementById("display").value;   //  pom iz valiable for insert id
    if(PIN.length == 4){

                CheckPIN();    //  call function for check id in base
                               // /document.getElementById("d").innerHTML = "Uspesno prosao test broja karaktera";  onlu for test          
    }
    else{

        if(PIN.length < 4)
        alert("Uneli ste nedovoljan broj karaktera, pokusajte ponovo");
        else
        alert("Uneli ste previse karaktera, pokusajte ponovo");  

    }
   // document.getElementById("display").value = "";
   reset();
}


function CheckPIN(){

    var niz = new Array(); // there iz line for insert conection vith sql base 
    niz = ['1111', '1499', '2222', '3333', '4444', '7777', '2405']; //test
    var p = false;
    let i = 0;

    for (let i = 0; i < niz.length; i++) {
        if(niz[i] == PIN)
        {   
            p = true;
            LoginAPI(); //call function for login or login2
            
        }
    }
    if(p == false){
            alert("Uneli ste pogresan pin, pokusajte ponovo");
    }
}


async function LoginAPI(){ 
    let pinInt = parseInt(PIN);
    

    fetch(`/values/emp/${pinInt}`)
    .then(resp => resp.json())
    .then(el => {

        el.forEach(employee => {
            var ansver = window.confirm(`${employee.Ime} ${employee.Prezime}` + '\n' + `${employee.Funkcija}` + '\n' + `${employee.Sluzba}`); 
            if(ansver){
                // inserf function for take photography

                var data = {};
                data.Jmbg = employee.Jmbg;
                data.Datum = Datum;
                data.VremeDolaska = VremeDolaska;
                

                let xhr = new XMLHttpRequest();

                xhr.open('POST', '/values/post', true);
                xhr.setRequestHeader('Content-Type', 'application/json');
                xhr.upload.onload = function(){
                    alert("Uspesno ste se logovali");
                }
                xhr.upload.onerror = function(){
                    alert("Doslo je do greske");
                }
                var dataJson = JSON.stringify(data)
                xhr.send(dataJson)

                 
            }
            else{
                alert("Niste se logovali");
            }
        });
    })
        
    
}

function Login(){

    // LoginAPI().then(data => console.log(data))

    
}



