using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
// Vẽ coin theo hình sin
// Mỗi 5s thì vẽ một lần
// Xóa coin bị bỏ qua


    public Transform _player; //ánh xạ tới nhân vật
    public GameObject _coin; //ánh xạ tới prefab coin
    public float _nextPosX;
    public float _nextPosY; //Vị trí sẽ sinh ra coin

    //độ cong hình sin

    private Vector3 _nextPos;
    public float _khoangCachve;

    public float _chieuCaoSin;
    public float _doRongSin;
    public float _chieuCao; //chiều cao so với mặt đất của coin
    public float _chieuCaoToiThieu;
    public float _thoiGian; //Bao lâu vẽ coin 1 lần
    public int _soLuongCoin; //Số lượng coin mỗi lần vẽ ra

    public float _timer; //Theo dõi thời gian

    void Start()
    {
        _khoangCachve = 20f;
        _chieuCaoToiThieu = 4f;
        _thoiGian = 5f;
        _soLuongCoin = 11;
        _timer = 0;
        vecoin2();

    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _thoiGian)
        {
            vecoin2();
            _timer = 0;
        }
    }

    //private void veCoin()
    //{
    //    _chieuCao = Random.Range(-1f, 0f) + _chieuCaoToiThieu;
    //    _chieuCaoSin = 3.5f;
    //    _doRongSin = 3.5f;
    //    //_doCong = Random.Range(0.8f, 1.2f);
    //    _nextPosX = _player.position.x + _khoangCach;
    //    for (int i = 0; i < _soLuongCoin; i++) { 
    //        _nextPosY = Mathf.Abs(_chieuCaoSin * Mathf.Sin(_nextPosX/ _doRongSin)) + _chieuCao;
    //        Instantiate(_coin, new Vector3(_nextPosX, _nextPosY, 0f), Quaternion.identity, transform);
    //        _nextPosX ++;
    //    }
    //}
    private void vecoin2()
    {
        float a;
        a = Random.Range(0.05f, 0.15f);

        float b;
        b = Random.Range(0.25f, 0.75f);

        _nextPos = _player.position + new Vector3(_khoangCachve, -20f, 0f);
        int _socoin2 = (int)(_soLuongCoin / 2);
        for (int i = -1 * _socoin2; i <= _socoin2; i++)
        {
            Vector3 toadove = _nextPos + new Vector3(i + _socoin2, -1 * a * i * i + _socoin2 * _socoin2 + b, 1f);
            Instantiate(_coin, toadove, Quaternion.identity, transform);
        }

    }
}

