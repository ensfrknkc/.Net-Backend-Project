using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //interface metotları default public tir fakat classlar değil
    public interface IProductDal:IEntityRepository<Product>
    {
        
    }
}

//Code Refactoring
