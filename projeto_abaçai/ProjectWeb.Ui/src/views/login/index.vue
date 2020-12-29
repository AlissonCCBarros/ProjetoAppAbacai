<template>
    <div class="gc-login__page--global" style="background-image: linear-gradient(45deg, #b5daba, #0a6f17);">
        <div class="abracai-login-container">
                    <div class="justify-content-md-center">
                        <div class="gc-login gc-login--signup gc-login--pre-signup">
                            <div class="gc-login__header">
                                <figure><img src="../../assets/imagens/logos/Logo.png" alt="Abraçaí" /></figure>
                            </div>
                            <br />

                            <form ref="account" class="gc-login__wpr">
                                <div class="gc-login__preform">

                                    <div class="gc-login__wpr">
                                        <div class="col-sm-12" v-if="!userCredentialsCorrect && !error">
                                            <p class="text-danger"><b><i>E-mail</i> e/ou senha incorretos, revise as informações.</b></p>
                                        </div>
                                        <div class="col-sm-12" v-if="error">
                                            <p class="text-danger">Opss, aconteceu algo de errado. <br /> Tente novamente em alguns instantes.</p>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <h2 class="title--main"><i>login</i></h2>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label class="label sr-only" for="">E-mail</label>
                                            <div class="form-group-icons">
                                                <input type="text" v-model="model.email" class="form-control input-lg" placeholder="E-mail" required>
                                                <span class="form-icon fa fa-envelope-o"></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label class="label sr-only" for="">Senha</label>
                                            <div class="form-group-icons">
                                                <input type="password" v-model="model.password" class="form-control input-lg" placeholder="Senha" required>
                                                <span class="form-icon fa fa-lock"></span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-12">
                                        <button class="btn btn-default btn-block btn-lg btn-wide" @click="account(model)" type="button">Entrar</button>
                                    </div>

                                </div>
                            </form>
                        </div>
            </div>
        </div>
    </div>
</template>
<script>

    import Auth from '@/common/auth'

    export default {
        name: 'account',
        data() {
            return {
                model: {
                    email: '',
                    password: ''
                },
                form: "account",
                userCredentialsCorrect: true,
                error: false
            }
        },
        methods: {
            account: function (model) {

                this.userCredentialsCorrect = true;

                if (this.formValidate() == false)
                    return;

                Auth.getUser(model, data => {
                    if (data == null) {
                        this.userCredentialsCorrect = false;
                    }
                }, error => {
                    this.error = true;
                })

            },
            formValidate: function () {
                var $form = this.$refs[this.form];
                $form.classList.add("was-validated");
                return $form.checkValidity();
            }
        },
        mounted() {

        }
    }
</script>
