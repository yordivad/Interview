<template lang="pug">

    md-app(md-waterfall md-mode="reveal")
        md-app-toolbar(class="md-primary")
            .md-toolbar-row
                .md-toolbar-section-start
                    md-button(class="md-icon-button" @click="toggle")
                        md-icon dehaze
                    span(class="md-title") Application
                .md-toolbar-section-end
                    md-button(class="md-icon-button")
                        md-icon more_vert
        md-app-drawer(:md-active.sync="menuVisible" md-persistent="mini")
            navigation(@click="toggle")
        md-app-content
            opening

</template>

<script>

    import Navigation from "./components/App/Navigation.vue"
    import Opening from "./Opening.vue"

    export default {
        name: "Home",
        components:{
            Opening,
            Navigation
        },
        data: () => ({
            menuVisible : false
        }),
        methods : {
            toggle() {
                this.menuVisible = !this.menuVisible;
            }
        }
    }
</script>

<style lang="scss" scoped >
    .md-drawer {
        width: 230px;
        max-width: calc(100vw - 125px);
    }
    .md-app {
        min-height: 100vh;
    }
</style>