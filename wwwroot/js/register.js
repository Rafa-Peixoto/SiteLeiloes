document.addEventListener('DOMContentLoaded', function () {
    const registerForm = document.getElementById('registerForm');

    registerForm.addEventListener('submit', function (event) {
        event.preventDefault(); // Impede o envio padrão do formulário

        // Validação básica do lado do cliente
        if (validarFormulario()) {
            // Aqui você pode adicionar qualquer lógica adicional antes de enviar o formulário
            // Como uma chamada de API ou manipulação de dados

            // Envia o formulário
            submitRegisterForm();
        }
    });
});

function validarFormulario() {
    // Exemplo de validação: verifique se a senha e a confirmação de senha são iguais
    const senha = document.getElementsByName('Password')[0].value;
    const confirmarSenha = document.getElementsByName('ConfirmPassword')[0].value;

    if (senha !== confirmarSenha) {
        alert('As senhas não coincidem.');
        return false;
    }

    // Adicione aqui mais validações conforme necessário
    // ...

    return true; // Retorna verdadeiro se o formulário for válido
}

function submitRegisterForm() {
    const registerForm = document.getElementById('registerForm');

    // Você pode usar XMLHttpRequest ou Fetch API para enviar os dados
    // Exemplo com Fetch API:
    fetch(registerForm.action, {
        method: 'POST',
        body: new FormData(registerForm),
        // Adicione quaisquer cabeçalhos necessários, como tokens de autenticação
    })
        .then(response => {
            if (response.ok) {
                return response.json(); // ou response.text() se a resposta for texto
            }
            throw new Error('Ocorreu um problema ao enviar o formulário.');
        })
        .then(data => {
            // Trate a resposta aqui
            console.log(data);
            alert('Registro concluído com sucesso!');
            // Redirecionar para outra página, se necessário
            // window.location.href = '/algumaOutraPagina';
        })
        .catch(error => {
            console.error('Erro ao enviar o formulário:', error);
            alert(error.message);
        });
}