using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> productsRepository;
    private readonly IGenericRepository<ProductRating> ratingsRepository;
    private readonly IGenericRepository<ProductCategory> categoriesRepository;
    private readonly IMapper mapper;

    public ProductsController(
        IGenericRepository<Product> productsRepository,
        IGenericRepository<ProductRating> ratingsRepository,
        IGenericRepository<ProductCategory> categoriesRepository,
        IMapper mapper)
    {
        this.productsRepository = productsRepository;
        this.ratingsRepository = ratingsRepository;
        this.categoriesRepository = categoriesRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var spec = new ProductWithCategoryAndRatingSpecification();
        var products = await productsRepository.GetAllWithSpec(spec);
        var res = mapper.Map<List<Product>, List<ProductDTO>>([.. products]);
        return Ok(res);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Product>> Get(int id)
    {
        var spec = new ProductWithCategoryAndRatingSpecification(id);
        var product = await productsRepository.GetEntityWithSpec(spec);

        if (product == null)
        {
            return NotFound();
        }

        var res = mapper.Map<Product, ProductDTO>(product);

        return Ok(res);
    }

    [HttpGet]
    [Route("ratings")]
    public ActionResult<List<ProductRating>> GetRatings()
    {
        var ratings = ratingsRepository.GetAll().ToList();
        return Ok(ratings.Count == 0 ? [] : ratings);
    }

    [HttpGet]
    [Route("categories")]
    public ActionResult<List<ProductCategory>> GetCategories()
    {
        var categories = categoriesRepository.GetAll().ToList();
        return Ok(categories.Count == 0 ? [] : categories);
    }
}
