using System.Collections;
using UnityEngine;

namespace MyRaces
{
    public delegate void EndTimer();
    
    public class MyCoroutine
    {
        public event EndTimer End;
        private Coroutine _coroutine;
        public void StartMyCoroutine(float second)
        {
            if (_coroutine != null)
            {
                return;
            }
            _coroutine = Coroutines.StarRoutine(MyTimer(second));
        }
        
        public void StopTestCoroutine()
        {
            Coroutines.StopRoutine(_coroutine);
            _coroutine = null;
        }
        
        private IEnumerator MyTimer(float second)
        {
            while (second>0)
            {
                yield return new WaitForSeconds(0.1f);
                second-=0.1f;
            }

            End?.Invoke();
        }
    }
}