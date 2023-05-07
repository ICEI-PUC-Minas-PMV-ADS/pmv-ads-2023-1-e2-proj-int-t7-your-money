# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Não deixe de enumerar os casos de teste de forma sequencial e de garantir que o(s) requisito(s) associado(s) a cada um deles está(ão) correto(s) - de acordo com o que foi definido na seção "2 - Especificação do Projeto". 

Por exemplo:
 
| **Caso de Teste** 	| **CT-01 – Adicionar uma receita com sucesso.** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF01 - A aplicação deve permitir o usuário gerenciar suas receitas. |
| Objetivo do Teste 	| Usuário adicionar uma nova receita com sucesso |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Clicar no botão de adicionar nova receita.<br> - Preencher os campos obrigatórios, como nome, valor e tipo de receita.  <br> - Clicar no botão de salvar.  |
|Critério de Êxito | - A nova receita deve ser adicionada com sucesso e exibida para o usuário atraves de uma lista. |
|  	|  	|
| **Caso de Teste** 	| **CT-02 – Editar uma receita com sucesso.** 	|
|	Requisito Associado 	| RF01 - A aplicação deve permitir o usuário gerenciar suas receitas. |
| Objetivo do Teste 	| Usuário editar uma receita com sucesso |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Selecionar uma receita existente na lista de receitas cadastradas.<br> - Clicar no botão de editar.  <br> - Alterar os campos desejados, como nome, valor ou tipo de receita. <br> - Clicar no botão de salvar. |
|Critério de Êxito | - A receita deve ser editada com sucesso na aplicação e as alterações devem ser exibidas para o usuário atraves de uma lista. |
|  	|  	|
| **Caso de Teste** 	| **CT-03 – Excluir uma receita existente com sucesso.** 	|
|	Requisito Associado 	| RF01 - A aplicação deve permitir o usuário gerenciar suas receitas. |
| Objetivo do Teste 	| Usuário poder excluir uma receita existente. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Selecionar uma receita existente na lista de receitas cadastradas.<br> - Clicar no botão de excluir.  <br> - Clicar no botão de salvar. <br> - Confirmar a exclusão na janela de confirmação.|
|Critério de Êxito | - A receita selecionada deve ser excluída com sucesso da aplicação e não deve mais aparecer na lista ou tabela de receitas. |
|  	|  	|
| **Caso de Teste** 	| **CT-04 – Falha ao preencher uma nova receita sem os campos obrigatórios.** 	|
|	Requisito Associado 	| RF01 - A aplicação deve permitir o usuário gerenciar suas receitas. |
| Objetivo do Teste 	| Usuário receber uma mensagem de erro quando tentar adicionar um receita sem os campos obrigatórios. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Clicar no botão adicionar nova receita. <br> - Deixar em branco um ou todos campos obrigatórios.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - Deverá aparecer uma mensagem de erro informando que os campos obrigatórios não foram preenchidos. |
|  	|  	|
| **Caso de Teste** 	| **CT-05 – Falha ao preencher a edição de uma receita sem os campos obrigatórios.** 	|
|	Requisito Associado 	| RF01 - A aplicação deve permitir o usuário gerenciar suas receitas. |
| Objetivo do Teste 	| Usuário receber uma mensagem de erro quando tentar adicionar um receita sem os campos obrigatórios. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Clicar no botão de editar.  <br> - Alterar os campos desejados, deixando um ou mais campos obrigatórios vazios.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - Deverá aparecer uma mensagem de erro informando que os campos obrigatórios não foram preenchidos. |
|  	|  	|
| **Caso de Teste** 	| **CT-06 – Adicionar uma despesa com sucesso.** 	|
|	Requisito Associado 	| RF02 - A aplicação deve permitir o usuário gerenciar suas despesas. |
| Objetivo do Teste 	| Usuário adicionar uma nova despesa com sucesso. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Clicar no botão de adicionar nova receita.  <br> - Preencher os campos obrigatórios, como nome, valor e tipo de despesa, se for recorrente, caso seja parcelado o número de vezes, data de vencimento.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - A nova despesa deve ser adicionada com sucesso e exibida para o usuário atraves de uma lista. |
|  	|  	|
| **Caso de Teste** 	| **CT-07 – Editar uma despesa com sucesso.** 	|
|	Requisito Associado 	| RF02 - A aplicação deve permitir o usuário gerenciar suas despesas. |
| Objetivo do Teste 	| Usuário editar uma despesa com sucesso |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Selecionar uma despesa existente na lista de despesas cadastradas.<br> - Clicar no botão de editar.  <br> - Alterar os campos desejados, como nome, valor ou tipo de despesa. <br> - Clicar no botão de salvar. |
|Critério de Êxito | - A despesa deve ser editada com sucesso na aplicação e as alterações devem ser exibidas para o usuário atraves de uma lista. |
|  	|  	|
| **Caso de Teste** 	| **CT-08 – Excluir uma despesa existente com sucesso.** 	|
|	Requisito Associado 	| RF02 - A aplicação deve permitir o usuário gerenciar suas despesas. |
| Objetivo do Teste 	| Usuário poder excluir uma despesa existente. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Selecionar uma despesa existente na lista de despesas cadastradas.<br> - Clicar no botão de excluir.  <br> - Clicar no botão de salvar. <br> - Confirmar a exclusão na janela de confirmação.|
|Critério de Êxito | - A despesa selecionada deve ser excluída com sucesso da aplicação e não deve mais aparecer na lista ou tabela de despesas. |
|  	|  	|
| **Caso de Teste** 	| **CT-09 – Falha ao preencher uma nova despesa sem os campos obrigatórios.** 	|
|	Requisito Associado 	| RF02 - A aplicação deve permitir o usuário gerenciar suas despesas. |
| Objetivo do Teste 	| Usuário receber uma mensagem de erro quando tentar adicionar um despesa sem os campos obrigatórios. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Clicar no botão adicionar nova despesa. <br> - Deixar em branco um ou todos campos obrigatórios.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - Deverá aparecer uma mensagem de erro informando que os campos obrigatórios não foram preenchidos. |
|  	|  	|
| **Caso de Teste** 	| **CT-10 – Falha ao preencher a edição de uma despesa sem os campos obrigatórios.** 	|
|	Requisito Associado 	| RF02 - A aplicação deve permitir o usuário gerenciar suas despesas. |
| Objetivo do Teste 	| Usuário receber uma mensagem de erro quando tentar adicionar um despesa sem os campos obrigatórios. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Clicar no botão de editar.  <br> - Alterar os campos desejados, deixando um ou mais campos obrigatórios vazios.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - Deverá aparecer uma mensagem de erro informando que os campos obrigatórios não foram preenchidos. |
|  	|  	|
| **Caso de Teste** 	| **CT-11 – Verificar se o saldo está sendo gerado de forma correta.** 	|
|	Requisito Associado 	| RF03 - A aplicação deve gerar um saldo pegando o valor das receitas e subtraindo aos das despesas. |
| Objetivo do Teste 	| Usuário receber uma mensagem de erro quando tentar adicionar um despesa sem os campos obrigatórios. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Adicionar uma receita.  <br> - Adicionar uma despesa.  <br> - Verificar o saldo no campo destinado a ele. |
|Critério de Êxito | - O saldo deve ser o valor exato da subtração da despesa na receita. |
|  	|  	|
| **Caso de Teste** 	| **CT-12 – Verificar se o alerta está sendo emitido.** 	|
|	Requisito Associado 	| RF04 - A aplicação deve emitir alertas quando as despesas atingirem 75% do valor das receitas. |
| Objetivo do Teste 	| Verificar se o alerta está sendo emitido quando as despesas atingirem 75% do valor das receitas. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Adicionar uma receita com valor X.  <br> - Adicionar uma despesa com o valor correspondente a 75% da receita adicionada anteriormente.  <br> - Verificar o saldo no campo destinado a ele. <br> Fechar o alerta emitido pela aplicação. |
|Critério de Êxito | - A aplicação deverá emitir um alerta informando que suas despesas estão em 75% ou mais em relação as receitas. |
|  	|  	|
| **Caso de Teste** 	| **CT-13 – Fazer o login com sucesso.** 	|
|	Requisito Associado 	| RF05 - A aplicação deve permitir que o usuário faça login. |
| Objetivo do Teste 	| Usuário possa acessar o site utilizando seu login e senha corretamente. |
| Passos 	| - Estar na tela de login. <br>  - Preencher o campo e-mail corretamente.  <br> - Preencher o campo senha corretamente.  <br> - Clicar no botão "Logar". |
|Critério de Êxito | - Login realizado com sucesso, a aplicação deverá direcionar o usuário para a tela principal do sistema. |
|  	|  	|
| **Caso de Teste** 	| **CT-14 – Falhar ao fazer login com e-mail inválido.** 	|
|	Requisito Associado 	| RF05 - A aplicação deve permitir que o usuário faça login. |
| Objetivo do Teste 	| Usuário tente realizar o login com o e-mail inválido. |
| Passos 	| - Estar na tela de login. <br>  - Preencher o campo e-mail de forma inválida.  <br> - Preencher o campo senha corretamente.  <br> - Clicar no botão "Logar". |
|Critério de Êxito | - A aplicação deverá emitir um alerta que o e-mail está inválido e não permitir o acesso ao sistema para o usuário. |
|  	|  	|
| **Caso de Teste** 	| **CT-15 – Falhar ao fazer login com e-mail vazio.** 	|
|	Requisito Associado 	| RF05 - A aplicação deve permitir que o usuário faça login. |
| Objetivo do Teste 	| Usuário tente realizar o login com o e-mail vazio. |
| Passos 	| - Estar na tela de login. <br>  - Não preencher o campo e-mail.  <br> - Preencher o campo senha corretamente.  <br> - Clicar no botão "Logar". |
|Critério de Êxito | - A aplicação deverá emitir um alerta que o e-mail está vazio e não permitir o acesso ao sistema para o usuário. |
|  	|  	|
| **Caso de Teste** 	| **CT-16 – Falhar ao fazer login com senha inválida.** 	|
|	Requisito Associado 	| RF05 - A aplicação deve permitir que o usuário faça login. |
| Objetivo do Teste 	| Usuário tente realizar o login com a senha inválida. |
| Passos 	| - Estar na tela de login. <br>  - Preencher o campo e-mail corretamente.  <br> - Preencher o campo senha de forma inválida.  <br> - Clicar no botão "Logar". |
|Critério de Êxito | - A aplicação deverá emitir um alerta que o senha está inválida e não permitir o acesso ao sistema para o usuário. |
|  	|  	|
| **Caso de Teste** 	| **CT-17 – Falhar ao fazer login com senha vazia.** 	|
|	Requisito Associado 	| RF05 - A aplicação deve permitir que o usuário faça login. |
| Objetivo do Teste 	| Usuário tente realizar o login com a senha vazia. |
| Passos 	| - Estar na tela de login. <br>  - Preencher o campo e-mail corretamente.  <br> - Não preencher o campo senha.  <br> - Clicar no botão "Logar". |
|Critério de Êxito | - A aplicação deverá emitir um alerta que o senha está vazia e não permitir o acesso ao sistema para o usuário. |
|  	|  	|
| **Caso de Teste** 	| **CT-18 – Criação de uma conta nova de usuário com sucesso.** 	|
|	Requisito Associado 	| RF06 - A aplicação deve permitir o auto gerenciamentos do usuários. |
| Objetivo do Teste 	| Um novo usuário faça cadastro na aplicação. |
| Passos 	| - Estar na tela de login. <br>  - Clicar no botão "Nova Conta".  <br> - Informar os campos: nome, e-mail, senha corretamente.  <br> - Clicar no botão "Criar conta". |
|Critério de Êxito | - A aplicação deverá criar um novo usuário e redireciona-lo para a tela principal do sistema. |
|  	|  	|
| **Caso de Teste** 	| **CT-19 – Falha na criação de conta por conta de informações vazias.** 	|
|	Requisito Associado 	| RF06 - A aplicação deve permitir o auto gerenciamentos do usuários. |
| Objetivo do Teste 	| Um novo usuário tente realizar login com informações vazias. |
| Passos 	| - Estar na tela de login. <br>  - Clicar no botão "Nova Conta".  <br> - Deixar de informar algum campo ou todos. <br> - Clicar no botão "Criar conta". |
|Critério de Êxito | - A aplicação deverá exibir uma mensagem mostrando que todos os campos são obrigatórios. |
|  	|  	|
| **Caso de Teste** 	| **CT-20 – Falha na criação de conta por conta de formato de e-mail inválido.** 	|
|	Requisito Associado 	| RF06 - A aplicação deve permitir o auto gerenciamentos do usuários. |
| Objetivo do Teste 	| Um novo usuário tente realizar login com informações vazias. |
| Passos 	| - Estar na tela de login. <br>  - Clicar no botão "Nova Conta".  <br> - Informar nome e senha corretamente. <br> - Inserir no campo e-mail, um e-mail que não contenha "@" no meio dele. <br> - Clicar no botão "Criar conta". |
|Critério de Êxito | - A aplicação deverá exibir uma mensagem de erro informando que o formato de e-mail é inválido. |
|  	|  	|
| **Caso de Teste** 	| **CT-21 – Cadastrar despesa com tipo e forma de pagamento.** 	|
|	Requisito Associado 	| RF07 - Para cada despesa cadastrada, o tipo e a forma de pagamento deve ser informado. |
| Objetivo do Teste 	| Realizar o cadastro de uma despesa informando o tipo e forma de pagamento. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Clicar no botão de "Adicionar Despesa".  <br> - Inserir os campos nome da despesa, data de vencimento, valor, tipo e forma de pagamento.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - A aplicação salvará a despesa e aparecerá na lista de despesas do mês em que a data de pagamento foi cadastrada. |
|  	|  	|
| **Caso de Teste** 	| **CT-22 – Falhar ao cadastrar uma despesa ao não informar tipo ou forma de pagamento.** 	|
|	Requisito Associado 	| RF07 - Para cada despesa cadastrada, o tipo e a forma de pagamento deve ser informado. |
| Objetivo do Teste 	| Não inserir o tipo ou forma de pagamento na hora de cadastrar uma despesa, deverá dar falha |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Clicar no botão de "Adicionar Despesa".  <br> - Inserir os campos nome da despesa, data de vencimento, valor e não informar o tipo ou forma de pagamento.  <br> - Clicar no botão de salvar. |
|Critério de Êxito | - A aplicação não deverá salvar essa despesa pois são informações que devem ser obrigatórias ao cadastrar uma despesa. |
|  	|  	|
| **Caso de Teste** 	| **CT-23 – Visualizar os relatórios de despesas e receitas anual com sucesso.** 	|
|	Requisito Associado 	| RF08 - A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros. |
| Objetivo do Teste 	| Após inserção das despesas e receitas gerar um relátório de despesas anual. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Ter receitas e despesas cadastradas.  <br> - Clicar na visualização do relátorio anual. |
|Critério de Êxito | - A aplicação deverá mostrar um gráfico das despesas em relação as receitas no ano. |
|  	|  	|
| **Caso de Teste** 	| **CT-24 – Visualizar os relatórios de despesas e receitas semestral com sucesso.** 	|
|	Requisito Associado 	| RF08 - A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros. |
| Objetivo do Teste 	| Após inserção das despesas e receitas gerar um relátório de despesas semestral. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Ter receitas e despesas cadastradas.  <br> - Clicar na visualização do relátorio semestral. |
|Critério de Êxito | - A aplicação deverá mostrar um gráfico das despesas em relação as receitas nos útimos 6 meses. |
|  	|  	|
| **Caso de Teste** 	| **CT-25 – Visualizar os relatórios de despesas e receitas trimestral com sucesso.** 	|
|	Requisito Associado 	| RF08 - A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros. |
| Objetivo do Teste 	| Após inserção das despesas e receitas gerar um relátório de despesas trimestral. |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br>  - Ter receitas e despesas cadastradas.  <br> - Clicar na visualização do relátorio trimestral. |
|Critério de Êxito | - A aplicação deverá mostrar um gráfico das despesas em relação as receitas nos útimos 3 meses. |
|  	|  	|
| **Caso de Teste** 	| **CT-26 – Visualizar um local destinado as dicas** 	|
|	Requisito Associado 	| RF09 - Aplicação deve ter uma área específica com dicas. |
| Objetivo do Teste 	| Um dos itens do menu deve ser as dicas e ao clicar ser redirecionado para uma página com mesmo nome. |
| Passos 	| - Estar na aplicação na tela principal. <br>  - Clicar no dicas.  <br> - Visualizar a página dicas. |
|Critério de Êxito | - Ao clicar nas dicas, uma nova página deverá ser carregada sobre dicas deverá ser carregada. |
|  	|  	|
| **Caso de Teste** 	| **CT-27 – Verificar alerta próximo do vencimento dos pagamentos** 	|
|	Requisito Associado 	| RF10 - A aplicação deve emitir alertas próximo aos vencimentos dos pagamentos cadastrados. |
| Objetivo do Teste 	| Adicionar uma despesa com vencimento para o próximo dia, deslogar e logar para ver se receberá o alerta. |
| Passos 	| - Estar na aplicação na tela principal. <br>  - Adicionar uma despesa com o vencimento para o próximo dia.  <br> - Deslogar da conta. <br> - Logar na conta. <br> - Fechar o alerta de vencimento próximo. |
|Critério de Êxito | - Ao logar na conta, um alerta deve ser emitido de que a despesa X está próxima do vencimento. |
|  	|  	|
| **Caso de Teste** 	| **CT-28 – Visualizar sessão de dicas e informações para controle financeiro** 	|
|	Requisito Associado 	| RF11 - Nas dicas a aplicação deve disponibilizar dicas e informações para um melhor controle financeiro. |
| Objetivo do Teste 	| Ao acessar as dicas, visualizar uma sessão de Dicas e Informações para melhor controle financeiro. |
| Passos 	| - Estar na aplicação na tela principal. <br>  - No menu clicar em dicas. <br> - Visualizar uma sessão de dicas e informações para melhor controle financeiro. |
|Critério de Êxito | - Ter no dicas uma sessão para melhor controle financeiro. |
|  	|  	|
| **Caso de Teste** 	| **CT-29 – Visualizar uma perspectiva de futuro de economia** 	|
|	Requisito Associado 	| RF12 - A aplicação deve ter um campo que ofereça uma perspectiva de futuro para o usuário de quanto ele terá em X anos, se ele economizar o valor Y ao final de cada mês. |
| Objetivo do Teste 	| Ao acessa |
| Passos 	| - Estar logada na aplicação na página principal do usuário. <br> - Clicar em Perspectiva do Futuro. <br>  - Inserir um valor e um tempo para simulação. <br> - Clicar no botão Simular. |
|Critério de Êxito | - Aparecer uma simulação com o valor que o usuário vai ter com o tempo de economia que colocou. |

 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
