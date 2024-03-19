// Handle the click event on the clickable area
document.querySelector('map area').addEventListener('click', function() {
    // Handle the click event here
    // You can navigate to a new page or perform any action you want
    console.log("Area clicked!");
});

// Handle the hover effect on the clickable area
document.querySelector('map area').addEventListener('mouseover', function() {
    // Add a hover effect (e.g., change border color) on mouseover
    this.classList.add('area-hover');
});

document.querySelector('map area').addEventListener('mouseout', function() {
    // Remove the hover effect on mouseout
    this.classList.remove('area-hover');
});
var cip = $(".video").hover( hoverVideo, hideVideo );

function hoverVideo(e) {  
    $('video', this).get(0).play(); 
}

function hideVideo(e) {
    $('video', this).get(0).pause(); 
}
