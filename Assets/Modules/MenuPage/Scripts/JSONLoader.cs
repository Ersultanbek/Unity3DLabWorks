using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public sealed class JSONLoader{
    private string path = "Assets/Data/scenesLink.json";
    private static JSONLoader instance = null;
    private static readonly object padlock = new object();

    public List<SceneLink> jSONLinks;


    public static JSONLoader Instance { get { return Nested.instance; } }

    private class Nested
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Nested()
        {

        }

        internal static readonly JSONLoader instance = new JSONLoader();
    }

    public List<SceneLink> GetSceneLinks() {
        return jSONLinks;
    }

    public JSONLoader() {
        using (StreamReader reader = new StreamReader(path))
        {
            var json = reader.ReadToEnd();
            jSONLinks = JsonHelper.FromJson<SceneLink>(json);
        }
    }

    public SceneLink GetSceneLink(string sceneName) {
        foreach (SceneLink link in jSONLinks) {
            if (link.sceneLink == sceneName)
                return link;
        }
        return null;
    }


    public static class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return new List<T>(wrapper.Items);
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }

}
