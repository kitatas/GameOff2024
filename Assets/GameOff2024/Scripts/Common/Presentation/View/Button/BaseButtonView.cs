using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameOff2024.Common.Presentation.View.Button
{
    public abstract class BaseButtonView : MonoBehaviour
    {
        [SerializeField] protected UnityEngine.UI.Button button = default;

        public void AddAction(Action action) => button.onClick.AddListener(() => action?.Invoke());

        public void SetInteractable(bool value) => button.interactable = value;

        public async UniTask OnClickAsync(CancellationToken token)
        {
            await button.OnClickAsync(token);
        }
    }
}