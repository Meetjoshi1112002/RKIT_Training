$(function () {

    // selecting using class
    $('.menu-item a').click(function (e) {
       console.log($(this).text())
    });

    // selecting using index
    $('.list-item:eq(2)').mouseenter(function(){
        console.log($(this).text())
    })

    // selecting using ID
    $('#section1').mouseenter(function(){
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

    // selecting using element name
    $('table').hover(function(){
        console.log("mouse over table")
    }, function(){
        console.log("mouse out table")
    })

    $()


});
