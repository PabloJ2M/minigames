using System.Collections.Generic;

namespace Minigames.Survey
{
    public class UniqueManager : Manager
    {
        private static List<Item> _constant = new();

        protected override void CreateList()
        {
            //reset global condition
            if (_constant.Count + _lentgh > _generator.Length) _constant.Clear();

            //remove already made
            List<Item> left = new (_generator.List.Elements);
            left.RemoveAll(x => _constant.Contains(x));

            int size = _lentgh == 0 ? left.Count : _lentgh;
            print($"<color=yellow>items left { left.Count }</color>");

            //add elements to list
            for (int i = 0; i < size; i++) _listOfQuestions.Enqueue(left[i]);
        }
    }
}