/* http://keith-wood.name/bookmark.html
   Sharing bookmarks for jQuery v1.5.1.
   Written by Keith Wood (kbwood{at}iinet.com.au) March 2008.
   Dual licensed under the GPL (http://dev.jquery.com/browser/trunk/jquery/GPL-LICENSE.txt) and 
   MIT (http://dev.jquery.com/browser/trunk/jquery/MIT-LICENSE.txt) licenses. 
   Please attribute the author if you use it. */

/* Allow your page to be shared with various bookmarking sites.
   Attach the functionality with options like:
   $('div selector').bookmark({sites: ['delicious', 'digg']});
*/

(function ($) { // Hide scope, no $ conflict

    /* Bookmark sharing manager. */
    function Bookmark() {
        this._defaults = {
            url: '',  // The URL to bookmark, leave blank for the current page
            sourceTag: '', // Extra tag to add to URL to indicate source when it returns
            title: '',  // The title to bookmark, leave blank for the current one
            description: '',  // A longer description of the site
            sites: [],  // List of site IDs or language selectors (lang:xx) or
            // category selectors (category:xx) to use, empty for all
            iconsStyle: 'bookmark_icons', // CSS class for site icons
            icons: 'bookmarks.png', // Horizontal amalgamation of all site icons
            iconSize: 16,  // The size of the individual icons
            iconCols: 16,  // The number of icons across the combined image
            target: '_blank',  // The name of the target window for the bookmarking links
            compact: true,  // True if a compact presentation should be used, false for full
            hint: 'Send to {s}',  // Popup hint for links, {s} is replaced by display name
            popup: false, // True to have it popup on demand, false to show always
            popupText: 'Bookmark this site...', // Text for the popup trigger
            addFavorite: false,  // True to add a 'add to favourites' link, false for none
            favoriteText: 'Favorite',  // Display name for the favourites link
            favoriteIcon: 0,  // Icon for the favourites link
            addEmail: false,  // True to add a 'e-mail a friend' link, false for none
            emailText: 'E-mail',  // Display name for the e-mail link
            emailIcon: 1,  // Icon for the e-mail link
            emailSubject: 'Interesting page',  // The subject for the e-mail
            emailBody: 'I thought you might find this page interesting:\n{t} ({u})', // The body of the e-mail,
            // use '{t}' for the position of the page title, '{u}' for the page URL,
            // '{d}' for the description, and '\n' for new lines
            manualBookmark: 'Please close this dialog and\npress Ctrl-D to bookmark this page.',
            // Instructions for manually bookmarking the page
            addShowAll: false, // True to show listed sites first, then all on demand
            showAllText: 'Show all ({n})', // Display name for show all link, use '{n}' for the number of sites
            showAllIcon: 2, // Icon for show all link
            showAllTitle: 'All bookmarking sites', // Title for show all popup
            onSelect: null, // Callback on selection
            addAnalytics: false, // True to include Google Analytics for links
            analyticsName: '/share/{r}/{s}' // The "URL" that is passed to the Google Analytics,
            // use '{s}' for the site code, '{n}' for the site name,
            // '{u}' for the current full URL, '{r}' for the current relative URL,
            // or '{t}' for the current title
        };
        this._sites = {  // The definitions of the available bookmarking sites, in URL use
            // '{u}' for the page URL, '{t}' for the page title, and '{d}' for the description
            'aol': {
                display: 'myAOL', icon: 3, lang: 'en', category: 'bookmark',
                url: 'http://favorites.my.aol.com/ffclient/AddBookmark?url={u}&amp;title={t}'
            },
            'bitly': {
                display: 'bit.ly', icon: 4, lang: 'en', category: 'tools',
                url: 'http://bit.ly/?url={u}'
            },
            'blogger': {
                display: 'Blogger', icon: 5, lang: 'en', category: 'blog',
                url: 'http://www.blogger.com/blog_this.pyra?t=&amp;u={u}&amp;n={t}'
            },
            'delicious': {
                display: 'del.icio.us', icon: 6, lang: 'en', category: 'bookmark',
                url: 'http://del.icio.us/post?url={u}&amp;title={t}'
            },
            'digg': {
                display: 'Digg', icon: 7, lang: 'en', category: 'news',
                url: 'http://digg.com/submit?phase=2&amp;url={u}&amp;title={t}'
            },
            'diigo': {
                display: 'Diigo', icon: 8, lang: 'en', category: 'social',
                url: 'http://www.diigo.com/post?url={u}&amp;title={t}'
            },
            'dzone': {
                display: 'DZone', icon: 9, lang: 'en', category: 'bookmark',
                url: 'http://www.dzone.com/links/add.html?url={u}&amp;title={t}'
            },
            'facebook': {
                display: 'Facebook', icon: 10, lang: 'en', category: 'social',
                url: 'http://www.facebook.com/sharer.php?u={u}&amp;t={t}'
            },
            'fark': {
                display: 'Fark', icon: 11, lang: 'en', category: 'news',
                url: 'http://cgi.fark.com/cgi/fark/submit.pl?new_url={u}&amp;new_comment={t}'
            },
            'google': {
                display: 'Google', icon: 12, lang: 'en', category: 'bookmark',
                url: 'http://www.google.com/bookmarks/mark?op=edit&amp;bkmk={u}&amp;title={t}'
            },
            'googlereader': {
                display: 'Google Reader', icon: 13, lang: 'en', category: 'tools',
                url: 'http://www.google.com/reader/link?url={u}&amp;title={t}&amp;srcTitle={u}'
            },
            'hotmail': {
                display: 'Hotmail', icon: 14, lang: 'en', category: 'mail',
                url: 'http://www.hotmail.msn.com/secure/start?action=compose&amp;to=&amp;body={u}&amp;subject={t}'
            },
            'linkedin': {
                display: 'LinkedIn', icon: 15, lang: 'en', category: 'social',
                url: 'http://www.linkedin.com/shareArticle?mini=true&amp;url={u}&amp;title={t}&amp;ro=false&amp;summary={d}&amp;source='
            },
            'mixx': {
                display: 'Mixx', icon: 16, lang: 'en', category: 'news',
                url: 'http://www.mixx.com/submit/story?page_url={u}&amp;title={t}'
            },
            'multiply': {
                display: 'Multiply', icon: 17, lang: 'en', category: 'social',
                url: 'http://multiply.com/gus/journal/compose/addthis?body=&amp;url={u}&amp;subject={t}'
            },
            'myspace': {
                display: 'MySpace', icon: 18, lang: 'en', category: 'social',
                url: 'http://www.myspace.com/Modules/PostTo/Pages/?u={u}&amp;t={t}'
            },
            'netvibes': {
                display: 'Netvibes', icon: 19, lang: 'en', category: 'news',
                url: 'http://www.netvibes.com/share?url={u}&amp;title={t}'
            },
            'newsvine': {
                display: 'Newsvine', icon: 20, lang: 'en', category: 'news',
                url: 'http://www.newsvine.com/_wine/save?u={u}&amp;h={t}'
            },
            'reddit': {
                display: 'reddit', icon: 21, lang: 'en', category: 'news',
                url: 'http://reddit.com/submit?url={u}&amp;title={t}'
            },
            'stumbleupon': {
                display: 'StumbleUpon', icon: 22, lang: 'en', category: 'bookmark',
                url: 'http://www.stumbleupon.com/submit?url={u}&amp;title={t}'
            },
            'technorati': {
                display: 'Technorati', icon: 23, lang: 'en', category: 'news',
                url: 'http://www.technorati.com/faves?add={u}'
            },
            'tipd': {
                display: 'Tip\'d', icon: 24, lang: 'en', category: 'news',
                url: 'http://tipd.com/submit.php?url={u}'
            },
            'tumblr': {
                display: 'tumblr', icon: 25, lang: 'en', category: 'blog',
                url: 'http://www.tumblr.com/share?v=3&amp;u={u}&amp;t={t}'
            },
            'twitter': {
                display: 'twitter', icon: 26, lang: 'en', category: 'blog',
                url: 'http://twitter.com/home?status={t}%20{u}'
            },
            'windows': {
                display: 'Windows Live', icon: 27, lang: 'en', category: 'bookmark',
                url: 'https://favorites.live.com/quickadd.aspx?marklet=1&amp;mkt=en-us&amp;url={u}&amp;title={t}'
            },
            'wishlist': {
                display: 'Amazon WishList', icon: 28, lang: 'en', category: 'shopping',
                url: 'http://www.amazon.com/wishlist/add?u={u}&amp;t={t}'
            },
            'yahoo': {
                display: 'Yahoo Bookmarks', icon: 29, lang: 'en', category: 'bookmark',
                url: 'http://bookmarks.yahoo.com/toolbar/savebm?opener=tb&amp;u={u}&amp;t={t}'
            },
            'yahoobuzz': {
                display: 'Yahoo Buzz', icon: 30, lang: 'en', category: 'bookmark',
                url: 'http://buzz.yahoo.com/submit?submitUrl={u}&amp;submitHeadline={t}'
            }
        };
        this.commonSites = [];
        for (var id in this._sites) {
            this.commonSites.push(id);
        }
    }

    $.extend(Bookmark.prototype, {
        /* Class name added to elements to indicate already configured with bookmarking. */
        markerClassName: 'hasBookmark',
        /* Name of the data property for instance settings. */
        propertyName: 'bookmark',

        /* Class name for the popup trigger. */
        _popupTextClass: 'bookmark_popup_text',
        /* Class name for the popup content. */
        _popupClass: 'bookmark_popup',
        /* Class name for the bookmark list. */
        _listClass: 'bookmark_list',
        /* Class name for the compact mode. */
        _compactClass: 'bookmark_compact',
        /* Class name for the popup all sites list. */
        _allId: 'bookmark_all',

        /* Override the default settings for all bookmarking instances.
           @param  settings  (object) the new settings to use as defaults
           @return void */
        setDefaults: function (settings) {
            $.extend(this._defaults, settings || {});
            return this;
        },

        /* Add a new bookmarking site to the list.
           @param  id        (string) the ID of the new site
           @param  display   (string) the display name for this site
           @param  icon      (string) the location (URL) of an icon for this site (16x16), or
                             (number) the index of the icon within the combined image
           @param  lang      (string) the language code for this site
           @param  category  (string) the category for this site
           @param  url       (string) the submission URL for this site,
                             with {u} marking where the current page's URL should be inserted,
                             and {t} indicating the title insertion point
           @return this singleton */
        addSite: function (id, display, icon, lang, category, url) {
            this._sites[id] = { display: display, icon: icon, lang: lang, category: category, url: url };
            return this;
        },

        /* Return the list of defined sites.
           @return  (object[]) indexed by site id (string), each object contains
                    display (string) the display name,
                    icon    (string) the location of the icon, or
                            (number) the icon's index in the combined image
                    lang    (string) the language code for this site
                    url     (string) the submission URL for the site */
        getSites: function () {
            return this._sites;
        },

        /* Attach the bookmarking widget to a div.
           @param  target   (element) the control to affect
           @param  options  (object) the custom options for this instance */
        _attachPlugin: function (target, options) {
            target = $(target);
            if (target.hasClass(this.markerClassName)) {
                return;
            }
            var inst = { options: $.extend({}, plugin._defaults) };
            target.addClass(this.markerClassName).data(this.propertyName, inst);
            this._optionPlugin(target, options);
        },

        /* Retrieve or reconfigure the settings for a max length control.
           @param  target   (element) the control to affect
           @param  options  (object) the new options for this instance or
                            (string) an individual property name
           @param  value    (any) the individual property value (omit if options
                            is an object or to retrieve the value of a setting)
           @return  (any) if retrieving a value */
        _optionPlugin: function (target, options, value) {
            target = $(target);
            var inst = target.data(this.propertyName);
            if (!options || (typeof options == 'string' && value == null)) { // Get option
                var name = options;
                options = (inst || {}).options;
                return (options && name ? options[name] : options);
            }

            if (!target.hasClass(this.markerClassName)) {
                return;
            }
            options = options || {};
            if (typeof options == 'string') {
                var name = options;
                options = {};
                options[name] = value;
            }
            $.extend(inst.options, options);
            this._updatePlugin(target, inst.options);
        },

        /* Construct the requested bookmarking links.
           @param  target   (element) the bookmark container
           @param  options  (object) the settings for this container */
        _updatePlugin: function (target, options) {
            var sites = options.sites;
            if (sites.length == 0) { // All sites
                sites = [];
                $.each(plugin._sites, function (id) {
                    sites.push(id);
                });
                sites.sort();
            }
            else {
                $.each(sites, function (index, value) {
                    var lang = value.match(/lang:(.*)/); // Select by language
                    if (lang) {
                        $.each(plugin._sites, function (id, site) {
                            if (site.lang == lang[1] && $.inArray(id, sites) == -1) {
                                sites.push(id);
                            }
                        });
                    }
                    var category = value.match(/category:(.*)/); // Select by category
                    if (category) {
                        $.each(plugin._sites, function (id, site) {
                            if (site.category == category[1] && $.inArray(id, sites) == -1) {
                                sites.push(id);
                            }
                        });
                    }
                });
            }
            target.empty();
            var container = target;
            if (options.popup) {
                target.append('<a href="#" class="' + plugin._popupTextClass + '">' + options.popupText + '</a>');
                container = $('<div class="' + plugin._popupClass + '"></div>').appendTo(target);
            }
            var details = plugin._getSiteDetails(options);
            var list = $('<ul class="' + plugin._listClass +
                (options.compact ? ' ' + plugin._compactClass : '') + '"></ul>').appendTo(container);
            if (options.addFavorite) {
                plugin._addOneSite(options, list, options.favoriteText, options.favoriteIcon, '#', function () {
                    plugin._addFavourite(details.url.replace(/'/g, '\\\''), details.title.replace(/'/g, '\\\''));
                    return false;
                });
            }
            if (options.addEmail) {
                plugin._addOneSite(options, list, options.emailText, options.emailIcon,
                    'mailto:?subject=' + encodeURIComponent(options.emailSubject) +
                    '&amp;body=' + encodeURIComponent(options.emailBody.
                    replace(/\{u\}/, details.url).replace(/\{t\}/, details.title).replace(/\{d\}/, details.desc)));
            }
            plugin._addSelectedSites(sites, details, options, list);
            if (options.addShowAll) {
                var count = 0;
                for (var n in plugin._sites) {
                    count++;
                }
                var showAll = options.showAllText.replace(/\{n\}/, count);
                plugin._addOneSite(options, list, showAll, options.showAllIcon, '#', function () {
                    plugin._showAll(this, options);
                    return false;
                }, showAll);
            }
            if (options.popup) {
                target.find('a.' + plugin._popupTextClass).click(function () {
                    var target = $(this).parent();
                    var offset = target.offset();
                    target.find('.' + plugin._popupClass).css('left', offset.left).
                        css('top', offset.top + target.outerHeight()).toggle();
                    return false;
                });
            }
        },

        /* Add all the selected sites to the list.
           @param  sites    (string[]) the IDs of the selected sites
           @param  details  (object) details about this page
           @param  options  (object) the bookmark settings
           @param  list     (jQuery) the list to add to */
        _addSelectedSites: function (sites, details, options, list) {
            $.each(sites, function (index, id) {
                var site = plugin._sites[id];
                if (site) {
                    plugin._addOneSite(options, list, site.display, site.icon, (options.onSelect ? '#' :
                        site.url.replace(/\{u\}/, details.url2 + (details.sourceTag ? details.sourceTag + id : '')).
                        replace(/\{t\}/, details.title2).replace(/\{d\}/, details.desc2)),
                        function () {
                            if (options.addAnalytics && window.pageTracker) {
                                window.pageTracker._trackPageview(options.analyticsName.
                                    replace(/\{s\}/, id).replace(/\{n\}/, site.display).
                                    replace(/\{u\}/, details.url).replace(/\{r\}/, details.relUrl).
                                    replace(/\{t\}/, details.title));
                            }
                            $('#' + plugin._allId).remove();
                            if (options.onSelect) {
                                plugin._selected($(this).closest('.' + plugin.markerClassName)[0], id);
                                return false;
                            }
                            return true;
                        });
                }
            });
        },

        /* Add a single site to the list.
           @param  options  (object) the bookmark settings
           @param  list     (jQuery) the list to add to
           @param  display  (string) the display name for this site
           @param  icon     (string) the location (URL) of an icon for this site (16x16), or
                            (number) the index of the icon within the combined image
           @param  url      (string) the URl for this site
           @param  onclick  (function, optional) additional processing for this link
           @param  hint     (string, optional) the hint text to use for this link */
        _addOneSite: function (options, list, display, icon, url, onclick, hint) {
            var hintFormat = options.hint || '{s}';
            var html = '<li><a href="' + url + '"' +
                (options.target ? ' target="' + options.target + '"' : '') + '>';
            if (icon != null) {
                var title = hint || hintFormat.replace(/\{s\}/, display);
                if (typeof icon == 'number') {
                    html += '<span title="' + title + '" ' +
                        (options.iconsStyle ? 'class="' + options.iconsStyle + '" ' : '') +
                        'style="' + (options.iconsStyle ? 'background-position: ' :
                        'background: transparent url(' + options.icons + ') no-repeat ') + '-' +
                        ((icon % options.iconCols) * options.iconSize) + 'px -' +
                        (Math.floor(icon / options.iconCols) * options.iconSize) + 'px;"></span>';
                }
                else {
                    html += '<img src="' + icon + '" alt="' + title + '" title="' +
                        title + '" style="vertical-align: baseline;"/>';
                }
                html += (options.compact ? '' : '&#xa0;');
            }
            html += (options.compact ? '' : display) + '</a></li>';
            html = $(html).appendTo(list);
            if (onclick) {
                html.find('a').click(onclick);
            }
        },

        /* Remove the max length functionality from a control.
           @param  target  (element) the control to affect */
        _destroyPlugin: function (target) {
            target = $(target);
            if (!target.hasClass(this.markerClassName)) {
                return;
            }
            target.removeClass(this.markerClassName).empty().
                removeData(this.propertyName);
        },

        /* Callback when selected.
           @param  target  (element) the target div
           @param  siteID  (string) the selected site ID */
        _selected: function (target, siteID) {
            var inst = $.data(target, plugin.propertyName);
            var site = plugin._sites[siteID];
            var details = plugin._getSiteDetails(inst.options);
            inst.options.onSelect.apply(target, [siteID, site.display, site.url.replace(/&amp;/g, '&').
                replace(/\{u\}/, details.url2 + (details.sourceTag ? details.sourceTag + siteID : '')).
                replace(/\{t\}/, details.title2).replace(/\{d\}/, details.desc2)]);
        },

        /* Add the current page as a favourite in the browser.
           @param  url    (string) the URL to bookmark
           @param  title  (string) the title to bookmark */
        _addFavourite: function (url, title) {
            if (window.external && typeof window.external.addFavorite !== 'undefined') {
                window.external.addFavorite(url, title);
            }
            else {
                alert(this._defaults.manualBookmark);
            }
        },

        /* Show all sites in a popup list.
           @param  elem     (element) the clicked 'Show all' link
           @param  options  (object) the bookmark settings */
        _showAll: function (elem, options) {
            var sites = [];
            $.each(plugin._sites, function (id) {
                sites.push(id);
            });
            sites.sort();
            var details = plugin._getSiteDetails(options);
            var list = $('<ul class="' + plugin._listClass + '"></ul>');
            var saveCompact = options.compact;
            options.compact = false;
            plugin._addSelectedSites(sites, details, options, list);
            options.compact = saveCompact;
            var all = $('<div id="' + plugin._allId + '"><p>' + options.showAllTitle + '</p></div>').
                append(list).appendTo('body');
            all.css({
                left: ($(window).width() - all.width()) / 2,
                top: ($(window).height() - all.height()) / 2
            }).show();
            $('div.' + plugin._popupClass).hide();
        },

        /* Retrieve details about the current site.
           @param  options  (object) the bookmark settings
           @return  (object) the site details */
        _getSiteDetails: function (options) {
            var url = options.url || window.location.href;
            var title = options.title || document.title || $('h1:first').text();
            var desc = options.description || $('meta[name="description"]').attr('content') || '';
            var sourceTag = (!options.sourceTag ? '' :
                encodeURIComponent((url.indexOf('?') > -1 ? '&' : '?') + options.sourceTag + '='));
            return {
                url: url, title: title, desc: desc, relUrl: url.replace(/^.*\/\/[^\/]*\//, ''),
                sourceTag: sourceTag, url2: encodeURIComponent(url),
                title2: encodeURIComponent(title), desc2: encodeURIComponent(desc)
            };
        }
    });

    // The list of commands that return values and don't permit chaining
    var getters = [];

    /* Determine whether a command is a getter and doesn't permit chaining.
       @param  command    (string, optional) the command to run
       @param  otherArgs  ([], optional) any other arguments for the command
       @return  true if the command is a getter, false if not */
    function isNotChained(command, otherArgs) {
        if (command == 'option' && (otherArgs.length == 0 ||
                (otherArgs.length == 1 && typeof otherArgs[0] == 'string'))) {
            return true;
        }
        return $.inArray(command, getters) > -1;
    }

    /* Attach the bookmarking functionality to a jQuery selection.
       @param  options  (object) the new settings to use for these instances (optional) or
                        (string) the command to run (optional)
       @return  (jQuery) for chaining further calls or
                (any) getter value */
    $.fn.bookmark = function (options) {
        var otherArgs = Array.prototype.slice.call(arguments, 1);
        if (isNotChained(options, otherArgs)) {
            return plugin['_' + options + 'Plugin'].
                apply(plugin, [this[0]].concat(otherArgs));
        }
        return this.each(function () {
            if (typeof options == 'string') {
                if (!plugin['_' + options + 'Plugin']) {
                    throw 'Unknown command: ' + options;
                }
                plugin['_' + options + 'Plugin'].
                    apply(plugin, [this].concat(otherArgs));
            }
            else {
                plugin._attachPlugin(this, options || {});
            }
        });
    };

    /* Initialise the bookmarking functionality. */
    var plugin = $.bookmark = new Bookmark(); // Singleton instance

    $(function () {
        /* Remove popups. */
        $(document).bind('click.' + plugin.propertyName, function (e) { // ... on external click
            if ($(e.target).closest('div.' + plugin._popupClass).length == 0) {
                $('div.' + plugin._popupClass).hide();
            }
            if ($(e.target).closest('#' + plugin._allId).length == 0) {
                $('#' + plugin._allId).remove();
            }
        }).bind('keyup.' + plugin.propertyName, function (e) { // ... on ESC
            if (e.keyCode == 27) {
                $('div.' + plugin._popupClass).hide();
                $('#' + plugin._allId).remove();
            }
        });
        $('div.' + plugin._popupClass).on('click.' + plugin.propertyName, 'a', function () {
            $('div.' + plugin._popupClass).hide();
        });
    });

})(jQuery);
