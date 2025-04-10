// DOM Elements
const sidebarToggle = document.getElementById('sidebarToggle');
const sidebar = document.querySelector('.sidebar');
const createSurveyBtn = document.getElementById('createSurveyBtn');
const createSurveyModal = document.getElementById('createSurveyModal');
const closeModal = document.getElementById('closeModal');
const tabBtns = document.querySelectorAll('.tab-btn');
const tabPanes = document.querySelectorAll('.tab-pane');
const questionEditorModal = document.getElementById('questionEditorModal');

// Welcome animation elements
const welcomeScreen = document.createElement('div');
welcomeScreen.className = 'welcome-screen';
welcomeScreen.innerHTML = `
    <div class="welcome-content">
        <div class="welcome-logo">
            <svg viewBox="0 0 100 100" width="100" height="100">
                <circle cx="50" cy="50" r="40" fill="none" stroke="#4a90e2" stroke-width="8" stroke-dasharray="251" stroke-dashoffset="251">
                    <animate attributeName="stroke-dashoffset" from="251" to="0" dur="1.5s" fill="freeze" />
                </circle>
                <path d="M35,50 L45,60 L65,40" fill="none" stroke="#4a90e2" stroke-width="8" stroke-dasharray="45" stroke-dashoffset="45">
                    <animate attributeName="stroke-dashoffset" from="45" to="0" dur="0.5s" begin="1s" fill="freeze" />
                </path>
            </svg>
        </div>
        <h1 class="welcome-title">Welcome to Smart Surveys</h1>
        <p class="welcome-message">Build secure survey and quizes with Automation</p>
        <div class="loading-bar">
            <div class="loading-progress"></div>
        </div>
    </div>
`;

// Add welcome screen styles
const welcomeStyles = document.createElement('style');
welcomeStyles.textContent = `
    .welcome-screen {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: #ffffff;
        display: flex;
        justify-content: center;
        align-items: center;
        z-index: 9999;
        opacity: 1;
        transition: opacity 0.5s ease-out;
    }
    .welcome-content {
        text-align: center;
        max-width: 500px;
        padding: 20px;
    }
    .welcome-logo {
        margin-bottom: 20px;
    }
    .welcome-title {
        font-size: 2rem;
        color: #333;
        margin-bottom: 15px;
        opacity: 0;
        transform: translateY(20px);
        animation: fadeIn 0.8s ease-out 0.5s forwards;
    }
    .welcome-message {
        font-size: 1.1rem;
        color: #666;
        margin-bottom: 30px;
        opacity: 0;
        transform: translateY(20px);
        animation: fadeIn 0.8s ease-out 0.8s forwards;
    }
    .loading-bar {
        width: 100%;
        height: 6px;
        background-color: #eee;
        border-radius: 3px;
        overflow: hidden;
        opacity: 0;
        animation: fadeIn 0.8s ease-out 1s forwards;
    }
    .loading-progress {
        height: 100%;
        width: 0;
        background-color: #4a90e2;
        border-radius: 3px;
        animation: progress 2s ease-out 1.2s forwards;
    }
    @keyframes fadeIn {
        to {
            opacity: 1;
            transform: translateY(0);
        }
    }
    @keyframes progress {
        to {
            width: 100%;
        }
    }
    .welcome-screen.fade-out {
        opacity: 0;
        pointer-events: none;
    }
`;

// Function to initialize welcome animation
function initWelcomeAnimation() {
    // Append welcome screen and styles to document
    document.head.appendChild(welcomeStyles);
    document.body.appendChild(welcomeScreen);
    
    // Hide main content initially
    const mainContent = document.querySelector('main') || document.querySelector('.container') || document.querySelector('.dashboard-container');
    if (mainContent) {
        mainContent.style.opacity = '0';
        mainContent.style.transition = 'opacity 0.5s ease-out';
    }
    
    // Remove welcome screen after animation completes
    setTimeout(() => {
        welcomeScreen.classList.add('fade-out');
        if (mainContent) {
            mainContent.style.opacity = '1';
        }
        
        // Remove welcome screen from DOM after fade out
        setTimeout(() => {
            welcomeScreen.remove();
        }, 1000);
    }, 4500); // Total animation time: ~3.5s
    
    // Check if this is the user's first visit
    const isFirstVisit = !localStorage.getItem('hasVisited');
    if (isFirstVisit) {
        // Set flag in localStorage for future visits
        localStorage.setItem('hasVisited', 'true');
    } else {
        // For returning users, we could make the animation shorter
        // by immediately triggering the fade-out
        setTimeout(() => {
            welcomeScreen.classList.add('fade-out');
            if (mainContent) {
                mainContent.style.opacity = '1';
            }
            setTimeout(() => {
                welcomeScreen.remove();
            }, 1000);
        }, 4500); // Shorter time for returning users
    }
}

// Toggle Sidebar
sidebarToggle.addEventListener('click', () => {
    sidebar.classList.toggle('collapsed');
});

// Modal Handling
createSurveyBtn.addEventListener('click', () => {
    createSurveyModal.classList.add('active');
    document.body.style.overflow = 'hidden';
});

// Close modal on X button click
if (closeModal) {
    closeModal.addEventListener('click', () => {
        createSurveyModal.classList.remove('active');
        document.body.style.overflow = 'auto';
    });
}

// Close modal when clicking outside
window.addEventListener('click', (e) => {
    if (e.target === createSurveyModal) {
        createSurveyModal.classList.remove('active');
        document.body.style.overflow = 'auto';
    }
    
    if (e.target === questionEditorModal) {
        questionEditorModal.classList.remove('active');
        document.body.style.overflow = 'auto';
    }
});

// Tab Functionality
tabBtns.forEach(btn => {
    btn.addEventListener('click', () => {
        // Remove active class from all buttons and panes
        tabBtns.forEach(b => b.classList.remove('active'));
        tabPanes.forEach(p => p.classList.remove('active'));
        
        // Add active class to clicked button
        btn.classList.add('active');
        
        // Show corresponding tab pane
        const tabId = btn.getAttribute('data-tab');
        document.getElementById(tabId).classList.add('active');
    });
});

// Create & Add Questions button functionality
document.querySelectorAll('.primary-btn').forEach(btn => {
    if (btn.textContent.includes('Create & Add Questions')) {
        btn.addEventListener('click', () => {
            // Close the current modal
            createSurveyModal.classList.remove('active');
            
            // Open the question editor modal
            questionEditorModal.classList.add('active');
        });
    }
});

// Question type selection
const questionTypes = document.querySelectorAll('.question-types ul li');
questionTypes.forEach(type => {
    type.addEventListener('click', () => {
        questionTypes.forEach(t => t.classList.remove('active'));
        type.classList.add('active');
        
        // Here you would update the form based on the selected question type
        updateQuestionForm(type.textContent.trim());
    });
});

// Question list selection
const questionList = document.querySelectorAll('.question-list ul li:not(.add-question)');
questionList.forEach(question => {
    question.addEventListener('click', () => {
        questionList.forEach(q => q.classList.remove('active'));
        question.classList.add('active');
        
        // Here you would load the selected question data
    });
});

// Add new question button
const addQuestionBtn = document.querySelector('.add-question');
if (addQuestionBtn) {
    addQuestionBtn.addEventListener('click', () => {
        const questionCount = document.querySelectorAll('.question-list ul li:not(.add-question)').length;
        
        // Create new question item
        const newQuestion = document.createElement('li');
        newQuestion.textContent = `Question ${questionCount + 1}`;
        
        // Insert before the add button
        addQuestionBtn.parentNode.insertBefore(newQuestion, addQuestionBtn);
        
        // Add click event to new question
        newQuestion.addEventListener('click', () => {
            questionList.forEach(q => q.classList.remove('active'));
            newQuestion.classList.add('active');
        });
        
        // Trigger click on new question
        newQuestion.click();
    });
}

// Add option button functionality
const addOptionBtn = document.querySelector('.add-option');
if (addOptionBtn) {
    addOptionBtn.addEventListener('click', () => {
        const optionList = document.querySelector('.option-list');
        const optionCount = document.querySelectorAll('.option-item').length;
        
        // Create new option item
        const newOption = document.createElement('div');
        newOption.className = 'option-item';
        newOption.innerHTML = `
            <input type="radio" name="correctOption" id="option${optionCount + 1}">
            <label for="option${optionCount + 1}">Mark as correct</label>
            <input type="text" placeholder="Option text">
            <button class="remove-option"><i class="fas fa-trash"></i></button>
        `;
        
        // Insert before the add button
        optionList.insertBefore(newOption, addOptionBtn);
        
        // Add remove functionality to new option
        const removeBtn = newOption.querySelector('.remove-option');
        removeBtn.addEventListener('click', () => {
            newOption.remove();
        });
    });
}

// Remove option functionality
document.querySelectorAll('.remove-option').forEach(btn => {
    btn.addEventListener('click', () => {
        if (document.querySelectorAll('.option-item').length > 1) {
            btn.closest('.option-item').remove();
        } else {
            alert('You must have at least one option.');
        }
    });
});

// Update question form based on question type
function updateQuestionForm(questionType) {
    const questionForm = document.querySelector('.question-form');
    const currentOptions = questionForm.querySelector('.question-type-options');
    
    // Save current question text and points
    const questionText = questionForm.querySelector('#questionTitle').value;
    const questionPoints = questionForm.querySelector('#questionPoints').value;
    
    // Clear form and re-add basic elements
    questionForm.innerHTML = `
        <div class="form-group">
            <label for="questionTitle">Question Text</label>
            <input type="text" id="questionTitle" placeholder="Enter your question" value="${questionText}">
        </div>
    `;
    
    // Add type-specific options
    if (questionType.includes('Multiple Choice')) {
        questionForm.innerHTML += `
            <div class="question-type-options">
                <h4>Options</h4>
                <div class="option-list">
                    <div class="option-item">
                        <input type="radio" name="correctOption" id="option1" checked>
                        <label for="option1">Mark as correct</label>
                        <input type="text" placeholder="Option text" value="Option 1">
                        <button class="remove-option"><i class="fas fa-trash"></i></button>
                    </div>
                    <div class="option-item">
                        <input type="radio" name="correctOption" id="option2">
                        <label for="option2">Mark as correct</label>
                        <input type="text" placeholder="Option text" value="Option 2">
                        <button class="remove-option"><i class="fas fa-trash"></i></button>
                    </div>
                    <button class="add-option"><i class="fas fa-plus"></i> Add Option</button>
                </div>
            </div>
        `;
    } else if (questionType.includes('Fill in the Blank')) {
        questionForm.innerHTML += `
            <div class="question-type-options">
                <h4>Fill in the Blank</h4>
                <p class="mb-2">Use [blank] in your question text to indicate where the blank should appear.</p>
                <div class="form-group">
                    <label for="blankAnswer">Correct Answer</label>
                    <input type="text" id="blankAnswer" placeholder="Enter the correct answer">
                </div>
                <div class="form-group">
                    <label for="caseSensitive">
                        <input type="checkbox" id="caseSensitive"> Case sensitive
                    </label>
                </div>
            </div>
        `;
    } else if (questionType.includes('Coding')) {
        questionForm.innerHTML += `
            <div class="question-type-options">
                <h4>Coding Question</h4>
                <div class="form-group">
                    <label for="programmingLanguage">Programming Language</label>
                    <select id="programmingLanguage">
                        <option value="javascript">JavaScript</option>
                        <option value="python">Python</option>
                        <option value="java">Java</option>
                        <option value="csharp">C#</option>
                        <option value="cpp">C++</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="initialCode">Initial Code (Optional)</label>
                    <textarea id="initialCode" placeholder="// Add initial code here" rows="5"></textarea>
                </div>
                <div class="form-group">
                    <label for="expectedOutput">Expected Output / Test Cases</label>
                    <textarea id="expectedOutput" placeholder="Enter expected output or test cases" rows="3"></textarea>
                </div>
            </div>
        `;
    } else if (questionType.includes('Q&A')) {
        questionForm.innerHTML += `
            <div class="question-type-options">
                <h4>Q&A Question</h4>
                <div class="form-group">
                    <label for="answerType">Answer Type</label>
                    <select id="answerType">
                        <option value="short">Short Answer</option>
                        <option value="paragraph">Paragraph</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="modelAnswer">Model Answer (Optional)</label>
                    <textarea id="modelAnswer" placeholder="Enter a model answer" rows="5"></textarea>
                </div>
                <div class="form-group">
                    <label for="keywordMatching">
                        <input type="checkbox" id="keywordMatching"> Enable keyword matching for auto-grading
                    </label>
                </div>
                <div class="form-group" id="keywordGroup" style="display: none;">
                    <label for="keywords">Keywords (comma separated)</label>
                    <input type="text" id="keywords" placeholder="Enter keywords for matching">
                </div>
            </div>
        `;
        
        // Show/hide keyword field based on checkbox
        document.getElementById('keywordMatching').addEventListener('change', (e) => {
            document.getElementById('keywordGroup').style.display = e.target.checked ? 'block' : 'none';
        });
    }
    
    // Add points and actions to all question types
    questionForm.innerHTML += `
        <div class="form-group">
            <label for="questionPoints">Points</label>
            <input type="number" id="questionPoints" min="1" value="${questionPoints || 10}">
        </div>
        
        <div class="form-actions">
            <button class="secondary-btn">Previous Question</button>
            <button class="secondary-btn">Next Question</button>
            <button class="primary-btn">Save Question</button>
        </div>
    `;
    
    // Reinitialize event listeners for new elements
    initQuestionFormEvents();
}

// Initialize events for dynamically added elements in question form
function initQuestionFormEvents() {
    // Add option button
    const addOptionBtn = document.querySelector('.add-option');
    if (addOptionBtn) {
        addOptionBtn.addEventListener('click', () => {
            const optionList = document.querySelector('.option-list');
            const optionCount = document.querySelectorAll('.option-item').length;
            
            // Create new option
            const newOption = document.createElement('div');
            newOption.className = 'option-item';
            newOption.innerHTML = `
                <input type="radio" name="correctOption" id="option${optionCount + 1}">
                <label for="option${optionCount + 1}">Mark as correct</label>
                <input type="text" placeholder="Option text">
                <button class="remove-option"><i class="fas fa-trash"></i></button>
            `;
            
            // Insert before add button
            optionList.insertBefore(newOption, addOptionBtn);
            
            // Add remove functionality
            const removeBtn = newOption.querySelector('.remove-option');
            removeBtn.addEventListener('click', () => {
                newOption.remove();
            });
        });
    }
    
    // Remove option buttons
    document.querySelectorAll('.remove-option').forEach(btn => {
        btn.addEventListener('click', () => {
            if (document.querySelectorAll('.option-item').length > 1) {
                btn.closest('.option-item').remove();
            } else {
                alert('You must have at least one option.');
            }
        });
    });
}

// Initialize dashboard
function initDashboard() {
    // Sample data for demonstration
    const surveys = [
        { id: 1, title: 'Customer Satisfaction', questions: 10, responses: 124, status: 'active', created: '5 days ago' },
        { id: 2, title: 'Employee Feedback', questions: 15, responses: 87, status: 'active', created: '1 week ago' },
        { id: 3, title: 'Product Feedback', questions: 8, responses: 56, status: 'draft', created: '2 weeks ago' }
    ];
    
    const quizzes = [
        { id: 1, title: 'JavaScript Basics', questions: 12, responses: 45, status: 'active', created: '3 days ago' },
        { id: 2, title: 'Database Concepts', questions: 8, responses: 32, status: 'draft', created: '2 weeks ago' },
        { id: 3, title: 'Web Development Fundamentals', questions: 15, responses: 28, status: 'active', created: '1 month ago' }
    ];

    // Update recent surveys and quizzes if needed
    // (Already included in HTML for demo purposes)
}

// Initialize the dashboard on load
document.addEventListener('DOMContentLoaded', () => {
    // First display the welcome animation
    initWelcomeAnimation();
    
    // Then initialize the dashboard
    initDashboard();
});