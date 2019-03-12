var i=10;
(function globalTest(){
    var icDegisken='ic';
    console.log(i);
    i=15;
    console.log(i)
}());
console.log(icDegisken);