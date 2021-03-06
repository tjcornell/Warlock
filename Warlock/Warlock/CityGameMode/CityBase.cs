using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace Warlock
{
    public class CityBase : IDrawable, IInteractable
    {
        public string CityBG { get; set; }
        private Rectangle rect1;
        public CityBase()
        {
            rect1 = new Rectangle(0, 0, WarlockGame.Graphics.PreferredBackBufferWidth, WarlockGame.Graphics.PreferredBackBufferHeight);
        } 

        public void Draw()
        {
            // Main Draw for every city
            
            WarlockGame.Batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            WarlockGame.Batch.Draw(WarlockGame.TextureDictionary[CityBG], rect1, Color.White);
            WarlockGame.Batch.End();
        }

        public virtual void Update() { }

        public void LoadContent()
        {
            WarlockGame.Instance.EnsureTexture(CityBG);
        }

        public void InteractLocation(TouchLocation touchLocation)
        {

        }

        public bool InteractGesture(GestureSample gestureSample)
        {
            return false;
        }
    }
}
