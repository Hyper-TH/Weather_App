using Google.Cloud.Firestore;

namespace React_ASPNETCore.Models
{
    [FirestoreData]
    public class ProductDocument
    {

        [FirestoreProperty]     // Manual 
        public int ProductID { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]

        public double Price { get; set; }
    }
}
