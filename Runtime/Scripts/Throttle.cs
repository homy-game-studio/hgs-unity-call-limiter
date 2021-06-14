using System;
using UnityEngine;

namespace HGS.CallLimiter
{
    /// <summary>
    /// Garante que um bloco de código seja chamado apenas a cada x segundos, caso contrario a invocação será ignorada
    /// </summary>
    public class Throttle
    {
        float _targetTime = 0;

        /// <summary>
        /// Garante que um bloco de codigo só seja executado a cada x de intervalo
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="interval"></param>
        public void Run(Action callback, float interval)
        {
            if (_targetTime <= Time.time)
            {
                _targetTime = Time.time + interval;
                callback?.Invoke();
            }
        }

        public void ResetTimer()
        {
            _targetTime = 0;
        }
    }
}