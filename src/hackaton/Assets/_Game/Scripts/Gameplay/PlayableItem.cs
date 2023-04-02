using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class PlayableItem : MonoBehaviour
    {
        public bool IsGoodItem;

        private GameplayData data;
        private Can can;

        [Inject]
        private void Construct(GameplayData data, Can can)
        {
            this.data = data;
            this.can = can;
        }
        
        public void StartMoveToCan()
        {
            transform.DOJump(can.transform.position + new Vector3(0,-1,0), data.JumpPower, 1, data.CurrentSettings.MediumDuration);
            var sequence = transform.DORotate(
                new Vector3(0, 0, 360), 2, RotateMode.FastBeyond360).SetEase(Ease.Linear);
            sequence.SetLoops(-1);
            sequence.Play();
        }
    }
}