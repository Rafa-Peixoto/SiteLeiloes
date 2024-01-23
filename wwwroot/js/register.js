<script>
    document.addeventlistener("domcontentloaded", function(){
        // valida��o do lado do cliente, se necess�rio
        var form = document.queryselector('form');
    form.onsubmit = function() {
            // verifique se os campos do formul�rio s�o v�lidos
            if (!form.checkvalidity()) {
        event.preventdefault(); // impede o envio do formul�rio
    event.stoppropagation();
            }
    form.classlist.add('was-validated');
        };
    });

     document.addEventListener('DOMContentLoaded', (event) => {
        const logo = document.querySelector('.logo-container img'); // Seleciona a imagem do logotipo
    const inputs = document.querySelectorAll('.container input'); // Seleciona todos os inputs dentro do container

        inputs.forEach(input => {
        // Quando qualquer input ganha foco
        input.addEventListener('focus', () => {
            logo.classList.add('logo-enlarged'); // Adiciona a classe que aumenta o logotipo
        });

            // Quando qualquer input perde foco
            input.addEventListener('blur', () => {
        logo.classList.remove('logo-enlarged'); // Remove a classe que aumenta o logotipo
            });
        });
    });
</script>
