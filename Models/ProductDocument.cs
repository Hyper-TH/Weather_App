using Google.Cloud.Firestore;

namespace React_ASPNETCore.Models
{
    [FirestoreData]
    public class ProductDocument
    {
        [FirestoreDocumentId]
        public int ID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]

        public decimal Price { get; set; }
    }
}
