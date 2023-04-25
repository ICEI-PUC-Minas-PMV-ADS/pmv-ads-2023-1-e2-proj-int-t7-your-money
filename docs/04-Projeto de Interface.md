
# Projeto de Interface

<span style="color:red">Pré-requisitos: <a href="02-Especificação do Projeto.md"> Documentação de Especificação</a></span>

Visão geral da interação do usuário pelas telas do sistema e protótipo interativo das telas com as funcionalidades que fazem parte do sistema (wireframes).

 Apresente as principais interfaces da plataforma. Discuta como ela foi elaborada de forma a atender os requisitos funcionais, não funcionais e histórias de usuário abordados nas <a href="02-Especificação do Projeto.md"> Documentação de Especificação</a>.

## Diagrama de Fluxo

![Diagrama de Fluxo Final (Your Money)](img/DiagramadeFluxoYourMoney.png)


A equipe desenvolveu este Diagrama de Fluxo pensando em como será o fluxo de dados e em quais serão os processos pelos quais o usuário passará para utilizar a nossa aplicação. Debatemos algumas possibilidades durante o desenvolvimento e chegamos a esta foi a melhor delas até o momento.

### User Flow
Fluxo de usuário (User Flow), é uma técnica que permite ao desenvolvedor mapear todo fluxo de telas da aplicação. Essa técnica funciona para alinhar os caminhos e as possíveis ações que o usuário pode fazer junto com os membros de sua equipe.
![userFlow](img/UserFlow.png)


## Wireframes

Conforme fluxo de telas do projeto, apresentado no item anterior, as telas do sistema são apresentadas em detalhes nos itens que se seguem. As telas do sistema apresentam uma estrutura comum que é apresentada na Figura acima. Nesta estrutura, existem 3 grandes blocos, descritos a seguir. São eles:

● Cabeçalho - local onde são dispostos elementos fixos de identidade (logo) e navegação principal do site (menu da aplicação);

● Conteúdo - apresenta o conteúdo da tela em questão;

● Rodapé - apresenta a síntese do site associados aos elementos presentes no sistema, auxiliando na navegação do usuário e ajuda-lo com informações de contato para a empresa.

### Tela - Home Page
![Home Page](img/Wireframe-YourMoney(0).png)

### Tela - FAQ
Requisitos funcionais contemplados nesta tela:
* `RF-09` Aplicação deve ter uma área específica com FAQ.
* `RF-11` No FAQ a aplicação deve disponibilizar dicas e informações para um melhor controle financeiro.
* `RF-13` No FAQ da aplicação deve também fornecer informações gerais e dicas sobre o mercado financeiro atual para o usuário.
![FAQ](img/Wireframe-YourMoney(1).png)

### Tela - Cadastro | Login
Requisitos funcionais contemplados nesta tela:
* `RF-05` A aplicação deve permitir que o usuário faça login.
![Cadastro e Login](img/Wireframe-YourMoney(2).png)

### Tela - Usuário logado (1)
Requisitos funcionais contemplados nesta tela:
* `RF-01` A aplicação deve permitir o usuário gerenciar suas receitas.
* `RF-02` A aplicação deve permitir o usuário gerenciar seus despesas.
* `RF-03` A aplicação deve gerar um saldo pegando o valor das receitas e subtraindo aos das despesas.
* `RF-04` A aplicação deve emitir alertas, quando as despesas atingirem 75% do valor das receitas.
* `RF-10` A aplicação deve emitir alertas próximo aos vencimentos dos pagamentos cadastrados.
![Usuario logado](img/Wireframe-YourMoney(3).png)

### Tela - Lançamento Receita ou Despesa
Requisitos funcionais contemplados nesta tela:
* `RF-07` Para cada despesa cadastrada, o tipo e a forma de pagamento deve ser informado.
![Usuario logado](img/Wireframe-YourMoney(6).png)

### Tela - Usuário logado (2)
Requisitos funcionais contemplados nesta tela:
* `RF-12` A aplicação deve ter um campo que ofereça uma perspectiva de futuro para o usuário de quanto ele terá em X 
anos, se ele economizar o valor Y ao final de cada mês.	Média
* `RF-08` A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros.
![Usuario logado 1](img/Wireframe-YourMoney(4).png)

### Tela - Usuário logado (3)
Requisitos funcionais contemplados nesta tela:
* `RF-06` A aplicação deve permitir o auto gerenciamentos do usuários.
![Usuario logado 2](img/Wireframe-YourMoney(5).png)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

> 03-Metodologia- https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t7-your-money/blob/main/docs/03-Metodologia.md >
> 05-Arquitetura da Solução- https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t7-your-money/blob/main/docs/05-Arquitetura%20da%20Solu%C3%A7%C3%A3o.md >