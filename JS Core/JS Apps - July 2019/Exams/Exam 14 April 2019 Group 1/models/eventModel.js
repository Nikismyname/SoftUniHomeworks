const eventModel = function () {

    const create = function (params) {
        let data = { ...params };
        let url = `/appdata/${storage.appKey}/events`
        ///the requester will set Auth Token authentiacation
        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };
        return requester.post(url, headers);
    }

    const edit = function (params, eventId) {
        let data = { ...params };
        let url = `/appdata/${storage.appKey}/events/${eventId}`
        ///the requester will set Auth Token authentiacation
        let headers = {
            body: JSON.stringify(data),
            headers: {}
        };
        return requester.put(url, headers);
    }

    const getAll = function () { 
        let url = `/appdata/${storage.appKey}/events`
        let headers = {
            headers: {}
        };
        return requester.get(url, headers);
    }

    const getSingle = function (eventId) {
        let url = `/appdata/${storage.appKey}/events/${eventId}`
        let headers = {
            headers: {}
        };
        return requester.get(url, headers);
    }

    const deleteEvent = function (eventId) {
        let url = `/appdata/${storage.appKey}/events/${eventId}`;
        let headers = {
            headers: {}
        };
        return requester.del(url,headers);
    }

    return {
        create,
        getAll,
        edit,
        getSingle,
        deleteEvent,
    }
}();