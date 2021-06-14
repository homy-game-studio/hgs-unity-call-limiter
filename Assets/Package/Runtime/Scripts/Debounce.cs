using System;
using System.Collections;
using UnityEngine;

namespace HGS.CallLimiter
{
    /// <summary>
    /// Evita que um bloco de código seja chamado inumeras vezes, apenas a ultima invocação será permitida
    /// </summary>
    public class Debounce
    {
        Action _callback = null;

        Coroutine _corountine = null;

        /// <summary>
        /// E
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="interval"></param>
        public void Run(Action callback, float interval, MonoBehaviour mono)
        {
            _callback = callback;

            ResetTime(mono);

            _corountine = mono.StartCoroutine(DebounceCorountine(interval));
        }

        public void ResetTime(MonoBehaviour mono)
        {
            if (_corountine != null)
            {
                mono.StopCoroutine(_corountine);
            }
        }

        private IEnumerator DebounceCorountine(float time)
        {
            yield return new WaitForSeconds(time);
            _callback?.Invoke();
        }
    }
}