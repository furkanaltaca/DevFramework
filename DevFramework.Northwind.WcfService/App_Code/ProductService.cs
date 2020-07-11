using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductService
/// </summary>
public class ProductService : IProductService
{
    private IProductService _productService = InstanceFactory.GetInstance<IProductService>();

    public ProductService()
    {

    }

    public Product Add(Product product)
    {
        return _productService.Add(product);
    }

    public Product Delete(Product product)
    {
        return _productService.Delete(product);
    }

    public List<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public Product Update(Product product)
    {
        return _productService.Update(product);
    }

    public void TransactionalOperation(Product product1, Product product2)
    {
        _productService.Add(product1);
        _productService.Update(product2);
    }
}