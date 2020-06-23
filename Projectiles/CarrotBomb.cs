using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PracticeTerrariaMod.Projectiles
{
    class CarrotBomb: ModProjectile
    {
        // Private Properties
        private int imageWidth = 24;
        private int imageHeight = 23;
        private float bounceSpeedMult = 0.75f;

        // SetStaticDefaults()
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Carrot Bomb");
        }

        // SetDefaults()
        public override void SetDefaults()
        {
            // Generic Projectile properties
            projectile.arrow = false;               // (Default) This project is NOT an arrow
            projectile.width = 8;                   // Hitbox Size X
            projectile.height = 8;                  // Hitbox Size Y

            // Bomb-Specific properties
            // projectile.aiStyle = ProjectileID.Bomb;
            projectile.aiStyle = 0;
            projectile.penetrate = 4;                       // Bomb bounces 3 times before exploding
            projectile.timeLeft = Int32.MaxValue - 1;       // Int32.MaxValue ensures that bomb bounces before exploding
            projectile.friendly = true;                     // 
            projectile.hostile = false;                     // 
            drawOffsetX = (projectile.width / 2) - (imageWidth / 2);
            drawOriginOffsetY = (projectile.height / 2) - (imageHeight / 2);

            /* === CRIT CHANCES ===
             * 
             * Depending on which of these booleans is true, the crit chance
             * for the projectile will be influenced by the player's crit
             * change modifiers for the specified damage type.
             * 
             * Since this item is a bomb, the chance to crit should not be
             * modified. Ergo, all the following values are the default
             * values for all projectiles.
             */
            projectile.melee = false;
            projectile.ranged = false;
            projectile.magic = false;
            projectile.minion = false;
            projectile.thrown = false;
        }

        // PreAI() -- Determines if vanilla AI code is run (based on "aiStyle" property)
        public override bool PreAI()
        {
            return true;
        }

        // AI()
        public override void AI()
        {
            // Incrementing the tick counter
            projectile.ai[0] += 1;

            // Rotating based on X velocity
            projectile.rotation += 0.05f * projectile.velocity.X;

            // Adding gravity
            projectile.velocity.Y += 0.1f;
            if (projectile.velocity.Y > 16f) projectile.velocity.Y = 16f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Incrementing the projectile penetrate count
            projectile.penetrate -= 1;

            // Reversing the the appropriate movement direction
            if (projectile.velocity.X == oldVelocity.X)
            {
                projectile.velocity.Y = oldVelocity.Y * -1;
                projectile.velocity *= bounceSpeedMult;
            }
            if (projectile.velocity.Y == oldVelocity.Y)
            {
                projectile.velocity.X = oldVelocity.X * -1 * bounceSpeedMult;
            }

            // IF the bomb is bouncing for the 4th time, create an explosion
            if (projectile.penetrate < 1)
            {
                Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileID.Explosives, 80, 10);
            }

            // Returning false (disables running normal "OnTileCollide" code)
            return false;
        }
    }
}
