$(document).ready(function () {

    const sess_initialSeconds = 120;
    const sess_expirySeconds = 60;
    const sess_pollingInterval = 1000;
    var sess_currentSeconds = sess_initialSeconds;

    InitializeSessionMonitoring();   

    $('#drinkInputSearch').on('keyup change paste', function () {
        FormatSearchString($(this));        
    });

    function FormatSearchString(input) {
        var formattedSearchString = input.val().replace(/[^a-zA-Z /s]/g, '');
        input.val(formattedSearchString);
    };


    function InitializeSessionMonitoring() {
        if ($('#btnLogout').is(":visible")) {
            $('#sessionrow').toggleClass('d-none');
            setTimeout(SessionValidation, 0);
            $('#btnsess_continue').on('click', function () {
                sess_currentSeconds = sess_initialSeconds;
                $("#staticBackdrop").modal('hide');
            });
            $('#btnsess_logout').on('click', function () {
                $('#sessionrow').toggleClass('d-none');
                $('#staticBackdrop').modal('hide');
                document.location.replace('/Account/Logout');
            });
        }        
    }

    function SessionValidation() {
        var displayedSeconds = sess_currentSeconds % 60;
        var displayedMinutes = Math.floor(sess_currentSeconds / 60) % 60;
        if (displayedMinutes <= 9) displayedMinutes = "0" + displayedMinutes;
        if (displayedSeconds <= 9) displayedSeconds = "0" + displayedSeconds;
        sess_currentSeconds--;

        $('.timeout').text(displayedMinutes + " minutes  " + displayedSeconds + " seconds");
        if (sess_currentSeconds === -1) {           
            $('#staticBackdrop').modal('hide');
            document.location.replace('/Account/Logout');

        } else {
            if (sess_currentSeconds < sess_expirySeconds) {
               
                $('#staticBackdrop').modal('show');
                setTimeout(SessionValidation, sess_pollingInterval);
            } else {
                setTimeout(SessionValidation, sess_pollingInterval);
            }
        }
    }
});