using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using React_ASPNETCore.Models;

namespace React_ASPNETCore.Services
{
    public class FirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string ProductsCollection = "Products";
        private const string KeysCollection = "Keys";

        public FirestoreService(string projectId)
        {
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        // Helper method to get FirestoreID using productID
        private async Task<string> GetFireStoreID(int productID)
        {
            DocumentReference keyDocRef = _firestoreDb.Collection(KeysCollection).Document(productID.ToString());
            DocumentSnapshot keySnapshot = await keyDocRef.GetSnapshotAsync();

            if (keySnapshot.Exists && keySnapshot.ContainsField("DocID"))
            {
                return keySnapshot.GetValue<string>("DocID");

            }

            return null;
        }

        public async Task<ProductDocument> GetProductAsync(int productID)
        {
            // Find FirestoreID using ProductID from Keys Collection
            var firestoreID = await GetFireStoreID(productID);

            if (firestoreID == null)
            {
                return null;
            }

            // Use the FirestoreID to retrieve the product document from the Products collection
            DocumentReference productDocRef = _firestoreDb.Collection(ProductsCollection).Document(firestoreID);
            DocumentSnapshot productSnapshot = await productDocRef.GetSnapshotAsync();

            if (productSnapshot.Exists)
            {
                return productSnapshot.ConvertTo<ProductDocument>();
            }

            return null;
        }

        public async Task<List<ProductDocument>> GetAllProductsAsync()
        {
            Query query = _firestoreDb.Collection(ProductsCollection);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            List<ProductDocument> products = new List<ProductDocument>();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                products.Add(doc.ConvertTo<ProductDocument>());
            }

            return products;
        }

        public async Task AddProductAsync(ProductDocument product)
        {
            // Check if ProductID already exists
            DocumentReference keyDocRef = _firestoreDb.Collection(KeysCollection).Document(product.ProductID.ToString());
            DocumentSnapshot keySnapshot = await keyDocRef.GetSnapshotAsync();

            if (keySnapshot.Exists)
            {
                throw new InvalidOperationException($"Product with ProductID {product.ProductID} already exists.");
            }

            // Add the product to the Products collection
            DocumentReference productDocRef = _firestoreDb.Collection(ProductsCollection).Document();
            await productDocRef.SetAsync(product);

            // Get the Firestore-generated ID 
            var firestoreID = productDocRef.Id;
            var keyEntry = new { DocID = firestoreID };

            await keyDocRef.SetAsync(keyEntry);
        }

        //public async Task UpdateProductAsync(int productID, ProductDocument updatedProduct)
        //{
        //    DocumentReference docRef = _firestoreDb.Collection(ProductsCollection).Document(productID);

        //    await docRef.SetAsync(updatedProduct, SetOptions.Overwrite);
        //}

        //public async Task DeleteProductAsync(int productID)
        //{
        //    DocumentReference docRef = _firestoreDb.Collection(ProductsCollection).Document(productID);

        //    await docRef.DeleteAsync();
        //}
    }
}
