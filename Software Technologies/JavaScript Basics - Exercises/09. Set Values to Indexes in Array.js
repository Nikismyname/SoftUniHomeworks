function solve(arr) {
    let leng = Number(arr[0]);
    let result = [];
    for (let i = 1; i < arr.length; i++) {
        let tokens = arr[i].split(" - ");
        let ind = Number(tokens[0]);
        let val = Number(tokens[1]);
        result[ind] = val;
    }
    for (let i = 0; i < leng; i++) {
        if(result[i] == undefined){
            console.log(0);
        }else {
            console.log(result[i]);
        }
    }
}

solve([
    "5",
    "0 - 3",
    "3 - -1",
    "4 - 2",
]);