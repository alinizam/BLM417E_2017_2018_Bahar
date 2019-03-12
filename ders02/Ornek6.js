    var a=false;
    var callSayHello;
    if (a) {   
        callSayHello=function sayHello() {     
        return 'trueHello';   
       } 
    } 
    else {   
     console.log('Fonsiyon tanımı yapılmadı.');
    } 
    console.log(callSayHello());