function dataFunction(){
    return 400;
}

function validateDataForAge(age){
    if (age>1 && age<200){
        return true;
    }else{
        return false;
    }
}

function errorHandlerForAge(age){
    console.log('Hatalı yaş bilgisi :'+age);
}

function parseRequest( data , validateData, errorHandler){
    if (validateData(data())){
        console.log("Girilen yaş bilgisi işleme alındı.");
        return true;
    }else{
        errorHandler(data());
    }

}

parseRequest(dataFunction,validateDataForAge,errorHandlerForAge);