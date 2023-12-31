using UnityEngine;
using DiceSpace.CompleteObserver;
using DiceSpace.StartObserver;
using AttributeSpace;
using Zenject;
using System.Threading.Tasks;
using UISpace;

namespace DiceSpace
{
    public sealed class DiceSideSetter : IRollStartObserver, IRollCompleteObserver, IAttributeUseObserver
    {
        private RectTransform diceTransform;
        private DiceEdge diceEdge;

        #region
        private Vector3[] diceEdges = {
            new Vector3(346,198,239),
            new Vector3(341,355,120),
            new Vector3(51,205,14),
            new Vector3(326,64,128),
            new Vector3(56,80,38),
            new Vector3(304,263,9),
            new Vector3(48,144,31),
            new Vector3(51,31,203),
            new Vector3(52,151,213),
            new Vector3(333,290,102),
            new Vector3(25,246,281),
            new Vector3(308,19,40),
            new Vector3(51,209,198),
            new Vector3(315,25,219),
            new Vector3(62,263,178),
            new Vector3(299,99,212),
            new Vector3(32,116,313),
            new Vector3(317,331,198),
            new Vector3(20,178,296),
            new Vector3(13,18,181),
            };
        #endregion

        [Inject]
        public void Constructor(DiceEdge diceEdge) => this.diceEdge = diceEdge;

        public void SetTransform(RectTransform diceTransform) => this.diceTransform = diceTransform;

        public void OnDiceRollStart() => diceEdge.GenerateRandomNumber();

        public void OnDiceRollCompleted() => SetSide();

        public void OnAttributeUse() => WaitAndSetSide();

        private async void WaitAndSetSide()
        {
            await Task.Delay(1000);
            SetSide();
        }

        private void SetSide()
        {
            int diceEdge = this.diceEdge.EdgeNumber;
            diceTransform.rotation = Quaternion.Euler(diceEdges[diceEdge]);
        }
    }
}