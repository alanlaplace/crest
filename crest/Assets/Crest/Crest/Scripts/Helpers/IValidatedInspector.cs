﻿
namespace Crest
{
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    using System;

    // This class is part of function proposal
    public static class ValidatedHelper
    {
        // This won't work cos we want to combine strings for help box but not for debug log. So we would have to have a 
        // collector which is the same as the advanced proposal anyway.
        public delegate void ShowMessage(string message, MessageType type);

        public static void DebugLog(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Warning: Debug.LogWarning(message); break;
                case MessageType.Error: Debug.LogError(message); break;
                default: Debug.Log(message); break;
            }
        }

        public static void HelpBox(string message, MessageType type)
        {
            EditorGUILayout.HelpBox(message, type);
        }
    }


    public interface IValidatedInspector
    {
        // Basic proposal. This interface could be improved not to use pass throughs
        void OnInspectorValidation(out bool showMessage, out string message, out MessageType messageType);

        // Function proposal
        void OnInspectorValidation(ValidatedHelper.ShowMessage function);

        // Advanced proposal so we can use same validation code for HelpBox and DebugLog
        void OnInspectorValidation(List<ValidatedMessage> messages);
    }

    // Used for advanced proposal
    public struct ValidatedMessage
    {
        public string message;
        public MessageType type;
    }
}