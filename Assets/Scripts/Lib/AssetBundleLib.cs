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
            T assets = bundle.LoadAsset<T>(name);
            return assets;
        }
    }
}