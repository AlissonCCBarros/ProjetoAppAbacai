<template>

    <form ref="projeto-form-create" v-on:submit.prevent="executeCreate(model)" novalidate>

        <div class="row">

            
					<div class="form-group col-md-12">
                        <label for="nome">Nome</label>
                        <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="model.nome" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="descricao">Descricao</label>
                        <input type="text" class="form-control" name="descricao" placeholder="Descricao" v-model="model.descricao" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="dataInicio">DataInicio</label>
                        <input type="text" v-datepicker class="form-control" name="dataInicio" v-model="model.dataInicio" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="dataFim">DataFim</label>
                        <input type="text" v-datepicker class="form-control" name="dataFim" v-model="model.dataFim"  />
                    </div>
					<div class="form-group col-md-12">
                        <label for="enderecoId">EnderecoId</label>
                        <input type="text" class="form-control" name="enderecoId" placeholder="EnderecoId" v-model="model.enderecoId" required />
                    </div>
					<div class="form-group col-md-12">
                        <label for="usuarioId">UsuarioId</label>
                        <input type="text" class="form-control" name="usuarioId" placeholder="UsuarioId" v-model="model.usuarioId" required />
                    </div>


        </div>

        <button type="button" class="btn btn-default" @click="onBack()">
            <span>Voltar</span>
        </button>
        <button type="button" class="btn btn-success float-right" @click="executeCreate(model)">
            <span>Salvar</span>
        </button>

    </form>


</template>
<script>
    
	import base from '@/common/base.js'
    import { Api } from '@/common/api'

    export default {
        name: "projeto-form-create",
        mixins: [base],
        data: () => ({

            model: {},

            form: "projeto-form-create",
            
            resources: {
                create: 'projeto',
            },

        }),
		
        methods: {

            executeCreate: function (model) {

                if (this.formValidate() == false)
                    return;

                new Api(this.resources.create).post(model).then(data => {
                    this.$emit('on-saved', data)
                    this.defaultSuccessResult('Registro inserido com sucesso');
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
    };
</script>

