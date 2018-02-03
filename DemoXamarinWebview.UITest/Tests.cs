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
            //app.Repl();

            //Arraning
            string inputId = "#lst-ib";
            string inputText = "xamarin";
            string buttonId = "#tsbb";
            Func<AppQuery, AppQuery> webView = e => e.Marked("myWebview");

            //Action
            app.WaitForElement(webView, "Time out");
            app.Tap(c => c.WebView(0).Css(inputId));
            app.EnterText(inputText);
            app.Tap(c => c.WebView(0).Css(buttonId));
            app.WaitForElement(c => c.WebView(0).Css(inputId), "Time out");

            //Asserting
            var assert = app.Query(w => w.WebView().InvokeJS("return document.getElementById('lst-ib').value"))[0];
            Assert.AreEqual(inputText, assert);
        }
    }
}

