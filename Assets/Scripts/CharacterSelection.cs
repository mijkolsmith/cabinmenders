using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private string _left;
    [SerializeField]
    private string _right;
    [SerializeField]
    private string _up;
    [SerializeField]
    private string _down;


    [SerializeField]
    private Text _characterText;

    [SerializeField]
    private string[] _characterNames;

    [SerializeField]
    private GameObject _obj;

    [SerializeField]
    private Image _button;

    [SerializeField]
    private Image _characterSpriteHolder;

    [SerializeField]
    private Sprite[] _characters;

    public int _number;

    public bool selected = false;

    [SerializeField]
    private AudioClip _readyClip;
    [SerializeField]
    private AudioClip _scrollClip;
    private AudioSource _audioSource;

    private void Start()
    {
        _number = Random.Range(0, 3);

        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_left) && !selected){
            if (_number < 2)
                _number += 1;
            else
                _number = 0;

            _audioSource.PlayOneShot(_scrollClip, 1f);
        }

        if (Input.GetKeyDown(_right) && !selected)
        {
            if (_number > 0)
                _number -= 1;
            else
                _number = 2;

            _audioSource.PlayOneShot(_scrollClip, 1f);
        }

        if (Input.GetKeyDown(_up) || Input.GetKeyDown(_down))
        {
            HideCanvasUI();
            _audioSource.PlayOneShot(_readyClip, 1f);
        }

        _characterText.text = _characterNames[_number];

        _characterSpriteHolder.sprite = _characters[_number];
    }

    private void HideCanvasUI()
    {
        if (_obj.activeInHierarchy)
        {
            _obj.SetActive(false);
            _button.GetComponent<Image>().color = Color.green;
            selected = true;
        }
        else
        {
            _obj.SetActive(true);
            _button.GetComponent<Image>().color = Color.white;
            selected = false;
        }
    }
}
