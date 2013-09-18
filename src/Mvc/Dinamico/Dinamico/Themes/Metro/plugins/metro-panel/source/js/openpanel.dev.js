/*!
=====================================

OpenPanel by SONHLAB.com - version 1.1
website: http://sonhlab.com
Documentation: http://docs.sonhlab.com/openpanel-responsive-panel-anywhere/

=====================================
*/
(function($){

	var OpenPanel = function(e, options){
	
		//Default settings
		var settings = $.extend({}, $.fn.openpanel.defaults, options);
		
		var $panelid;		
		
		// Set Panel Style
		function setPanelStyle() {
			var $panelWidth;
			var $panelHeight;
			var panelObj = {};
			
			$panelWidth = $(window).width();
			$panelHeight = $(window).height();
			
			panelObj['width'] = $panelWidth+'px';
			panelObj['height'] = $panelHeight+'px';
			
			var $panelformHeight = $panelHeight-88;
			
			$('.op-panel').css(panelObj);
			
			$('.op-panelform').css({'height':$panelformHeight+'px'});
			
		}
		
		
		// Open Panel Function
		function OpenPanelFunc(e, $pos, $panelbg, $paneltext) {
			
			if ( !$pos ) {
				$pos = 'none';
			}
			
			// Check Station
			if ( ! $('#op-station').length ) {
				$('body').append("<div id='op-station'></div>");
			}
			
			// Check Pane Exist or Not
			if ( !$('#'+e).length ) {
			
				var $filepath = 'content/openpanel/'+e+'.'+settings.ext;
				
				// AJAX load
				$.ajax({
					url: $filepath,
					type:'POST',
					data:'',
					cache: false,
					success: function(data){
						if (data) {
						
							$('#op-station').append(data);
							if ( $('#'+e).length > 0 ) {
								
								// Add Text Color and Background for Panel
								$('#'+e).addClass($panelbg+' '+$paneltext);
								
								// Set Panel Style
								setPanelStyle();
								$('#'+e).css({'display':'block'});
								
								// Position Effect
								PostionEffect($pos);
								
								// Call Close Panel Function
								ClosePanel();
								
								// Call Close All Panels Function
								CloseAllPanels();
				
							}
						}
					}
				});
				// End AJAX
			}
			else {
				
				// Add Text Color and Background for Panel
				$('#'+e).addClass($panelbg+' '+$paneltext);
			
				// Set Panel Style
				setPanelStyle();
				$('#'+e).css({'display':'block'});
				
				// Position Effect
				PostionEffect($pos);
				
				// Call Close Panel Function
				ClosePanel();
				
				// Call Close All Panels Fuction
				CloseAllPanels();
				
			}
			
			// Position Effect
			function PostionEffect($pos) {
				var directionObj = {};
				
				if ( $pos == 'left' ) {
					directionObj['left'] = '-'+$(window).width()+'px';
					directionObj['top'] = '0px';
					$('#'+e).css(directionObj);
					$('#'+e).animate({'left':'0px'},400,'swing',
					function(){
						
					});
				}
				else if ( $pos == 'right' ) {
					directionObj['right'] = '-'+$(window).width()+'px';
					directionObj['top'] = '0px';
					$('#'+e).css(directionObj);
					$('#'+e).animate({'right':'0px'},400,'swing',
					function(){
	
					});
				}
				else if ( $pos == 'bottom' ) {
					directionObj['bottom'] = '-'+$(window).height()+'px';
					$('#'+e).css(directionObj);
					$('#'+e).animate({'bottom':'0px'},400,'swing',
					function(){
	
					});
				}
				
				else if ( $pos == 'top' ) {
					directionObj['top'] = '-'+$(window).height()+'px';
					$('#'+e).css(directionObj);
					$('#'+e).animate({'top':'0px'},400,'swing',
					function(){
						
					});
				}
				else { // fade effect
					directionObj['top'] = '0px';
					directionObj['display'] = 'none';
					$('#'+e).css(directionObj);
					$('#'+e).fadeIn(400);
				}
				
			} // End Position Effect
		
		}
		
		// Close Panel
		function ClosePanel() {
			$('.op-bt-close').on('click',function() {
				var $close = $(this).attr('data-close');
				$('#'+$close).fadeOut(400);
			});
		}
		
		// Close All Panels
		function CloseAllPanels() {
			$('.op-bt-closeall').on('click',function() {
				$('.op-panel').css({'display':'none'});
			});
			
			$(document).keydown(function(event) {
				if ( event.keyCode == 27 ) {
					$('.op-panel').css({'display':'none'});
					return false;
				}
			});
			
		}
		
		
		// Open Panel
		$(e).on('click',function(){
			
			$panelid = $(this).attr('data-panelid');
			var $pos = $(this).attr('data-pos');
			var $panelbg = $(this).attr('data-pbg');
			var $paneltext = $(this).attr('data-ptext');

			if ( $paneltext === undefined ) {
				$paneltext = 'light-text';
			}

			if ( $panelbg === undefined ) {
				$panelbg = 'solid-black';
			}

			// Open Panel
			OpenPanelFunc($panelid, $pos, $panelbg, $paneltext);
			
			// Add Scroll Bar
			$('#'+$panelid).find('.op-panelform').jScrollPane({
				showArrows: false,
				maintainPosition: false,
				autoReinitialise: true
			}).data('jsp');
			

		});
		
		
		// Resize Window
		$(window).on('resize',function(){
			setPanelStyle();
		});
		// End Resize

	
	};
	
	$.fn.openpanel = function(options) {
	
		return this.each(function(key, value){
					
			// Return early if this element already has a plugin instance
            if ($(this).data('openpanel')) return $(this).data('openpanel');
			
			// Pass options to plugin constructor
			var openpanel = new OpenPanel(this, options);
			
			// Store plugin object in this element's data
            $(this).data('openpanel', openpanel);
		
		});

	};
	
	//Default settings
	$.fn.openpanel.defaults = {
		ext: 'php'
	};	
	
})(jQuery);