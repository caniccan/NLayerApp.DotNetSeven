﻿using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryWithDTOController : CustomBaseController
    {
        private readonly IServiceWithDTO<Category, CategoryDTO> _categoryServiceWithDTO;

        public CategoryWithDTOController(IServiceWithDTO<Category, CategoryDTO> service)
        {
            _categoryServiceWithDTO = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return CreateActionResult(await _categoryServiceWithDTO.GetAllAsync());
        }


        [HttpPost]
        public async Task<IActionResult> Get(CategoryDTO category)
        {
            return CreateActionResult(await _categoryServiceWithDTO.AddAsync(category));
        }

    }
}
