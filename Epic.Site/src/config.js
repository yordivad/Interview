import axios from "axios";


axios.defaults.xsrfHeaderName = "XSRF-TOKEN";
axios.defaults.xsrfCookieName = "AntiForgery";


axios.get(process.env.VUE_APP_API_URL + "/AntiForgery").then(resp =>{

    axios.defaults.headers.common[resp.data.tokenName] = resp.data.token;

});
