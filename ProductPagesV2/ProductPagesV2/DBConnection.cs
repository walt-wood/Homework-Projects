using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductPagesV2
{    
    public static class DBConnection
    {
        private static String ConnectionString
        {
            get
            {
                var connBUilder = new SqlConnectionStringBuilder
                {
                    DataSource = "csc.henderson.edu",
                    InitialCatalog = "AdventureWorks2012",        // Relative to assignment
                    UserID = "wood",
                    Password = "05311567H$u"
                };

                return connBUilder.ToString();
            }

        }

        public static DataTable GetAllSQLData()
        {
            var data = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // Create SQL Query
                var query = @"SELECT Product.Name, ProductCategory.Name, Product.ListPrice, ProductDescription.Description, ProductPhoto.LargePhoto
                            FROM Production.Product
                            INNER JOIN Production.ProductSubcategory ON Product.ProductSubCategoryID = ProductSubcategory.ProductSubcategoryID
                            INNER JOIN Production.ProductCategory ON ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID
                            INNER JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID
                            INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID
                            INNER JOIN Production.ProductModelProductDescriptionCulture ON Product.ProductModelID = ProDuctModelProductDescriptionCulture.ProductModelID
                            INNER JOIN Production.ProductDescription ON ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID
                            WHERE ProductModelProductDescriptionCulture.CultureID = 'en'";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    try
                    {
                        conn.Open();
                        adapter.Fill(data);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return data;
        }

        public static DataTable GetCatSpecificSQLData(String catName)
        {
            var data = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // Create SQL Query
                var query = String.Format(@"SELECT Product.Name AS ProductName, ProductCategory.Name AS CategoryName, FORMAT(Product.ListPrice, 'c') AS ListPrice, ProductDescription.Description, ProductPhoto.LargePhoto
                            FROM Production.Product
                            INNER JOIN Production.ProductSubcategory ON Product.ProductSubCategoryID = ProductSubcategory.ProductSubcategoryID
                            INNER JOIN Production.ProductCategory ON ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID
                            INNER JOIN Production.ProductProductPhoto ON Product.ProductID = ProductProductPhoto.ProductID
                            INNER JOIN Production.ProductPhoto ON ProductProductPhoto.ProductPhotoID = ProductPhoto.ProductPhotoID
                            INNER JOIN Production.ProductModelProductDescriptionCulture ON Product.ProductModelID = ProDuctModelProductDescriptionCulture.ProductModelID
                            INNER JOIN Production.ProductDescription ON ProductModelProductDescriptionCulture.ProductDescriptionID = ProductDescription.ProductDescriptionID
                            WHERE ProductCategory.Name = '{0}' AND ProductModelProductDescriptionCulture.CultureID = 'en'", catName);

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    try
                    {
                        conn.Open();
                        adapter.Fill(data);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return data;
        }

        public static DataTable GetProductCategoriesSQLData()
        {
            var data = new DataTable();

            using (var conn = new SqlConnection(ConnectionString))
            {
                // Create SQL Query
                var query = @"SELECT * FROM Production.ProductCategory";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    try
                    {
                        conn.Open();
                        adapter.Fill(data);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            return data;
        }
        
    }
}
