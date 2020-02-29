

let date = document.getElementById("date");
let dateObj = new Date();
let dd = dateObj.getDate();
let mm = dateObj.getMonth() + 1;
let yyyy = dateObj.getFullYear();

if (mm < 10) {
    mm = '0' + mm
}

date.value = dd + '.' + mm + '.' + yyyy;

function startTime() {
    timeObj = new Date();
    let hour = timeObj.getHours();
    let min = timeObj.getMinutes();
    let sec = timeObj.getSeconds();
    min = checkTime(min);
    sec = checkTime(sec);
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
    niz = ['2345','1234','3456','4567', '1111', '1499', '2222']; //test
    var p = false;
    let i = 0;

    for (let i = 0; i < niz.length; i++) {
        if(niz[i] == PIN)
        {    // document.getElementById("d").innerHTML = "Uspesno ste se prijavili kao " + pom;
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
    let empName, empSur, empFunc, empSector;

    fetch(`/values/emp/${pinInt}`)
    .then(resp => resp.json())
    .then(el => {

        el.forEach(employee => {
            var ansver = window.confirm(`${employee.Ime} ${employee.Prezime}` + '\n' + `${employee.Funkcija}` + '\n' + `${employee.Sluzba}`); // insert name and other parameter for person
            if(ansver){
                alert("Uspesno ste se logovali"); // inserf function for take photography
            }
            else{
                alert("Niste se logovali");
            }
        });
    })
        
    // 
}

function Login(){

    // LoginAPI().then(data => console.log(data))

    
}



