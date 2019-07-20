<template lang="pug">
    md-content
        div
           md-card
                md-card-header
                    .md-title Information disclaimer
                    .md-subhead To continue with the application process, please read the following disclaimer and click "Accept". If you decline, you will not be able to apply for a position.
                md-card-content
                    p {{disclaimer}}
                md-card-actions
                    md-button(class="md-raised md-accent" @click="navEvent('jobs/list')") Decline
                    md-button(class="md-raised md-primary" @click="navEvent('jobs/form')") Accept 

</template>

<script>
    
    export default {
        name: "ShowDisclaimer",
        event : ["click"],
        data: () => ({
            disclaimer: 'aliweugflaiuweglfiabwliuefglaiuwbefiluqbwailebfilawbeilufabwliefbliawbeifubalwiuebfliauwbefiluabwliuebfiulawbefiulalbwiefbilauwbefiulawbiuflabwliuefbiualwblefiulabwelif'
        }),
        methods: {
             navEvent(component) {
                this.$router.push('/' + component);
            }
        }
    }
</script>

<style scoped>
    .md-card {
        margin: 4px;
    }

    .md-title {
        font-size: 30px;
    }

    .md-subhead {
        font-size: 15px;
    }

</style>