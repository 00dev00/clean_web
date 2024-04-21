using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGenericRepository<Product> productsRepository;
    private readonly IGenericRepository<ProductBrand> brandsRepository;
    private readonly IGenericRepository<ProductType> typesRepository;

    public ProductsController(
        IGenericRepository<Product> productsRepository,
        IGenericRepository<ProductBrand> brandsRepository,
        IGenericRepository<ProductType> typesRepository)
    {
        this.productsRepository = productsRepository;
        this.brandsRepository = brandsRepository;
        this.typesRepository = typesRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        // var products = productsRepository.GetAll().ToList();
        var spec = new ProductsWithTypesAndBrandsSpecification();
        var products = await productsRepository.GetAllWithSpec(spec);
        return Ok(products.Count == 0 ? [] : products);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await productsRepository.Get(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet]
    [Route("brands")]
    public ActionResult<List<ProductBrand>> GetBrands()
    {
        var brands = brandsRepository.GetAll().ToList();
        return Ok(brands.Count == 0 ? [] : brands);
    }

    [HttpGet]
    [Route("types")]
    public ActionResult<List<ProductType>> GetTypes()
    {
        var types = typesRepository.GetAll().ToList();
        return Ok(types.Count == 0 ? [] : types);
    }
}
