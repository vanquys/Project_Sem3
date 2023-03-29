
document.addEventListener('DOMContentLoaded', () => {
    var closebtns = document.getElementsByClassName("close-btn");
    var rgtbtns = document.getElementsByClassName("cp-btn-rgt");
    var dialog = document.querySelector('.dialog-cp-rgt');
    var i;

    //
   
    //

    for (i = 0; i < closebtns.length; i++) {
        closebtns[i].addEventListener("click", function () {
            dialog.classList.remove('showDialog')
        });
    }
    // 
    for (i = 0; i < rgtbtns.length; i++) {
        rgtbtns[i].addEventListener("click", function () {
            var name = this.dataset.name;
            var competitionId = this.getAttribute("data-competitionId")
            var userId = this.getAttribute("data-userId")
            dialog.querySelector("#dialog-competitionId").value = competitionId;
            dialog.querySelector("#dialog-name").value = name;
            dialog.querySelector("#dialog-roll").value = userId;
            dialog.classList.add('showDialog')

        });
    }
    
});