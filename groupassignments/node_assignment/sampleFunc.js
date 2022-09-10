const fs = require('fs-extra');
const connectedFile = require('./connectedFile.js');


let myVar1 = 'Bungee';

let myVar2 = 2;

let myVar3 = connectedFile.myFunc(myVar1, myVar2);

fs.writeFileSync('./ReadMe.txt', myVar3);

fs.appendFileSync('./ReadMe.txt', '');

let myVar4 = fs.readFileSync('./ReadMe.txt');

console.log(myVar4.toString)


/**
 * 1. create some functions that will write to a new file
 * 2. append to that new file
 * 3. and then read from that file
 * 4. print the contents to console
 * 5. use variable(s) and a function that you exported from another module(file)
 *                                                  ...using Node, etc.
 */