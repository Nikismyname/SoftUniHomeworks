function solve(arr) {
    let obj = {};
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(" -> ");
        if(isNaN( tokens[1])) {
            obj[tokens[0]] = tokens[1]
        }else{
            obj[tokens[0]] = Number(tokens[1]);
        }
    }
    console.log(JSON.stringify(obj));
}

solve([
    "name -> Angel",
    "surname -> Georgiev",
    "age -> 20",
    "grade -> 6.00",
    "date -> 23/05/1995",
    "town -> Sofia",
]);