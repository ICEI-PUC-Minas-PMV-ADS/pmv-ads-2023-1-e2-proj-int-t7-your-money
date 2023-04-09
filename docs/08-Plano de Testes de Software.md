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


 
> **Links Úteis**:
> - [IBM - Criação e Geração de Planos de Teste](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Práticas e Técnicas de Testes Ágeis](http://assiste.serpro.gov.br/serproagil/Apresenta/slides.pdf)
> -  [Teste de Software: Conceitos e tipos de testes](https://blog.onedaytesting.com.br/teste-de-software/)
> - [Criação e Geração de Planos de Teste de Software](https://www.ibm.com/developerworks/br/local/rational/criacao_geracao_planos_testes_software/index.html)
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
> - [UX Tools](https://uxdesign.cc/ux-user-research-and-user-testing-tools-2d339d379dc7)
