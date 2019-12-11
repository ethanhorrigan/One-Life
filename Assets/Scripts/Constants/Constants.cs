using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Author: Ethan Horrigan
 * Stores Unique variables to avoid the use of 'Magic Numbers'
 */
namespace Assets.Scripts.Constants
{
    public class Constants
    {
        public Constants(){}

        public const int NORTH = 0;
        public const int SOUTH = 1;
        public const int EAST = 2;
        public const int WEST = 3;

        public const int STARTING_BULLETS = 3;
        public const float MOVE_SPEED = 5.0f;
        public const float MOVE_LIMITER = 0.7f;
        public const float DESTROY_DELAY = 1.0F;

        public const int LEVEL_COUNT = 3;
        public const string SCENE_NAME = "Level_";

        public const float MIN_DELAY = 0.1f;
        public const float MAX_DELAY = 0.4f;

        public const float FLIP_OFFSET = 0.5f;

        public const int LEFT_CLICK = 0;
        public const int RIGHT_CLICK = 1;

    }
}
