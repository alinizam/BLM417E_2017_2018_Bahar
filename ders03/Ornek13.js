var arabaFonk= function(){this.a='AnaModel'};
arabaFonk.prototype.b='Ana Prototip Özellik';
var araba=new arabaFonk();

console.log(araba.a);
console.log(araba.b);

var altArabaFonk=function(){};
//altArabaFonk.prototype=Object.create(arabaFonk.prototype);
altArabaFonk.prototype = new arabaFonk();
altArabaFonk.prototype.c='Alt Prototip Özellik';

var mercedes=new altArabaFonk();
console.log(mercedes.a);
console.log(mercedes.b);
console.log(mercedes.c);


