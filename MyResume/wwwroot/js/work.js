function readTextFile(file, callback) {
    var rawFile = new XMLHttpRequest();
    rawFile.overrideMimeType("application/json");
    rawFile.open("GET", file, true);
    rawFile.onreadystatechange = function () {
        if (rawFile.readyState === 4 && rawFile.status == "200") {
            callback(rawFile.responseText);
        }
    }
    rawFile.send(null);
}

//usage:
readTextFile("\Users\Sasha1648\Desktop\SashaStudies\MyResume\MyResume\MyResume\wwwroot\js\particles.json", function (text) {
    var data = JSON.parse(text);
    console.log(data);
});