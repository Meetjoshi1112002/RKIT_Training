$(function () {
    /// Helper function
    const askServer = (value) => {
        const registeredMails = [
            "john.doe@example.com",
            "jane.smith@gmail.com",
            "user123@yahoo.com",
            "test.account@outlook.com",
            "dummy.email@company.org",
            "contact@domain.co",
            "sample_user@service.net",
            "hello.world@website.io"
        ];

        const d = $.Deferred();
        setTimeout(() => {
            registeredMails.includes(value) ? d.reject() : d.resolve();
        }, 1000);
        return d.promise();
    };

    /// Function to calculate age from DOB
    function calculateAge(dob) {
        if (!dob) return null;
        const today = new Date();
        const birthDate = new Date(dob);
        let age = today.getFullYear() - birthDate.getFullYear();
        const monthDiff = today.getMonth() - birthDate.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        return age >= 18 ? age : null; // Ensuring the age is at least 18
    }

    /// Input fields
    $("#nameContainer").dxTextBox({
        placeholder: "Enter your name",
        mode: "text",
        valueChangeEvent: "keyup",
        maxLength: 20
    }).dxValidator({
        validationRules: [
            { type: "required", message: "Username is required" },
            { type: "pattern", pattern: "^[a-zA-Z]+$", message: "Should contain only letters" }
        ],
        validationGroup: "Signup"
    });

    $("#emailContainer").dxTextBox({
        placeholder: "Enter your email",
        mode: "email",
        onInitialized: function () {
            console.log("intializer")
        },
        onContentReady: function () {
            console.log("content")
        },
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            { type: "required", message: "Email is required" },
            { type: "email", message: "Please enter a valid email address" },
            {
                type: "async",
                message: "Email is already registered",
                validationCallback: (arg) => askServer(arg.value)
            }
        ]
    });

    /// DOB field with change event to update age
    $("#dobContainer").dxDateBox({
        placeholder: "Select your DOB",
        type: "date",
        pickerType: "rollers",
        max: new Date(),
        min: new Date(2000, 0, 1),
        displayFormat: "dd/MM/yyyy",
        onValueChanged: function (e) {
            const age = calculateAge(e.value);
            $("#ageContainer").dxNumberBox("instance").option("value", age);
        }
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            { type: "required", message: "DOB is required" },
            { type: "range", max: new Date(), message: "Invalid DOB" },
            {
                type: "custom",
                validationCallback: function (e) {
                    return calculateAge(e.value) !== null;
                },
                message: "You must be at least 18 years old"
            }
        ]
    });

    $("#profileContainer").dxSelectBox({
        items: ["DSA", "Web", "ML"],
        value: null,
        placeholder: "Select your profile",
        valueChangeEvent:'keyup',
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            { type: "required", message: "Profile selection is required" },
            {
                type: "custom",
                validationCallback: function (e) {
                    return e.value !== "ML";
                },
                message: "ML is not available currently"
            }
        ]
    });

    /// Age field (readonly, updated automatically from DOB)
    $("#ageContainer").dxNumberBox({
        min: 18,
        max: 100,
        readOnly: true
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            { type: "range", min: 18, max: 100, message: "Age must be valid" },
            { type: "required", message: "Age is required" }
        ]
    });

    $("#commentContainer").dxTextArea({
        value: "Give your suggestion here",
        spellcheck: false,
        readOnly: false,
        autoResizeEnabled: true,
        valueChangeEvent: "keyup"
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            { type: "required", message: "Your suggestion is required" },
            { type: "stringLength", min: 5, max: 100, message: "Suggestion must be between 5 and 100 characters" }
        ]
    });

    $("#termsContainer").dxCheckBox({
        text: "T & C",
        hint: "You must agree",
        value: false,
        valueChangeEvent: "keyup",
        isValid:false,
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [{ type: "required", message: "You must agree to the terms" }]
    });

    $("#fileUploader").dxFileUploader({
        accept: "image/*",
        selectButtonText: "Upload Resume",
        uploadUrl: "https://js.devexpress.com/Demos/NetCore/FileUploader/Upload",
        allowCanceling: true,
        maxFileSize: 1000000
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [
            {
                type: "custom",
                validationCallback: function (e) {
                    return e.value.length === 1;
                },
                message: "Only one resume is required"
            },
            { type: "required", message: "Resume is required" }
        ]
    });

    $("#genderContainer").dxRadioGroup({
        items: ["Male", "Female", "Other"],
        value: "Male"
    }).dxValidator({
        validationGroup: "Signup",
        validationRules: [{ type: "required", message: "Gender selection is required" }]
    });

    /// Submit handler:
    $("#submitHandler").dxButton({
        text: "Submit",
        icon: "like",
        onClick: function () {
            let result = DevExpress.validationEngine.validateGroup("Signup");
            if (result.isValid) {
                // Retrieve values correctly
                let formData = {
                    name: $("#nameContainer").dxTextBox("instance").option("value"),
                    email: $("#emailContainer").dxTextBox("instance").option("value"),
                    dob: $("#dobContainer").dxDateBox("instance").option("value"),
                    country: $("#profileContainer").dxSelectBox("instance").option("value"),
                    age: $("#ageContainer").dxNumberBox("instance").option("value"),
                    yourRequirement: $("#commentContainer").dxTextArea("instance").option("value"),
                    tc: $("#termsContainer").dxCheckBox("instance").option("value"),
                    gender: $("#genderContainer").dxRadioGroup("instance").option("value")
                };

                let storedData = JSON.parse(sessionStorage.getItem("userData")) || [];
                storedData.push(formData);
                sessionStorage.setItem("userData", JSON.stringify(storedData));

                alert("Resume added");
            } else {
                alert("Resume not added");
            }
        }
    });

    /// Search Feature
    $("#searchContainer").dxTextBox({
        placeholder: "Search saved data",
        onValueChanged: function (e) {
            var searchQuery = e.value.trim().toLowerCase(); // Trim extra spaces and convert to lowercase
            var savedData = JSON.parse(sessionStorage.getItem("userData")) || [];

            if (savedData.length > 0) {
                var filteredData = savedData.filter(item => item.name.toLowerCase().includes(searchQuery));

                if (filteredData.length > 0) {
                    $("#dataGridContainer").dxDataGrid({
                        dataSource: filteredData,
                        columns: Object.keys(filteredData[0]).map(key => ({
                            dataField: key,
                            caption: key.charAt(0).toUpperCase() + key.slice(1)
                        })),
                        showBorders: true,
                        paging: { pageSize: 5 },
                        searchPanel: { visible: true }
                    }).dxDataGrid("instance").option("visible", true); // Make grid visible
                } else {
                    $("#dataGridContainer").dxDataGrid("instance").option("visible", false);
                    alert("No matching data found!");
                }
            } else {
                alert("No saved data found in session storage!");
            }
        }
    });

    $("#dataGridContainer").dxDataGrid({
        visible: false, // Initially hidden
        showBorders: true
    });
});
