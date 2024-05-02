using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using static UnityEngine.JsonUtility;

namespace JsonSaverLib
{
    public static class Saver
    {
        private static readonly string[] _pathTypes =
        {
            Application.persistentDataPath,
            Application.streamingAssetsPath,
        };

        public static bool Exists(string path) => File.Exists(Application.persistentDataPath + path);
        public static bool Exists(string path, Mode mode) => File.Exists(_pathTypes[(int)mode] + path);

        public static void Save<T>(string path, T obj)
        {
            path = Application.persistentDataPath + path;
            var json = ToJson(obj);
            File.WriteAllText(path, json);
        }

        public static void Save<T>(string path, T obj, Mode mode)
        {
            path = _pathTypes[(int)mode] + path;
            var json = ToJson(obj);
            File.WriteAllText(path, json);
        }

        public static T Load<T>(string path)
        {
            path = Application.persistentDataPath + path;
            var json = File.ReadAllText(path);
            return FromJson<T>(json);
        }

        public static T Load<T>(string path, Mode mode)
        {
            path = _pathTypes[(int)mode] + path;
            var json = File.ReadAllText(path);
            return FromJson<T>(json);
        }

        public enum Mode
        {
            Persistent,
            Streaming,
        }
    }

    [Serializable]
    public struct SerializableFloat
    {
        public int Value;

        public SerializableFloat(int value)
        {
            Value = value;
        }
    }
}