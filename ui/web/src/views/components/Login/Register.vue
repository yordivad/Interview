<template lang="pug">

    .register
        .md-layout(class="title md-alignment-top-center")
            span(class = "md-title") Create User

        form(class="md-layout content" data-vv-scope="register")
                md-field( :class ="{'md-invalid':errors.has('register.name')}")
                    label name
                    md-input(type="text" v-model="name" data-vv-name="name" v-validate="'required'" )
                    span(class ="md-error") {{ errors.first('register.name')}}

                md-field( :class ="{'md-invalid':errors.has('register.lastname')}")
                    label last name
                    md-input( type="text" v-model="lastname" data-vv-name="lastname" v-validate="'required'" )
                    span(class ="md-error") {{ errors.first("register.lastname")}}

                md-field( :class ="{'md-invalid':errors.has('register.email')}")
                    label email
                    md-input( type="email" v-model="email" data-vv-name="email" v-validate="'required|email'" )
                    span(class ="md-error") {{ errors.first('register.email')}}

                md-field( :class ="{'md-invalid':errors.has('register.password')}")
                    label password
                    md-input( type="password" v-model="password" data-vv-name="password" ref="password" v-validate="'required|min:8'" )
                    span(class ="md-error") {{ errors.first('register.password')}}

                md-field( :class ="{'md-invalid':errors.has('register.password_confirm')}")
                    label password confirm
                    md-input(type="password" v-model="password_confirm" data-vv-name="password_confirm"  data-vv-as="password" v-validate="'required|min:8|confirmed:password'" )
                    span(class ="md-error") {{ errors.first('register.password_confirm')}}


        .md-layout(class="button_line md-alignment-bottom-right")
            md-button(class="md-raised md-primary" @click="create" :disabled="errors.any()") Save

</template>

<script>

    import {mapGetters} from 'vuex'
    import {bus} from "../../../eventbus"

    
    export default {
        name: "Register",
        event: ["created"],
        data() {
            return {
                name: '',
                lastname: '',
                email: '',
                password: '',
                password_confirm: ''
            }
        },
        computed: {
            ...mapGetters(["status"])
        },
        methods: {
            create() {
                this.$validator.validateAll('register').then((result) => {
                    if (result) {

                        this.$store.dispatch("register", {
                            name: this.name,
                            lastName: this.lastname,
                            email: this.email,
                            password: this.password,
                            passwordConfirm: this.password_confirm
                        })
                            .then(() =>{
                                this.$emit('created')
                                bus.$emit("ERROR", "the user was created")
                            })
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

    .register {
        .md-title {
            padding-top: 10px;
        }
        
        .button_line {
            padding-top: 10px;
            padding-bottom: 10px;
        }
    }

</style>