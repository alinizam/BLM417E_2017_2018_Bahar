function Player(){};
var obj=Player();
if (obj===undefined){
    console.log('Tanımsız');
}


var obj1=new Player();
if (obj1!==undefined){
    console.log('İkinci nesne tanımlı');
}
obj1.firstName='Deneme';
console.log(obj1.firstName);