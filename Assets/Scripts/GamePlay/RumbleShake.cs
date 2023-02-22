using System.Collections.Generic;
using MathFighter.GamePlay;
using UnityEngine;

namespace MathFighter.vfx
{
    public class RumbleShake
    {
        private float _rumbleLeft;
        private float _rumbleRight;
        private float _shakeFreq;
        private float _shakeDistX;
        private float _shakeDistY;
        private string _taskList;
        //private T2DSceneCamera _camera;
        private ShakeController _shakeController = new ShakeController();

        public void Start(float rumbleLeft, float rumbleRight, float shakeFreq, float shakeDistX, float shakeDistY, string taskList)
        {
            _rumbleLeft = rumbleLeft;
            _rumbleRight = rumbleRight;
            _shakeFreq = shakeFreq;
            _shakeDistX = shakeDistX;
            _shakeDistY = shakeDistY;
            _taskList = taskList;
            //_camera = TorqueObjectDatabase.Instance.FindObject<T2DSceneCamera>();

#if XBOX
            foreach (Player p in Game.Instance.ActiveGameplaySettings.Players)
            {
                if (p is PlayerLocal)
                {
                    Microsoft.Xna.Framework.Input.GamePad.SetVibration((p as PlayerLocal).XNAPlayerIndex, _rumbleLeft, _rumbleRight);
                }
            }
#endif

            _shakeController.PlayShakeFX = true;
            //AsyncTaskManager.Instance.AddTask(AsyncTask_DoShakeFX(), _taskList, false);
        }

        public void Stop()
        {
#if XBOX
            foreach (Player p in Game.Instance.ActiveGameplaySettings.Players)
            {
                if (p is PlayerLocal)
                {
                    Microsoft.Xna.Framework.Input.GamePad.SetVibration((p as PlayerLocal).XNAPlayerIndex, 0.0f, 0.0f);
                }
            }
#endif

            _shakeController.PlayShakeFX = false;
        }

        //private IEnumerator<AsyncTaskStatus> AsyncTask_DoShakeFX()
        //{
        //    try
        //    {
        //        System.Random rnd = new System.Random();
        //        Vector2 targetPos = new Vector2((float)rnd.NextDouble() * (_shakeDistX + _shakeDistX) - _shakeDistX, (float)rnd.NextDouble() * (_shakeDistY + _shakeDistY) - _shakeDistY);
        //        Vector2 velocity = targetPos - _camera.Position;
        //        float timeElapsed = 0.0f;

        //        // Boom shake shake shake the room!!!
        //        do
        //        {
        //            timeElapsed += Game.Instance.dt;

        //            if (timeElapsed >= 1.0f / _shakeFreq)
        //            {
        //                _camera.Position = targetPos;   // make sure it ends up in the right position so errors don't build up or could seesaw out of control as the velocity increases to cover the distance
                        
        //                targetPos = new Vector2((float)rnd.NextDouble() * (_shakeDistX + _shakeDistX) - _shakeDistX, (float)rnd.NextDouble() * (_shakeDistY + _shakeDistY) - _shakeDistY);
        //                velocity = targetPos - _camera.Position;

        //                timeElapsed = 0.0f;
        //            }

        //            _camera.Position += velocity * timeElapsed * _shakeFreq;

        //            yield return null;

        //        } while (_shakeController.PlayShakeFX);

        //        // make sure the camera goes is re-centered
        //        _camera.Position = Vector2.zero;
        //    }
        //    finally
        //    {
        //        _shakeController.PlayShakeFX = false;
        //    }
        //}

        private struct ShakeController
        {
            public bool PlayShakeFX;
        }
    }
}
