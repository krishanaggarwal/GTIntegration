function getParameter(name, url) {
    if (!url) {
        url = window.location.href;
    }
    var paramsStart = url.indexOf("?");

    if (paramsStart !== -1) {
        var paramString = url.substr(paramsStart + 1);
        var tokenStart = paramString.indexOf(name);

        if (tokenStart !== -1) {
            var paramToEnd = paramString.substr(tokenStart + name.length + 1);
            var delimiterPos = paramToEnd.indexOf("&");

            if (delimiterPos === -1) {
                return paramToEnd;
            }
            return paramToEnd.substr(0, delimiterPos);
        }
    }
    return -1;
}

function paramsToObject(url) {
    var o = {};
    if (!url) {
        url = window.location.href;
    }
    var paramsStart = url.indexOf("?");
    if (paramsStart !== -1) {
        var paramString = url.substr(paramsStart + 1);
        var middle = 0, end = 0;

        while (paramString.length > 0 && end >= 0) {
            middle = paramString.indexOf("=");
            end = paramString.indexOf("&");
            var key = paramString.substr(0, middle);

            var value = paramString.substr(middle + 1, (end > 0) ? end - middle - 1 : paramString.length - middle - 1);
            o[key] = value;
            paramString = paramString.substr(end + 1);
        }
    }
    return o;
}

function objectToParams(o) {
    var str = [];
    for (var p in o) {
        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(o[p]));
    }
    return str.join("&");
}