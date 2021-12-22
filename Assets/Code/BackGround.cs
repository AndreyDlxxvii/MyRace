using UnityEngine;

namespace MyRaces
{
    public class BackGround : MonoBehaviour
    {
        [SerializeField] private float _leftBoarder;
        [SerializeField] private float _rightBoarder;

        [SerializeField] private float _relativeSped;

        public void Move(float value)
        {
            transform.position += Vector3.right * value * _relativeSped;
            Vector3 pos = transform.position;
            if (pos.x <= _leftBoarder)
            {
                transform.position = new Vector3(_rightBoarder - (_leftBoarder - pos.x), pos.y, pos.z);
            }
            else if (transform.position.x >= _rightBoarder)
            {
               transform.position = new Vector3(_leftBoarder+(_leftBoarder-pos.x), pos.y,pos.z); 
            }
        }
    }
}