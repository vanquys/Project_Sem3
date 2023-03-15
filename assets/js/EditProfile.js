
document.addEventListener('DOMContentLoaded', () => {
    var closeEditProfile= document.getElementsByClassName("close-editProfile");
    var btnEditProfile = document.getElementsByClassName("editProfile");
    var dialogEditProfile = document.querySelector('.dialog-editProfile');
    var i;

    //

    //

    for (i = 0; i < closeEditProfile.length; i++) {
        closeEditProfile[i].addEventListener("click", function () {

            dialogEditProfile.classList.add('hidden')
        });
    }
    // 
    for (i = 0; i < btnEditProfile.length; i++) {
        btnEditProfile[i].addEventListener("click", function () {
            dialogEditProfile.classList.remove('hidden')
        });
            
    }
})