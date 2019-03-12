var add=function f(){
    var count=0;
    return (function(){
        count+=1;
        return count;
    });
}();
add();
add();
add();
console.log(add());