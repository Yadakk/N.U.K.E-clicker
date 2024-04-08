using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AssetBundleLib
{
    public static class AssetGetter<T> where T : Object
    {
        public static T[] GetAssets(AssetBundle bundle)
        {
            T[] assets = bundle.LoadAllAssets<T>();
            return assets;
        }

        public static T GetAsset(AssetBundle bundle, string name)
        {
            T asset = bundle.LoadAsset<T>(name);
            return asset;
        }
    }

    public static class AssetUtility
    {
        public static void GetFromBundle<T>(AssetBundle bundle, ref T obj) where T : Object
        {
            obj = AssetGetter<T>.GetAsset(bundle, obj.name);
        }
    }
}