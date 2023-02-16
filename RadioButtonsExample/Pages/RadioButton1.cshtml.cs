using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RadioButtonsExample.Models;
using System.Reflection;
using RadioButtonsExample.Classes;

namespace RadioButtonsExample.Pages
{
    public class RadioButton1Model : PageModel
    {
     
        public List<Shape?> Shapes { get; set; } = Operations.Shapes;
        [BindProperty]
        public Shape? Shape { get; set; }


        public void OnGet()
        {
            Shape = Shapes[1];
        }
        public async Task<IActionResult> OnPost()
        {
            await Task.Delay(0);

            var selection = Shape;
            return Page();
        }
    }
}
