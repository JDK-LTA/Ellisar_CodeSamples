using UnityEngine;

namespace Ellisar.EllisarAssets.Scripts.UI
{
    public class MenuOpener : MonoBehaviour
    {
        private MainMenuManager _mainMenu;
        public static bool CanOpenMenu = true;

        private void Start()
        {
            _mainMenu = MainMenuManager.Instance;
        }

        public void ToggleMenu()
        {
            if (!_mainMenu) return;

            _mainMenu.gameObject.SetActive(!_mainMenu.gameObject.activeSelf);
        }

        public void OpenMenu()
        {
            if (CanOpenMenu)
            {
                _mainMenu.gameObject.SetActive(true);
            }
        }
    }
}
