let userData = JSON.parse(localStorage.getItem('CLIENTE'));

const {
    nomeCompleto,
    } = userData;

const userName = JSON.parse(localStorage.getItem(`user-${userData.nomeCompleto}`));

let userNewData = {
    nomeCompleto: userName.nomeCompleto,
    nomeDisplay: userName.nomeDisplay,
    email: userName.email,
    senha: userName.senha,
    experiencia: userName.experiencia,
    dataNascimento: userName.dataNascimento,
    trilhasCadastradas: userName.trilhasCadastradas,
    trilhasFavoritadas: userName.trilhasFavoritadas
};

function alterarNome() {
    trailFuncs.verificarSessaoLogado();
    this.event.preventDefault();
    let inputUsuario = document.getElementById("input-nome").value;
    if(inputUsuario) {
        userNewData.nomeDisplay = inputUsuario;
        localStorage.setItem(`user-${userData.nomeCompleto}`, JSON.stringify(userNewData));
        alert("Nome alterado com sucesso! Favor entrar novamente");
        trailFuncs.logOut();
    }
}


function alterarSenha() {
    trailFuncs.verificarSessaoLogado();
    this.event.preventDefault();
    let inputSenha = document.getElementById("input-senha").value;
    if(inputSenha) {
        userNewData.senha = inputSenha;
        localStorage.setItem(`user-${userData.nomeCompleto}`, JSON.stringify(userNewData));
        alert("Senha alterado com sucesso! Favor entrar novamente");
        trailFuncs.logOut();
    }
}

function alterarEmail() {
    trailFuncs.verificarSessaoLogado();
    this.event.preventDefault();
    let inputEmail = document.getElementById("input-email").value;
    if(inputEmail) {
        userNewData.email = inputEmail;
        localStorage.setItem(`user-${userName.nomeCompleto}`, JSON.stringify(userNewData));
        alert("E-mail alterado com sucesso! Favor entrar novamente");
        trailFuncs.logOut();
    }
}

window.onload = () => {
    let userData = JSON.parse(localStorage.getItem('CLIENTE'));
    let name = document.querySelector('#NameUser');

    const {
    nomeCompleto,
    } = userData;

    name.innerHTML = userData.nomeDisplay;
};