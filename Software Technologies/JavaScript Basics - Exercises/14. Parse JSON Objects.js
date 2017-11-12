function solve(arr) {
    for (let i = 0; i < arr.length; i++) {
        let obj = JSON.parse(arr[i]);
        console.log(`Name: ${obj["name"]}`);
        console.log(`Age: ${obj["age"]}`);
        console.log(`Date: ${obj["date"]}`);
    }
}