using UnityEngine;

namespace Minigames.Puzzle
{
    [ExecuteAlways]
    public class Generator : GameGenerator
    {
        [SerializeField] private Transform _self, _image, _container;
        [SerializeField, Range(0, 10)] private float _radius;
        private Piece[] _pieces;

        private void Reset() => _self = transform;
        private void OnEnable() => _pieces = _container.GetComponentsInChildren<Piece>();
        private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(_self.position, _radius);

        private void Start()
        {
            if (!Application.isPlaying) return;
            for (int i = 0; i < _items.Length; i++) { _items[i].ID = i; }
            foreach (Piece piece in _pieces) { piece.transform.position = _radius * Random.insideUnitCircle; }
        }

        [ContextMenu("Build")] private void Build()
        {
            for (int i = 0; i < _pieces.Length; i++)
            {
                _pieces[i].ID = i;
                if (_pieces[i].transform.childCount > 0) DeleteChild(_pieces[i].transform);
                Instantiate(_image.gameObject, _image.position, Quaternion.identity, _pieces[i].transform).name = "image";
            }
        }
        [ContextMenu("Delete")] private void Delete()
        {
            foreach (Piece piece in _pieces) DeleteChild(piece.transform);
        }

        private void DeleteChild(Transform item)
        {
            int length = item.childCount;
            for (int i = length - 1; i >= 0; i--) DestroyImmediate(item.GetChild(i).gameObject);
        }
    }
}