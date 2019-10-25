<template lang="pug">

    md-snackbar( md-position="center" md-persistent  :md-active.sync="show")
        span {{message}}
        md-button(class="md-primary" @click="show = false") Close

</template>

<script>

    import {bus} from "../../../eventbus.js";

    export default {
        name: "ErrorBar",
        data() {
            return {
                message: '',
                show: false
            }
        },
        mounted() {
            bus.$on('ERROR', (message) => {
                this.message = message
                this.show = true
            })
        }
    }
</script>

<style scoped>

</style>