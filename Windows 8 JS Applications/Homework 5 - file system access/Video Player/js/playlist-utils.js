// Binding.List passed as the 'dataSource' argument in the ListViews
(function () {
    "use strict";
    var VideoFrameId = "#video-frame";
    var ListViewId = "#playlist-listView-container";

    function startVideo(source) {
        return function () {
            // Set video element's source 
            var videoFrame = WinJS.Utilities.query(VideoFrameId)[0];
            videoFrame.src = source;
            videoFrame.play();
        };
    }

    function stopVideo() {
        var videoFrame = WinJS.Utilities.query(VideoFrameId)[0];
        if (!videoFrame.paused) {
            videoFrame.pause();
        }
    }

    function playFromFile() {
        var videoFrame = WinJS.Utilities.query(VideoFrameId)[0];
        var selectedIndex = WinJS.Utilities.query(ListViewId)[0].winControl.selection.getIndices();
        if (selectedIndex.length > 0) {    
            var itemToken = VideosData.PlayList.getAt(selectedIndex[0]).videoToken;
            Windows.Storage.AccessCache.StorageApplicationPermissions.futureAccessList
                .getFileAsync(itemToken).done(function(item) {
                    videoFrame.src = URL.createObjectURL(item, { oneTimeOnly: true });
                    videoFrame.play();
                });
        }
    }

    function addVideoFile() {
        var picker = new Windows.Storage.Pickers.FileOpenPicker();
        picker.fileTypeFilter.append("*");
        picker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.videosLibrary;
        picker.pickSingleFileAsync().done(
            function (file) {
                if (file) {
                    var item = {};
                    item.title = file.name;
                    item.type = file.displayType;
                    item.thumbnail = "/images/smalllogo.png";
                    var timeStamp = new Date().getTime();
                    var videoToken = timeStamp.toString();
                    Windows.Storage.AccessCache.StorageApplicationPermissions.futureAccessList.addOrReplace(videoToken, file);
                    item.videoToken = videoToken;

                    VideosData.PlayList.push(item);
                }
            });
    }

    function removeVideoFile() {
        var selectedIndex = WinJS.Utilities.query(ListViewId)[0].winControl.selection.getIndices();
        if (selectedIndex.length > 0) {
            var itemToken = VideosData.PlayList.splice(selectedIndex[0], 1);
        }
    }

    function openPlaylist() {
        var openPicker = Windows.Storage.Pickers.FileOpenPicker();

        openPicker.fileTypeFilter.replaceAll([".pls"]);
        openPicker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.videosLibrary;
        openPicker.pickSingleFileAsync().then(function (file) {
            if (file) {
                Windows.Storage.FileIO.readTextAsync(file).done(function (text) {
                    var playlist = JSON.parse(text);
                    VideosData.loadPlaylist(playlist);
                })
            }
        });
    }

    function savePlaylist() {
        var savePicker = new Windows.Storage.Pickers.FileSavePicker();
        savePicker.defaultFileExtension = ".pls"
        savePicker.fileTypeChoices.insert("Playlist", [".pls"])
        savePicker.suggestedFileName = "New Playlist";
        savePicker.suggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.videosLibrary;
        
        savePicker.pickSaveFileAsync().then(function (file) {
            if (file) {
                var playlist = JSON.stringify(VideosData.PlayList.slice(0));
                Windows.Storage.FileIO.writeTextAsync(file, playlist);
            }
        });
    }


    // Create a namespace to make the methods publicly accessible.
    var publicMembers =
        {
            startVideo: startVideo,
            stopVideo: stopVideo,
            playFromFile: playFromFile,
            openPlaylist: openPlaylist,
            savePlaylist: savePlaylist,
            addVideoFile: addVideoFile,
            removeVideoFile: removeVideoFile,
        };
    WinJS.Namespace.define("PlaylistUtils", publicMembers);

    var videoFilesList = new WinJS.Binding.List();

    function loadPlaylist(list) {
        while (videoFilesList.length > 0) {
            videoFilesList.pop();
        }

        for (var i = 0; i < list.length; i++) {
            videoFilesList.push(list[i]);
        }
    }

    var publicDataMembers = 
        {
            PlayList: videoFilesList,
            loadPlaylist: loadPlaylist
        };
    WinJS.Namespace.define("VideosData", publicDataMembers);

})();
