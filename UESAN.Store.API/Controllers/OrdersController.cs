﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.Store.CORE.DTOs;
using UESAN.Store.CORE.Interfaces;

namespace UESAN.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("OrderByUser/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var orders = await _ordersService.GetAllByUser(userId);
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(OrdersInsertDTO ordersInsertDTO)
        {
            var result = await _ordersService.Insert(ordersInsertDTO);
            return Ok(result);
        }
    }
}
