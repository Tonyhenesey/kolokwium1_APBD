using Kolokwium.Properties.DTOs;
using Kolokwium.Properties.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Properties.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase {
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService) {
        _bookService = bookService;
    }

    [HttpPost(" api/books")]
    public async Task<IActionResult> AddBook([FromBody] BookDto bookDto) {
        if (bookDto == null || string.IsNullOrWhiteSpace(bookDto.Title) || !bookDto.Authors.Any()) {
            return BadRequest("Wprowadzono błedne dane");
        }

        var createdBookId = await _bookService.CreateBookAsync(bookDto);

        var bookWithAuthors = await _bookService.GetBookWithAuthorsAsync(createdBookId);

        return CreatedAtAction(
            nameof(GetBookWithAuthors), 
            new { id = createdBookId }, 
            bookWithAuthors
        );
    }

    [HttpGet("{id}/authors")]
    public async Task<IActionResult> GetBookWithAuthors(int id) {
        var bookDto = await _bookService.GetBookWithAuthorsAsync(id);
        if (bookDto == null) {
            return NotFound();
        }
        return Ok(bookDto);
    }
}
