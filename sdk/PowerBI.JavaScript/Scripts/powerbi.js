(function (powerbi) {
    'use script';

    powerbi.tiles = [];

    if (window.addEventListener) {
        window.addEventListener("load", onLoad, false);
    } else {
        window.attachEvent("onload", onLoad);
    }

    function onLoad () {
        if (window.addEventListener) {
            window.addEventListener("message", onReceiveMessage, false);
        } else {
            window.attachEvent("onmessage", onReceiveMessage);
        }

        var tiles = document.querySelectorAll('.powerbi-tile');
        for (var i = 0; i < tiles.length; i++) {
            var tile = new Tile(tiles[0]);
            tile.init();

            powerbi.tiles.push(tile);
        }
    };

    //////////////////////////////////////

    function Tile(element, options) {
        var me = this;

        this.element = element;
        this.options = options || {};
        this.options.onClientLoad = element.getAttribute('data-load');
        this.options.onClientClick = element.getAttribute('data-click');
        this.init = init;

        //////////////////////////////////////

        function init() {
            if (me.element.contentWindow) {
                onIFrameLoad();
            } else {
                if (me.element.addEventListener) {
                    me.element.addEventListener("load", onIFrameLoad, false);
                } else {
                    me.element.attachEvent("onload", onIFrameLoad);
                }
            }
        }

        function onIFrameLoad() {
            var message = {
                action: "loadTile",
                accessToken: powerbi.accessToken,
                width: me.element.style.width,
                height: me.element.style.height
            };

            me.element.contentWindow.postMessage(JSON.stringify(message), "*");
        }
    }

    function onReceiveMessage(event) {
        if (!event) {
            return;
        }

        try {
            messageData = JSON.parse(event.data);
            for (var i = 0; i < powerbi.tiles.length; i++) {
                var tile = powerbi.tiles[i];

                if (event.source === tile.element.contentWindow) {
                    switch (messageData.event) {
                        case 'tileClicked':
                            method = 'onClientClick';
                            break;
                        case 'tileLoaded':
                            method = 'onClientLoad';
                            break;
                    };

                    if (typeof (window[tile.options[method]]) === 'function') {
                        window[tile.options[method]].call(tile, messageData);
                    }
                }
            }
        }
        catch (e) {
            if (typeof (window.powerbi.onError) === 'function') {
                window.powerbi.onError.call(window, e);
            }
        }
    }

}(window.powerbi = window.powerbi || {}));