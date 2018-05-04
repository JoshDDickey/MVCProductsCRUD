using DataLayer.Models;
using MVCProductCRUD.Models;
using System.Collections.Generic;

namespace MVCProductCRUD.Mapping
{
    public class ProductMapper
    {
        //Method for mapping a ProductDO to a ProductPO
        public static ProductPO MapDOToPO(ProductDO fromItem)
        {
            //Declaring local variables
            ProductPO toItem = new ProductPO();

            //Transferring property values from passed ProductDO to ProductPO
            toItem.ProductID = fromItem.productID;
            toItem.ProductName = fromItem.productName;
            toItem.QuantityPerUnit = fromItem.quantityPerUnit;
            toItem.UnitPrice = fromItem.unitPrice;
            toItem.UnitsInStock = fromItem.unitsInStock;
            toItem.UnitsOnOrder = fromItem.unitsOnOrder;

            return toItem;
        }

        //Method for mapping a list of ProductDOs to a list of ProductPOs
        public static List<ProductPO> MapDOToPO(List<ProductDO> fromList)
        {
            //Declaring local variables
            List<ProductPO> toList = new List<ProductPO>();

            //Adding a ProductPO object to the toList for each ProductDO object in the fromList
            if(fromList != null)
            {
                foreach( ProductDO item in fromList)
                {
                    ProductPO mappedItem = MapDOToPO(item);
                    toList.Add(mappedItem);
                }
            }
            return toList;
        }

        //Method for mapping a ProductPO to a ProductDO
        public static ProductDO MapPOToDO(ProductPO fromItem)
        {
            //Declaring local variables
            ProductDO toItem = new ProductDO();

            //Transferring property values from passed ProductPO to ProductDO
            toItem.productID = fromItem.ProductID;
            toItem.productName = fromItem.ProductName;
            toItem.quantityPerUnit = fromItem.QuantityPerUnit;
            toItem.unitPrice = fromItem.UnitPrice;
            toItem.unitsInStock = fromItem.UnitsInStock;
            toItem.unitsOnOrder = fromItem.UnitsOnOrder;

            return toItem;
        }

        //Method for mapping a list of ProductPOs to a list of ProductDOs
        public static List<ProductDO> MapPOToDO(List<ProductPO> fromList)
        {
            //Declaring local variables
            List<ProductDO> toList = new List<ProductDO>();

            //Adding a ProductDO object to the toList for each ProductPO object in the fromList
            if (fromList != null)
            {
                foreach (ProductPO item in fromList)
                {
                    ProductDO mappedItem = MapPOToDO(item);
                    toList.Add(mappedItem);
                }
            }
            return toList;
        }
    }
}