
import axios from 'axios'
import {Promise} from "q";

export default {
    namespace: true,
    state: {
        status: '',
        token: localStorage.getItem('token') || '',
        user: {
            login: "",
            password: ""
        }
    },
    mutations: {
        auth_request(state) {
            state.status = 'loading'
        },
        auth_success(state, token, user) {
            state.status = 'success';
            state.token = token;
            state.user = user
        },
        auth_failure(state) {
            state.status="fail"
        },
        auth_logout(state) {
            state.status = "";
            state.token = "";
            state.user = {}
        }
    },
    actions: {

        login({commit}, user) {
            return new Promise((resolve, reject) => {
                commit("auth_request");
                axios({url: process.env.API_URL + "/login", data: user, method: 'POST'})
                    .then(resp=> {
                        localStorage.setItem('token', resp.data.token);
                        axios.defaults.headers['Authorization'] = resp.data.token;
                        commit("auth_success", resp.data.token, user);
                        resolve(resp)
                    })
                    .catch(err =>{
                        commit('auth_failure');
                        localStorage.removeItem('token');
                        reject(err)
                    })

            })
        },
        register({commit}, user) {
            return new Promise((resolve, reject)=> {
                commit("auth_request");
                axios({url: process.env.API_URL + "/register", user, method: 'POST'})
                    .then(resp=> {
                        localStorage.setItem('token', resp.data.token);
                        axios.defaults.headers['Authorization'] = resp.data.token;
                        commit("auth_success", resp.data.token, user);
                        resolve(resp)
                    })
                    .catch(err=> {
                        reject(err)
                    })
            })
        },
        logout({commit}) {
            return new Promise(resolve => {
              commit('logout');
                localStorage.removeItem('token');
                axios.defaults.headers.common['Authorization'] = "";
               resolve()
            })
        }

    },
    getters: {
        isLogin: state => state.token,
        status : state => state.status
    }
}

