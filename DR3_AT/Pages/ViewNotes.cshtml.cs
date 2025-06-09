// Arquivo: Pages/ViewNotes.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DR3_AT.Pages;

public class ViewNotes : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly string _filesPath;

    public ViewNotes(IWebHostEnvironment environment)
    {
        _environment = environment;
        _filesPath = Path.Combine(_environment.WebRootPath, "files");
        Directory.CreateDirectory(_filesPath);
    }

    [BindProperty]
    [Required(ErrorMessage = "O conteúdo da anotação não pode estar vazio.")]
    public string NoteContent { get; set; }

    public List<string> AvailableFiles { get; set; } = new List<string>();

    public string SelectedFileContent { get; set; }
    public string SelectedFileName { get; set; }

    public void OnGet(string fileName = null)
    {
        LoadAvailableFiles();

        if (!string.IsNullOrEmpty(fileName))
        {
            if (fileName.Contains("..") || fileName.Contains("/") || fileName.Contains("\\"))
            {
                return;
            }
            
            var fullPath = Path.Combine(_filesPath, fileName);

            if (System.IO.File.Exists(fullPath))
            {
                SelectedFileName = fileName;
                SelectedFileContent = System.IO.File.ReadAllText(fullPath);
            }
        }
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            LoadAvailableFiles();
            return Page();
        }

        var fileName = $"nota_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        var fullPath = Path.Combine(_filesPath, fileName);

        System.IO.File.WriteAllText(fullPath, NoteContent);

        TempData["SuccessMessage"] = $"Anotação '{fileName}' salva com sucesso!";

        return RedirectToPage();
    }
    
    private void LoadAvailableFiles()
    {
        AvailableFiles = Directory.GetFiles(_filesPath, "*.txt")
                                  .Select(Path.GetFileName)
                                  .ToList();
    }
}