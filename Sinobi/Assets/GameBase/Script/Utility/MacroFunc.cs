using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    /// <summary>
    /// 汎用的な関数一覧
    /// </summary>
    public static class MacroFunc
    {
        /// <summary>
        /// 入れ替え処理
        /// </summary>
        public static void Swap<T>(ref T a, ref T b)
        {
            T _work = a;
            a = b;
            b = _work;
        }
    }
}