var ui = (function () {
	function buildLoginForm() {
		var html =
            '<div id="login-form-holder">' +
				'<form>' +
                	'<a href="#" id="btn-show-login" class="link selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="link">Register</a>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="text" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="text" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
	
				'</form>' +
				'<div id="error-messages"></div>' +
            '</div>';
		return html;
	}

	function buildGameUI(nickname) {
		var html = '<span id="user-nickname">' +
				nickname +
		'</span>' +
		'<button id="btn-logout">Logout</button><br/>' +
		'<div id="create-game-holder">' +
			'Title: <input type="text" id="tb-create-title" />' +
			'Password: <input type="text" id="tb-create-pass" />' +
			'<button id="btn-create-game">Create</button>' +
		'</div>' +
		'<div id="open-games-container">' +
			'<h2>Open</h2>' +
			'<div id="open-games"></div>' +
		'</div>' +
		'<div id="active-games-container">' +
			'<h2>Active</h2>' +
			'<div id="active-games"></div>' +
		'</div>' +
		'<div id="game-holder">' +
		'</div>' +
		'<div id="messages-holder">' +
		'</div>';
		return html;
	}

	function buildOpenGamesList(games) {
		var list = '<ul class="game-list open-games">';
		for (var i = 0; i < games.length; i++) {
			var game = games[i];
			list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function buildActiveGamesList(games) {
		var gamesList = Array.prototype.slice.call(games, 0);
		gamesList.sort(function (g1, g2) {
			if (g1.status == g2.status) {
				return g1.title > g2.title;
			}
			else {
				if (g1.status == "in-progress") {
					return -1;
				}
			}
			return 1;
		});

		var list = '<ul class="game-list active-games">';
		for (var i = 0; i < gamesList.length; i++) {
			var game = gamesList[i];
			list +=
				'<li class="game-status-' + game.status + '" data-game-id="' + game.id + '" data-creator="' + game.creator + '">' +
					'<a href="#" class="btn-active-game">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function buildGameField(gameField, nickname) {
	    var playerInTurn = (gameField[gameField.inTurn].nickname == nickname);
	    var players = ["red", "blue"];
	    var field = [[], [], [], [], [], [], [], [], []];
	    for (var i = 0; i < players.length; i++) {
	        var units = gameField[players[i]].units;
	        for (var j = 0; j < units.length; j++) {
	            field[units[j].position.y][units[j].position.x] = units[j];
	        }
	    }
	    // console.log(field);
	    var html =
			'<div id="game-state" data-game-id="' + gameField.gameId + '">' +
				'<h2>' + gameField.title + '</h2>' +
				'<h4> Current turn: ' + gameField.turn + '</h4>' +
				'<h5> ' + (playerInTurn ? "You are " : "Your enemy is") + ' on turn</h5>' + 
	                '<table id="battle-game-field">';
	    for (var r = 0; r < field.length; r++) {
	        html +=     '<tr>';
	        for (var c = 0; c < field.length; c++) {
	            if (field[r][c]) {
	                html += '<td class="cell-player-' + field[r][c].owner + '">' + field[r][c].type +
                            ' ' + field[r][c].hitPoints + (field[r][c].mode == "defend" ? ' (D)' : '');
	                if (playerInTurn && field[r][c].owner == gameField.inTurn) {
	                    html += '<span class="cell-battleship-info battleship-id">' + field[r][c].id + '</span>' +
                            '<span class="cell-battleship-info battleship-posx">' + field[r][c].position.x + '</span>' +
                            '<span class="cell-battleship-info battleship-posy">' + field[r][c].position.y + '</span><hr/>' +
					        '<a href="#" class="cell-battleship-move">move</a> ' +
					        '<a href="#" class="cell-battleship-attack">attack</a> ' +
	                        (field[r][c].mode == "defend" ? '' : '<a href="#" class="cell-battleship-defend">defend</a>');
	                }

	                html += '</td>';
	            } else {
	                html += '<td>&nbsp;</td>';
	            }
	        }
	        html +=     '</tr>';
	    }
	    html +=     '</table>';
	    html += '</div>';
	    // console.log(html);
		return html;
	}
	
	function buildMessagesList(messages) {
		var list = '<ul class="messages-list">';
		var msg;
		for (var i = 0; i < messages.length; i += 1) {
			msg = messages[i];
			var item =
				'<li>' +
					'<a href="#" class="message-state-' + msg.state + '">' +
						msg.text +
					'</a>' +
				'</li>';
			list += item;
		}
		list += '</ul>';
		return list;
	}

	return {
		gameUI: buildGameUI,
		openGamesList: buildOpenGamesList,
		loginForm: buildLoginForm,
		activeGamesList: buildActiveGamesList,
		gameField: buildGameField,
		messagesList: buildMessagesList
	}

}());