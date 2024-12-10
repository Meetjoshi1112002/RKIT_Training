$(function () {
  const namePatter = /^[A-Z][a-z]+ [A-Z][a-z]+$/;
  const emailPattern = /^[a-zA-Z0-9._]+@[a-zA-Z]+\.[a-zA-Z]+$/;
  const passwd = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/;
  $("#userForm").on({
    submit: function (e) {
      e.preventDefault();
      const name = $("#name").val().trim();
      const email = $("#email").val().trim();
      const pass = $("#pass").val().trim();

      let error = "";
      let success = false;

      if (name === "" || email === "" || pass === "") {
        error = "Please fill all the fields";
      } else if (!namePatter.test(name)) {
        error = "Please enter a valid name";
      } else if (!emailPattern.test(email)) {
        error = "Please enter a valid email";
      } else if (!passwd.test(pass)) {
        error = "Please enter a valid password";
      } else {
        success = true;
      }
      if(success){
          alert("Form submitted successfully")
      }else{
        alert(error)
      }
      console.log(name, email, pswd);
    },
  });
});
