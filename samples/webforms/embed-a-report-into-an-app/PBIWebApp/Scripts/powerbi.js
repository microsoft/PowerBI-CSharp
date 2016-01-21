(function (powerbi) {
    'use script';

    powerbi.embeds = [];

    if (window.addEventListener) {
        window.addEventListener('load', onLoad, false);
    } else {
        window.attachEvent('onload', onLoad);
    }

    var componentTypes = [
        { type: 'powerbi-tile', component: Tile },
        { type: 'powerbi-report', component: Report }
    ];

    function onLoad() {
        if (window.addEventListener) {
            window.addEventListener('message', onReceiveMessage, false);
        } else {
            window.attachEvent('onmessage', onReceiveMessage);
        }

        var components = document.querySelectorAll('[powerbi-embed]');
        for (var i = 0; i < components.length; i++) {
            var element = components[i];

            for (var j = 0; j < componentTypes.length; j++) {
                var componentType = componentTypes[j];

                if (element.getAttribute(componentType.type) !== null) {
                    var instance = new componentType.component(element);
                    powerbi.embeds.push(instance);
                    break;
                }
            }
        }
    };

    //////////////////////////////////////

    function Embed() {

    }

    Embed.prototype = {
        init: function () {
            var iframeHtml = '<iframe style="width:100%;height:100%;" scrolling="no"></iframe>';
            var embedUrl = this.element.getAttribute('embed-url');
            this.element.innerHTML = iframeHtml;

            this.iframe = this.element.childNodes[0];
            if (embedUrl) {
                this.iframe.src = embedUrl;
            }

            if (this.iframe.addEventListener) {
                this.iframe.addEventListener('load', this.load.bind(this), false);
            } else {
                this.iframe.attachEvent('onload', this.load.bind(this));
            }
        },
        load: function (evt) {
            var computedStle = window.getComputedStyle(this.element);

            var message = {
                action: this.options.loadAction,
                accessToken: powerbi.accessToken,
                width: computedStle.width,
                height: computedStle.height
            };

            evt.currentTarget.contentWindow.postMessage(JSON.stringify(message), '*');
        }
    }

    function Tile(element, options) {
        this.element = element;
        this.options = options || {};
        this.options.loadAction = 'loadTile';
        this.init();
    }

    function Report(element, options) {
        this.element = element;
        this.options = options || {};
        this.options.loadAction = 'loadReport';
        this.init();
    }

    Tile.prototype = Embed.prototype;
    Report.prototype = Embed.prototype;

    var EmbedEventMap = {
        'tileClicked': 'tile-click',
        'tileLoaded': 'tile-load',
        'reportPageLoaded': 'report-load'
    };

    function onReceiveMessage(event) {
        if (!event) {
            return;
        }

        try {
            messageData = JSON.parse(event.data);
            for (var i = 0; i < powerbi.embeds.length; i++) {
                var embed = powerbi.embeds[i];

                // Only raise the event on the embed that matches the post message origin
                if (event.source === embed.iframe.contentWindow) {
                    raiseCustomEvent(embed.element, EmbedEventMap[messageData.event], messageData);
                }
            }
        }
        catch (e) {
            if (typeof (window.powerbi.onError) === 'function') {
                window.powerbi.onError.call(window, e);
            }
        }
    }

    function raiseCustomEvent(element, eventName, eventData) {
        var customEvent;
        if (typeof (window.CustomEvent) === 'function') {
            customEvent = new CustomEvent(eventName, { detail: eventData });
        } else {
            customEvent = document.createEvent('CustomEvent');
            customEvent.initCustomEvent(eventName, true, true, eventData);
        }

        element.dispatchEvent(customEvent);
    }

}(window.powerbi = window.powerbi || {}));