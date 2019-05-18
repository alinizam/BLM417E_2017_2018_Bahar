var second=function second(){
    console.log(2);
  }
function first(callback){
    // Simulate a code delay
     setTimeout( function(){
      console.log(1);
      callback();
    }, 500 );
    
  }

  first(second);
  //second();