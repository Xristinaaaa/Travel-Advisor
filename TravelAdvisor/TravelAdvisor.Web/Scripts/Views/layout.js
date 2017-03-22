jQuery = jQuery.noConflict();

/* Scroll for navigation */
jQuery(function () {
	jQuery('a.page-scroll').bind('click', function (event) {
		var $anchor = jQuery(this);
		jQuery('html, body').stop().animate({
			scrollTop: jQuery($anchor.attr('href')).offset().top
		}, 1500, 'easeInOutExpo');
		event.preventDefault();
	});
});

/* Shows and hides contact button */
jQuery(function () {
	jQuery('.contact-btn').on('click', function (ev) {
		ev.preventDefault();

		jQuery('#contact-form').toggle();
	});
});

jQuery(function () {
	jQuery('[data-toggle="tooltip"]').tooltip();
});