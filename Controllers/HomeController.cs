using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace AiChatBot.Controllers;

public class HomeController : Controller
{
   

    public HomeController()
    {
       
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("/prompt")]
    [HttpPost]
    public async Task<IActionResult> Prompt(  promptObj obj )
    {
       var response = await  PromptService.GetImage(obj.prompttext);



        return PartialView("MessageResponse" ,response);
    }
}

public class promptObj
{
    public string? prompttext { get; set; }
}