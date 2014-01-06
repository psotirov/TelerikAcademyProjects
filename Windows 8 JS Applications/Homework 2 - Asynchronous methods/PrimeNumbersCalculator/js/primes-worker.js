/// <reference group="Dedicated Worker" />

var isPrime = function (number) {
    //Prime Numbers are 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113
    var maxDivider = Math.round(Math.sqrt(number)) + 1; // if the number is not prime, it has at least one divider in the range (1,sqrt(number))
    var i = 2; // the correction (MaxDivider + 1) ensures at least one flow through the for loop (if the number is in the range [2, 6]
    for (; (i < maxDivider) && (number % i != 0) ; i++) { }
    return (i == maxDivider); // true if number is prime
}

var calculatePrimes = function (fromNumber, toNumber, count) {
    count = count | 0;
    if (count > 0) {
        toNumber = fromNumber;
    }

    var primesList = [];
    var currentNumber = fromNumber;

    while (currentNumber < toNumber || count > 0) {
        if (isPrime(currentNumber)) {
            primesList.push(currentNumber);
            if (count > 0) {
                count--;
            }
        }

        currentNumber++;
    }

    return primesList;
}

onmessage = function (event) {
    var firstNumber = event.data.firstNumber;
    var lastNumber = event.data.lastNumber;
    var count = event.data.count;

    var primes = calculatePrimes(firstNumber, lastNumber, count);

    postMessage(primes);
}
