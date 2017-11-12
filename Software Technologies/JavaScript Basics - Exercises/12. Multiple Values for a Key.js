function solve(arr) {
    let map = {};
    for (let i = 0; i < arr.length; i++) {
        var tokens = arr[i].split(" ");
        if(tokens.length == 2){
            let key = tokens[0];
            let val = tokens[1];
            if(!map.hasOwnProperty(key)){
                map[key] = [];
            }
            map[key].push(val);
        }
        else{
            if(map.hasOwnProperty(tokens[0])){
                for (let obj of map[tokens[0]]) {
                    console.log(obj);
                }
            }
            else{
                console.log("None");
            }
            break;
        }
    }
}

solve([
    "3 test",
    "3 test1",
    "4 test2",
    "4 test3",
    "4 test5",
    "4",
]);