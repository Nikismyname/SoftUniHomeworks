function solve(arr){
    let objs = [];
    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(" -> ");
        let obj = {Name: tokens[0], Age: tokens[1], Grade: tokens[2]};
        objs.push(obj);
    }
    for(let obj of objs){
        console.log(`Name: ${obj.Name}`);
        console.log(`Age: ${obj.Age}`);
        console.log(`Grade: ${obj.Grade}`);
    }
}