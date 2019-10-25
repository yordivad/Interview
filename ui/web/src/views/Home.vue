<template lang="pug">

    md-content
        HomeNavigation
        HomeContent

</template>

<script>

    import HomeNavigation from "./components/Home/HomeNavigation.vue"
    import HomeContent from "./components/Home/HomeContent.vue"

    export default {
        name: "Home",
        components:{
            HomeNavigation,
            HomeContent
        },
        data: () => ({
        }),
        methods : {
        }
    }
</script>

<style lang="scss" scoped >

    @import "~vue-material/dist/theme/engine";

</style>