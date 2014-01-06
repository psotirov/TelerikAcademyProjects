var gPlusHelper = (function () {
    var BASE_API_PATH = 'plus/v1/';
    return {
        /**
         * Hides the sign in button and starts the post-authorization operations.
         *
         * @param {Object} authResult An Object which contains the access token and
         *   other authentication information.
         */
        onSignInCallback: function (authResult) {
            gapi.client.load('plus', 'v1', function () {
                $('#authResult').html('Auth Result:<br/>');
                for (var field in authResult) {
                    $('#authResult').append(' ' + field + ': ' +
                        authResult[field] + '<br/>');
                }
                if (authResult['access_token']) {
                    $('#gPlusConnectButton').hide();
                    $('#gPlusDisconnectButton').show();                    
                    gPlusHelper.profile();
                } else if (authResult['error']) {
                    // There was an error, which means the user is not signed in.
                    // As an example, you can handle by writing to the console:
                    console.log('There was an error: ' + authResult['error']);
                    $('#authResult').append('Logged out');
                    $('#gPlusProfile').hide();
                    $('#gPlusDisconnectButton').hide();
                    $('#gPlusConnectButton').show();
                }
            });
        },

        /**
         * Calls the OAuth2 endpoint to disconnect the app for the user.
         */
        disconnect: function () {
            // Revoke the access token.
            $.ajax({
                type: 'GET',
                url: 'https://accounts.google.com/o/oauth2/revoke?token=' +
                    gapi.auth.getToken().access_token,
                async: false,
                contentType: 'application/json',
                dataType: 'jsonp',
                success: function (result) {
                    console.log('revoke response: ' + result);
                    $('#gPlusProfile').empty();
                    $('#authResult').empty();
                    $('#gPlusConnectButton').show();
                },
                error: function (e) {
                    console.log(e);
                }
            });
        },

        /**
         * Gets and renders the currently signed-in user's profile data.
         */
        profile: function () {
            var request = gapi.client.plus.people.get({ 'userId': 'me' });
            request.execute(function (profile) {
                $('#gPlusProfile').empty();
                if (profile.error) {
                    $('#gPlusProfile').append(profile.error);
                    return;
                }
                $('#gPlusProfile').append(
                    $('<h3>Hello ' + profile.displayName + '!</h3><img src=\"' + "https://plus.google.com/s2/photos/profile/me" + "?sz=50" + '\">'));

                console.log("Profile");
                console.log(profile);
            });
        }
    };
})();

/**
 * Calls the helper method that handles the authentication flow.
 *
 * @param {Object} authResult An Object which contains the access token and
 *   other authentication information.
 */
function onSignInCallback(authResult) {
    gPlusHelper.onSignInCallback(authResult);
}

// You Tube player scripts
var player;
function onYouTubeIframeAPIReady() {
    player = new YT.Player('youTubePlayer', {
        height: '390', //must be bigger than 200px
        width: '640', //must be bigger than 200px
        videoId: '1S5YO20Mxlc',
/*        events: {
            'onReady': onPlayerReady,
        }*/
    });

    console.log(player);
}

/*function onPlayerReady(event) {
    event.target.playVideo();
}*/

document.getElementById('single-video').addEventListener('click', function () {
    var video = document.getElementById('load-video').value;

    //player.cueVideoById(video, 0, "large");
    player.loadVideoById(video, 0, "large");
}, false);

document.getElementById('pause').addEventListener('click', function () {
    player.pauseVideo();
}, false);

document.getElementById('play').addEventListener('click', function () {
    player.playVideo();
}, false);

document.getElementById('load-playlist').addEventListener('click', function () {
    var videoPlaylist = document.getElementById('playlist').value.split(',');

    //player.cuePlaylist(videoPlaylist, 0, 0, "large");
    player.loadPlaylist(videoPlaylist, 0, 0, "large");
}, false);

document.getElementById('previous').addEventListener('click', function () {
    player.previousVideo();
}, false);

document.getElementById('next').addEventListener('click', function () {
    player.nextVideo();
}, false);