(function (powerbi) {
    'use script';

    var embeds = [];

    powerbi.Tile = Tile;
    powerbi.Report = Report;
    powerbi.get = get;
    powerbi.embed = embed;

    //////////////////////////////////////

    window.addEventListener('DOMContentLoaded', onLoad, false);
    window.addEventListener('message', onReceiveMessage, false);

    var componentTypes = [
        { type: 'powerbi-tile', component: Tile },
        { type: 'powerbi-report', component: Report }
    ];

    function get(element) {
        return element.powerBIEmbed || embed(element);
    }

    function embed(element) {
        var instance;

        for (var j = 0; j < componentTypes.length; j++) {
            var componentType = componentTypes[j];

            if (element.getAttribute(componentType.type) !== null) {
                instance = new componentType.component(element);
                element.powerBIEmbed = instance;
                embeds.push(instance);
                break;
            }
        }

        return instance;
    }

    function onLoad() {
        var components = document.querySelectorAll('[powerbi-embed]');
        for (var i = 0; i < components.length; i++) {
            embed(components[i]);
        }
    };

    //////////////////////////////////////

    function Embed() { }

    Embed.prototype = {
        init: function () {
            var embedUrl = this.getEmbedUrl();
            var iframeHtml = '<iframe style="width:100%;height:100%;" src="' + embedUrl + '" scrolling="no" allowfullscreen="true"></iframe>';
            this.element.innerHTML = iframeHtml;
            this.iframe = this.element.childNodes[0];
            this.iframe.addEventListener('load', this.load.bind(this), false);
        },
        load: function () {
            var computedStle = window.getComputedStyle(this.element);

            var initEventArgs = {
                message: {
                    action: this.options.loadAction,
                    accessToken: powerbi.accessToken,
                    width: computedStle.width,
                    height: computedStle.height
                }
            };

            raiseCustomEvent(this.element, 'embed-init', initEventArgs);
            this.iframe.contentWindow.postMessage(JSON.stringify(initEventArgs.message), '*');
        },
        getEmbedUrl: function () {
            return this.element.getAttribute('powerbi-embed');
        },
        fullscreen: function () {
            var elem = this.iframe;

            if (elem.requestFullscreen) {
                elem.requestFullscreen();
            } else if (elem.msRequestFullscreen) {
                elem.msRequestFullscreen();
            } else if (elem.mozRequestFullScreen) {
                elem.mozRequestFullScreen();
            } else if (elem.webkitRequestFullscreen) {
                elem.webkitRequestFullscreen();
            }
        },
        exitFullscreen: function () {
            if (!this.isFullscreen()) {
                return;
            }

            if (document.exitFullscreen) {
                document.exitFullscreen();
            } else if (document.mozCancelFullScreen) {
                document.mozCancelFullScreen();
            } else if (document.webkitExitFullscreen) {
                document.webkitExitFullscreen();
            } else if (document.msExitFullscreen) {
                document.msExitFullscreen();
            }
        },
        isFullscreen: function () {
            return document.fullscreenElement === this.iframe
                || document.webkitFullscreenElement === this.iframe
                || document.mozFullscreenScreenElement === this.iframe
                || document.msFullscreenElement === this.iframe;
        }
    }

    function Tile(element, options) {
        this.element = element;
        this.options = options || {};
        this.options.loadAction = 'loadTile';
        this.getEmbedUrl = getEmbedUrl;

        this.init();

        ///////////////////////////////

        function getEmbedUrl() {
            var embedUrl = Embed.prototype.getEmbedUrl.call(this);
            if (!embedUrl) {
                var dashboardId = this.element.getAttribute('powerbi-dashboard');
                var tileId = this.element.getAttribute('powerbi-tile');

                if (!(dashboardId && tileId)) {
                    throw new Error('dashboardId & tileId are required');
                }

                embedUrl = 'https://app.powerbi.com/embed?dashboardId=' + dashboardId + '&tileId=' + tileId;
            }

            return embedUrl;
        }
    }

    function Report(element, options) {
        this.element = element;
        this.options = options || {};
        this.options.loadAction = 'loadReport';
        this.getEmbedUrl = getEmbedUrl;

        this.init();

        ///////////////////////////////

        function getEmbedUrl() {
            var embedUrl = Embed.prototype.getEmbedUrl.call(this);
            if (!embedUrl) {
                var reportId = this.element.getAttribute('powerbi-report');

                if (!reportId) {
                    throw new Error('reportId is required');
                }

                embedUrl = 'https://app.powerbi.com/reportEmbed?reportId=' + reportId;
            }

            return embedUrl;
        }
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
            for (var i = 0; i < embeds.length; i++) {
                var embed = embeds[i];

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
            customEvent = new CustomEvent(eventName, {
                detail: eventData,
                bubbles: true,
                cancelable: true
            });
        } else {
            customEvent = document.createEvent('CustomEvent');
            customEvent.initCustomEvent(eventName, true, true, eventData);
        }

        element.dispatchEvent(customEvent);
        if (customEvent.defaultPrevented || !customEvent.returnValue) {
            return;
        }

        var inlineEventAttr = 'on' + eventName.replace('-', '');
        var inlineScript = element.getAttribute(inlineEventAttr);
        if (inlineScript) {
            eval.call(element, inlineScript);
        }
    }
}(window.powerbi = window.powerbi || {}));