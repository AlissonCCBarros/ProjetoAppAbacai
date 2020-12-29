import Vue from 'vue'
import Router from 'vue-router'

import Auth from '@/common/auth'

import Template from '@/template/index'
import Home from '@/views/home'
import Login from '@/views/login'

import routersgenerated from './generated'

Vue.use(Router)

let childrens = routersgenerated.concat([
    {
        path: 'home',
        name: 'Home',
        component: Home
    }
]);

const router = new Router({
    mode: 'history',
    routes: [
        {
            path: '/login',
            name: 'Login',
            component: Login
        },
        {
            path: '/',
            redirect: '/home',
            component: Template,
            meta: { requiresAuth: true },
            children: childrens
        },
    ]
})

router.beforeEach(async (to, from, next) => {
    if (to.matched.some(record => record.meta.requiresAuth)) {

        if (!Auth.logged()) {
            Auth.login(true);
            return;
        }
    }
    next();
});


export default router;
