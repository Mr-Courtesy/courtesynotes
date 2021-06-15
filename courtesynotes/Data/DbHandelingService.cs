using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace courtesynotes.Data
{
    public class DbHandelingService
    {
        public static FirestoreDb CreateDb(string id)
        {
            FirestoreDb db = FirestoreDb.Create(id);

            return db;
        }

        public static DocumentReference ReferenceDocument(string projectId, string collection, string documentName)
        {
            var db = CreateDb(projectId);
            DocumentReference reference = db.Collection(collection).Document(documentName);

            return reference;
        }
        public static CollectionReference ReferenceUsersCollection()
        {
            CollectionReference reference = CreateDb("courtesy-notes").Collection("users");
            return reference;
        }
    }
}
