function second(){
    console.log(2);
}
function first(){
    console.log(11); 
   for (let index = 0; index < 1000000000; index++) {
       let a=5;
       a+=1000;
   }
   console.log(12); 
}

  first();
  second(); 