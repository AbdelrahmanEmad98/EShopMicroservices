using Marten.Schema;

namespace Catalog.API.Data;

public class CatelogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfigureProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfigureProducts() => new List<Product>()
    {
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone X",
            Description = "This Iphone x description",
            ImageFile = "Iphone x.png",
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone 11",
            Description = "This Iphone 11 description",
            ImageFile = "Iphone 11.png",
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone 12",
            Description = "This Iphone 12 description",
            ImageFile = "Iphone 12.png",
            Category = new List<string>{"Smart Phone"}
        },
        new Product()
        {
            Id = Guid.NewGuid(),
            Name = "IPhone 13",
            Description = "This Iphone 13 description",
            ImageFile = "Iphone 13.png",
            Category = new List<string>{"Smart Phone"}
        },
    };
}
