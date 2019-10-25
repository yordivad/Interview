
import Vue from 'vue'
import Router from 'vue-router'
import store from './store/store'
import Login from './views/Login'
import Home from './views/Home'
import Admin from './views/Admin'
import Opening from './views/Opening'
import Disclaimer from './views/components/Admin/Disclaimer'
import JobPosting from './views/components/Admin/JobPosting'

Vue.use(Router);

let router = new Router({
    mode: 'history',

    routes: [
        {
            path: '/',
            name: 'home',
            component: Home,
            meta: {
                auth: true
            }
        },
        {
            path: '/login',
            name: 'login',
            component: Login,
        },
        {
            path: '/jobs',
            name: 'jobs',
            component: Opening
        },
        {
            path: '/admin',
            name: 'admin',
            component: Admin,
            children: [
                {
                    path: 'disclaimer',
                    name: 'disclaimer',
                    component: Disclaimer
                },
                {
                    path: 'jobPosting',
                    name: 'jobPosting',
                    component: JobPosting 
                }
            ]
        },
        {
            path: '*',
            redirect: '/'
        }
    ]
});


router.beforeEach((to,from, next) => {
    if (to.matched.some(record => record.meta.auth)) {
        if (store.getters.isLogin) {
            next();
            return
        }
        next("/login");
    } else {
        next()
    }
});

export default router;