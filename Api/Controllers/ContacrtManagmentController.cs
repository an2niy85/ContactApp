using Microsoft.AspNetCore.Mvc;

public class ContacrtManagmentController : BaseController
{
    private readonly ContactStorage storage;

    public ContacrtManagmentController(ContactStorage storage)
    {
        this.storage = storage;
    }

    [HttpPost("contacts")]
    public IActionResult Create([FromBody] Contact contact)
    {
        bool res = storage.Add(contact);
        if (res)
        {
            return Create(contact);
        }
        return Conflict("Контакт с указанным ID существует");
    }

    [HttpGet("contacts")]
    public ActionResult<List<Contact>> GetContacts()
    {
        return Ok(storage.GetContacts());
    }

    [HttpGet("contacts/{id}")]
    public IActionResult GetContactById(int id)
    {
        int maxId = storage.GetContactMaxId();
        if (id < 0 || id >= maxId) return BadRequest($"Неверный id. Он должен быть положительным и меньше {maxId}");
        Contact findContact = storage.GetContactById(id);
        if (findContact == null)
            return NotFound($"Контакт с {id} не найден");
        return Ok(findContact);
    }

    [HttpDelete("contacts/{id}")]
    public IActionResult DeleteContact(int id)
    {
        bool res = storage.Remove(id);
        if (res) return NoContent();
        return BadRequest("Ошибка Id");
    }

    [HttpPut("contacts/{id}")]
    public IActionResult UpdateContact([FromBody] ContactDto contactDto, int id)
    {
        bool res = storage.UpdateContact(contactDto, id);
        if (res) Ok();
        return Conflict("Контакта с указанным ID не существует");
    }
}