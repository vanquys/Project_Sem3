
document.addEventListener('DOMContentLoaded', () => {
    var closebtns = document.getElementsByClassName("close-btn");
    var rgtbtns = document.getElementsByClassName("cp-btn-rgt");
    var dialog = document.querySelector('.dialog');
    var i;

    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {

            dialog.classList.add('hidden')
        });
    }


    for (i = 0; i < rgtbtns.length; i++) {
        rgtbtns[i].addEventListener("click", function () {
            dialog.classList.remove('hidden')
        });
    }
});