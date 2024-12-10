$(function () {
    // On click of action button, hide all elements
    $('.action-btn').dblclick(() => {
        $('body').children().hide();
    });

    $('.menu-item a').click(function (e) {
        e.preventDefault(); // Prevent the default action of the anchor tag
        
        // Find the target section based on the href attribute
        const targetSection = $($(this).attr('href'));
        
        // Check if the target section exists and toggle the 'hide' class
        if (targetSection.length) {
            targetSection.toggleClass('hide');
        } else {
            console.error('Target section not found:', $(this).attr('href'));
        }
    });

    // selecting using index
    $('.list-item:eq(2)').mouseenter(function(){
        console.log($(this).text())
    })

    // selecting using rank
    $('.list-item:first').mouseenter(function(){
        console.log($(this).text())
    })

    // selecting using attribute
    $(".list-item[target='thisOne']").mouseleave(function(){
       console.log($(this).text())
    })

    $('table').hover(function(){
        $(this).addClass('highlight')
    }, function(){
        $(this).removeClass('highlight')
    })

    $("footer").on({
        mouseenter: function(){
          $(this).css("background-color", "lightgray");
        },  
        mouseleave: function(){
          $(this).css("background-color", "lightblue");
        }, 
        click: function(){
          $(this).css("background-color", "yellow");
        }  
      });




});
