using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Warlock
{
    class SplashGameMode : IGameMode
    {
        private List<IDrawable> m_drawable;
        private List<IInteractable> m_interactable;

        public void Initialize()
        {
            m_drawable = new List<IDrawable>();
            m_interactable = new List<IInteractable>();
            NewGameSplashButton newgame = new NewGameSplashButton();
            ExitSplashButton exit = new ExitSplashButton();
            m_drawable.Add(newgame);
            m_drawable.Add(exit);
            m_interactable.Add(newgame);
            m_interactable.Add(exit);

            TouchPanel.EnabledGestures = GestureType.Tap;
        }

        public void Draw()
        {
            WarlockGame.m_graphics.GraphicsDevice.Clear(Color.Red);

            foreach (IDrawable drawable in m_drawable)
                drawable.Draw();

            return;
        }

        public void Update()
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                WarlockGame.m_Instance.Exit();

            if (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                foreach (IInteractable interactable in m_interactable)
                    interactable.Interact(gesture);
            }
        }
    }
}