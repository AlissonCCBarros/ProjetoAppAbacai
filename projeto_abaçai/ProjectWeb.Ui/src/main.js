import Vue from 'vue'
import App from './App.vue'
import router from './router/index.js'

import './common/directives/select'
import './common/directives/datepicker'

import BootstrapVue from 'bootstrap-vue'
Vue.use(BootstrapVue);

import VueTheMask from 'vue-the-mask'
Vue.use(VueTheMask)

import VueMask from 'di-vue-mask'
Vue.use(VueMask);

import vSelect from 'vue-select'
Vue.component('v-select', vSelect)

import VueSweetalert2 from 'vue-sweetalert2'
Vue.use(VueSweetalert2)

import Vue2Filters from 'vue2-filters'
Vue.use(Vue2Filters)

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import './assets/css/custom.scss'

Vue.config.productionTip = false

Vue.prototype.$eventHub = new Vue();

new Vue({
    router,
    render: h => h(App),
    mounted() {
        this.$eventHub.$on('show-notification', (data) => {

            let _config = {
                position: 'top',
                toast: true,
                type: data.type,
                title: data.title,
                text: data.text,
                timer: 3000,
                showConfirmButton: false,
            }

            if (data.modal) {
                _config.position = 'center';
                _config.toast = false;
                _config.showConfirmButton = true;
                _config.timer = null;
            }

            this.$swal(_config);
        })
    },
    beforeDestroy() {
        this.$eventHub.$off('show-notification');
    },
}).$mount('#app')
