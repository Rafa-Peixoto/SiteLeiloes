@section Scripts {
    <script>
        document.addEventListener("DOMContentLoaded", function(){
            // Validação do lado do cliente, se necessário
            var form = document.querySelector('form');
        form.onsubmit = function() {
                // Verifique se os campos do formulário são válidos
                if (!form.checkValidity()) {
            event.preventDefault(); // Impede o envio do formulário
        event.stopPropagation();
                }
        form.classList.add('was-validated');
            };
        });
    </script>
}