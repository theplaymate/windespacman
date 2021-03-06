using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using GameStateManagement;


namespace Karo.Gui
{
    class Letters : DrawableGameComponent
    {
        List<Model> letters;
        List<Model> cijfers;
        GameplayScreen game;
        BoardManager manager;

        public Letters(GameplayScreen game, BoardManager manager)
            : base(game.ScreenManager.Game)
        {
            this.game = game;
            this.manager = manager;
        }

        public override void Initialize()
        {
            letters = new List<Model>();
            cijfers = new List<Model>();
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (letters.Count == 0)
            {
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/A"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/B"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/C"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/D"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/E"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/F"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/G"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/H"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/I"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/J"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/K"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/L"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/M"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/N"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/O"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/P"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/Q"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/R"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/S"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/T"));
                letters.Add(game.ScreenManager.Game.Content.Load<Model>("letters/U"));
            }

            if (cijfers.Count == 0)
            {
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/1"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/2"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/3"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/4"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/5"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/6"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/7"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/8"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/9"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/10"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/11"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/12"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/13"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/14"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/15"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/16"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/17"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/18"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/19"));
                cijfers.Add(game.ScreenManager.Game.Content.Load<Model>("cijfers/20"));
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.ScreenManager.ResetGraphicsDeviceSettings();

            if (game.IsActive && manager.MinY > 0 && manager.MinX > 0)
            {
                int min = manager.MinX;
                int max = manager.MaxX;

                //letters
                for (int i = min; i <= max; i++)
                {
                    int selected = 21 - i;
                    foreach (ModelMesh mesh in letters[selected].Meshes)
                    {
                        foreach (BasicEffect effect in mesh.Effects)
                        {
                            Matrix trans = Matrix.Identity;

                            trans *= Matrix.CreateScale(2f);
                            if (game.EnableTopView)
                            {
                                trans *= Matrix.CreateRotationX(MathHelper.ToRadians(-1 * (180 + (44.9f - 315))));
                                trans *= Matrix.CreateRotationZ(MathHelper.ToRadians(-180));
                            }
                            else
                            {
                                trans *= Matrix.CreateRotationX(MathHelper.ToRadians(-1 * (180 + (manager.XRotation - 315))));
                                trans *= Matrix.CreateRotationZ(MathHelper.ToRadians(-1 * (180 - manager.ZRotation)));
                            }
                            trans *= Matrix.CreateTranslation(i, manager.MinY - 2, 0);
                            trans *= game.World;

                            effect.World = trans;
                            effect.View = game.View;
                            effect.Projection = game.Projection;

                            effect.LightingEnabled = true;
                            effect.DirectionalLight0.Enabled = true;
                            effect.DirectionalLight0.DiffuseColor = Color.Orange.ToVector3();
                            effect.DirectionalLight0.SpecularColor = Color.White.ToVector3();
                            effect.DirectionalLight0.Direction = new Vector3(-1, -1, -1);

                            effect.DirectionalLight1.Enabled = true;
                            effect.DirectionalLight1.DiffuseColor = Color.Orange.ToVector3();
                            effect.DirectionalLight1.Direction = new Vector3(1, 1, 1);
                        }
                        mesh.Draw();
                    }
                }

                //numbers
                min = manager.MinY - 1;
                max = manager.MaxY - 1;

                for (int i = min; i <= max; i++)
                {
                    Matrix[] transforms = new Matrix[cijfers[i].Bones.Count];
                    cijfers[i].CopyAbsoluteBoneTransformsTo(transforms);

                    foreach (ModelMesh mesh in cijfers[i].Meshes)
                    {
                        foreach (BasicEffect effect in mesh.Effects)
                        {
                            Matrix trans = Matrix.Identity;

                            trans *= Matrix.CreateScale(2f);

                            if (game.EnableTopView)
                            {
                                trans *= Matrix.CreateRotationX(MathHelper.ToRadians(-1 * (180 + (44.9f - 315))));
                                trans *= Matrix.CreateRotationZ(MathHelper.ToRadians(-180));
                            }
                            else
                            {
                                trans *= Matrix.CreateRotationX(MathHelper.ToRadians(-1 * (180 + (manager.XRotation - 315))));
                                trans *= Matrix.CreateRotationZ(MathHelper.ToRadians(-1 * (180 - manager.ZRotation)));
                            }
                            trans *= Matrix.CreateTranslation(manager.MaxX - (manager.BoardWidth + 1), manager.MinY + i - min, 0);
                            trans *= transforms[mesh.ParentBone.Index] * game.World;

                            effect.World = trans;
                            effect.View = game.View;
                            effect.Projection = game.Projection;

                            effect.LightingEnabled = true;
                            effect.DirectionalLight0.Enabled = true;
                            effect.DirectionalLight0.DiffuseColor = Color.Orange.ToVector3();
                            effect.DirectionalLight0.SpecularColor = Color.White.ToVector3();
                            effect.DirectionalLight0.Direction = new Vector3(-1, -1, -1);

                            effect.DirectionalLight1.Enabled = true;
                            effect.DirectionalLight1.DiffuseColor = Color.Orange.ToVector3();
                            effect.DirectionalLight1.Direction = new Vector3(1, 1, 1);
                        }
                        mesh.Draw();
                    }
                }
            }
            base.Draw(gameTime);
        }
    }
}