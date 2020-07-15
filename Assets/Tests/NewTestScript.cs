using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Managers;
namespace Tests
{
    public class testingScript{
        private string username;
        private string password;
    
        // A Test behaves as an ordinary method
        [Test]
        public void testingScriptSimplePasses()
        {
             string response = Manager.Instance.Login(username,password);
             Assert.AreEqual(response,"User logged");
            // Use the Assert class to test conditions
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
