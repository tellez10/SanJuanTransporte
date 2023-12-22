document.addEventListener("DOMContentLoaded", function () {
    const rotatingImagesContainer = document.querySelector(".rotating-images-container");

    function rotateImages() {
        const currentImage = rotatingImagesContainer.firstElementChild;
        rotatingImagesContainer.appendChild(currentImage);
        currentImage.style.transform = "translateX(0)";
        currentImage.style.opacity = 1;
    }

    setInterval(rotateImages, 5000);
});
