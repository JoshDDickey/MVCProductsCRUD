using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ProductsDAO
    {
        //Dependencies
        private string connectionString;

        //Basic Constructor
        public ProductsDAO(string connString)
        {
            connectionString = connString;
        }

        public List<ProductDO> ReadAllProducts()
        {
            //Declaring local variables
            List<ProductDO> productList = new List<ProductDO>();

            try
            {
                //Creating a new connection to the NORTHWND database and a SqlCommand using a stored procedure
                using (SqlConnection northwndConnection = new SqlConnection(connectionString))
                using (SqlCommand readAllCommand = new SqlCommand("READ_PRODUCTS_1", northwndConnection))
                {
                    //Setting command type and opening the database connection
                    readAllCommand.CommandType = CommandType.StoredProcedure;
                    northwndConnection.Open();

                    //Creating an object to read each row of the Products table
                    using (SqlDataReader productReader = readAllCommand.ExecuteReader())
                    {
                        //Reading NORTHWND Products table the end of the table is reached
                        while (productReader.Read())
                        {
                            //Reading table data to current ProductDO
                            ProductDO toProduct = new ProductDO();
                            toProduct.productID = productReader.GetInt32(0);
                            toProduct.productName = productReader.GetString(1);
                            toProduct.quantityPerUnit = productReader.GetString(2);
                            toProduct.unitPrice = productReader.GetDecimal(3);
                            toProduct.unitsInStock = productReader.GetInt16(4);
                            toProduct.unitsOnOrder = productReader.GetInt16(5);
                            productList.Add(toProduct);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return productList;
        }
    }
}
