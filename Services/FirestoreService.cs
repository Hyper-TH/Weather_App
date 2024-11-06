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
        private const string CollectionName = "Products";

        public FirestoreService(string projectId)
        {
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task AddProductAsync(ProductDocument product)
        {
            DocumentReference docRef = _firestoreDb.Collection(CollectionName).Document();
            product.ID = docRef.Id.GetHashCode();

            await docRef.SetAsync(product);
        }

        public async Task<ProductDocument> GetProductAsync(string productId)
        {
            DocumentReference docRef = _firestoreDb.Collection(CollectionName).Document(productId);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot != null)
            {
                return snapshot.ConvertTo<ProductDocument>();
            }

            return null;

        }

        public async Task<List<ProductDocument>> GetAllProductsAsync()
        {
            Query query = _firestoreDb.Collection(CollectionName);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            List<ProductDocument> products = new List<ProductDocument>();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                products.Add(doc.ConvertTo<ProductDocument>());
            }

            return products;
        }

        public async Task UpdateProductAsync(string productId, ProductDocument updatedProduct)
        {
            DocumentReference docRef = _firestoreDb.Collection(CollectionName).Document(productId);

            await docRef.SetAsync(updatedProduct, SetOptions.Overwrite);
        }

        public async Task DeleteProductAsync(string productId)
        {
            DocumentReference docRef = _firestoreDb.Collection(CollectionName).Document(productId);

            await docRef.DeleteAsync();
        }
    }
}
