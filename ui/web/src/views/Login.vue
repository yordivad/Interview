<template lang="pug">

    .md-layout(class="page md-alignment-center-center" )
        md-content(class="login md-elevation-23")
            transition(name="fade" mode="out-in")
                .is-login(key=1 v-if="isLogin")
                    md-content(class="md-primary register small-box")
                        .md-layout(class="md-alignment-center-center")
                            .md-layout-item
                                md-empty-state( md-icon="face" md-label="Welcome")
                                .md-layout(class="md-alignment-bottom-center")
                                    md-button(class="md-accent" @click="register") Create Account
                    .sing(class="large-box")
                        .md-layout(class="md-alignment-center-center")
                            .md-layout-item
                                sign-in(class="box")
                .is-login(key=2 v-else)
                    md-content(class="md-accent to-login small-box")
                        .md-layout(class="md-alignment-center-center")
                            .md-layout-item
                                md-empty-state( md-icon="undo" md-label="Back to login")
                                .md-layout(class="md-alignment-bottom-center")
                                    md-button(class="md-primary" @click="login") Back
                    .sing(class="large-box")
                        .md-layout(class="md-alignment-center-center")
                            .md-layout-item
                                register(class="box" @created="userCreated")

</template>

<script>

    import SignIn from "./components/Login/SignIn"
    import Register from "./components/Login/Register"

    export default {
        name: "Login",
        components: {
            SignIn,
            Register
        },
        data() {
            return {
                isLogin: true,
            }
        },
        methods: {
            register() {
                this.isLogin = false
            },
            login() {
                this.isLogin = true
            },
            userCreated() {
                this.isLogin = true
            }
        }
    }
</script>

<style lang="scss" scoped>

    @import "~vue-material/dist/theme/engine";


    .fade-enter {
        opacity: 0;
    }

    .fade-enter-active {
        transition: opacity 0.5s;
    }

    .fade-leave-active {
        transition: opacity 0.5s;
        opacity: 0;
    }

    .small-box {
        width: 38.2%;

    }

    .large-box {
        width: 61.8%;
    }


    .page {
        height: 100%;
        background-image: url("../assets/19604.jpg");
        background-repeat: no-repeat;
        background-size: cover;
        background-position: center center
    }

    .login {

        height: 500px;
        width: 840px;
        border-radius: 20px;

        .is-login {
            width: 100%;
            height: 100%;
            display: inline-flex;
        }

        .register {
            height: 100%;
            justify-content: center;
            vertical-align: center;
            border-bottom-left-radius: 20px;
            border-top-left-radius: 20px;
        }

        .to-login {
            height: 100%;
            justify-content: center;
            vertical-align: center;
            border-bottom-left-radius: 20px;
            border-top-left-radius: 20px;
        }

        .sign {
            padding: 20px;
            height: 100%;
        }

        .md-layout {
            height: 100%;
        }

        .box {
            padding: 20px 40px;
        }

    }

</style>