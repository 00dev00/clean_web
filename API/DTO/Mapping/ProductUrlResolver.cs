using AutoMapper;
using Core.Entities;

namespace API.DTO.Mapping;

public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
{
    public ProductUrlResolver(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            var baseUri = new Uri(Configuration["ApiUrl"]);
            return new Uri(baseUri, relativeUri: source.PictureUrl).ToString();
        }

        return source.PictureUrl;
    }

}
