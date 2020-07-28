using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Managers;
using System.Linq;
namespace Tests
{
    public class testingScript{
        private string username = "TestingUser";
        private string password="TestingUser";
        private string name="name";
        private string surname="surname";
        private string email="email";
        private string instrument = "trumpet";
        private  static System.Random random = new System.Random();


    
        // A Test behaves as an ordinary method
        [Test]
        public void testingScriptSimplePasses(){
             string response = Manager.Instance.Login(username,password);
             Assert.AreEqual(response,"User logged");
            // Use the Assert class to test conditions
        }
        [Test]
                public void testingRegisterAlreadyRegistered(){
             string response = Manager.Instance.Register(username,password,name,surname,email);
             Assert.AreEqual(response,"Username is already taken.");
            // Use the Assert class to test conditions
        }

                [Test]
                public void testingRegisterOK(){
                    System.Random rnd = new System.Random();
                    double test  = rnd.Next(1, 100000);
             string response = Manager.Instance.Register(username+test,password,name,surname,email);
             Assert.AreEqual(response,"New player created successfully");
        }

        [Test]
        public void testingLoginNotRegistered(){
            System.Random rnd = new System.Random();
            double test  = rnd.Next(1, 100000);
             string response = Manager.Instance.Login(username+"a",password);
             Assert.AreEqual(response,"User not registered");
        }

        [Test]
        public void testingLoginWrongCredentials(){
            System.Random rnd = new System.Random();
            double test  = rnd.Next(1, 100000);
             string response = Manager.Instance.Login(username,password+"a");
             Assert.AreEqual(response,"Wrong credential");
        }


        [Test]
        public void testingCreateProfile(){
            string response = Manager.Instance.createProfile(username,instrument);
             Assert.AreEqual(response,"Profile already created.");
        }



        [Test]
        public void testingCreateProfileOK(){
            string response = Manager.Instance.createProfile(username,RandomString(8));
             Assert.AreEqual(response,"Profile already created.");
        }


       [Test]
        public void createRoutineExercise(){
            string response = Manager.Instance.createRoutineExercise(1,null);
             Assert.AreEqual(response,"error");
        }


       [Test]
        public void getInstrumentsPlayer(){
            List<string> response = Manager.Instance.getInstrumentsPlayer();
             Assert.AreEqual(response,"error");
        }







    private static string RandomString(int length){
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
    }




        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator testingScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
