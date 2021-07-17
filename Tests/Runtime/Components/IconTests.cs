using NUnit.Framework;
using ReactUnity.ScriptEngine;
using ReactUnity.UGUI;
using System.Collections;

namespace ReactUnity.Tests
{
    public class IconTests : TestBase
    {
        const string BaseScript = @"
            function App() {
                const globals = ReactUnity.useGlobals();
                return <>
                    <icon>{globals.icon}</icon>
                </>;
            }

            Renderer.render(<GlobalsProvider children={<App />} />);
        ";

        const string BaseStyle = @"
            icon {
            }
        ";

        public IconComponent Icon => Host.QuerySelector("icon") as IconComponent;

        public IconTests(JavascriptEngineType engineType) : base(engineType) { }

        [ReactInjectableTest(BaseScript, BaseStyle)]
        public IEnumerator IconHasCorrectCharacter()
        {
            yield return null;

            Assert.AreEqual(string.Empty, Icon.TextContent);

            Globals["icon"] = "search";
            yield return null;
            Assert.AreEqual("\ue8b6", Icon.TextContent);

            Globals["icon"] = "people_outline";
            yield return null;
            Assert.AreEqual("\ue7fc", Icon.TextContent);
        }
    }
}
