using System;

namespace DependencyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProdcutDal());
            productManager.Save();
            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProdcutDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save  With EF");
        }
    }

    class NhProdcutDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Save  With NH");
        }
    }

    class ProductManager
    {
        private readonly IProductDal productDal;
        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }
        // Business Code
        public void Save()
        {
            // ProdcutDal prodcutDal = new ProdcutDal(); Eski yapı bunun yerine yukarda consructor ın içinde hangi nesne ile 
            // çalışacaksa orda set ettik.
            productDal.Save();
        }
    }

}

