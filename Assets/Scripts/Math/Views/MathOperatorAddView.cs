using MathFighter.GamePlay;
using UnityEngine;



namespace MathFighter.Math.Views
{
    public class MathOperatorAddView : MathOperatorView
    {
        public MathOperatorAddView(MathOperatorAdd op, float h, float spacing, Font font)
        {
            // get the textures for our parameters
            LogicalRenderTexture leftParamTexture = op.LeftParam.GenerateView(h, spacing, font).Texture;
            LogicalRenderTexture rightParamTexture = op.RightParam.GenerateView(h, spacing, font).Texture;

            // render the addition operator to a texture
            LogicalRenderTexture opTexture = DrawStringToTexture("+", h, font);

            // assemble all the textures into the final visual representation
            _texture = AssembleComponentTextures(spacing, opTexture, leftParamTexture, rightParamTexture);

            // cleanup
            LRTPool.Instance.ReleaseLRT(leftParamTexture);
            LRTPool.Instance.ReleaseLRT(rightParamTexture);
            LRTPool.Instance.ReleaseLRT(opTexture);
        }

        protected LogicalRenderTexture AssembleComponentTextures(float spacing, LogicalRenderTexture opTexture, LogicalRenderTexture leftParamTexture, LogicalRenderTexture rightParamTexture)
        {
            // work out texture size
            float w = leftParamTexture.Width + spacing + opTexture.Width + spacing + rightParamTexture.Width;
            float h = leftParamTexture.Height;

            if (opTexture.Height > h)
            {
                h = opTexture.Height;
            }
            else if (rightParamTexture.Height > h)
            {
                h = rightParamTexture.Height;
            }

            // get an LRT so we can do some custom texture composition
            LogicalRenderTexture lrt = LRTPool.Instance.AcquireLRT((int)w, (int)h);

            // setup the device stuff
            // TorqueEngineComponent.Instance.Game.GraphicsDevice.SetRenderTarget(0, lrt.RenderTarget);
            // TorqueEngineComponent.Instance.Game.GraphicsDevice.Clear(ClearOptions.Target, Color.TransparentBlack, 0.0f, 0);

            // setup the spritebatch
            // SpriteBatch spriteBatch = Game.SpriteBatch;// new SpriteBatch(TorqueEngineComponent.Instance.Game.GraphicsDevice);

            // render everything to texture
            float posX = 0.0f;

            // spriteBatch.Begin();
            lrt.Draw(leftParamTexture.Texture, new Vector2(posX, (h - leftParamTexture.Height) * 0.5f), leftParamTexture.Region, Color.white, 0.0f, Vector2.zero, 1.0f, 0.0f);
            posX += leftParamTexture.Width + spacing;
            lrt.Draw(opTexture.Texture, new Vector2(posX, (h - opTexture.Height) * 0.5f), opTexture.Region, Color.white, 0.0f, Vector2.zero, 1.0f, 0.0f);
            posX += opTexture.Width + spacing;
            lrt.Draw(rightParamTexture.Texture, new Vector2(posX, (h - rightParamTexture.Height) * 0.5f), rightParamTexture.Region, Color.white, 0.0f, Vector2.zero, 1.0f, 0.0f);
            // spriteBatch.End();

            // reset device stuff
            // TorqueEngineComponent.Instance.Game.GraphicsDevice.SetRenderTarget(0, null);

            // resolve and return the newly rendered texture
            // lrt.ResolveTexture();
            return lrt;
        }
    }
}
