using HybridCLR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using YooAsset;

namespace NFramework
{
    /// <summary>
    ///     主入口 包含资源系统初始化 热更新初始化
    /// </summary>
    public class MainRoot : MonoBehaviour
    {
        private async void Start()
        {
            // 开始更新资源流程
            var operation = new PatchOperation();
            YooAssets.StartOperation(operation);
            await operation;
            // 以下写GamePlay入口逻辑
            Debug.Log("资源更新完毕,加载入口场景");
            var TestObj = YooAssets.LoadAssetSync<GameObject>("TestTools_TestObj");
            await TestObj.ToUniTask();
            var obj = TestObj.InstantiateAsync();
        }
    }
}