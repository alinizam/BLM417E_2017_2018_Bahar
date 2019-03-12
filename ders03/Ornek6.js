function dwightJob(title) {
    return function(prefix) {
        title=prefix + ' ' + title;
        return title;
    };
}
var ahmet=dwightJob('Müdür');
console.log(ahmet('Genel'));
console.log(ahmet('CIO'));
console.log(ahmet('Başkan'));
