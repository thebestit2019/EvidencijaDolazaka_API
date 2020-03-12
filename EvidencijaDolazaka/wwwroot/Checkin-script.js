//set webcam
Webcam.set({
    width: 80,
    height: 60,
    image_format: 'jpeg',
    jpeg_quality: 90
});

Webcam.attach('#my_camera');

//Initialize date
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

//initialize time
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

//display time and initialize varible to store pin in it
let display = document.getElementById("display");
let PIN = '';

//adding evnt listeners for all buttons
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

//adding value to pin variable and displaying it on screen
function input(value){
    display.value += value;
    PIN += value;
    console.log("PIN " + PIN);
    
}

//reset function for reset button
document.getElementById("reset").addEventListener("click", reset);

function reset(){
    display.value = '';
    PIN = '';
    console.log("PIN " + PIN);
}
  
//fetching all pins from DB into array
let allPins = new Array;
function printPins(){


    fetch('/values/allPins')
    .then(resp => resp.json())
    .then(elements => {
        elements.forEach(respPin => {
            allPins.push(respPin);
        })
    })
    .then(() => {
        for (let index = 0; index < allPins.length; index++) {
            console.log(allPins[index]);
            
        }
    })

}

//checking if entered pin is valid. On true calling login function
function CheckPIN(){

    var p = false;
    
    for (let i = 0; i < allPins.length; i++) {
        if(allPins[i] == PIN)
        {   
            p = true;
            LoginAPI(); //call function for login or login2
            
        }
    }
    if(p == false){
            alert("Uneli ste pogresan pin, pokusajte ponovo");
    }
}

//defining variable to store picture
var pic;

//fetching data to show on popup, and sending data to DB if true
async function LoginAPI(){ 
    let pinInt = parseInt(PIN);
    

    fetch(`/values/emp/${pinInt}`)
    .then(resp => resp.json())
    .then(el => {

        el.forEach(employee => {
            var ansver = window.confirm(`${employee.Ime} ${employee.Prezime}` + '\n' + `${employee.Funkcija}` + '\n' + `${employee.Sluzba}`); 
            if(ansver){

                //snappshot taking function
                (function takeSnapshot(){
                    Webcam.snap(function (data_uri){
                        pic = data_uri;
                    });
                })();

                //forming data object to send
                var data = {};
                data.Jmbg = employee.Jmbg;
                data.Datum = Datum;
                data.VremeDolaska = VremeDolaska;
                data.Slika_1 = pic;
                
                //creating request object
                let xhr = new XMLHttpRequest();

                //sending data to controller with AJAX
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