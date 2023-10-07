using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Interfaces;
using UESAN.Store.CORE.Services;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _paymentService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _paymentService.GetById(id);
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(PaymentInsertDTO payment)
        {
            var result = await _paymentService.Insert(payment);
            if (!result)
                return BadRequest("Ocurrió un error");

            return Ok(result);
        }
       

    }
}
