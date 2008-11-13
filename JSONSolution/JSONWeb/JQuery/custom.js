$(document).ready(function() {
	// do something here
	$("a").toggle(function() {
		$(".stuff").animate({
			height: 'hide',
			opacity: 'hide'
		}, 'slow');
	}, function() {
		$(".stuff").animate({
			height: 'show',
			opacity: 'show'
		}, 'slow');
	});
});