using ReactUnity.Editor.Renderer;
using ReactUnity.Helpers;
using ReactUnity.ScriptEngine;
using ReactUnity.StyleEngine;
using ReactUnity.Timers;
using ReactUnity.UIToolkit;

namespace ReactUnity.Editor.UIToolkit
{
    public class ReactUnityEditorElement : ReactUnityElement
    {
        public ReactUnityEditorElement(ScriptSource script, GlobalRecord globals, ITimer timer, IMediaProvider mediaProvider, JavascriptEngineType engineType = JavascriptEngineType.Auto, bool debug = false, bool awaitDebugger = false, bool autorun = true)
            : base(script, globals, timer, mediaProvider, engineType, debug, awaitDebugger, autorun)
        {
        }

        protected override ReactContext CreateContext(ScriptSource script, bool isDevServer)
        {
            return new EditorContext(this, Globals, script, dispatcher, scheduler, Timer ?? EditorTimer.Instance, MediaProvider, isDevServer, Restart);
        }
    }
}
