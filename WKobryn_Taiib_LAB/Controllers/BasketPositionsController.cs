using BLL;
using BLL_EF;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketPositionsController : ControllerBase
    {
        private WebshopContext context;
        private BasketPositionService service;

        public BasketPositionsController(WebshopContext context, BasketPositionService service)
        {
            this.context = context;
            this.service = service;
        }

        [HttpPost]
        public bool PostBasketPosition([FromBody] BasketPositionRequestDTO basketPositionRequest)
        {
            return service.AddBasketPosition(basketPositionRequest);
        }

        [HttpDelete("{basketPositionId}")]
        public bool DeleteBasketPosition(int basketPositionId)
        {
            return service.DeleteBasketPosition(basketPositionId);
        }

        [HttpPut("{basketPositionId}")]
        public bool PutBasketPositionAmount(int basketPositionId, [FromBody] int amount)
        {
            return service.ChangeBasketPositionAmount(basketPositionId, amount);
        }

        [HttpGet("{userId}")]
        public IEnumerable<BasketPositionResponseDTO> GetUserBasketPositions(int userId)
        {
            return service.GetUserBasketPositions(userId);
        }
    }
}
