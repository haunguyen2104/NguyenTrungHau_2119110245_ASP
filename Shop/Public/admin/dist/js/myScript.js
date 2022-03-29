//Khởi tạo active cho class nav-link
const links = document.querySelectorAll("#main-nav .nav-link")
Array.from(links).forEach(function (link, index) {
    if (link.href.toLowerCase() == window.location.href.toLowerCase()) {
        link.classList.add("active")
    }
})