function solve(arr) {
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(" ");
        let com = tokens[0];
        let num = Number(tokens[1]);
        if (com == "add") {
            result.push(num);
        }
        else {
            if (num >= 0 && num < result.length) {
                result = result.slice(0,num).concat(result.slice(num+1,result.length));
            }
        }
    }
    for (let i = 0; i < result.length; i++) {
        console.log(result[i]);
    }
}

solve([
    "add 3",
    "add 5",
    "remove 2",
    "remove 0",
    "add 7",
])