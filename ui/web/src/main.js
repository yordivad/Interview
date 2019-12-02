import Vue from 'vue'
import VueMaterial from 'vue-material'
import VeeValidate  from 'vee-validate'
import 'vue-material/dist/vue-material.min.css'
import './theme/epic.theme.scss'

import store from './store/store'
import router from './router'


import App from './App.vue'


Vue.config.productionTip = false;

Vue.use(VueMaterial);
Vue.use(VeeValidate);


new Vue({
  store,
  router,
  render: h => h(App),
}).$mount('#app');
