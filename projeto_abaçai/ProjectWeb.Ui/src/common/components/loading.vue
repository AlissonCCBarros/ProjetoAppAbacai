<template>

    <div class="loader" v-show="isloading">
        <img src="../../assets/loader.png" alt="Carregando..." />
    </div>

</template>
<script>

    export default {
        name: "loading",
        data() {
            return {
                isloading: false
            };
        },
        mounted() {
            this.$eventHub.$on('show-loading', (show) => {
                this.isloading = show;
            })
        },
        beforeDestroy() {
            this.$eventHub.$off('show-loading');
        },
    };
</script>
<style>
    .loader {
        position: fixed;
        z-index: 9999;
        background-color: #2f2f2f;
        opacity: 0.6;
        filter: alpha(opacity=60);
        width: 100%;
        height: 100%;
    }

        .loader img {
            display: block;
            margin: 200px auto;
            -webkit-animation: sk-rotateplane 3s infinite ease-in-out;
            animation: sk-rotateplane 3s infinite ease-in-out;
            width: 150px;
            height:auto;
        }

    @-webkit-keyframes sk-rotateplane {
        0% {
            -webkit-transform: perspective(110px) rotateY(0deg);
        }

        25% {
            -webkit-transform: perspective(110px) rotateY(180deg);
        }

        50% {
            -webkit-transform: perspective(110px) rotateY(360deg) rotateX(180deg);
        }

        75% {
            -webkit-transform: perspective(110px) rotateY(180deg);
        }

        100% {
            -webkit-transform: perspective(110px) rotateY(0deg);
        }
    }

    @keyframes sk-rotateplane {

        0% {
            transform: perspective(110px) rotateY(0deg);
            -webkit-transform: perspective(110px) rotateY(0deg);
        }

        25% {
            transform: perspective(110px) rotateY(180deg);
            -webkit-transform: perspective(110px) rotateY(180deg);
        }

        50% {
            transform: perspective(110px) rotateY(360deg);
            -webkit-transform: perspective(110px) rotateY(360deg) rotateX(180deg);
        }

        75% {
            transform: perspective(110px) rotateY(180deg);
            -webkit-transform: perspective(110px) rotateY(180deg);
        }

        100% {
            transform: perspective(110px) rotateY(0deg);
            -webkit-transform: perspective(110px) rotateY(0deg);
        }
    }
</style>