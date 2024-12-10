$(function () {
  $("#userForm").validate({
    rules: {
      name: {
        required: true,
        pattern: /^[A-Z][a-z]+ [A-Z][a-z]+$/,
      },
      email: {
        required: true,
        email: true,
      },
      pass: {
        required: true,
        pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/,
      },
    },
    messages: {
      name: {
        required: "Please enter your name",
        pattern: "Please enter a valid name (e.g., John Doe)",
      },
      email: {
        required: "Please enter your email",
        email: "Please enter a valid email",
      },
      pass: {
        required: "Please enter your password",
        pattern:
          "Password must contain at least 8 characters, including uppercase, lowercase, and digits.",
      },
    },
    submitHandler: function () {
      const name = $("#name").val().trim();
      const email = $("#email").val().trim();
      const pass = $("#pass").val().trim();
      alert(
        "Form submitted successfully. Name: " +
          name +
          ", Email: " +
          email +
          ", Password: " +
          pass
      );
    },
  });
});
