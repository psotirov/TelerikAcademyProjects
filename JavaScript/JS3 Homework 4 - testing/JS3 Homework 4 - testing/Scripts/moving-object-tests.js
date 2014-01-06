module("MovingObject.init");

test("should set correct values",   
  function(){
    var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
    equal(piece.position, position)
    equal(piece.size, 15);
    equal(piece.fcolor, "#cccccc");
    equal(piece.scolor, "#222222");
    equal(piece.speed, speed);
    equal(piece.direction, dir);
  });


module("MovingObject.move");

test("When direction is 0, decrease x",
  function(){
    var position = {x: 150, y: 150}, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
    piece.move();
    position.x -= speed;
    deepEqual(piece.position, position);
  });

test("When  direction is 1, decrease update y",
  function(){
    var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
    piece.move();
    position.y -= speed;
    deepEqual(piece.position, position);
  });

test("When  direction is 2, increase x",
  function(){
    var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
    piece.move();
    position.x += speed;
    deepEqual(piece.position, position);
  });

test("When  direction is 3, should increase x",
  function(){
    var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
    var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
    piece.move();
    position.y += speed;
    deepEqual(piece.position, position);
  });


module("MovingObject.changeDirection");

test("When direction is 0, can chage it to 1",
  function () {
      var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
      dir = 1;
      piece.changeDirection(dir);
      deepEqual(piece.direction, dir);
  });

test("When direction is 0, can chage it to 3",
  function () {
      var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
      dir = 3;
      piece.changeDirection(dir);
      deepEqual(piece.direction, dir);
  });

test("When direction is 0, cannot chage it to 2 (opposite side)",
  function () {
      var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
      piece.changeDirection(2);
      deepEqual(piece.direction, dir); // the old value remains (0)
  });

test("When direction is 0, cannot chage it to 5 (out of possible directions)",
  function () {
      var position = { x: 150, y: 150 }, size = 15, fcolor = "#cccccc", scolor = "#222222", speed = 5, dir = 0;
      var piece = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, dir);
      piece.changeDirection(5);
      deepEqual(piece.direction, dir); // the old value remains (0)
  });