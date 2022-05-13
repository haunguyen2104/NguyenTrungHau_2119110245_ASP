const input = document.querySelector(".input");
const eyeClose = document.querySelector(".eye-close");
const eyeOpen = document.querySelector(".eye-open");

eyeOpen.addEventListener("click", function () {
    eyeOpen.classList.add("hidden");
    eyeClose.classList.remove("hidden");
    input.setAttribute("type", "password");
});
eyeClose.addEventListener("click", function () {
    eyeOpen.classList.remove("hidden");
    eyeClose.classList.add("hidden");
    input.setAttribute("type", "text");
});

