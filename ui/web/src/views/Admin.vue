<template lang="pug">

    md-app(md-waterfall md-mode="reveal")
        md-app-toolbar(class="md-primary")
            .md-toolbar-row
                .md-toolbar-section-start
                    md-button(class="md-icon-button" @click="toggle")
                        md-icon dehaze
                    span(class="md-title") Administration
                .md-toolbar-section-end
                    md-button(class="md-icon-button")
                        md-icon more_vert
        md-app-drawer(:md-active.sync="menuVisible" md-persistent="mini")
            AdNavigation(@click="toggle")
        md-app-content
            router-view
            
</template>
    


<script>
    import AdNavigation from "./components/Admin/AdNavigation.vue"
    import Disclaimer from "./components/Admin/Disclaimer.vue"
    import JobPosting from "./components/Admin/JobPosting.vue"

    export default {
        name: "Admin",
        components:{
            AdNavigation,
            Disclaimer,
            JobPosting
        },
        data: () => ({
            menuVisible : false,
        }),
        methods : {
            toggle() {
                this.menuVisible = !this.menuVisible;
            }
        }
    }
</script>

<style lang="scss" scoped>

    @import "~vue-material/dist/theme/engine";

    .md-drawer {
        width: 230px;
        max-width: 100vw;
    }
    .md-app {
        min-height: 100%;
    }

</style>