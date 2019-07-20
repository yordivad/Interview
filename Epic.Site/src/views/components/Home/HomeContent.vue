<template lang="pug">
    
    .homecontent
        .md-layout(class="page md-alignment-center-center" )
            .col
                h1(class="welcome") Welcome to Epic Software Development
                h3(class="hiring") We're hiring!
                p(class="intro") 
                    | Epic is a software company with clients all over the world.
                    br
                    br
                    | We're looking for new and fresh talents to join our ranks and be part of the Epic family. 
                .md-layout(class="md-alignment-center-center")
                    md-card(class="md-primary")
                            md-card-header
                                .md-title Join us!
                            md-card-content
                                | Check out our available jobs and apply! Join us today!
                            md-card-actions
                                md-button(@click="navEvent('jobs/list')") Apply Now!
                    md-card(class="md-primary")
                            md-card-header
                                .md-title Who Are We?
                            md-card-content
                                | Learn more about EPIC and what we have to offer
                            md-card-actions
                                md-button(href="http://epicsoftwaredev.com" target="_blank") About Us
                                
                    md-card(class="md-primary")
                            md-card-header
                                .md-title Contact
                            md-card-content
                                | Leave us a message or commentary, we'll get back to you soon
                            md-card-actions
                                md-button Send Message

</template>

<script>
    export default {
        name: "HomeContent",
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
    .md-card {
        vertical-align: bottom;
        display: inline-block;
        width: 23%;
        margin: 5%;
    }

    .page {
        height: 100%;
        background-image: url("../../../assets/19604.jpg");
        background-repeat: no-repeat;
        background-size: cover;
        background-position: center center
    }

    .welcome {
        font-size: 50px;
        color:white;
    }

    .intro {
        color: white;
        font-size: 20px;

    }

    .hiring {
        font-size: 30px;
        color: white;
    }
</style>