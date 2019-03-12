function Player(){
   // this.adi=function(){console.log("Adı var")}
};

var ahmet=new Player(); 
Player.prototype.adi = function(){console.log("Adı yok")}; 


ahmet.prototype.adi();