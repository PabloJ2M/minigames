using UnityEngine;

namespace Minigames.Survey
{
    [CreateAssetMenu(fileName = "question", menuName = "minigames/questions")]
    public class AnswerScriptable : Item
    {
        [Header("Questions")]

        [TextArea]
        public string question = "pregunta";
        public string[] answers = { "respuesta 1", "respuesta 2", "respuesta 3" };
    }
}