// NOTE: The comment sections inside the index.html file is an example of how suppose to be structured the current elements.
//       - You can use them as an example when you create those elements, to check how they will be displayed, just uncomment them.
//       - Also keep in mind that, the actual skeleton in judge does not have this comment sections. So do not be dependent on them!
//       - Тhey are present in the skeleton just to help you!


// This function will be invoked when the html is loaded. Check the console in the browser or index.html file.

// To check out your solution, just submit mySolution() function in judge system.

function mySolution() {
    
    var pendingQuestions = [];

    var sendButton = document.querySelector("#inputSection > div > button");
    var textArea = document.querySelector("#inputSection > textarea");
    var nameInput = document.querySelector("#inputSection > div > input");

    var pendingParent = document.getElementById("pendingQuestions");
    var openParent = document.getElementById("openQuestions");

    sendButton.addEventListener("click", function () {
        var textAreaValue = textArea.value;
        var userName = nameInput.value;

        if (textAreaValue == "") { //??
            return;
        }

        if (userName == "") {
            userName = "Anonymous";
        }
        
        var pendingQuestionDiv = document.createElement("div"); 
        pendingQuestionDiv.className = "pendingQuestion";

        var img = document.createElement("img");
        img.src = "./images/user.png";
        img.width = "32"
        img.height = "32";

        var span = document.createElement("span");
        span.textContent = userName;

        var p = document.createElement("p"); 
        p.textContent = textAreaValue; 

        var actionsDiv = document.createElement("div")
        actionsDiv.className = "actions"; 

        var archiveButton = document.createElement("button");
        archiveButton.className = "archive";
        archiveButton.textContent = "Archive"; 

        var currentQuestion = { name: userName, question: textAreaValue, domElement: pendingQuestionDiv};

        archiveButton.addEventListener("click", function (params) {
            this.remove();
        }.bind(pendingQuestionDiv));

        var openButton = document.createElement("button");
        openButton.className = "open";
        openButton.textContent = "Open"; 

        openButton.addEventListener("click", makeOpenQuestion.bind(currentQuestion))

        actionsDiv.appendChild(archiveButton);
        actionsDiv.appendChild(openButton);

        pendingQuestionDiv.appendChild(img);
        pendingQuestionDiv.appendChild(span);
        pendingQuestionDiv.appendChild(p);
        pendingQuestionDiv.appendChild(actionsDiv);

        pendingParent.appendChild(pendingQuestionDiv);
    });

    function makeOpenQuestion(){
        var name = this.name;
        var question = this.question;
        var domElement = this.domElement;
        
        domElement.remove(); 

        var openQuestionDiv = document.createElement("div"); //X 
        openQuestionDiv.className = "openQuestion"; //X

        var img = document.createElement("img");//
        img.src = "./images/user.png";//
        img.width = "32"//
        img.height = "32";//

        var span = document.createElement("span"); //
        span.textContent = name; //

        var p = document.createElement("p"); //
        p.textContent = question; //

        var actionsDiv = document.createElement("div") // 
        actionsDiv.className = "actions"; // 

        ///reply section
        replySectionDiv = document.createElement("div");
        replySectionDiv.className = "replySection"; 
        replySectionDiv.style.display = "none"; 

        var replyButton = document.createElement("button");
        replyButton.className = "reply"; 
        replyButton.textContent = "Reply";
        replyButton.addEventListener("click", replyHandler.bind({btn: replyButton, replySection: replySectionDiv}));

        var input = document.createElement("input");
        input.className = "replyInput"; 
        input.type = "text"
        input.placeholder = "Reply to this question here..."; 

        var sendButton = document.createElement("button");
        sendButton.className = "replyButton"; 
        sendButton.textContent = "Send";

        var ol = document.createElement("ol");
        ol.className = "reply";
        ol.type = "1";

        sendButton.addEventListener("click", function () {
            var input = this.input; 
            var ol = this.ol; 

            var li = document.createElement("li");
            li.textContent = input.value; 
            ol.appendChild(li);
        }.bind({input: input, ol: ol }));

        replySectionDiv.appendChild(input);
        replySectionDiv.appendChild(sendButton);
        replySectionDiv.appendChild(ol);
        
        actionsDiv.appendChild(replyButton);

        openQuestionDiv.appendChild(img);
        openQuestionDiv.appendChild(span);
        openQuestionDiv.appendChild(p);
        openQuestionDiv.appendChild(actionsDiv);
        openQuestionDiv.appendChild(replySectionDiv);

        openParent.appendChild(openQuestionDiv);
    }

    function replyHandler() {
        var btn = this.btn;
        var replySection = this.replySection;

        if (btn.textContent === "Reply") {
            btn.textContent = "Back"; 
            replySection.style.display = "block"
        } else {
            btn.textContent = "Reply"
            replySection.style.display = "none"
        }
    }
}