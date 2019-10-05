using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBGController : MonoBehaviour
{
    public static CBGController _pInstance = null;

    [SerializeField] private GameObject _prefCloud = null;
    [SerializeField] private Sprite[] _imageClouds = null;
    [SerializeField] private float _fCloudRegenTerm = 1f;
    [SerializeField] private Transform _trCloudParent = null;

    [SerializeField] private GameObject _prefWall = null;
    [SerializeField] private Sprite[] _imageWalls = null;
    [SerializeField] private Transform _trWallParent = null;

    [SerializeField] private MeshRenderer _matGroundRenderer = null;

    public float _fBGScrollSpeed = 1f;
    public Transform _trLastWall = null;
    public bool _bIsDestroyedWall = false;

    private float _fCloudRegenTimeStack = 0f;

    private void Awake()
    {
        if (_pInstance == null)
        {
            _pInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (CGameManager._pInstance._bIsScrollBG)
        {
            // Cloud Regen
            _fCloudRegenTimeStack += Time.deltaTime;
            if (_fCloudRegenTimeStack > _fCloudRegenTerm)
            {
                CloudRegen();
                _fCloudRegenTimeStack -= _fCloudRegenTerm;
            }

            // Ground Move
            float offsetX = _matGroundRenderer.material.mainTextureOffset.x + (Time.deltaTime * _fBGScrollSpeed);
            if (offsetX > 1f) offsetX--;

            _matGroundRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
        }
    }

    public void WallRegen()
    {
        Vector3 pos = new Vector3(_trLastWall.position.x + 1.6f,
            _trLastWall.position.y, _trLastWall.position.z);

        CWall obj = Instantiate(_prefWall, pos, Quaternion.identity).GetComponent<CWall>();
        obj.transform.SetParent(_trWallParent);
        _trLastWall = obj.transform;

        int randidx = Random.Range(0, _imageWalls.Length);
        obj.DoInit(_imageWalls[randidx]);
        _bIsDestroyedWall = false;
    }

    private void CloudRegen()
    {
        float posY = Random.Range(4.5f, 6.3f);
        CCloud obj = Instantiate(_prefCloud, new Vector3(6f, posY, 0f), Quaternion.identity).GetComponent<CCloud>();
        obj.transform.SetParent(_trCloudParent);

        int randidx = Random.Range(0, _imageClouds.Length);
        obj.DoInit(_imageClouds[randidx]);
    }
}
