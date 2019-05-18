var p=new Promise(function(resolve,reject){
    var a=$http.getData("www.servise.jason");
    resolve(a);
    reject("hatalı bitti");
});

p.then(
    result => console.log(result),
    error => console.log(error)
).catch(
    

)