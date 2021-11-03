using System;
using System.Collections.Generic;
using System.Text;

namespace Codereview
{
    class FrameController
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly float _targetFrameRate;
        private static double _previousFrameTime;
        private double _timeSinceLastFrame;
        private double NextFrameTime => _previousFrameTime + _targetFrameRate;

        public FrameController(float targetFrameRate)
        {
            _targetFrameRate = targetFrameRate;
            _previousFrameTime = DateTime.Now.ToUniversalTime().Subtract(Epoch).TotalMilliseconds;
            _timeSinceLastFrame = 0;
        }
        public bool OnNextFrame()
        {
            var now = DateTime.Now.ToUniversalTime().Subtract(Epoch).TotalMilliseconds;
            if (now > NextFrameTime)
            {
                _timeSinceLastFrame = now - _previousFrameTime * 0.01;

                Debugging.DisplayDeltaTime(_timeSinceLastFrame);

                _previousFrameTime = now;
                return true;
            }
            return false;
        }
    }
}
