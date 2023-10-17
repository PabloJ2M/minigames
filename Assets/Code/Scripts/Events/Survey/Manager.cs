using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.Survey
{
    [RequireComponent(typeof(Generator))]
    public class Manager : GameManager
    {
        [SerializeField] protected int _lentgh;
        [SerializeField] private int _failLimit;
        [SerializeField] private UnityEvent _onFailure;

        protected Queue<Item> _listOfQuestions = new();
        private WaitUntil _waitForContinue;
        private int _failCount, _current;

        protected override void Awake() { base.Awake(); _waitForContinue = new WaitUntil(() => Continue); }
        private void Start() { CreateList(); StartCoroutine(QuestionLoop()); }
        private void OnEnable() => onCompare += Performe;
        private void OnDisable() => onCompare -= Performe;
        private void Performe(bool value) { if (!value) _failCount++; Continue = true; }

        public override bool Compare(int value) => value == _current;
        protected virtual void CreateList()
        {
            float size = _lentgh == 0 ? _generator.List.Length : _lentgh;
            for (int i = 0; i < size; i++) _listOfQuestions.Enqueue(_generator.List[i]);
        }

        private IEnumerator QuestionLoop()
        {
            //setup question & answers
            AnswerScriptable item = _listOfQuestions.Dequeue() as AnswerScriptable;
            Generator manager = _generator as Generator;
            manager.Build(item.question, item.answers);
            _current = item.result;
            Continue = false;
            
            //wait for delay to continue
            yield return _waitForContinue;
            yield return _waitForDelay;

            //complete statement
            if (_listOfQuestions.Count == 0)
            {
                if (_failLimit != 0 && _failCount >= _failLimit) { _onFailure.Invoke(); yield break; }
                _onComplete.Invoke(); yield break;
            }

            //next step
            manager.Break();
            yield return _waitForDelay;
            StartCoroutine(QuestionLoop());
        }
    }
}