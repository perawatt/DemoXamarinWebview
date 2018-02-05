using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DemoXamarinWebview.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            // app.Repl();

            //Arraning
            string buttonId = "couponbutton";
            string couponId = "qrcodecoupon"; 

            //Action
            app.WaitForElement(c => c.WebView().Css($"#{buttonId}"), "Timed out waiting for button");
            app.Screenshot("First page");
            app.Tap(c => c.WebView(0).Css($"#{buttonId}"));
            app.WaitForElement(c => c.WebView().Css($"#{couponId}"), "Timed out waiting for coupon");
            app.Screenshot("Second page");
            
            //Asserting
            var assert = app.Query(w => w.WebView().InvokeJS("return document.getElementById('qrcodecoupon').id"))[0];
            Assert.AreEqual(couponId, assert);
            
        }
    }
}

