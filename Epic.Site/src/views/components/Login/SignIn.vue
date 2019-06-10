<template lang="pug">
    .sign-in
        .md-layout(class="title md-alignment-top-center")
            span(class = "md-title") Sign In

        form( class="md-layout content" data-vv-scope="login")

                md-field( :class ="{'md-invalid':errors.has('login.email')}")
                    label user
                    md-input(id="email" type="email" v-model="user" data-vv-name="email" v-validate="'required|email'" )
                    span(class ="md-error") {{ errors.first('login.email')}}

                md-field(:class ="{'md-invalid':errors.has('login.password')}")
                    label password
                    md-input(id="password" type="password" v-model="password" data-vv-name="password" v-validate="'required'")
                    span(class ="md-error") {{ errors.first('login.password')}}

        .md-layout(class="line-1 md-alignment-bottom-center")
                a(class="md-caption") forgot your password

        .md-layout(class="line-2 md-alignment-bottom-center")
                md-button(class="md-raised md-primary" @click="login" :disabled="errors.any()") Login

</template>

<script>
    import {mapGetters} from 'vuex'
    import {bus} from "../../../eventbus"


    export default {
        name: "SighIn",
        data() {
            return {
                user: "",
                password: ""
            }
        },
        computed: {
            ...mapGetters(["status", "isLogin"])
        },
        methods: {

            login() {
                this.$validator.validateAll('login').then((result) => {
                    if (result) {
                        this.$store.dispatch("login", {user: this.user, password: this.password})
                            .then(() => this.$router.push("/"))
                            .catch(err => {
                                return bus.$emit("ERROR", err.message);
                            })
                    }
                })
            }
        }
    }
</script>

<style lang="scss" scoped>

    .sign-in {

        .title {

        }

        .content {
            padding-top: 40px;
        }

        .line-1 {
            padding-top: 20px;
        }

        .line-2 {
            padding-top: 35px;
        }

    }


</style>