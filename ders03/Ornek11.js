function Person() {}
Person.prototype.cry = function(){
                                console.log('cry'); 
                       }
function Child() {}
Child.prototype={cry:Person.prototype.cry};

var aChild=new Child();
console.log(aChild instanceof Person);

