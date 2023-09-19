using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minigames.Memory
{
    [RequireComponent(typeof(Generator))]
    public class Manager : GameManager
    {
        private List<int> _results = new();
        private WaitForSeconds _instantDelay = new(0.25f);
        private bool _lessResults => _results.Count < _generator.Length;

        public override bool Compare(int value)
        {
            if (!_lessResults) return false;
            _results.Add(value);

            if (!_lessResults) StartCoroutine(Check());
            return true;
        }
        private IEnumerator Check()
        {
            //check all cards over limit
            bool isAllEqual = _results.Distinct().Count() == 1;
            yield return !isAllEqual ? _waitForDelay : _instantDelay;

            //clear results
            onCompare?.Invoke(isAllEqual);
            _results.Clear();

            //analize grid
            if (isAllEqual) { _complete++; print("same"); }
            if (_complete * 2 >= _generator.Results.Length) _onComplete.Invoke();
        }
    }
}