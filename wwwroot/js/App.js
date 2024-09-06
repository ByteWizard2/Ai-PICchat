
document.addEventListener("DOMContentLoaded", function () {
    
    var PromptInput = document.getElementById("PromptInput");


    PromptInput.addEventListener("keydown", function (event) {
    
        if (event.key === "Enter") {

            event.preventDefault();
           
            PromptAI();
        }
    });
});

function PromptAI() {
    var PromptInput = document.getElementById("PromptInput");
    var ChatList = document.getElementById("ChatList");

   
    ChatList.innerHTML += '<li class="max-w-4xl py-2 px-4 sm:px-6 lg:px-8 mx-auto flex gap-x-2 sm:gap-x-4">' +
        '<svg class="shrink-0 size-[38px] rounded-full" width="38" height="38" viewBox="0 0 38 38" fill="none" xmlns="http://www.w3.org/2000/svg">' +
        '<rect width="38" height="38" rx="6" fill="#2563EB"/>' +
        '<ellipse cx="19" cy="18.6554" rx="3.75" ry="3.6" fill="white"/>' +
        '</svg>' +
        '<div class="space-y-3">' +
        '<h2>' + PromptInput.value + '</h2>' +
        '</div>' +
        '</li>';

   
    $.ajax({
        type: "POST",
        url: "/prompt",
        data: { prompttext: PromptInput.value },
        dataType: "html",
        success: function (response) {
            
            ChatList.innerHTML += response;
        },
        error: function (xhr, status, error) {
            console.error("Error: ", error);
        }
    });

    
    PromptInput.value = '';
}
