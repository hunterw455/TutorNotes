using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TutorNotes;

namespace TutorNotesTests
{
    [TestClass]
    public class SignInHandlerTesting
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
            var find3 = signIn.userFound("Carol123");
            var find4 = signIn.userFound("abcdefg");

            Assert.IsTrue(find1);
            Assert.IsTrue(find2);
            Assert.IsFalse(find3);
            Assert.IsFalse(find4);
        }

        // Will intentionally cause some to fail
        [DataTestMethod]
        [DataRow("abc123")] //Should be true for first one
        [DataRow("123abc")] //Should fail
        [DataRow("blahblahblah")] //Should fail
        public void successfulSignInMethod(string password)
        {
            Dictionary<string, User> tutorNotesUsers = new Dictionary<string, User>();
            Educator user1 = new Educator("user1", "abc123", "Jane", "Doe", "Educator");
            Educator user2 = new Educator("user2", "123abc", "John", "Doe", "Educator");
            tutorNotesUsers.Add(user1.Username, user1);


            SignInHandler signIn = new SignInHandler(tutorNotesUsers);

            var find1 = signIn.successfulSignIn(user1.Username, password); 
            
            Assert.IsTrue(find1);
        }
    }
}
