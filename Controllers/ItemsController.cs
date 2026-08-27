namespace e_commerce_project.Controllers
{
    using e_commerce_project.Models;
    using e_commerce_project.Models.DTO;
    using e_commerce_project.Services;
    using Microsoft.AspNetCore.Mvc;    // microsoft virutual controller
    [ApiController] //
    [Route("[controller]")]   //set the URL path for the controller, so that it can be accessed via HTTP requests
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemsController(IItemService itemService) 
        {
            _itemService = itemService;
        }

        [HttpGet]

        public IActionResult GetAll()   // IActionResult is a return type that represents the result of an action method in an ASP.NET Core controller. It allows you to return different types of responses, such as JSON, HTML, or status codes (Ok,BadRequest,NotFound)
        {
            var item = _itemService.GetAll();
            var response = item.Select(i => new ItemDto
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Stock = i.Stock
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
            {
                return NotFound ($"Item with id {id} not found.");
            }
            var response = new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Stock = item.Stock
            };
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateItemDto newitemDTO)
        {
            var newItem = new Items
            {
                Name = newitemDTO.Name,
                Price = newitemDTO.Price,
                Stock = newitemDTO.Stock,
                SupplierId = newitemDTO.SupplierId
            };
            var createdItem = _itemService.Add(newItem);
            return Ok(createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id , [FromBody] UpdateItemDto updateitem)
        {
           var updatedItem = new Items
            {
                Name = updateitem.Name,
                Price = updateitem.Price,
                Stock = updateitem.Stock,
                SupplierId = updateitem.SupplierId
            };
            var success = _itemService.Update(id, updatedItem);
            if (!success)
            {
                return NotFound($"Item with id {id} not found ");
            }
            return Ok($"Item {id} is updated successfully {updateitem}.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _itemService.Delete(id);
            if(!success)
            {
                return NotFound ($"Item with id {id} not found ");
            }
          return Ok($"Item {id} deleted successfully.");
        }
    }
}
