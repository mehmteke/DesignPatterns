﻿using Ninject;
using System;

namespace DependencyInjection
{
    class Program
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<EfProdcutDal>().InSingletonScope(); 

            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());
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

