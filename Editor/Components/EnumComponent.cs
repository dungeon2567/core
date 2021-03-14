using ReactUnity.Editor.Renderer;
using ReactUnity.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace ReactUnity.Editor.Components
{
    public class EnumComponent<T> : BaseFieldComponent<T, Enum> where T : BaseField<Enum>, new()
    {
        Type type;
        object storedValue;

        public EnumComponent(EditorContext context, string tag) : base(context, tag)
        { }

        public override void SetProperty(string property, object value)
        {
            if (property == "type")
            {
                if (value is string s) type = ReflectionHelpers.FindType(s);
                else type = value as Type;

                if (type != null)
                {
                    if (storedValue != null) SetValue(storedValue, true);
                    else
                    {
                        var underlying = type.GetEnumUnderlyingType();
                        if (underlying.IsValueType) SetValue(Activator.CreateInstance(underlying), true);
                    }
                }
            }
            else if (property == "value")
            {
                if (type == null) storedValue = value;
                else SetValue(value);
            }

            else base.SetProperty(property, value);
        }

        void SetValue(object val, bool initialize = false)
        {
            var en = (Enum)Enum.ToObject(type, Convert.ChangeType(val, type.GetEnumUnderlyingType()));

            if (initialize)
            {
                if (Element is EnumField e) e.Init(en);
                else if (Element is EnumFlagsField f) f.Init(en);
            }

            Element.SetValueWithoutNotify(en);
            storedValue = null;
        }
    }
}