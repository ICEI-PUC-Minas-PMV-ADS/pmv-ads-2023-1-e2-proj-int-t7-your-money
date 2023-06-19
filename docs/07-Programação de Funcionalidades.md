# Programação de Funcionalidades

Implementação do sistema descrita por meio dos requisitos funcionais e/ou não funcionais.

|ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|------|-----------------------------------------|----|
|RF-001| A aplicação deve permitir o usuário gerenciar suas receitas. | Views/Lancamentos, Models/Lancamento.cs, Controllers/LancamentosController.cs |
|RF-002| A aplicação deve permitir o usuário gerenciar seus despesas. | Views/Lancamentos, Models/Lancamento.cs, Controllers/LancamentosController.cs |
|RF-003| A aplicação deve permitir o usuário o parcelamento de suas receitas e despesas. | Views/Parcelamentos, Controllers/ParcelamentosController.cs|
|RF-004| A aplicação deve gerar um saldo pegando o valor das receitas e subtraindo aos das despesas. | Views/Usuarios/Index.cshtml, Views/Lancamentos/Index, Views/Lancamentos/Relatorio, Controllers/UsuariosController.cs, Controllers/LancamentosController.cs |
|RF-005| A aplicação deve emitir alertas, quando as despesas atingirem 75% do valor das receitas. | Views/Usuarios/Index | 
|RF-006| A aplicação deve permitir que o usuário faça login. | Views/Usuarios, Controllers/UsuariosController.cs |
|RF-007| A aplicação deve ter uma funcionalidade de recuperação de senha através do e-mail. | Views/Usuarios/RecuperarSenha, Controllers/UsuariosController.cs |
|RF-008| A aplicação deve permitir o auto gerenciamentos do usuários. | Views/Usuarios, Controllers/UsuariosController.cs |
|RF-009| A aplicação deve emitir relatórios, seja de despesas, receitas e/ou outros. | Views/Lancamentos/Relatorio, Controllers/LancamentosController.cs |
|RF-010| Aplicação deve ter uma área específica com dicas. | Views/Home/Dicas.cshtml |
|RF-011| A aplicação deve emitir alertas próximo aos vencimentos dos pagamentos cadastrados. | Views/Usuarios/Index.cshtml |
|RF-012| Na área dicas a aplicação deve disponibilizar dicas e informações para um melhor controle financeiro. | Views/Home/Dicas.cshtml |
|RF-013| A aplicação deve ter uma página com a Visão Geral dos Lançamentos(Despesas/Receitas) com Status de Efetivado ou Pendente, identificados com cores. | Views/Lancamentos/Index |

# Instruções de acesso

[Your Money](https://your-money20230609182318.azurewebsites.net/)

Usuário de teste:
Usuário - teste@teste.com
Senha - 123Teste@
