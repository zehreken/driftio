using UnityEngine;

namespace cln
{
    public class Menu : MonoBehaviour
    {
        protected MenuManager MenuManager;

        public void Initialize(MenuManager menuManager)
        {
            MenuManager = menuManager;
        }
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}