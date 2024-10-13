document.addEventListener("DOMContentLoaded", () => {
  const createViewForm = document.getElementById("createViewForm");

  createViewForm.addEventListener("submit", (event) => {
    event.preventDefault(); // prevent form reload which results in loss of form data
    let success = true;

    // Validate username ----------------------------------------------------------------------------
    const username = document.getElementById("username");
    const usernameError = document.getElementById("usernameError");
    if (username.value === "" || username.value == null) {
      usernameError.innerHTML = "Please enter the name of the user";
      success = false;
    } else if (!/^[a-zA-Z]{3,}\s[a-zA-Z]{3,}/.test(username.value)) {
      usernameError.innerHTML = "Please enter a valid name for the user";
      success = false;
    } else {
      usernameError.innerHTML = "";
    }

    // Validate password: ---------------------------------------------------------------------------
    const password = document.getElementById("password");
    const confirmPassword = document.getElementById("confirmPassword");
    const passwordError = document.getElementById("passwordError");
    const confirmPasswordError = document.getElementById(
      "confirmPasswordError"
    );

    const atleastOneLowerCase = /^(?=.*[a-z])/;
    const atleastOneUpperCase = /^(?=.*[A-Z])/;
    const atleastOneDigit = /^(?=.*\d)/;
    const atleastOneSpecialChar = /^(?=.*[!@#$%^&*])/;

    if (success) {
      passwordError.innerHTML = "";
      if (!atleastOneLowerCase.test(password.value)) {
        passwordError.innerHTML =
          "Password must contain at least one lowercase letter";
        confirmPasswordError.innerHTML = "Please enter a valid password";
        success = false;
      } else if (!atleastOneUpperCase.test(password.value)) {
        passwordError.innerHTML =
          "Password must contain at least one uppercase letter";
        confirmPasswordError.innerHTML = "Please enter a valid password";
        success = false;
      } else if (!atleastOneDigit.test(password.value)) {
        passwordError.innerHTML = "Password must contain at least one digit";
        confirmPasswordError.innerHTML = "Please enter a valid password";
        success = false;
      } else if (!atleastOneSpecialChar.test(password.value)) {
        passwordError.innerHTML =
          "Password must contain at least one special character";
        confirmPasswordError.innerHTML = "Please enter a valid password";
        success = false;
      } else if (password.value.length < 8) {
        passwordError.innerHTML = "Password must be at least 8 characters long";
        confirmPasswordError.innerHTML = "Please enter a valid password";
        success = false;
      } else if (password.value !== confirmPassword.value) {
        passwordError.innerHTML = "Passwords don't match";
        confirmPasswordError.innerHTML = "Passwords don't match";
        success = false;
      } else {
        passwordError.innerHTML = "";
        confirmPasswordError.innerHTML = "";
      }
    }

    // Validate image (JPEG only): -----------------------------------------------------------------
    const imageInput = document.getElementById("image");
    const imageError = document.getElementById("imageError");

    const file = imageInput.files[0];
    const maxSize = 2 * 1024 * 1024; // say 2mb

    if (success && !file) {
      imageError.innerHTML = "Please upload an image.";
      success = false;
    } else if (success && !["image/jpeg"].includes(file.type)) {
      imageError.innerHTML = "Only JPEG images are allowed.";
      success = false;
    } else if (success && file.size > maxSize) {
      imageError.innerHTML = "File size must be less than 2MB.";
      success = false;
    } else {
      imageError.innerHTML = "";
    }

    // Validate type of view: ----------------------------------------------------------------------
    const viewType = document.getElementById("viewType");
    const viewTypeError = document.getElementById("viewTypeError");

    if (success && viewType.value === "") {
      viewTypeError.innerHTML = "Please select a view type.";
      success = false;
    } else {
      viewTypeError.innerHTML = "";
    }

    // Validate type of user (radio buttons): ------------------------------------------------------
    const userRadios = document.getElementsByName("user");
    const userError = document.getElementById("userError");

    let userSelected = false;
    for (let i = 0; i < userRadios.length; i++) {
      if (userRadios[i].checked === true) {
        userSelected = true;
        break;
      }
    }

    if (success && !userSelected) {
      userError.innerHTML = "Please select a user type.";
      success = false;
    } else {
      userError.innerHTML = "";
    }

    // all OK then form submit
    if (success) {
      createViewForm.submit();
    }
  });
});
