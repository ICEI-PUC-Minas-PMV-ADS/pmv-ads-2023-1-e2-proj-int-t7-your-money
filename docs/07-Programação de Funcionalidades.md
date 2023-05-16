# Programação de Funcionalidades

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais. Deve relacionar os requisitos atendidos com os artefatos criados (código fonte), deverão apresentadas as instruções para acesso e verificação da implementação que deve estar funcional no ambiente de hospedagem.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir o usuário gerenciar suas receitas. | Views/Lancamentos, Models/Lancamento.cs, Controllers/LancamentosController.cs |
|RF-002| A aplicação deve permitir o usuário gerenciar seus despesas. | Views/Lancamentos, Models/Lancamento.cs, Controllers/LancamentosController.cs |
|RF-003| A aplicação deve gerar um saldo pegando o valor das receitas e subtraindo aos das despesas. | Em construção |
|RF-004| A aplicação deve emitir alertas, quando as despesas atingirem 75% do valor das receitas. | Em construção | 
|RF-005| A aplicação deve permitir que o usuário faça login. | Usuarios/Login.cshtml, Models/Usuario.cs, Controllers/UsuariosController.cs | 
|RF-006| A aplicação deve permitir o auto gerenciamentos do usuários.   | Views/Usuarios, Controllers/UsuariosController.cs |
|RF-007| Para cada despesa cadastrada, o tipo e a forma de pagamento deve ser informado. | Views/Lancamentos, Models/Lancamento.cs, Controllers/LancamentosController.cs |
|RF-008| A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros. | Em construção |
|RF-009| Aplicação deve ter uma área específica com dicas. | Views/Home/Dicas.cshtml |
|RF-010| A aplicação deve emitir alertas próximo aos vencimentos dos pagamentos cadastrados. | Em construção |
|RF-011| Nas dicas a aplicação deve disponibilizar dicas e informações para um melhor controle financeiro. | Views/Home/Dicas.cshtml |
|RF-012| A aplicação deve ter um campo que ofereça uma perspectiva de futuro para o usuário de quanto ele terá em X anos, se ele economizar o valor Y ao final de cada mês. | Em construção |

# Instruções de acesso

Não deixe de informar o link onde a aplicação estiver disponível para acesso (por exemplo: https://adota-pet.herokuapp.com/src/index.html).

Se houver usuário de teste, o login e a senha também deverão ser informados aqui (por exemplo: usuário - admin / senha - admin).

O link e o usuário/senha descritos acima são apenas exemplos de como tais informações deverão ser apresentadas.

> **Links Úteis**:
>
> - [Trabalhando com HTML5 Local Storage e JSON](https://www.devmedia.com.br/trabalhando-com-html5-local-storage-e-json/29045)
> - [JSON Tutorial](https://www.w3resource.com/JSON)
> - [JSON Data Set Sample](https://opensource.adobe.com/Spry/samples/data_region/JSONDataSetSample.html)
> - [JSON - Introduction (W3Schools)](https://www.w3schools.com/js/js_json_intro.asp)
> - [JSON Tutorial (TutorialsPoint)](https://www.tutorialspoint.com/json/index.htm)
