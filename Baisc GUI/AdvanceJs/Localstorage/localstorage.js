const form = document.getElementById("createViewForm");
form.addEventListener("submit", function (event) {
  event.preventDefault();

  const formData = {
    username: document.getElementById("username").value,
    password: document.getElementById("password").value,
    viewType: document.getElementById("viewType").value,
    user: document.querySelector('input[name="user"]:checked').value,
    image: document.getElementById("image").files[0]?.name,
  };

  localStorage.setItem("user-data", JSON.stringify(formData));

  window.location.href = "./viewData.html";
});
