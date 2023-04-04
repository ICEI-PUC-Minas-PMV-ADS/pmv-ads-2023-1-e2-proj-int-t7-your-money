const verificacaoUsuarioLogado = Object.keys(localStorage).some(key => key == 'CLIENTE');

if(verificacaoUsuarioLogado) {
    let navHeaderLogado = ` 
    <div class="container-fluid">
        <img onclick="location=href='index.html'" src="src/image/YourMoneyIcon.png" width="120" alt="100" style="cursor: pointer;">      
        <div class="row align-items-center">
            <div class="header-list col">
                <img src="images/icons/user.png" width="30" style="cursor: pointer;" onclick="location=href='UserPage.html'" alt="icone usuário">
            </div>
            <div class="header-list col">
                <img src="images/icons/logout.png" width="30" style="cursor: pointer;" alt="icone sair" onclick="trailFuncs.logOut()">
            </div>
        </div>
    </div> 
    `;

    document.getElementById("logado").innerHTML = navHeaderLogado;
} else {
    navHeaderLogado = `
    <div class="container-fluid">
        <img onclick="location=href='HomePage.html'" src="src/image/YourMoneyIcon.png" width="120" alt="100" style="cursor: pointer;">
        <div>
        <button class="btn btn-danger"
            onclick="document.getElementById('id00').style.display='block'">Cadastre-se</button>
        <button class="btn btn-danger" onclick="document.getElementById('id01').style.display='block'">Entrar</button>
        </div>

        <div id="id00" class="modal" style="z-index:99">
            <form class="modal-content">
            <div class="container">
                <span onclick="document.getElementById('id00').style.display='none'" class="close" title="close">&times;</span>
                <label for="name"><b>Nome</b></label>
                <input type="text" placeholder="Digite o seu nome completo" name="name" required id="nome_usuario_cadastro">
                <label for="email"><b>Email</b></label>
                <input type="text" placeholder="Digite o seu Email" name="email" required id="email_usuario_cadastro">

                <div class="d-flex justify-content-center">
                <div class="containerC">
                    <div class="row">
                
                    <div class="col-sm-6 justify-content-center align-self-center p-2">
                        <div class="form-floating">
                        <div>
                            <label><b>Data de Nascimento</b></label>
                        </div>
                        <input type="date" class="form-control" required id="date">
                        </div>
                    </div>
                    <div class="col-sm-6 justify-content-center align-self-center width=50%">
                        <div>
                        <label for=""><b>Tempo de Ciclismo</b></label>
                        </div>
                        <select required id="floatingSelect" class="trilha_nivel form-select">
                        <option value="">-</option>
                        <option value="1">1 Ano</option>
                        <option value="2">2 Anos</option>
                        <option value="3">3 Anos</option>
                        <option value="4">4 Anos</option>
                        <option value="5">5 Anos</option>
                        <option value="6">6 Anos</option>
                        <option value="7">7 Anos</option>
                        <option value="8">8 Anos</option>
                        <option value="9">9 Anos</option>
                        <option value="10">10 Anos</option>
                        <option value="+10">Acima de 10 Anos</option>
                        </select>
                    </div>
                
                    <div class="col-sm-6 justify-content-center align-self-center p-2">
                        <div class="form-floating">
                        <div>
                            <label for="psw"><b>Senha</b></label>
                        </div>
                        <input type="password" placeholder="Digite sua senha" name="psw" required id="senha_usuario_cadastro">
                        </div>
                    </div>
                
                    <div class="col-sm-6 justify-content-center align-self-center width=50%">
                        <div>
                        <label for="psw-repeat"><b>Repita sua Senha</b></label>
                        </div>
                        <input type="password" placeholder="Digite sua senha" name="psw-repeat" required
                        id="senha_usuario_cadastro_verificacao">
                    </div>
                
                    </div>
                </div>
                </div>
                <div class="row justify-content-between">
                <button type="button" onclick="document.getElementById('id00').style.display='none'" class="cancelarbtn col-4">Cancelar</button>
                <button type="button" onclick="trailFuncs.cadastrarUsuario()" class="col-4">Cadastrar</button>
                </div>    
            </div>
            </form>
        </div>

        <div id="id01" class="modal" style="z-index:99">
        
            <form class="modal-content animate">
            <div class="imgcontainer">
                <span onclick="document.getElementById('id01').style.display='none'" class="close"
                title="Close Modal">&times;</span>
            </div>
            <div class="containerX">
                <label for="uname"><b>Usuário</b></label>
                <input type="text" placeholder="Digite seu e-mail" name="uname" required id="email_login_usuario">
                <label for="psw"><b>Senha</b></label>
                <input type="password" placeholder="Digite sua senha" name="psw" required id="senha_login_usuario">

            <div class="row justify-content-between pt-3 m-0">
                <button type="button" onclick="document.getElementById('id01').style.display='none'" class="cancelarbtn col-4">Cancelar</button>
                <button type="submit" onclick="trailFuncs.login()" class="col-4">Entrar</button>
            </div>

            </form>
            </div>
        </div>
    </div>
    `;

    document.getElementById("logado").innerHTML = navHeaderLogado;
}