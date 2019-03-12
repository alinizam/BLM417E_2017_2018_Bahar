var call_back_array = []
var aaa=function a(){
for (var i = 0; i <= 2; i++) {
        function f(i){
           call_back_array[i] =  function(){ return (i * 2) };
        };
}}();
aaa();
console.log(call_back_array[1]);
