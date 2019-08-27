using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private Vector3[] Points = new Vector3[2];
    public float speed;
    private Transform _Pos;
    private int _number;
    void Start()
    {
        _Pos = GetComponent<Transform>();
        Points[0] = new Vector3(_Pos.position.x, _Pos.position.y + 0.2f, _Pos.position.z);
        Points[1] = _Pos.position;
    }
    void Update()
    {
        _Pos.position = Vector3.MoveTowards(_Pos.position, Points[_number], speed);
        if(_Pos.position == Points[_number])
        {
            _number++;
            if(_number == Points.Length)
            {
                _number = 0;
            }
        }
    }
}
