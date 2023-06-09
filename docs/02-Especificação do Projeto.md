# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Para direcionar melhor a aplicação proposta, precisamos entender quais faixas etárias compreendem os maiores endividados do pais, segundo dados do Serasa[1], a faixa de pessoas entre os 26 e 40 anos, representa a maioria dos endividados correspondendo a 34,8% sendo seguida de perto pela faixa de 41 a 60 anos que compreende 34,7% da população, em pesquisa realizada em Janeiro de 2023. 

A aplicação é destinada a qualquer pessoa que busque uma melhor organização de suas finanças, mas estas faixas citadas a cima, serão o foco da solução e de sua divulgação. 

## Personas
As personas levantadas durante o processo de entendimento do problema são apresentadas na Figuras que se seguem.

* `Armando Gomes` é um advogado trabalhista com 5 anos de experiência, atuando em processos judiciais, promovendo defesas de empresas e de clientes em ações trabalhistas. Armando tem grande dificuldade de organizar suas finanças pois ele atende muitos clientes simultaneamente e com varios clientes que necessitam ser cobrados em datas especificas, com este situação ele esta acabando se atrapalhando em fazer as cobraças e administrar suas contas em geral(despesas, ganhos).

* `João Pedro` é um jovem de 22 anos, recentemente formado como Desenvolvedor e Analista de Sistemas, trabalhando como Desenvolvedor Web Front-End na HP Brasil. Demonstra ter um problema grave de disciplina e organização quando o assunto é Finanças, não tendo controle nenhum sobre seus gastos, fazendo com que ele não consiga criar suas reservas financeiras para seu próprio futuro e para ajudar sua família.  

* `David Amaral` tem 25 anos e está cursando Economia na UFMG. Tem um filho de 5 anos do último relacionamento e paga pensão para a criança. Faz estágio remunerado na área de formação, com rendimento em torno de R$1.572,00. Apesar de estar cursando Economia, não tem conseguido gerir bem as suas finanças para conseguir pagar as suas despesas sem se endividar com empréstimos e cartões de crédito.

* `José Antonio Moreira` tem 43 anos, é criador de gado, ama sua família e tem um casal de filhos gêmeos que entraram recentemente na faculdade. No seu tempo livre, gosta de participar de competições de tiro  ao alvo.

* `Sophie Santos Faria` tem 29 anos, estudante universitária, tem dois gatos, namora, mora sozinha, sua renda é de aproximadamente R$5000,00. Nas horas vagas adora assistir séries e uma ou duas vezes por mês se reunir com os amigos. Como mora sozinha e tem muitas contas a serem pagas, fica perdida no que foi pago e no que é preciso pagar, já tentou planilha, anotar em papel mas sempre perde a paciencia de ter que preencher mês a mês.

* `Cláudio Roberto` tem 39 anos, agricultor, trabalhador do campo, uma pessoa que vive da terra e seus plantios. Tem dificuldades para gerir suas finanças e vive recorrendo a empréstimos para sanar suas despesas e poder manter suas contas em dia. Não tem reservas e tem grandes problemas em suas lavouras devido ao fato de não ter capital de giro para subsidiar seu manejo. 
 

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:


|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Armando Gomes | Conseguir preencher uma descrição para cada transação realizada. | Para saber qual foi o motivo da transação em questão. |
| Armando Gomes | Poder classificar minhas receitas e despesas | Poder visualizar receitas e despesas de acordo com a sua classificação. |
| Armando Gomes | Preciso gerar relatorios financeiros para um grupo especifico de transaçoes, por exemplo de acordo com uma tag especifica. | Para enviar aos clientes o total gasto, ou enviar para o meu contador.                                        |
| João Pedro | Encontrar um método de controle de gastos que me ajude a manter uma rotina de economia, para que eu consiga criar minhas reservas financeiras para o futuro.  |  Saber a quantia que poderei ter reservada na perspectiva de 6 meses a 1 ano, mantendo uma rotina de economia. |
| João Pedro | Encontrar um método para definir um limitador para meus gastos mensais por meio de algum tipo de aviso.  | Evitar gastos desnecessários.  |
| João Pedro | Encontrar uma fonte de dicas gerais sobre o mercado financeiro.  | Ter a oportunidade de aprender mais sobre o finanças.  |
| David Amaral | Encontrar ferramenta que o auxilie no controle de gastos.|  Ter ciência e controle dos gastos, fixos e eventuais.|
| David Amaral | Conseguir visualizar de forma prática para onde, exatamente, sua receita(salário) está indo.|Ter acesso, fácil e claro, aos gastos.|
| David Amaral | Manter os gastos menores que a receita mensal.|Conseguir quitar suas despesas mensais sem a necessidade de contrair empréstimos ou utilizar cartão de crédito|
| José Antonio Moreira | Ter uma visão simples, clara e objetiva dos meus gastos mensais| Ter informação rápida sobre meu saldo mensal |
| José Antonio Moreira | Receber alertas perto do vencimento de pagamentos. |Evitar de pagar juros. |
| José Antonio Moreira | Visualizar de maneira clara como estão minhas finanças | Entender como estão sendo efetivados os gastos frente as minhas receitas |
| Sophie Santos Faria | Adicionar minhas contas em um lugar e especificar se é corrente, parcelado ou uma vez.| Ter melhor controle de quando termina e acaba minhas contas.|
| Sophie Santos Faria | Poder visualizar todos os meus lançamentos de despesas ou receitas independente do mês. | Entender como estão minhas receitas e despesas para planejar melhor meu futuro. |
| Sophie Santos Faria | Ter um sistema onde faça as somas automaticas para mim por mês e me diga se estou no vermelho ou azul| Me programar melhor nos proximos meses e/ou poder investir meu dinheiro caso sobre.|
| Cláudio Roberto    | Visualizar quais despesas são mais impactantes no orçamento mensalmente | Ter informações suficientes e relevantes a fim de tomar decisões mais corretamente |
| Cláudio Roberto    | Poder estruturar minhas finanças pessoais com uma visão de longo prazo | Com uma visão de longo prazo, é possível estruturar um planejamento futuro mais assertivo |
| Cláudio Roberto    | Saber o quanto de dinheiro eu terei livre, após o pagamento de todas as minhas despesas | Saber em cada mês, se precisarei economizar ou não |



## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

|ID   | Descrição do Requisito  | Prioridade |
|-----|-----------------------------------------|----|
|RF-01| A aplicação deve permitir o usuário gerenciar suas receitas.| Alta | 
|RF-02| A aplicação deve permitir o usuário gerenciar seus despesas. | Alta |
|RF-03| A aplicação deve permitir o usuário o parcelamento de suas receitas e despesas. | Alta |
|RF-04| A aplicação deve gerar um saldo pegando o valor das receitas e subtraindo aos das despesas. | Alta |
|RF-05| A aplicação deve emitir alertas, quando as despesas atingirem 75% do valor das receitas.| Alta |
|RF-06| A aplicação deve permitir que o usuário faça login. | Alta |
|RF-07| A aplicação deve ter uma funcionalidade de recuperação de senha através do e-mail. | Alta |
|RF-08| A aplicação deve permitir o auto gerenciamentos do usuários. | Alta |
|RF-09| A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros.| Alta |
|RF-10| Aplicação deve ter uma área específica com dicas. | Alta |
|RF-11| A aplicação deve emitir alertas próximo aos vencimentos dos pagamentos cadastrados. | Alta |
|RF-12| Na área dicas a aplicação deve disponibilizar dicas e informações para um melhor controle financeiro. | Alta |
|RF-13| A aplicação deve ter uma página com a Visão Geral dos Lançamentos(Despesas/Receitas) com Status de Efetivado ou Pendente, identificados com cores. | Média |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01| A aplicação deve ser fácil de usar e entender para os usuários, com uma interface de usuário intuitiva e clara. | Alta |
|RNF-02| A aplicação deve ser responsiva. | Alta |
|RNF-03| A aplicação deve ter tempo se resposta menor que 2 segundo a cada requisição realizada. | Alta |
|RNF-04| A aplicação deve estar disponível e funcionando corretamente durante a maior parte do tempo, com tempo de inatividade mínimo ou nulo. |  Alta | 
|RNF-05| A aplicação deve ser fácil de manter e atualizar, com uma arquitetura dividida em modulos e documentação clara para os desenvolvedores. |  Alta |
|RNF-06| A aplicação deve ser compatível com diferentes dispositivos, navegadores e sistemas operacionais, para garantir que os usuários possam acessá-lo independentemente do seu equipamento. Exemplos de navegadores: Microsoft Edge, Google Chrome, Mozila Firefox e Opera. Exemplos de sistemas operacionais: Windows, MAC, IOS, Android.  |  Alta |  


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| O projeto deverá ser executado apenas pelos alunos que compõe o grupo, sem contratação de profissionais |
|03| A aplicação deverá ser exibida em navegador web | 


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![Diagrama de caso de uso (6)](https://user-images.githubusercontent.com/53917285/229490518-434e2e03-b61d-432e-9906-c10223b74844.png)



> **Referências**:
> 1. https://www.serasa.com.br/limpa-nome-online/blog/mapa-da-inadimplencia-e-renogociacao-de-dividas-no-brasil/ Acesso em 01/03/2023.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------
> 01-Documentação de Contexto https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t7-your-money/blob/main/docs/01-Documenta%C3%A7%C3%A3o%20de%20Contexto.md >
> 03-Metodologia  https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e2-proj-int-t7-your-money/blob/main/docs/03-Metodologia.md >

