
document.addEventListener('DOMContentLoaded', () => {
    var closeEditProfile = document.getElementsByClassName("close-editProfile");
    var btnEditProfile = document.getElementsByClassName("editProfile");

    var closeEditAccountSurvey = document.getElementsByClassName("close-editAccountSurvey");
    var btnEditAccountSurvey = document.getElementsByClassName("editAccountSurvey");

    
    var dialogEditProfile = document.querySelector('.dialog-editProfile');
    var dialogEditAccountSurvey = document.querySelector('.dialog-editAccountSurvey');
    var i;

    //

    //

    for (i = 0; i < closeEditProfile.length; i++) {
        closeEditProfile[i].addEventListener("click", function () {

            dialogEditProfile.classList.remove('showDialogProfile')
        });
    }
    // 
    for (i = 0; i < btnEditProfile.length; i++) {
        btnEditProfile[i].addEventListener("click", function () {
            dialogEditProfile.classList.add('showDialogProfile')
        });
            
    }

    // Edit account survey

    for (i = 0; i < closeEditAccountSurvey.length; i++) {
        closeEditAccountSurvey[i].addEventListener("click", function () {

            dialogEditAccountSurvey.classList.remove('showDialogProfile')
        });
    }
    for (i = 0; i < btnEditAccountSurvey.length; i++) {
        btnEditAccountSurvey[i].addEventListener("click", function () {
            dialogEditAccountSurvey.classList.add('showDialogProfile')
        });

    }
    $('.edit-btn-delete').click(function (event) {
        event.preventDefault();
        var id = $(this).data('id');
        if (confirm('Are you sure you want to delete your servey account?')) {
            $.ajax({
                url: '/Account/DeleteAccountSurvey',
                type: 'POST',
                data: { id: id },
                success: function (result) {
                    if (result.success) {
                        location.reload();
                        alert(result.message);
                    } else {
                        alert('You participating in the contest, cannot be deleted!');
                        console.log(result.message);
                    }
                },
                error: function () {
                    alert('Error');
                }
            });
        }
    });

})