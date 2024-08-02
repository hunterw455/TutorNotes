using Microsoft.VisualStudio.TestTools.UnitTesting;
using TutorNotes;

namespace TutorNotesTesting
{
    [TestClass]
    public class SignInHandlerTest
    {

        [TestMethod]
        public void findingMethod()
        {
            Dictionary<string, User> tutorNotesUsers = new Dictionary<string, User>();
            Educator user1 = new Educator("user1", "abc123", "Jane", "Doe", "Educator");
            Educator user2 = new Educator("user2", "123abc", "John", "Doe", "Educator");
            tutorNotesUsers.Add(user1.Username, user1);
            tutorNotesUsers.Add(user2.Username, user2);

            SignInHandler signIn = new SignInHandler(tutorNotesUsers);

            var find1 = signIn.userFound(user1.Username);
            var find2 = signIn.userFound(user2.Username);

            Assert.AreEqual(true, find1);
            Assert.IsTrue(find2);

        }
    }
}