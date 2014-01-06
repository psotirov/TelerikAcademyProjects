/// <reference path="http-layer.js" />
/// <reference path="class.js" />
/// <reference path="http://crypto-js.googlecode.com/svn/tags/3.1.2/build/rollups/sha1.js" />
var services = (function () {
	var nickname = localStorage.getItem("nickname");
	var sessionKey = localStorage.getItem("sessionKey");
	function saveUserData(userData) {
		localStorage.setItem("nickname", userData.nickname);
		localStorage.setItem("sessionKey", userData.sessionKey);
		nickname = userData.nickname;
		sessionKey = userData.sessionKey;
	}
	function clearUserData() {
		localStorage.removeItem("nickname");
		localStorage.removeItem("sessionKey");
		nickname = "";
		sessionKey = "";
	}

    // services wrapper
	var MainService = Class.create({
		init: function (rootUrl) {
			this.rootUrl = rootUrl;
			this.user = new UserService(this.rootUrl);
			this.game = new GameService(this.rootUrl);
			this.message = new MessagesService(this.rootUrl);
			this.battle = new BattleService(this.rootUrl);
		},
		isUserLoggedIn: function () {
			var isLoggedIn = nickname != null && sessionKey != null;
			return isLoggedIn;
		},
		nickname: function () {
			return nickname;
		}
	});

    // services, related to user (login, logout, register)
	var UserService = Class.create({
		init: function (rootUrl) {
			this.rootUrl = rootUrl + "user/";
		},
		login: function (user, success, error) {
			var url = this.rootUrl + "login";
			var userData = {
				username: user.username,
				authCode: CryptoJS.SHA1(user.username + user.password).toString()
			};

			httpLayer.postJSON(url, userData,
				function (data) {
					saveUserData(data);
					success(data);
				}, error);
		},
		register: function (user, success, error) {
			var url = this.rootUrl + "register";
			var userData = {
				username: user.username,
				nickname: user.nickname,
				authCode: CryptoJS.SHA1(user.username + user.password).toString()
			};
			httpLayer.postJSON(url, userData,
				function (data) {
					saveUserData(data);
					success(data);
				}, error);
		},
		logout: function (success, error) {
			var url = this.rootUrl + "logout/" + sessionKey;
			httpLayer.getJSON(url, function (data) {
				clearUserData();
				success(data);
			}, error)
		},
		scores: function (success, error) {
		}
	});

    // services, related to Game (create, join, start, open, active-games, field state)
	var GameService = Class.create({
		init: function (url) {
			this.rootUrl = url + "game/";
		},
		create: function (game, success, error) {
			var gameData = {
				title: game.title,
			};
			if (game.password) {
				gameData.password = CryptoJS.SHA1(game.password).toString();
			}
			var url = this.rootUrl + "create/" + sessionKey;
			httpLayer.postJSON(url, gameData, success, error);
		},
		join: function (game, success, error) {
			var gameData = {
				"id": game.gameId,
			};
			if (game.password) {
				gameData.password = CryptoJS.SHA1(game.password).toString();
			}
			var url = this.rootUrl + "join/" + sessionKey;
			httpLayer.postJSON(url, gameData, success, error);
		},
		start: function (gameId, success, error) {
			var url = this.rootUrl + gameId + "/start/" + sessionKey;
			httpLayer.getJSON(url, success, error)
		},
		myActive: function (success, error) {
			var url = this.rootUrl + "my-active/" + sessionKey;
			httpLayer.getJSON(url, success, error);
		},
		open: function (success, error) {
			var url = this.rootUrl + "open/" + sessionKey;
			httpLayer.getJSON(url, success, error);
		},
		field: function (gameId, success, error) {
			var url = this.rootUrl + gameId + "/field/" + sessionKey;
			httpLayer.getJSON(url, success, error);
		}
	});

    // services, related to Play the Game (move, attack, defend)
	var BattleService = Class.create({
	    init: function (url) {
	        this.rootUrl = url + "battle/";
	    },
	    move: function (gameId, unit, success, error) {
	        var gameData = {
	            "unitId": unit.id,
	            "position": { "x": unit.posX, "y": unit.posY }
	        };
	        var url = this.rootUrl + gameId + "/move/" + sessionKey;
	        httpLayer.postJSON(url, gameData, success, error);
	    },
	    attack: function (gameId, unit, success, error) {
	        var gameData = { 
	            "unitId": unit.id,
	            "position": { "x": unit.posX, "y": unit.posY }
	        };
	        var url = this.rootUrl + gameId + "/attack/" + sessionKey;
	        httpLayer.postJSON(url, gameData, success, error);
	    },
	    defend: function (gameId, unit, success, error) {
	        var gameData = unit.id;
	        var url = this.rootUrl + gameId + "/defend/" + sessionKey;
	        httpLayer.postJSON(url, gameData, success, error);
	    }
	});

    // services, related to commmunication with server via Messages (unread, all)
	var MessagesService = Class.create({
		init: function (url) {
			this.rootUrl = url + "messages/";
		},
		unread: function (success, error) {
			var url = this.rootUrl + "unread/" + sessionKey;
			httpLayer.getJSON(url, success, error);
		},
		all: function (success, error) {
			var url = this.rootUrl + "all/" + sessionKey;
			httpLayer.getJSON(url, success, error);
		}
	});
	return {
		get: function (url) {
			return new MainService(url);
		}
	};
}());