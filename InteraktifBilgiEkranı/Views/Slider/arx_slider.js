

if(document.querySelectorAll(".slider").length == 1) {

	const timerlength = 3000 // Change it if you want to change the autoslide speed (in miliseconds, 10000 means 10 seconds) 
	const slider = document.querySelector(".slider");
	const sliderImg = slider.querySelectorAll("img");
	const sliderPreviusButton = slider.querySelector(".left")
	const sliderNextButton = slider.querySelector(".right")
	const slider_dots_holder = slider.querySelector(".slider_dots_holder")
	const sliderCount = slider.querySelectorAll("img").length - 1
	const imgHolder = slider.querySelector(".imgholder")
	


	let currentSlider = 0;
	let dotsnum = sliderCount + 1;
	// CreateDots function creates clickable dots & caption based on the number of images and alt texts
	for ( ;dotsnum != 0;dotsnum--) {
		const realId = sliderCount-(dotsnum-1)
		const newDot = document.createElement("div");
		const newCaption = document.createElement("div");
		newDot.classList.add("slider_dots");
		newDot.setAttribute("id", realId);
		newDot.setAttribute("onclick", ("sliderJump" + "(" + realId + ")") )
		newCaption.classList.add("slider_alts");
		newCaption.innerHTML = sliderImg[realId].alt;
		slider_dots_holder.appendChild(newDot);
		imgHolder.appendChild(newCaption);
	}

	// Below codes are for Next and previous butttons 
	const sliderdots =  slider.querySelectorAll(".slider_dots")
	const slideralts =  slider.querySelectorAll(".slider_alts")

	
  

	// Functions
	// Auto Play Codes (autoplay is Optional. you can remove the below code if you do not want Autoplay)
	function slideTimer() {
		if (currentSlider < sliderCount) {
			
			slidNext ()
			window.setTimeout (slideTimer, timerlength) 
		} else {
			
			sliderJump(0)
			window.setTimeout (slideTimer, timerlength) 
		}
	}

	function sliderShow() {
	
		sliderImg[currentSlider].style.opacity = "1";
		sliderdots[currentSlider].style.opacity = "1";
		slideralts[currentSlider].style.opacity = "0.8";

	}

	function sliderHide() {
	
		sliderImg[currentSlider].style.opacity = "0";
		sliderdots[currentSlider].style.opacity = "0.5";
		slideralts[currentSlider].style.opacity = "0";
	}

	function slidNext() {
		if (currentSlider < sliderCount) {
			
			sliderHide();
			currentSlider++;
			sliderShow();
		} else {
		
			sliderHide();
			currentSlider = 0;
			sliderShow();
		}
	}

	function slidePrevius() {
		if (currentSlider > 0) {
		
			sliderHide();
			currentSlider --;
			sliderShow();
		} else {
		
			sliderHide();
			currentSlider = sliderCount;
			sliderShow();
		}
	}
	
	function sliderJump(number) {
	
		sliderHide();
		currentSlider = number;
		sliderShow();
		resetTimer();
	}

	function resetTimer() {	
	}

	// Init
	if(sliderCount !== -1) {
		
		sliderPreviusButton.addEventListener("click", slidePrevius);
		sliderNextButton.addEventListener("click", slidNext);
		sliderShow()

		// Events
		window.setTimeout(slideTimer, timerlength);
	}
}