<template lang="pug">
    
    .homenavigation
        md-toolbar(class="md-transparent" md-elevation="0")
            .md-toolbar-section-start
                img(src="../../../assets/EPIC_logo.png")
            .md-toolbar-section-end
                md-button(class="md-raised md-primary" @click="navEvent('login')") Login/Sign Up

</template>

<script>
    export default {
        name: "HomeNavigation",
        event : ["click"],
        data() {
            return {

            }
        },
         methods : {
            navEvent(component) {
                this.$router.push('/' + component);
            }
        }
    }
</script>

<style scoped>
    img {
            width: 15%;
            height: 7.5%;
            padding: 5px;
        }
</style>