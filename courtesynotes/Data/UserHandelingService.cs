using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace courtesynotes.Data
{
    public class UserHandelingService
    {
        private DbHandelingService DbHandelingService = new();
        public static async Task<bool> AddUser(string email, string password)
        {
            CollectionReference reference = DbHandelingService.ReferenceUsersCollection();
            QuerySnapshot snapshot = await reference.GetSnapshotAsync();
            List<string> userEmails = new List<string>();
            
            foreach (var user in snapshot.Documents)
            {
                var userValues = user.ToDictionary();
                var userEmail = userValues.GetValueOrDefault("email");
                userEmails.Add(userEmail.ToString());
            }
            if (!userEmails.Contains(email))
            {
                Dictionary<string, string> newUser = new Dictionary<string, string>()
                {
                    {"email", email },
                    {"password", password }
                };
                
                await reference.Document(email).SetAsync(newUser);
                return true;
            }
            return false;
        }
        public static async Task<bool> LoginUser(string email, string password)
        {
            CollectionReference userCollectionReference = DbHandelingService.ReferenceUsersCollection();
            QuerySnapshot snapshot = await userCollectionReference.GetSnapshotAsync();
            List<string> userEmails = new();

            foreach (var user in snapshot.Documents)
            {
                var userValues = user.ToDictionary();
                var userEmail = userValues.GetValueOrDefault("email");

                if (userEmail.ToString() == email)
                {
                    var userPassword = userValues.GetValueOrDefault("password");
                    if (userPassword.ToString() == password)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }
        public static async Task<bool> AddCourse(string email, string courseName)
        {
            CollectionReference usersCollection = DbHandelingService.ReferenceUsersCollection();
            var courses = usersCollection.Document(email).Collection("Courses");
            QuerySnapshot coursesSnapshot = await courses.GetSnapshotAsync();

            var existingCourse = coursesSnapshot.FirstOrDefault(c => c.Id == courseName);
            if (existingCourse != null)
            {
                return false;
            }
            else
            {
                Dictionary<string, object> _course = new()
                {
                    { "name", courseName }
                };

                await courses.Document(courseName).SetAsync(_course);
                return true;
            }
        }
    }
}
