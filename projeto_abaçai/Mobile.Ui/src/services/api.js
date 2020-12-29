import axios from 'axios';
import qs from 'qs';
import * as Cache from '../services/cache';

import { NativeModules } from 'react-native';
import NavigationService from '../services/navigationService';

export class Api {
    constructor(resource, endpoint) {
        this.Resourse = resource;
        this.EndPoint = endpoint;

        this.defaultFilter = {
            pageSize: 10,
            pageIndex: 0,
            isPaginate: true
        };

        this.byCache = false;
        this.hasDefaultFilters = true;
        this.lastAction = 'none';
        this.url = '';
        this.get = _get;
        this.post = _post;
        this.put = _put;
        this.delete = _delete;
        this.dataItem = _dataItem;
        var self = this;

        async function _post(model) {
            self.lastAction = 'post';
            self.url = await makeUri();
            return axios
                .post(self.url, model)
                .then(res => {
                    handleSuccess(res.data);
                    return res.data;
                })
                .catch(err => {
                    handleError(err.response);
                    throw err.response;
                });
        }

        async function _put(model) {
            self.lastAction = 'put';
            self.url = await makeUri();
            return axios
                .put(self.url, model)
                .then(res => {
                    handleSuccess(res.data);
                    return res.data;
                })
                .catch(err => {
                    handleError(err.response);
                    throw err.response;
                });
        }

        async function _delete(model) {
            self.lastAction = 'delete';
            self.url = await makeUri();
            return axios
                .delete(self.url, { params: model })
                .then(res => {
                    handleSuccess(res.data);
                    return res.data;
                })
                .catch(err => {
                    handleError(err.response);
                    throw err.response;
                });
        }

        async function _get(filters) {
            self.lastAction = 'get';
            self.url = await makeUri();
            var _filters = Object.assign(this.defaultFilter, filters);
            if (_filters.id) self.url = String.format('{0}/{1}', self.url, _filters.id);
            return axios
                .get(self.url, {
                    params: _filters,
                    paramsSerializer: () => {
                        return qs.stringify(filters);
                    }
                })
                .then(res => {
                    handleSuccess(res.data);
                    return res.data;
                })
                .catch(err => {
                    handleError(err.response);
                    throw err.response;
                });
        }

        async function _dataItem(filters) {
            self.lastAction = 'get';
            self.url = await makeUri();
            var _filters = Object.assign(this.defaultFilter, filters);
            if (_filters.id) self.url = String.format('{0}/{1}', self.url, _filters.id);
            return axios
                .get(self.url, {
                    params: _filters,
                    paramsSerializer: () => {
                        return qs.stringify(filters);
                    }
                })
                .then(res => {
                    handleSuccess(res.data);
                    return res.data;
                })
                .catch(err => {
                    handleError(err.response);
                    throw err.response;
                });
        }

        async function makeUri() {
            var endpoint = self.EndPoint;
            if (!self.EndPoint) endpoint = 'http://518e8a1733bb.ngrok.io';


            await configHeaders();
            return String.format('{0}/api/{1}', endpoint, self.Resourse);
        }

        async function configHeaders() {
            let accesstoken = await Cache.get('ACCESS_TOKEN');
            if (accesstoken) axios.defaults.headers.common['Authorization'] = 'Bearer ' + accesstoken;
            axios.defaults.headers.common['Accept-Language'] = 'pt-BR';
        }

        function handleSuccess(response) {
            addCache(response.data);
        }

        async function handleError(err) {
            if (err && err.status == 401) {
                //redirecionar para o login
                await Cache.clear();
                NativeModules.DevSettings.reload();
            }
        }

        function addCache(data) {
            if (!self.byCache) return;
            if (self.url == '') return;
            if (self.lastAction == 'get') {
                if (data.Data != null || (data.DataList != null && data.DataList.length > 0)) {
                    data = JSON.stringify(data);
                    Cache.Add(self.url, data);
                }
            }
        }

        String.format = function () {
            var theString = arguments[0];
            for (var i = 1; i < arguments.length; i++) {
                var regEx = new RegExp('\\{' + (i - 1) + '\\}', 'gm');
                theString = theString.replace(regEx, arguments[i]);
            }
            return theString;
        };

        Object.$httpParamSerializer = function () {
            var qs = JSON.stringify(arguments[0]);
            var pairs = qs.split('&');
            var result = {};
            pairs.forEach(p => {
                var pair = p.split('=');
                var key = pair[0];
                var value = decodeURIComponent(pair[1] || '');
                if (result[key]) {
                    if (Object.prototype.toString.call(result[key]) === '[object Array]') {
                        result[key].push(value);
                    } else {
                        result[key] = [result[key], value];
                    }
                } else {
                    result[key] = value;
                }
            });
            return JSON.parse(JSON.stringify(result));
        };
    }
}
