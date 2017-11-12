function solve(arr) {
    let map = {};
    for (let i = 0; i < arr.length; i++) {
        var tokens = arr[i].split(" ");
        if(tokens.length == 2){
            let key = tokens[0];
            let val = tokens[1];
            map[key] = val;
        }
        else{
            if(map.hasOwnProperty(tokens[0])){
                console.log(map[tokens[0]]);
            }else{
                console.log("None");
            }
            break;
        }
    }
}