document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("signupForm");
    const element = document.getElementById("clickButton");
  
    // some basic property of elements :
    let arr = element.attributes;
    console.log(element.attributes);   // we can see all attributes of this element
    console.log(element.parentElement);
    console.log(element.classList[0]);
  
    element.style.background = "white"; // we can modify the style of the element
  
    form.addEventListener("submit", (event) => {
      event.preventDefault();
      event.stopImmediatePropagation();  // prevent any other events from firing on this element or its parents
      console.log("HI");
  
      // Get event details
      console.log(event.timeStamp);
      console.log(event.target);   // returns the element that fired the event
  
      const username = document.getElementById("username");
      const email = document.getElementById("email");
      const error = document.getElementById("error");
      var success = true;
      error.style.color = "red";
  
      if (username.value === "" || username.value == null) {
        error.innerText = "Please enter the name of the user\n";
        success = false;
      } else if (!/^[a-zA-Z]{3,}\s[a-zA-Z]{3,}/.test(username.value)) {
        error.innerText = "Please enter a valid name for the user\n";
        success = false;
      } else {
        error.innerHTML = "";
      }
  
      if (email.value === "" || email.value == null) {
        error.innerText += "Please enter the email\n";
        success = false;
      } else if (!/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email.value)) {
        error.innerText += "Enter a valid email\n";
      } else {
        error.innerText = "";
      }
  
      if (success) {
        console.log("success");
        // Store the data in localStorage:
        var arr = localStorage.getItem("forms");
  
        if (!arr) {
          arr = [];
        } else {
          arr = JSON.parse(arr);
        }
  
        arr.push({
          user: username.value,
          email: email.value,
        });
  
        localStorage.setItem("forms", JSON.stringify(arr));
      } else {
        console.log("failure");
      }
    });
  
    // Clear localStorage when delete button is clicked
    const delButton = document.getElementById("delete_storage");
  
    delButton.addEventListener("click", () => {
      localStorage.clear();
      const log = document.getElementById("area");
      log.style.color = "green";
      log.innerText = "Memory cleared";
    });
  
    // Show data in the table
    const showdata = document.getElementById("Show_data");
  
    showdata.addEventListener("click", () => {
      const table = `
        <h2>Dynamic Table Example</h2>
        <table id="dataTable" border="1">
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
            </tr>
          </thead>
          <tbody id="tableBody">
            <!-- Dynamic rows will go here -->
          </tbody>
        </table>
      `;
  
      // Insert the table structure into the container
      const container = document.getElementById("area");
      container.innerHTML = table;
  
      // Retrieve data from localStorage and populate the table
      const storedData = localStorage.getItem("forms");
      const tableBody = document.getElementById("tableBody");
  
      if (storedData) {
        const parsedData = JSON.parse(storedData);
  
        // Loop through the stored data and create table rows
        parsedData.forEach(item => {
          const row = document.createElement("tr");
  
          const nameCell = document.createElement("td");
          nameCell.textContent = item.user;  // User name from stored data
          row.appendChild(nameCell);
  
          const emailCell = document.createElement("td");
          emailCell.textContent = item.email;  // User email from stored data
          row.appendChild(emailCell);
  
          tableBody.appendChild(row);  // Append the row to the table body
        });
      } else{
        const row = document.createElement("tr");

        const cell = document.createElement("td");
        cell.textContent = "No data to show !";
        cell.colSpan = 2;
        row.appendChild(cell);

        tableBody.appendChild(row);


      }
    });
  
    // Auto-focus the div on page load (optional)
    window.onload = () => {
      document.getElementById("magicbox").focus();
    };
  });
  