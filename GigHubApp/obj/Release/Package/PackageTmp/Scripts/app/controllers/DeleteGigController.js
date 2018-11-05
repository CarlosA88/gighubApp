var DeleteGigController = function () {

    var init = function () {
        $(".js-cancel-gig").click(function (e) {
            var link = $(e.target);

            var dialog = bootbox.dialog({
                title: 'Confirm',
                message: "<p>Are you sure you want to cancel this gig?</p>",
                buttons: {
                    no: {
                        label: "No",
                        className: 'btn-default',
                        callback: function () {
                            bootbox.hideAll();
                        }
                    },
                    yes: {
                        label: "Yes",
                        className: 'btn-danger',
                        callback: function () {
                            $.ajax({
                                url: "/api/gigs/" + link.attr("data-gig-id"),
                                method: "DELETE"
                            })
                            .done(function () {
                                link.parents("li").fadeOut(function () {
                                    $(this).remove();
                                })
                            })
                          .fail(function () {
                              alert("Something failed!")
                          })
                        }
                    },
                }
            });
        });
    }
 
    return {
        init: init
    }

}();