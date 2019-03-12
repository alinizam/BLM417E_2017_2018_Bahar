var outer = 'Outer'; //Variable declared in global scope 
var copy;
function outerFn() { //Function declared in global scope 
    var inner = 'Inner'; //Variable has function scope only, can not be 
 
    function innerFn() {
        
        console.log(outer);
        console.log(inner);
    }
    copy = innerFn;
   
}

//console.log(inner); Hatalı kod
outerFn();
copy();  