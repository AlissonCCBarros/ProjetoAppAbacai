<template>
    <main>
        <section>
            <div class="content-960">
                <div class="row">
                    <section class="col-sm-12">
                        <button class="btn-large-40 btn-primary uppercase pull-right btn-header  mr-1" @click="showHideFiltros()">
                            Filtros
                        </button>
                    </section>
                </div>
            </div>

            <div class="content-960 mobile-row mt-4" v-if="showFiltros">
                <div class="wrapper-960 clearfix">
                    <div class="titles icons icon-news-middle">
                        <h2 class="uppercase">
                            <b>Filtros</b>
                        </h2>
                    </div>
                    <div class="mold-txt-center">
                        <form v-on:submit.prevent="executeFilter(filter)">
                            <div class="row">
                                <div class="form-group col-md-3">
                                    <label for="nome">Nome</label>
                                    <input type="text" class="form-control" name="nome" placeholder="Nome" v-model="filter.nome" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="descricao">Descrição</label>
                                    <input type="text" class="form-control" name="descricao" placeholder="Descrição" v-model="filter.descricao" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="dataInicio">Data de Início</label>
                                    <input type="text" v-datepicker class="form-control" name="dataInicio" v-model="filter.dataInicio" />
                                </div>
                                <div class="form-group col-md-3">
                                    <label for="dataFim">Data Término</label>
                                    <input type="text" v-datepicker class="form-control" name="dataFim" v-model="filter.dataFim" />
                                </div>
                            </div>
                            <button type="button" class="btn-large-40 btn-red uppercase" @click="executeFilter(filter)">Buscar</button>
                        </form>
                    </div>
                </div>
            </div>



            <div class="content-960 mobile-row mt-4">
                <div class="wrapper-960 clearfix">
                    <div class="titles icons icon-news-middle">
                        <h2 class="uppercase"><b>Projetos</b></h2>
                    </div>

                    <div class="table-responsive standard-table header-cinza">
                        <table>
                            <thead>
                                <tr>
                                    <th>Nome<i @click="executeOrderBy('Nome')" class="fa fa-sort"></i></th>
                                    <th>Descrição<i @click="executeOrderBy('Descricao')" class="fa fa-sort"></i></th>
                                    <th>Data de Início<i @click="executeOrderBy('DataInicio')" class="fa fa-sort"></i></th>
                                    <th>Data Término<i @click="executeOrderBy('DataFim')" class="fa fa-sort"></i></th>

                                    <th class="text-center" width="150"><i class="fa fa-cog"></i></th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in result.items" v-bind:key="item.tagJobsId" class="animated fadeIn">
                                    <td>{{ item.nome }}</td>
                                    <td>{{ item.descricao }}</td>
                                    <td>{{ item.dataInicio == null ? 'Data Início não informada' : format_date(item.dataInicio) }}</td>
                                    <td>{{ item.dataFim == null ? 'Projeto ainda não foi encerrado' : format_date(item.dataFim) }}</td>

                                    <td class="text-center">
                                        <button type="button" class="btn btn-sm btn-danger" @click="openRemove({ projetoId: item.projetoId })">
                                            <i class="fa fa-trash-o"></i>
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>

                    <div class="card-block no-padding">
                        <pagination :total="result.total" :page-size="filter.pageSize" :callback="executePageChanged"></pagination>
                    </div>

                </div>
            </div>
        </section>

        <b-modal :no-close-on-backdrop="true" size="lg" :no-close-on-esc="true" centered v-model="dialogCreate" :hide-footer="true" title="Criar">
            <form-create v-if="dialogCreate" @on-saved="onSaved()" @on-back="hideAll()" />
        </b-modal>

        <b-modal :no-close-on-backdrop="true" size="lg" :no-close-on-esc="true" centered v-model="dialogEdit" :hide-footer="true" title="Editar">
            <form-edit v-if="dialogEdit" :id="projetoId" @on-saved="onSaved()" @on-back="hideAll()" />
        </b-modal>

        <b-modal :no-close-on-backdrop="true" :no-close-on-esc="true" centered v-model="dialogRemove" title="Confirmação">
            <p>Tem certeza que deseja remover este item?</p>
            <div slot="modal-footer">
                <button class="btn btn-sm btn-danger" @click="executeRemove()">
                    Remover
                </button>
            </div>
        </b-modal>

    </main>

</template>
<script>

    import base from '@/common/base.js'
    import { Api } from '@/common/api'
    import moment from 'moment'

    import formCreate from './form-create'
    import formEdit from './form-edit'

    export default {
        name: 'projeto',
        mixins: [base],
        components: { formCreate, formEdit },
        data() {
            return {

                resources: {
                    filter: 'projeto',
                    remove: 'projeto'
                },
                showFiltros: false,
                dialogRemove: false,
                dialogCreate: false,
                dialogEdit: false,

                model: {},
                filter: {
                    pageSize: 50,
                    pageIndex: 1,
                    isPagination: true,
                },

                result: {
                    total: 0,
                    items: []
                }
            }
        },
        methods: {
                format_date(value) {
                if (value) {
                    return moment(value, 'YYYY/MM/DD HH:mm').format('DD/MM/YYYY')
                }
            },
            showHideFiltros: function () {
                this.showFiltros = !this.showFiltros;
            },
            openEdit: function (model) {
                this.projetoId = model.projetoId;
                this.dialogEdit = true;
            },
            openCreate: function () {
                this.dialogCreate = true;
            },
            onSaved: function () {
                this.hideAll();
                this.executeLoad();
            },
            hideAll: function () {
                this.dialogCreate = false;
                this.dialogEdit = false;
                this.dialogRemove = false;
            },

            openRemove: function (model) {
                this.dialogRemove = true;
                this.model = model;
            },
            executeRemove: function (model) {
                if (model) this.model = model;

                this.model.attributeBehavior = "DeletarProjetoAdmin";

                new Api(this.resources.remove).post(this.model).then(() => {
                    this.defaultSuccessResult("Item removido com sucesso");
                    this.hideAll();
                    this.executeLoad();
                }, err => {
                    this.defaultErrorResult(err);
                })
            },

            executeFilter: function (filter) {
                if (filter) this.filter = filter;
                this.executeLoad();
            },
            executePageChanged: function (index) {
                this.filter = this.defaultPageChanged(this.filter, index);
                this.executeLoad();
            },
            executeOrderBy: function (field) {
                this.filter = this.defaultOrderBy(this.filter, field);
                this.executeLoad();
            },
            executeLoad: function () {
                this.showLoading();
                new Api(this.resources.filter).get(this.filter).then(data => {
                    if (data.summary) this.result.total = data.summary.total;
                    this.result.items = data.dataList;
                    this.hideLoading();
                }, (err) => {
                    this.failLoading();
                    if (err && err.data && err.data.errors) {
                        this.$eventHub.$emit('show-notification', {
                            type: 'error',
                            title: 'Atenção',
                            text: err.data.errors[0]
                        })
                    }
                });
            },

        },

        mounted() {
            this.executeFilter();
        }

    };
</script>