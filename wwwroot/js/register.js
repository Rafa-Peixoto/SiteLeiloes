@section Scripts {
    <script>
        document.addEventListener("DOMContentLoaded", function(){
            // Valida��o do lado do cliente, se necess�rio
            var form = document.querySelector('form');
        form.onsubmit = function() {
                // Verifique se os campos do formul�rio s�o v�lidos
                if (!form.checkValidity()) {
            event.preventDefault(); // Impede o envio do formul�rio
        event.stopPropagation();
                }
        form.classList.add('was-validated');
            };
        });
    </script>
}