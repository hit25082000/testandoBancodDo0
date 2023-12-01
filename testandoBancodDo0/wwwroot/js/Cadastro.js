const mode = document.getElementById('mode_icon');

mode.addEventListener('click', () => {
    const form = document.getElementById('login_form');

    if (mode.classList.contains('fa-moon')) {
        mode.classList.remove('fa-moon');
        mode.classList.add('fa-sun');

        form.classList.add('dark');
        return;
    }

    mode.classList.remove('fa-sun');
    mode.classList.add('fa-moon');

    form.classList.remove('dark');
});

const loginForm = document.getElementById('login_form');

loginForm.addEventListener('submit', function (e) {
    e.preventDefault(); // Impede o envio padrão do formulário

    // Crie um objeto FormData com os dados do formulário
    const formData = new FormData(loginForm);

    // Faça uma solicitação Fetch para a ação "Cadastrar" no controlador "CadastroController"
    fetch('/Cadastro/Cadastrar', {
        method: 'POST',
        body: formData
    })
        .then(response => {
            // Verifique se a solicitação foi bem-sucedida
            if (!response.ok) {
                throw new Error(`Erro na solicitação: ${response.statusText}`);
            }
            // Redirecione ou realize outras ações conforme necessário
            window.location.href = "página de sucesso ou redirecionamento";
        })
        .catch(error => {
            console.error('Erro:', error);
            // Lide com o erro conforme necessário, exibindo uma mensagem ao usuário, por exemplo
        });
});

