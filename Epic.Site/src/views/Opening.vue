<template lang="pug">
    md-content
        HomeNavigation
        div
            router-view

</template>

<script>
    import HomeNavigation from "./components/Home/HomeNavigation.vue"

    export default {
        name: "Opening",
        components:{
            HomeNavigation
        },
        data: () => ({
            }),
        methods: {
            }           
    }
</script>

<style scoped lang="sass">

</style>