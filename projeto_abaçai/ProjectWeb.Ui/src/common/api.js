import Vue from 'vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import Cache from './cache.js'
import Global from './global.js'
import Auth from './auth.js'

Vue.use(VueAxios, axios)

export function Api(resource, endpoint) {
    
    this.Resourse = resource;
    this.EndPoint = endpoint;

    this.defaultFilter = {
        pageSize: 10,
        pageIndex: 0,
        isPaginate: true,
    };

    this.byCache = false;
    this.hasDefaultFilters = true;
    this.lastAction = "none";
    this.url = "";

    this.get = _get;
    this.post = _post;
    this.put = _put;
    this.delete = _delete;
    this.dataItem = _dataItem;

    var self = this;

    function _post(model) {

        self.lastAction = "post";
        self.url = makeUri();

        return axios
            .post(self.url, model)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _put(model) {

        self.lastAction = "put";
        self.url = makeUri();

        return axios
            .put(self.url, model)
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _delete(model) {

        self.lastAction = "delete";
        self.url = makeUri()

        return axios
            .delete(self.url, { params: model })
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _get(filters) {
        
        self.lastAction = "get";
        self.url = makeUri()

        var _filters = Object.assign(this.defaultFilter, filters);
        if (_filters.id)
            self.url = String.format("{0}/{1}", self.url, _filters.id);

        return axios
            .get(self.url, { params: _filters })
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function _dataItem(filters) {

        self.lastAction = "get";
        self.url = makeUri()

        var _filters = Object.assign(this.defaultFilter, filters);
        if (_filters.id)
            self.url = String.format("{0}/{1}", self.url, _filters.id);

        return axios
            .get(self.url, { params: _filters })
            .then(res => { handleSuccess(res.data); return res.data; })
            .catch(err => { handleError(err.response); throw err.response; })
    }

    function makeUri() {

        var endpoint = self.EndPoint;
        
        if (!self.EndPoint)
            endpoint = Global.END_POINT_DEFAULT;

        configHeaders();

        return String.format("{0}/{1}", endpoint, self.Resourse)
    }

    function configHeaders() {
        
        var accesstoken = Cache.get(Global.ACCESS_TOKEN);
        if (accesstoken)
            axios.defaults.headers.common['Authorization'] = "Bearer " + Cache.get(Global.ACCESS_TOKEN);
        
        axios.defaults.headers.common['Accept-Language'] = "pt-BR";
    }

    function handleSuccess(response) {
        addCache(response.data);
    }

    function handleError(err) {
        if (err && err.status == 401)
            Auth.login(true);
    }

    function addCache(data) {

        if (!self.byCache)
            return;

        if (self.url == "")
            return;

        if (self.lastAction == "get") {
            if (data.Data != null || (data.DataList != null && data.DataList.length > 0)) {
                data = JSON.stringify(data);
                Cache.Add(self.url, data)
            }
        }
    }

    String.format = function () {
        var theString = arguments[0];
        for (var i = 1; i < arguments.length; i++) {
            var regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
            theString = theString.replace(regEx, arguments[i]);
        }
        return theString;
    }

    Object.$httpParamSerializer = function () {
        var obj = arguments[0];
        return Object.entries(obj).map(([key, val]) => `${key}=${val}`).join('&')
    }

}
