<template>

    <header :class="{Scroll: scrollPosition > 80}">

        <div class="row-black clearfix">
            <div class="content-960">


                <button type="button" id="sidebarCollapse" class="btn btn-dark rounded ml-2 float-left mr-3 mt-1" @click="toggle()">
                    <i class="fa fa-bars" aria-hidden="true"></i>
                </button>

                <a href="/home" title="Abraçaí" class="logo-header" style="margin-right: 55px;">
                    <img src="../assets/imagens/logos/Logo.png" style="width: 16%; float:right !important;" alt="Imagem Logo" title="Abraçaí" class="logo-desktop" />
                </a>

            </div>
        </div>

        <!-- Sidebar  -->
        <nav id="sidebar" v-bind:class="{ 'active': isActive }">

            <div id="dismiss" @click="toggle()">
                <i class="fa fa-close"></i>
            </div>
            <div class="user">
                <div class="media">
                    <img src="../assets/imagens/logos/Logo.png" style="width: 80%;" alt="Imagem Logo" title="Abraçaí" />
                </div>

                <br/>

                <div class="text-right">
                    <a style="cursor: pointer;" @click="logout()" class="text-light">
                        <i class="fa fa-sign-out"></i>  Sair
                    </a>
                </div>

            </div>

            <ul class="list-unstyled components" @click="toggle()">

                <li>
                    <router-link to="/home">Home</router-link>
                </li>
                <li>
                    <router-link to="/account">Usuários</router-link>
                </li>
                <li>
                    <router-link to="/projeto">Projetos</router-link>
                </li>

            </ul>
        </nav>
        <div class="overlay" v-bind:class="{ 'active': isActive }" @click="toggle()"></div>
    </header>

</template>
<script>

    import Auth from '@/common/auth'



    export default {
        name: "header-abracai",
        data() {
            return {
                user: {},
                scrollPosition: null,
                isActive: false
            }
        },
        computed: {
        },
        methods: {
            logout: function () {
                Auth.logout()
            },
            updateScroll() {
                this.scrollPosition = window.scrollY
            },
            toggle: function () {

                this.isActive = !this.isActive;
                let myBody = document.getElementsByTagName('body')[0];
                myBody.classList.toggle('modal-open');
            }
        },
        mounted() {
            window.addEventListener('scroll', this.updateScroll);
        },

    };


</script>