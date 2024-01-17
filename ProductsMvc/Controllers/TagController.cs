using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using ProductsMvc.Data;
using ProductsMvc.Models;
using ProductsMvc.Models.ViewModels;
using ProductsMvc.Repositories.Abstractions;

namespace ProductsMvc.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagsRepository _tagsRepository;

        public TagController(ITagsRepository tagRepo)
        {
            _tagsRepository = Guard.Against.Null(tagRepo);
        }

        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> AddTag(TagViewModel tag)
        {
            if (ModelState.IsValid)
            {
                await _tagsRepository.AddTagAsync(tag);
                return RedirectToAction("AddTag");
            }
            return View(tag);
        }
    }
}
