<template>
    <main class="opacity-introjs">

        <section>

            <div style="margin-top: 45px; margin-bottom: 45px" class="content-960 mobile-row">
                <div class="wrapper-960 clearfix">
                    <div class="row">
                        <div class="col-md-12">

                            <div class="text-center">
                                <img style="border-radius: 20px; height: 150px; width: auto" src="../../../src/assets/imagens/home/ESAMC.png" />
                                <p style="font-size: 30px; font-weight: bold; color: #3A5276">Olá!</p>
                                <p style="font-size: 20px; font-weight: bold;">
                                    Você sabia que o aplicativo Abraçaí foi desenvolvido como um projeto de conclusão de curso?
                                </p>
                                <p style="font-size: 15px;">
                                    Cursamos Análise e Desenvolvimento de Sistemas pela faculdade ESAMC Sorocaba e trabalhamos com uma
                                    equipe de quatro alunos durante um semestre para esse aplicativo se tornar realidade.
                                </p>
                                <div class="row">
                                    <div class="col-md-3">
                                        <img style="border-radius: 20px; height: 150px; width: auto" src="../../../src/assets/imagens/home/avatar1.png" />
                                        <div>
                                            <div class="content-960 clearfix">
                                                <ul class="list-icons">
                                                    <li>
                                                        <a target="_blank" href="https://www.linkedin.com/in/alisson-barros-356828162" title="Linkedin">
                                                            <div class="fa fa-linkedin" style="color: #4169E1"></div>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a target="_blank" href="mailto:cardoso_barros16@hotmail.com" title="E-mail">
                                                            <div class="fa fa-envelope" style="color: #1E90FF"></div>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <p style="font-weight: bold">Alisson Caique Cardoso de Barros</p>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <img style="border-radius: 20px; height: 150px; width: auto" src="../../../src/assets/imagens/home/avatar2.png" />
                                        <div>
                                            <div class="content-960 clearfix">
                                                <ul class="list-icons">
                                                    <li>
                                                        <a target="_blank" href="https://www.linkedin.com/in/gabriel-drey-seco-62062715b/" title="Linkedin">
                                                            <div class="fa fa-linkedin" style="color: #4169E1"></div>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a target="_blank" href="mailto:gabriel.drey.seco@outlook.com" title="E-mail">
                                                            <div class="fa fa-envelope" style="color: #1E90FF"></div>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <p style="font-weight: bold">Gabriel Drey Seco</p>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <img style="border-radius: 20px; height: 150px; width: auto" src="../../../src/assets/imagens/home/avatar3.png" />
                                        <div>
                                            <div class="content-960 clearfix">
                                                <ul class="list-icons">
                                                    <li>
                                                        <a target="_blank" href="https://www.linkedin.com/in/joao-silva-0526b9176/" title="Linkedin">
                                                            <div class="fa fa-linkedin" style="color: #4169E1"></div>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a target="_blank" href="mailto:silva_junior99@hotmail.com" title="E-mail">
                                                            <div class="fa fa-envelope" style="color: #1E90FF"></div>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <p style="font-weight: bold">João Antonio Da Silva Junior</p>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <img style="border-radius: 20px; height: 150px; width: auto" src="../../../src/assets/imagens/home/avatar4.png" />
                                        <div>
                                            <div class="content-960 clearfix">
                                                <ul class="list-icons">
                                                    <li>
                                                        <a target="_blank" href="https://www.linkedin.com/in/matheusgbs" title="Linkedin">
                                                            <div class="fa fa-linkedin" style="color: #4169E1"></div>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a target="_blank" href="mailto:matheus.gbseco@gmail.com" title="E-mail">
                                                            <div class="fa fa-envelope" style="color: #1E90FF"></div>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <p style="font-weight: bold">Matheus Gonçalves Barbieri Seco</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
        </section>

    </main>
</template>
<script>

    import base from '@/common/base.js'

    export default {
        name: 'home',
        components: {},
        mixins: [base],
        data() {
            return {
                filter: {
                    pageSize: 50,
                    pageIndex: 1,
                    isPagination: true,
                },
                detectaMobile: false,

                result: {
                    total: 0,
                    items: []
                }
            }
        },
        methods: {

        },
        mounted() {
        }
    };
</script>
