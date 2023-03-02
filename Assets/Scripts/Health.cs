using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Health : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private PlayerController _playerController;
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        if (_player.TryGetComponent(out PlayerController playerController) == false)
        {
            Debug.LogError("Player not specified");
        }
        _playerController = playerController;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        _textMeshPro.text = ((int)_playerController.currentHealth).ToString();
    }
}
