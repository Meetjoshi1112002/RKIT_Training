// onClick event
const button = document.getElementById("clickButton");
button.addEventListener("click", () => {
  document.getElementById("clickMessage").innerText = "Button Clicked!";
});

// basic hover event
const hoverButton = document.getElementById("hoverButton");

hoverButton.addEventListener("mouseover", () => {
  document.getElementById("hoverMessage").innerText = "You hovered over me!";
});

hoverButton.addEventListener("mouseout", () => {
  document.getElementById("hoverMessage").innerText = "You left me!";
});

// onKeyDown and onKeyUp events
const textInput = document.getElementById("textInput");

textInput.addEventListener("keydown", (event) => {
  document.getElementById("keyMessage").innerText = `Key Down: ${event.key}`;
});

textInput.addEventListener("keyup", (event) => {
  document.getElementById("keyMessage").innerText = `Key Up: ${event.key}`;
});

const handler = (event)=>{
  // document.getElementById("keyMessage").innerText = `Key Down: ${event.code}`;
  alert("heleo")
}

// onFormSubmit event
const form = document.getElementById("demoForm");

form.addEventListener("submit", (event) => {
  event.preventDefault(); // Prevents page reload
  const nameValue = document.getElementById("name").value;

  if (nameValue) {
    document.getElementById(
      "formMessage"
    ).innerText = `Form Submitted! Hello, ${nameValue}.`;
  } else {
    document.getElementById("formMessage").innerText =
      "Please enter your name.";
  }
});
