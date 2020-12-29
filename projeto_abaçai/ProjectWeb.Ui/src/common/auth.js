import Cache from './cache'
import Global from './global'
import { Api } from './api'

export default {

    loadfinished_key: 'Login',
    lastlocation_key: 'HOME',

    logged: function () {
        return Cache.get(this.loadfinished_key) == "finished";
    },

    getUser: function (model, onSuccess, onError) {

        model.attributeBehavior = "WebSystem";

        new Api("user").post(model).then(result => {
            if (onSuccess) onSuccess(result.data);

            if (result.data != null) {

                Cache.add(Global.ACCESS_TOKEN, result.data.token);

                Cache.add(this.loadfinished_key, "finished")

                setTimeout(() => {
                    let _lastlocation = Cache.get(this.lastlocation_key);
                    if (_lastlocation) window.location = _lastlocation;
                    else window.location = "/";
                }, 500);
            }
        }, (err) => {
            if (onError) onError(err);
        })
    },

    login: function (saveActualPage) {

        if (saveActualPage)
            Cache.add(this.lastlocation_key, window.location.pathname);

        window.location = "/login";

        this.reset();
    },

    reset: function () {
        Cache.remove(Global.ACCESS_TOKEN);
    },

    logout: function () {
        this.reset();

        window.location = "/login";
    },

}
