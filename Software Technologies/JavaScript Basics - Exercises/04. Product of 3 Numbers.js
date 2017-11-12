function sovle(arr) {
    let x = Number(arr[0]);
    let y = Number(arr[1]);
    let z = Number(arr[2]);
    let sign = 1;
    if(x<0){
        sign*=-1;
    }
    if(y<0){
        sign*=-1;
    }
    if(z<0){
        sign*=-1;
    }
    if(sign === 1){
        console.log("Positive");
    }else{
        console.log("Negative");
    }
}