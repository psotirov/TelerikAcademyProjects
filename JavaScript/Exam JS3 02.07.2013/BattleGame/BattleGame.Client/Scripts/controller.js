/// <reference path="class.js" />
/// <reference path="services.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var controllers = (function () {

	var updateTimer = null;
	var rootUrl = "http://localhost:22954/api/";

	var Controller = Class.create({
		init: function () {
		    this.service = services.get(rootUrl);
		    this.inGameId = 0;
		},
        // entry point of the cotroller (loads loginForm or gameUI if we have user already)
		loadUI: function (selector) {
			if (this.service.isUserLoggedIn()) {
				this.loadGameUI(selector);
			}
			else {
				this.loadLoginFormUI(selector);
			}

            // sets user interaction
			this.attachUIEventHandlers(selector);
		},
        // login Form
		loadLoginFormUI: function (selector) {
			var loginFormHtml = ui.loginForm()
			$(selector).html(loginFormHtml);
		},
        // main Game UI 
		loadGameUI: function (selector) {
			var self = this;
			var gameUIHtml = ui.gameUI(this.service.nickname());
			$(selector).html(gameUIHtml);

            // updates the data
			this.updateUI(selector);

            // sets UI to update on every 15 seconds
			updateTimer = setInterval(function () {
				self.updateUI(selector);
			}, 15000);
		},
		loadField: function (selector, gameId) {
			this.service.game.field(gameId, function (gameFieldState) {
			    var gameHtml = ui.gameField(gameFieldState, $(selector + " #user-nickname").html());
				$(selector + " #game-holder").html(gameHtml)
			});
		},
        // sets user interaction
		attachUIEventHandlers: function (selector) {
			var wrapper = $(selector);
			var self = this;

			wrapper.on("click", "#btn-show-login", function () {
				wrapper.find(".button.selected").removeClass("selected");
				$(this).addClass("selected");
				wrapper.find("#login-form").show();
				wrapper.find("#register-form").hide();
			});
			wrapper.on("click", "#btn-show-register", function () {
				wrapper.find(".button.selected").removeClass("selected");
				$(this).addClass("selected");
				wrapper.find("#register-form").show();
				wrapper.find("#login-form").hide();
			});

			wrapper.on("click", "#btn-login", function () {
				var user = {
					username: $(selector + " #tb-login-username").val(),
					password: $(selector + " #tb-login-password").val()
				}

				self.service.user.login(user, function () {
					self.loadGameUI(selector);
				}, function (err) {
					wrapper.find("#error-messages").text(err.responseJSON.Message);
				});
				return false;
			});
			wrapper.on("click", "#btn-register", function () {
				var user = {
					username: $(selector).find("#tb-register-username").val(),
					nickname: $(selector).find("#tb-register-nickname").val(),
					password: $(selector + " #tb-register-password").val()
				}
				self.service.user.register(user, function () {
					self.loadGameUI(selector);
				}, function (err) {
					wrapper.find("#error-messages").text(err.responseJSON.Message);
				});
				return false;
			});
			wrapper.on("click", "#btn-logout", function () {
				self.service.user.logout(function () {
					self.loadLoginFormUI(selector);
					clearInterval(updateTimer);
				}, function (err) {
				});
			});

            // click on open game name -> opens join button
			wrapper.on("click", "#open-games-container a", function () {
				$("#game-join-inputs").remove();
				var html =
					'<div id="game-join-inputs">' +
						'Password: <input type="text" id="tb-game-pass"/><br/>' +
						'<button id="btn-join-game">join</button>' +
					'</div>';
				$(this).after(html);
			});
			wrapper.on("click", "#btn-join-game", function () {
				var game = {
					gameId: $(this).parents("li").first().data("game-id")
				};

				var password = $("#tb-game-pass").val();

				if (password) {
					game.password = password;
				}
				self.service.game.join(game);
			});
			wrapper.on("click", "#btn-create-game", function () {
				var game = {
					title: $("#tb-create-title").val(),
				}
				var password = $("#tb-create-pass").val();
				if (password) {
					game.password = password;
				}
				self.service.game.create(game);
			});

            // button to start game
			wrapper.on("click", "#active-games-container li.game-status-full a.btn-active-game", function () {
				var gameCreator = $(this).parent().data("creator");
				var myNickname = self.service.nickname();
				if (gameCreator == myNickname) {
					$("#btn-game-start").remove();
					var html =
					'<div id="game-start-inputs">' +
						'<button id="btn-game-start">Start</button>' +
					'</div>';
					$(this).parent().append(html);
				}
			});

			wrapper.on("click", "#btn-game-start", function () {
				var parent = $(this).parent();

				var gameId = parent.data("game-id");
				self.service.game.start(gameId, function () {
					wrapper.find("#game-holder").html("started");
				},
				function (err) {
					alert(JSON.stringify(err));
				});

				return false;
			});
			
			wrapper.on("click", "li.game-status-in-progress a.btn-active-game", function () {
			    self.inGameId = $(this).parent().data("game-id") | 0;
			    self.loadField(selector, self.inGameId);
			});
            
			wrapper.on("click", "#battle-game-field a.cell-battleship-defend", function () {
			    var unit = {
			        id: $(this).parent().find(".battleship-id").html()
			    }
			    console.log(unit);
			    self.service.battle.defend(self.inGameId, unit, function () {
			        self.loadField(selector, self.inGameId);
			    });
			});
		},
		updateUI: function (selector) {
			this.service.game.open(function (games) {
				var list = ui.openGamesList(games);
				$(selector + " #open-games")
					.html(list);
			});
			this.service.game.myActive(function (games) {
				var list = ui.activeGamesList(games);
				$(selector + " #active-games")
					.html(list);
				if (list.length == 0) {
				    self.inGameId = 0;
				}
			});
			this.service.message.all(function (msg) {
				var msgList = ui.messagesList(msg);
				$(selector + " #messages-holder").html(msgList);
			});
		    // checks if there is a game in progress and show UI of the battle field
			if (this.inGameId) {
			    this.loadField(selector, this.inGameId);
			}
		}
	});
	return {
		get: function () {
			return new Controller();
		}
	}
}());

$(function () {
	var controller = controllers.get();
	controller.loadUI("#content");
});