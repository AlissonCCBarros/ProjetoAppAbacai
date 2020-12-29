<template>

    <form ref="account-form-edit" v-on:submit.prevent="executeEdit(model)" novalidate>

        <div class="row">

            
					<div class="form-group col-md-12">
                        <label for="name">Name</label>
                        <input type="text" class="form-control" name="name" placeholder="Name" v-model="model.name" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="email">Email</label>
                        <input type="text" class="form-control" name="email" placeholder="Email" v-model="model.email" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="password">Password</label>
                        <input type="text" class="form-control" name="password" placeholder="Password" v-model="model.password" required />
                    </div>


        </div>

        <button type="button" class="btn btn-default" @click="onBack()">
            <span>Voltar</span>
        </button>
        <button type="button" class="btn btn-success float-right" @click="executeEdit(model)">
            <span>Salvar</span>
        </button>

    </form>


</template>
<script>

    import base from '@/common/base.js'
    import { Api } from '@/common/api'

    export default {
        name: "account-form-edit",
        mixins: [base],
        props: { id: Number },
        data: () => ({

            model: {},

            form: "account-form-edit",
            
            resources: {
                edit: 'account',
            },

        }),
		
        methods: {

            executeEdit: function (model) {

                if (this.formValidate() == false)return;

                new Api(this.resources.edit).put(model).then(data => {
                    this.defaultSuccessResult("Edição realizada com sucesso");
                    this.$emit('on-saved', data)
                }, err => {
                    this.defaultErrorResult(err);
                })
            },

            formValidate: function () {
                var $form = this.$refs[this.form];
                $form.classList.add("was-validated");
                return $form.checkValidity();
            },

            onBack: function () {
                this.$emit('on-back')
            }
        },

        mounted() {
            new Api(this.resources.edit).get({ accountId: this.id }).then(data => {
                if (data.data) this.model = data.data;
                else if (!data.dataList) this.model = {};
                else if (data.dataList.length == 1) this.model = data.dataList[0];
                else this.model = {};
            }, err => {
                this.defaultErrorResult(err);
            })
        }
    };
</script>