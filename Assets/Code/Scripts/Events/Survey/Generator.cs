using UnityEngine;
using TMPro;

namespace Minigames.Survey
{
    public class Generator : GameGenerator
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField, Range(0, 0.1f)] protected float _delay = 0.05f;
        private int _size;

        public override float Delay => _delay * _size;

        public void Build(string question, string[] answers)
        {
            _size = answers.Length;
            _text?.SetText(question);
            int[] index = new int[_size];

            for (int i = 0; i < _size; i++)
            {
                //random value
                int r = (_random ? Random.Range(0, _size) : i) + 1;
                if (_list.Contains(index, r)) { i--; continue; }

                //setup question & answers
                Answer answer = _items[i] as Answer;
                answer.Text = answers[r - 1];
                answer.ID = index[i] = r;

                //show animation
                answer.Show(_delay * (i + 1));
            }
        }
        public void Break()
        {
            for (int i = 0; i < _size; i++)
            {
                //hide animation
                Answer answer = _items[i] as Answer;
                answer.Hide(_delay * (i + 1));
            }
        }
    }
}