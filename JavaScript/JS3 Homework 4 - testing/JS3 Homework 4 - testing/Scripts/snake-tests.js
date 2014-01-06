module("Snake.init");

test("When snake is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  ok(snake.pieces,"SnakePieces are created");
  equal(snake.pieces.length, 5,"Five SnakePieces are created");
  ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");

test("When object is Food, should grow", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);
  var size = snake.size;
  snake.consume(new snakeGame.Food());
  var actual = snake.size;
  var expected = size + 1;
  equal(actual, expected);
});

test("When object is SnakePiece, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.SnakePiece());
  ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.Obstacle());
  ok(isDead, "The snake is dead");
});


module("Snake.Move");

test("Check for correct move in direction 0", function () {
    var snake = new snakeGame.Snake({x: 150, y: 150}, 1, 0);
    snake.move();
    for (var i = 0, size = snake.size; i < size; i++) {
        equal(snake.pieces[i].position.x, 149 + i * 10, "Position.x of snake " + (i + 1) + "-th piece is correct"); // 10 is the default snake piece size
        equal(snake.pieces[i].position.y, 150, "Position.y of snake " + (i + 1) + "-th piece is correct");
    }
});


module("Snake.ChangeDirection");

test("Check for correct move when direction is changed from 0 to 1", function () {
    var snake = new snakeGame.Snake({ x: 150, y: 150 }, 1, 0);
    snake.changeDirection(1);
    // the snake head must go into the new direction
    equal(snake.pieces[0].position.x, 150, "Position.x of snake head is correct");
    equal(snake.pieces[0].position.y, 149, "Position.y of snake head is correct");
    // all other pieces must go into the initial direction (0)
    for (var i = 1, size = snake.size; i < size; i++) {
        equal(snake.pieces[i].position.x, 149 + i * 10, "Position.x of snake " + (i + 1) + "-th piece is correct"); // 10 is the default snake piece size
        equal(snake.pieces[i].position.y, 150, "Position.y of snake " + (i + 1) + "-th piece is correct");
    }
});

test("Check for correct move when direction is invalid (from 0 to 2)", function () {
    var snake = new snakeGame.Snake({ x: 150, y: 150 }, 1, 0);
    snake.changeDirection(2);
    // the snake must go into the initial direction (0)
    for (var i = 0, size = snake.size; i < size; i++) {
        equal(snake.pieces[i].position.x, 149 + i * 10, "Position.x of snake "+(i+1)+"-th piece is correct"); // 10 is the default snake piece size
        equal(snake.pieces[i].position.y, 150, "Position.y of snake " + (i + 1) + "-th piece is correct");
    }
});


module("Snake.Grow");

test("Check if snake grows correctly", function () {
    var snake = new snakeGame.Snake({ x: 150, y: 150 }, 1, 0);
    var size = snake.size + 1;
    snake.grow();
    // the size is increased
    equal(snake.size, size, "Snake size is correctly increased");
    // the new snake tail is in correct positiion
    equal(snake.pieces[size - 1].position.x, 150 + (size - 1) * 10, "Position.x of snake tail piece is correct"); // 10 is the default snake piece size
    equal(snake.pieces[size - 1].position.y, 150, "Position.y of snake tail piece is correct");
});


module("Snake.Die");

test("The snake dies (checks also Snake.AddDieHandler)", function () {
    var snake = new snakeGame.Snake({x: 150, y: 150 }, 1, 0);
    var isDead = false;
    var size = 0;
    snake.addDieHandler(function (result) {
        isDead = true;
        size = result.score;
    });

    snake.die();
    ok(isDead, "The snake is dead");
    equal(size, snake.size, "The score is snake size");
});

test("The snake dies if bites itself", function () {
    var game = new snakeGame.SnakeEngine(null, 300, 300);
    var isDead = false;
    game.snake.addDieHandler(function (result) {
        isDead = true;
    });
    // first remove all other obstacles to make clear test
    game.gameObjects = [];
    game.gameObjects.push(game.snake);
    // snake moves up, right and down in order to byte itself immmediately
    game.snake.changeDirection(1);
    game.snake.changeDirection(2);
    game.snake.changeDirection(3);
    game.checkCollisions();
    ok(isDead, "The snake is dead due to bitten itself");
});

module("Food.Init");

test("When food is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var size = 15;
    var food = new snakeGame.Food(position, size);

    equal(position, food.position, "Position is set");
    equal(size, food.size, "Size is set");
    ok(food.fcolor.length == 7 && food.fcolor[0] == '#', "Fill color is set");
    ok(food.scolor.length == 7 && food.scolor[0] == '#', "Stroke color is set");
});
