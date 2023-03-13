# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Para direcionar melhor a aplicação proposta, precisamos entender quais faixas etárias compreendem os maiores endividados do pais, segundo dados do Serasa, a faixa de pessoas entre os 26 e 40 anos, representa a maioria dos endividados correspondendo a 34,8% sendo seguida de perto pela faixa de 41 a 60 anos que compreende 34,7% da população, em pesquisa realizada em Janeiro de 2023. 

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
| Armando Gomes      |   Conseguir preencher uma descrição para cada transação realizada.                                 |Para saber qual foi o motivo da transação em questão.                                       |
| Armando Gomes      |   Conseguir criar tags personalizar.                                 |Para conseguir filtrar e separar minhas transações, pelo nome do cliente por exemplo.                                         |
| Armando Gomes      |   Preciso gerar relatorios financeiros para um grupo especifico de transaçoes, por exemplo de acordo com uma tag especifica.                                 |Para enviar aos clientes o total gasto, ou enviar para o meu contador.                                        |
| João Pedro         | Encontrar um método de controle de gastos que me ajude a manter uma rotina de economia, para que eu consiga criar minhas reservas financeiras para o futuro.  |  Saber a quantia que poderei ter reservada na perspectiva de 1 ano, 5 anos e 10 anos, mantendo uma rotina de economia.  |
| João Pedro         | Receber avisos e notificações sobre possíveis mudanças do mercado financeiro que possam influenciar diretamente minha vida financeira na perspectiva de 6 meses à 1 ano.  | Me prevenir com relação as grandes oscilações do mercado financeiro que possam influenciar diretamente minhas finanças.  |
| João Pedro         | Encontrar uma fonte confiável de informações sobre o tema Finanças.  | Ter a oportunidade de conhecer mais sobre o mercado financeiro em geral.  |
| David Amaral       | Encontrar ferramenta que o auxilie no controle de gastos.|  Ter ciência e controle dos gastos, fixos e eventuais.|
| David Amaral       | Conseguir visualizar de forma prática para onde, exatamente, sua receita(salário) está indo.|Ter acesso, fácil e claro, aos gastos.|
| David Amaral       | Manter os gastos menores que a receita mensal.|Conseguir quitar suas despesas mensais sem a necessidade de contrair empréstimos ou utilizar cartão de crédito|
| José Antonio Moreira       |Ser avisado quando houver uma grande movimentação de débito em sua conta. |Ter segurança contra fraudes. |
| José Antonio Moreira       |Ser avisado perto do vencimento de pagamentos. |Evitar de pagar juros. |
| José Antonio Moreira       |Visualizar de maneira clara o quanto seu dinheiro rende por mês. |Saber se está investindo seu dinheiro corretamente. |
| Sophie Santos Faria       |Adicionar minhas contas em um lugar e especificar se é corrente, parcelado ou uma vez.|Ter melhor controle de quando termina e acaba minhas contas.|
| Sophie Santos Faria       |Fazer controle de compras no cartão de crédito. |Ter melhor controle de quando gasto por mês no cartão de crédito. |
| Sophie Santos Faria       |Ter um sistema onde faça as somas automaticas para mim por mês e me diga se estou no vermelho ou azul|Me programar melhor nos proximos meses e/ou poder investir meu dinheiro caso sobre. |
| Cláudio Roberto    | Visualizar quais despesas são mais impactantes no orçamento mensalmente | Ter informações suficientes e relevantes a fim de tomar decisões mais corretamente |
| Cláudio Roberto    | Visualizar quais despesas são mais impactantes no orçamento mensalmente | Ter informações suficientes e relevantes a fim de tomar decisões mais corretamente |
| Cláudio Roberto    |	Poder estruturar minhas finanças pessoais com uma visão de longo prazo |	Com uma visão de longo prazo, é possível estruturar um planejamento futuro mais assertivo |
| Cláudio Roberto    |	Saber o quanto de dinheiro eu terei livre, após o pagamento de todas as minhas despesas |	Saber em cada mês, se precisarei economizar ou não |



## Requisitos

O escopo funcional do projeto é definido por meio dos requisitos funcionais que descrevem as possibilidades interação dos usuários, bem como os requisitos não funcionais que descrevem os aspectos que o sistema deverá apresentar de maneira geral. Estes requisitos são apresentados a seguir.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-01| A aplicação deve permitir que o usuário gerencie seus gastos fixos e variáveis.| Alta | 
|RF-02| Para cada gasto cadastrado, o tipo de gasto e a forma de pagamento deve ser informada. | Alta |
|RF-03| A aplicação deve permitir que o usuário gerencie suas receitas (salários, aluguéis, dentre outros). | Alta |
|RF-04| A aplicação deve emitir alertas, quando gastos forem maiores ou estiverem atingindo o valor das receitas.| Alta |
|RF-05| A aplicação deve permitir o auto gerenciamento dos Usuários. | Alta |
|RF-06| A aplicação deve permitir que o Usuário faça Login. | Alta |
|RF-07| A aplicação deve permitir inserir contas e valores de entrada, para ter controle de quanto tem na carteira. | Alta |
|RF-08| A aplicação deve disponibilizar dicas e informações para um melhor controle financeiro | Alta |
|RF-09| A aplicação deve permitir que o usuário descadastre seus gastos fixos e variáveis. | Alta |
|RF-10| A aplicação deve permitir que o usuário descadastre suas receitas. | Alta |
|RF-11| Aplicação deve permitir que o usuário, a qualquer momento, verifique o status da sua conta. | Alta |
|RF-12| Aplicação deve emitir relatórios(De gastos, receitas e outros). | Alta |
|RF-13| Aplicação deve ter uma área específica com FAQ. | Alta |
|RF-14| A aplicação deve permitir adicionar um cartão de crédito e as compras vinculadas a ele. | Média |
|RF-15| A aplicação deve emitir alertas, próximo aos vencimentos dos pagamentos cadastrados.| Média |
|RF-16| A aplicação deve ter uma área específica para fornecer informações gerais e dicas sobre o mercado financeiro atual para o usuário. | Média |
|RF-17| A aplicação deve ter um campo que ofereça uma perspectiva de futuro para o usuário de quanto ele terá em X anos, se ele economizar o valor Y ao final de cada mês.   | Baixa |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-01| A aplicação deve ser compatível com os principais navegadores do mercado (Google Chrome, Firefox, Microsoft Edge) | Alta |
|RNF-02| A aplicação deverá ser responsiva. | Alta |
|RNF-03| A aplicação deve ser publicada em um ambiente acessível publicamente na Internet. | Alta |
|RNF-04|  A aplicação deverá seguir as normas estabelecidas pela Legislação de privacidade do usuário. |  Alta | 


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| O projeto deverá ser trabalhado apenas pelo grupo de alunos, sem contratação de profissionais |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![Diagrama de Casos de Uso](https://user-images.githubusercontent.com/98750413/224128323-3f6832ac-059d-4f09-91da-d0594b5ba4b6.png)

> **Referências**:
> 1. https://www.serasa.com.br/limpa-nome-online/blog/mapa-da-inadimplencia-e-renogociacao-de-dividas-no-brasil/ Acesso em 01/03/2023.

