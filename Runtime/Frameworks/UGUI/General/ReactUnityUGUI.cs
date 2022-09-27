using System.Collections.Generic;
using ReactUnity.Scheduling;
using ReactUnity.Styling;
using ReactUnity.Styling.Rules;
using UnityEngine;

namespace ReactUnity.UGUI
{
    public class ReactUnityUGUI : ReactUnityBase
    {
        public RectTransform Root => transform as RectTransform;
        public CursorSet CursorSet;
        public IconSet DefaultIconSet;
        public List<IconSet> IconSets;

        protected override void ClearRoot()
        {
            if (!Root) return;
            for (int i = Root.childCount - 1; i >= 0; i--)
                GameObject.DestroyImmediate(Root.GetChild(i).gameObject);
        }

        protected override ReactContext CreateContext(ScriptSource script)
        {
            return new UGUIContext(new UGUIContext.Options
            {
                HostElement = Root,
                Globals = Globals,
                Source = script,
                Timer = timer ?? UnityTimer.Instance,
                MediaProvider = MediaProvider,
                OnRestart = () => Render(),
                IconSets = IconSets,
                DefaultIconSet = DefaultIconSet,
                CursorSet = CursorSet,
                EngineType = EngineType,
                Debug = AdvancedOptions.DebugMode != DebugMode.None,
                AwaitDebugger = AdvancedOptions.DebugMode == DebugMode.DebugAndAwait,
                BeforeStart = AdvancedOptions.BeforeStart.Invoke,
                AfterStart = AdvancedOptions.AfterStart.Invoke,
                Pooling = AdvancedOptions.Pooling,
            });
        }

        protected override IMediaProvider CreateMediaProvider()
        {
            return DefaultMediaProvider.CreateMediaProvider("runtime", "ugui", false);
        }
    }
}
