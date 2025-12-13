using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.EntryPoint
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}