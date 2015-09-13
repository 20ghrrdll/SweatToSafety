var main = function(){

    var sideBarOpen = false;

    // Open menu on click of button
    $('.menu-btn').click(function(){
        sideBarOpen = true;
		$('.sidebar').animate({
			right: '0px'
		}, 200);
	});

    //close menu on click of close button
    $('.menu-close').click(function(){
        sideBarOpen = false;
        $('.sidebar').animate({
            right: '-250px'
        }, 200);
    });

    // close menu when u click the body
    $('.cvas, .c, .light, .moon, .house, .header, .container, .section, .blog-header, .about, .about-title, .posts, .projects-title, .projects, .blog, .contact-me, .sidebar li a').click(function(){
        $('.sidebar').animate({
            right: '-250px'
        }, 200);
    });

    $('.menu-close').click(function(){
        sideBarOpen = false;
        $('.sidebar').animate({
            right: '-250px'
        }, 200);
    });

};

$(document).ready(main);