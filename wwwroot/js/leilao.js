document.addEventListener('DOMContentLoaded', function () {
    var stars = document.querySelectorAll('.star');
    var starRating = document.querySelector('.star-rating');

    stars.forEach(function (star) {
        star.addEventListener('click', function () {
            // Remove 'hover' de todas as estrelas antes de adicionar 'active'
            stars.forEach(function (s) {
                s.classList.remove('hover');
            });

            this.classList.add('active');
            var previousStars = Array.from(this.previousSiblings());
            previousStars.forEach(function (previousStar) {
                previousStar.classList.add('active');
            });
            var nextStars = Array.from(this.nextElementSibling ? this.nextElementSibling.nextSiblings() : []);
            nextStars.forEach(function (nextStar) {
                nextStar.classList.remove('active');
            });
            starRating.setAttribute('data-rating', star.getAttribute('data-value'));
        });

        star.addEventListener('mouseover', function () {
            // Adiciona 'hover' a todas as estrelas antes da estrela atual
            var previousStars = Array.from(this.previousSiblings());
            previousStars.forEach(function (previousStar) {
                previousStar.classList.add('hover');
            });
        });

        star.addEventListener('mouseout', function () {
            // Remove 'hover' de todas as estrelas
            stars.forEach(function (s) {
                s.classList.remove('hover');
            });
        });
    });

    // Adiciona um método 'previousSiblings' ao protótipo de HTMLElement para obter irmãos anteriores
    HTMLElement.prototype.previousSiblings = function () {
        var siblings = Array.from(this.parentNode.children);
        return siblings.slice(0, siblings.indexOf(this));
    };
});