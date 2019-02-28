using UnityEngine;
using HoloToolkit.Unity.InputModule;

namespace HoloUtils
{
    public class HeadsetAdjustmentDisplaySwitcher : MonoBehaviour, IInputClickHandler
    {
        [SerializeField] GameObject HeadAdjustmentDisplay;

        void Start()
        {
            InputManager.Instance.AddGlobalListener(gameObject);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (GazeManager.Instance.HitObject == null)
			{
                if (HeadAdjustmentDisplay != null)
                {
                    HeadAdjustmentDisplay.SetActive(!HeadAdjustmentDisplay.activeSelf);
                }
            }
        }
    }
}
