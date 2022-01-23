using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Tiled;


namespace Solarheart2
{
    using anim_size_offset = List<Rectangle>;

    /// <summary>
    /// Merge with main
    /// </summary>
    /*
    public class s_levelloader
    {

        public void LoadLevel(s_map map)
        {
            s_map newMap = new s_map();

            ushort sx = map.mapSizeX, sy = map.mapSizeY;
            ushort tx = map.tileSizeX, ty = map.tileSizeY;

            newMap.mapSizeX = sx;
            newMap.mapSizeY = sy;
            newMap.tileSizeX = (byte)tx;
            newMap.tileSizeY = (byte)ty;

            newMap.tiles = new ushort[map.tiles.Length];
            newMap.entities = new List<o_entity>();
            for (ushort i = 0; i < map.tiles.Length; i++)
            {
                newMap.tiles[i] = map.tiles[i];
            }
            for (int i = 0; i < map.entities.Count; i++)
            {
                o_entity ent = map.entities[i];
                newMap.entities.Add(map.entities[i]);

            }
            //level = newMap;

            #region CREATE TILES
            int x = 0, y = 0;
            for (ushort i = 0; i < map.tiles.Length; i++)
            {
                anim_size_offset anim = new anim_size_offset();
                if (x == (sx * tx))
                {
                    y += ty;
                    x = 0;
                }
                ushort tex = map.tiles[i];
                if (tex == 0)
                {
                    x += tx;
                    continue;
                }
                else
                    tex--;
                Texture2D texTu = textures["tiles"].Item1;

                int tilX = tex % (texTu.Width / map.tileSizeX);
                int tilY = ((tex * map.tileSizeX) / texTu.Width);

                Vector2 pos = new Vector2(x, y);
                int intPos = 0;
                CreateTiles();
                x += tx;
            }
            #endregion

            #region CREATE ENTITIES
            int leng = map.entities.Count;
            for (int i = 0; i < map.entities.Count; i++)
            {
                o_entity ent = map.entities[i];
                ushort id = ent.id;
                int a = ent.position.X;
                Vector2 pos = new Vector2(ent.position.X, ent.position.Y);
                ushort label = ent.labelToCall;
                anim_size_offset anim = new anim_size_offset();
                CreateEntities();

            }
            #endregion
        }

        public virtual void CreateEntities()
        {
            throw new NotImplementedException();
        }

        public virtual void CreateTiles()
        {
            throw new NotImplementedException();
        }
    }
    */

    /// <summary>
    /// Merge with main
    /// </summary>
    public static class s_globals
    {
        public static Dictionary<string, int> flags = new Dictionary<string, int>();

        public static void SetFlag()
        {

        }
        public static int GetFlag(string name)
        {
            return flags[name];
        }
    }

    /// <summary>
    /// Merge with main
    /// </summary>
    /*
    public static class s_soundManager
    {
        public static List<SoundEffect> sounds = new List<SoundEffect>();
        public static void PlaySound(int sfx_num)
        {
            SoundEffect se = sounds[sfx_num];
            se.Play();
        }
        public static void PlaySound(int sfx_num, Vector2 position)
        {
            float hyp = s_maths.HypotenuseVector(position - (position + centreOfScreen));

            if (hyp > 145)
                return;
            SoundEffect se = sounds[sfx_num];
            se.Play();
        }
    }
    */

    /*
    /// <summary>
    /// Merge with main
    /// </summary>
    public static class s_objectManager
    {
        public static T AddObject<T>(Vector2 pos, string name) where T : s_object, new()
        {
            if (e_solarHeart.objects.Count > 20)
                return null;
            T cha = new T();
            cha.position = pos;
            cha.SetCollisonSize(new Vector2(20, 20));
            cha.name = name;
            e_solarHeart.objects.Add(cha);
            //chara.Add(cha);
            return cha;
        }
        public static T AddObject<T>(Vector2 pos, string name, anim_size_offset sizesAndOffsets, Texture2D texture) where T : s_object, new()
        {
            if (e_solarHeart.objects.Count > 20)
                return null;
            T cha = new T();
            cha.position = pos;
            cha.SetCollisonSize(new Vector2(20, 20));
            cha.renderer.SetSpriteOffsetsAndSizes(sizesAndOffsets);
            cha.renderer.texture = texture;
            cha.name = name;
            e_solarHeart.objects.Add(cha);
            //chara.Add(cha);
            return cha;
        }
        public static void RemoveObject(s_object obj)
        {
            s_object obja = e_solarHeart.objects.Find(x => x == obj);
            if (obja != null)
                e_solarHeart.objects.Remove(obja);
        }

        public static T FindCharacter<T>(string nam) where T : s_object
        {
            for (int i = 0; i < e_solarHeart.objects.Count; i++)
            {
                T obj = e_solarHeart.objects[i].GetComponent<T>();
                if (obj != null)
                {
                    if (obj.name != nam)
                        continue;
                    return obj;
                }
            }
            return null;
        }
        public static T[] FindCharacters<T>(string nam) where T : s_object
        {
            List<T> objec = new List<T>();
            for (int i = 0; i < e_solarHeart.objects.Count; i++)
            {
                T obj = e_solarHeart.objects[i].GetComponent<T>();
                if (obj != null)
                {
                    if (obj.name != nam)
                        continue;
                    objec.Add(obj);
                }
            }
            return objec.ToArray();
        }

        public static void ClearObjects()
        {

        }
    }
    */

    /*
    /// <summary>
    /// Merge with main
    /// </summary>
    public static class s_renderer
    {
        public static RenderTarget2D VirtScreen;
        public static GraphicsDevice grDev;
        public static SpriteBatch spriteBatch;
        public static Texture2D blank;
        public static Dictionary<string, Tuple<Texture2D, anim_size_offset>> textures = new Dictionary<string, Tuple<Texture2D, anim_size_offset>>();

        public static void Start()
        {
            blank = new Texture2D(grDev, 1, 1);
            //CreateSpriteSheets();
        }

        public static void CreateVirtualScreen()
        {
            VirtScreen = new RenderTarget2D(grDev, 384, 216);
        }
        public static Vector2 centreOfScreen
        {
            get
            {
                return new Vector2(VirtScreen.Width / 2, VirtScreen.Height / 2);
            }
        }

        public static Vector2 screenSize
        {
            get
            {
                return new Vector2(VirtScreen.Width, VirtScreen.Height);
            }
        }

        public static Vector2 ScreenToVirtualScreen(Vector2 pos)
        {
            Vector2 realScreen = new Vector2(grDev.Viewport.Width, grDev.Viewport.Height);

            float posx = pos.X / realScreen.X;
            float posy = pos.Y / realScreen.Y;

            return new Vector2(VirtScreen.Width * posx, VirtScreen.Height * posy);
        }

        public static void CreateSpriteSheets(ContentManager Content)
        {
            anim_size_offset aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(23, 20)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(30, 0), new Vector2(60, 60)));
            textures.Add("bomb", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("explosion"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 25)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(20, 0), new Vector2(20, 25)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(40, 0), new Vector2(20, 25)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(60, 0), new Vector2(20, 25)));
            textures.Add("spring", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("spring"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            textures.Add("ball", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("ball"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 40)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(20, 0), new Vector2(20, 40)));
            textures.Add("door", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("door"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            textures.Add("bound", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("boundary"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(36, 46), new Vector2(25, 42)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(1, 47), new Vector2(29, 41)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(36, 2), new Vector2(28, 41)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(1, 0), new Vector2(29, 41)));
            textures.Add("annie", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("annie_sprite"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            textures.Add("spikes", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("spikes"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(20, 0), new Vector2(20, 20)));
            textures.Add("switch", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("switch"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(20, 0), new Vector2(20, 20)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(40, 0), new Vector2(20, 20)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(60, 0), new Vector2(20, 20)));
            textures.Add("tiles", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("tiles"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 20)));
            textures.Add("bomber", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("bomber"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(20, 40)));
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(20, 0), new Vector2(20, 40)));
            textures.Add("portal", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("portal"), aso));

            aso = new anim_size_offset();
            aso.Add(new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(10, 10)));
            textures.Add("font", new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>("font"), aso));
        }

        public static void DrawShape(s_shape sh, GameTime gt, SpriteBatch sb, Vector2 position)
        {
            if (sh.points == null)
                return;
            if (sh.points.Count == 0)
                return;
            Vector2 point = sh.points[0];
            for (int i = 1; i < sh.points.Count; i++)
            {
                Vector2 pt = sh.points[i];
                DrawLine(pt + position, point + position, gt);
                point = pt;
            }
        }
        public static void DrawShape(s_shape sh, GameTime gt, SpriteBatch sb)
        {
            if (sh.points == null)
                return;
            if (sh.points.Count == 0)
                return;
            Vector2 point = sh.points[0] + sh.position;
            for (int i = 1; i < sh.points.Count; i++)
            {
                Vector2 pt = sh.points[i] + sh.position;
                DrawLine(pt, point, gt);
                point = pt;
            }
        }

        public static void DrawStart(Color BG_COLOUR)
        {
            grDev.Clear(Color.CornflowerBlue);
            grDev.SetRenderTarget(VirtScreen);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            grDev.Clear(Color.CornflowerBlue);

            grDev.Clear(BG_COLOUR);
        }

        public static void DrawEnd(Color BG_COLOUR)
        {
            grDev.SetRenderTarget(null);
            spriteBatch.Draw(VirtScreen, new Rectangle(0, 0, VirtScreen.Width, VirtScreen.Height), Color.White);
            spriteBatch.End();
        }

        public static void DrawLine(Vector2 direction, Vector2 origin, float length, GameTime gt)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;
            direction.Normalize();

            Vector2 pos = origin;
            pos = new Vector2(pos.X, pos.Y);

            for (float i = 0; i < length; i += delta)
            {
                pos += direction;
                spriteBatch.Draw(blank, pos, Color.White);
            }
        }

        public static void DrawLine(Vector2 end, Vector2 origin, GameTime gt)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);

            dist.Normalize();

            for (float i = 0; i < hypotenuse; i += delta)
            {
                pos += dist * delta;
                spriteBatch.Draw(blank, pos, Color.Black);
            }
        }

        public static void DrawLine(Vector2 direction, Vector2 origin, float length, GameTime gt, Color colour)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;
            direction.Normalize();

            Vector2 pos = origin;
            pos = new Vector2(pos.X, pos.Y);

            for (float i = 0; i < length; i += delta)
            {
                pos += direction;
                spriteBatch.Draw(blank, pos, colour);
            }
        }

        public static void DrawLine(Vector2 end, Vector2 origin, GameTime gt, Color colour)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);

            dist.Normalize();

            for (float i = 0; i < hypotenuse; i += delta)
            {
                pos += dist * delta;
                spriteBatch.Draw(blank, pos, colour);
            }
        }
    }
    */

    public class o_platformControler : s_object
    {
        public bool isgrounded;
        public float velocityLimiter = 0.85f;
        public float fallVel = 0.1f;
        public const float gravity = 0.1f;

        public int height = 1;

        public bool isdebug = false;
        public Vector2 spawnpoint;
        public enum CHARA_STATE
        {
            PLATFORM,
            TOP_DOWN
        }

        public o_platformControler()
        {
        }
        public o_platformControler(Vector2 _position) : base(_position)
        {
        }

        public o_platformControler(Vector2 _position, float velocityLimiter) : base(_position)
        {
            this.velocityLimiter = velocityLimiter;
        }

        public virtual void TouchingGround(ushort blocktype)
        {

        }

        public virtual void OnGround()
        {

        }
        public virtual void OnGround(ushort blocktype)
        {

        }

        /*
        public void CollisionDetectionY()
        {
            ForceCollisionBoxUpdate();
            Vector2 f = collisionBox.Location.ToVector2();
            ushort topR = Game1.game.GetTile(f + new Vector2(0, -1));
            ushort topL = Game1.game.GetTile(f + new Vector2(collisionBox.Width - 1, -1));

            ushort bottomR = Game1.game.GetTile(f + new Vector2(0, collisionBox.Height));
            ushort bottomL = Game1.game.GetTile(f + new Vector2(collisionBox.Width - 1, collisionBox.Height));

            ushort midR = Game1.game.GetTile(f + new Vector2(-1, collisionBox.Height / 2));
            ushort midL = Game1.game.GetTile(f + new Vector2(collisionBox.Width + 1, collisionBox.Height / 2));

            ushort leftT = Game1.game.GetTile(f + new Vector2(collisionBox.Width, collisionBox.Height - 2));
            ushort leftB = Game1.game.GetTile(f + new Vector2(collisionBox.Width, 0));

            ushort rightT = Game1.game.GetTile(f + new Vector2(-1, collisionBox.Height - 2));
            ushort rightB = Game1.game.GetTile(f + new Vector2(-1, 1));

            //Down
            CheckPointEnt<o_block>(new Vector2(0, collisionBox.Height), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, collisionBox.Height), x => x.issolid);

            CheckPointEnt<o_block>(new Vector2(0, collisionBox.Height / 2), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, collisionBox.Height / 2), x => x.issolid);
            //Up
            CheckPointEnt<o_block>(new Vector2(0, -1), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, -1), x => x.issolid);

            //Left
            CheckPointEnt<o_block>(new Vector2(-1, 0), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(-1, collisionBox.Height - 1), x => x.issolid);

            CheckPointEnt<o_block>(new Vector2(collisionBox.Width, 0), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width, collisionBox.Height - 1), x => x.issolid);

            if (Game1.IsSameLayer(bottomL, "solid") || Game1.IsSameLayer(bottomR, "solid") ||
                Game1.IsSameLayer(bottomL, "solidFall") || Game1.IsSameLayer(bottomR, "solidFall"))
            {
                if (Game1.IsSameLayer(bottomL, "solidFall") && Game1.IsSameLayer(bottomR, "solidFall"))
                    TouchingGround(bottomR);
                if (velocity.Y > 0)
                {
                    Vector2 v = Game1.game.getTruncLevel(centre + new Vector2(0, collisionBox.Height)) - new Vector2(0, height);
                    velocity.Y = 0;
                    v.Y *= Game1.game.level.tileSizeY;
                    position.Y = v.Y - (collisionBox.Height - Game1.game.level.tileSizeY);
                    isgrounded = true;
                    OnGround();
                    if (STATE != CHARA_STATE.SWIMMING)
                        Game1.PlaySound(5, position);
                    return;
                }
            }
            else
            {
                isgrounded = false;
            }
            if (Game1.IsSameLayer(topR, "solid") || Game1.IsSameLayer(topL, "solid"))
            {
                if (velocity.Y < 0)
                {
                    velocity.Y = 0;
                    //Vector2 v = Game1.game.getTruncLevel(collisionBox.Location.ToVector2() - new Vector2(0, collisionBox.Height/2)) - new Vector2(0, height);
                    Vector2 v = Game1.game.getTruncLevel(position - new Vector2(0, 1));// + new Vector2(0, height/2);
                    v.Y *= Game1.game.level.tileSizeY;
                    //position.Y = v.Y; + collisionBox.Height
                    position.Y = v.Y + Game1.game.level.tileSizeY;
                    return;
                }
            }
        }
        */

        /*
        public void CollisionDetectionX()
        {
            ForceCollisionBoxUpdate();
            Vector2 f = collisionBox.Location.ToVector2();
            ushort topR = Game1.game.GetTile(f + new Vector2(0, -1));
            ushort topL = Game1.game.GetTile(f + new Vector2(collisionBox.Width - 1, -1));

            ushort bottomR = Game1.game.GetTile(f + new Vector2(0, collisionBox.Height));
            ushort bottomL = Game1.game.GetTile(f + new Vector2(collisionBox.Width - 1, collisionBox.Height));

            ushort midR = Game1.game.GetTile(f + new Vector2(-1, collisionBox.Height / 2));
            ushort midL = Game1.game.GetTile(f + new Vector2(collisionBox.Width + 1, collisionBox.Height / 2));

            ushort leftT = Game1.game.GetTile(f + new Vector2(collisionBox.Width, collisionBox.Height - 2));
            ushort leftB = Game1.game.GetTile(f + new Vector2(collisionBox.Width, 0));

            ushort rightT = Game1.game.GetTile(f + new Vector2(-1, collisionBox.Height - 2));
            ushort rightB = Game1.game.GetTile(f + new Vector2(-1, 1));

            //Down
            CheckPointEnt<o_block>(new Vector2(0, collisionBox.Height), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, collisionBox.Height), x => x.issolid);

            CheckPointEnt<o_block>(new Vector2(0, collisionBox.Height / 2), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, collisionBox.Height / 2), x => x.issolid);
            //Up
            CheckPointEnt<o_block>(new Vector2(0, -1), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width - 1, -1), x => x.issolid);

            //Left
            CheckPointEnt<o_block>(new Vector2(-1, 0), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(-1, collisionBox.Height - 1), x => x.issolid);

            CheckPointEnt<o_block>(new Vector2(collisionBox.Width, 0), x => x.issolid);
            CheckPointEnt<o_block>(new Vector2(collisionBox.Width, collisionBox.Height - 1), x => x.issolid);

            if (Game1.IsSameLayer(leftT, "solid") || Game1.IsSameLayer(leftB, "solid") || Game1.IsSameLayer(midL, "solid"))
            {
                if (velocity.X > 0)
                {
                    velocity.X = 0;
                    Vector2 v = Game1.game.getTruncLevel(centre + new Vector2(20, 0)) + new Vector2(-1, 0);
                    v.X *= Game1.game.level.tileSizeX;
                    position.X = v.X;
                    return;
                }
            }
            if (Game1.IsSameLayer(rightT, "solid") || Game1.IsSameLayer(rightB, "solid") || Game1.IsSameLayer(midR, "solid"))
            {
                if (velocity.X < 0)
                {
                    velocity.X = 0;
                    Vector2 v = Game1.game.getTruncLevel(centre - new Vector2(20, 0)) + new Vector2(1, 0);
                    v.X *= Game1.game.level.tileSizeX;
                    position.X = v.X;
                    return;
                }
            }
        }
        */

        public override void Start()
        {

        }

        /*
        public override void Update(GameTime gametime)
        {
            if (isKenematic)
            {
                if (!isdebug)
                {
                    if (!isgrounded)
                        if (velocity.Y < 4.6f)
                            velocity.Y += fallVel;
                    if (position.Y > Game1.game.level.mapSizeY * 20)
                        position = spawnpoint;
                }
                if (isdebug)
                    velocity.Y *= velocityLimiter;
                velocity.X *= velocityLimiter;
                if (Math.Abs(velocity.X) < 0.001f)
                    velocity.X = 0;

                ForceCollisionBoxUpdate();
                position.Y += velocity.Y;
                CollisionDetectionY();

                ForceCollisionBoxUpdate();
                position.X += velocity.X;
                CollisionDetectionX();

                o_block bl = IntersectBox<o_block>(new Vector2(0, 0), x => x.TYPEOFBLOCK == o_block.BLOCK_TYPE.BOUNCER);
                if (bl != null)
                {
                    bl.OnBounce();
                    velocity.Y = 6.1f * -1;
                }
            }
            base.Update(gametime);
        }
        */

    }

    /// <summary>
    /// Merge with main
    /// </summary>
    /*
    public class s_gui
    {
        public s_font font;
        public void AddFont()
        {
            Vector2 fontsize = new Vector2(10, 10);
            Vector2 fontglyph = new Vector2(12, 7);
            List<char> characters = new List<char>();

            string fontstr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789: .0><?,!-()+[]=_#/" +
                " " + ";%*|^abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < fontstr.Length; i++)
            {
                characters.Add(fontstr[i]);
                char c = fontstr[i];
            }
            font = new s_font(fontsize, fontglyph, characters, textures["font"].Item1);
        }
        public void AddFontOld()
        {
            List<Rectangle> glyp = new List<Rectangle>();
            List<Rectangle> bound = new List<Rectangle>();
            List<Vector3> kern = new List<Vector3>();
            List<char> characters = new List<char>();

            for (int i = 0; i < 66; i++)
            {
                kern.Add(new Vector3(0, 0, 0));
                glyp.Add(new Rectangle(0, 0, 10, 10));
            }
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    bound.Add(new Rectangle(x * 10, y * 10, 10, 10));
                }
            }
            string fontstr = "abcdefghijklmnopqrstuvwxyz123456789: .0><?,!";
            for (int i = 0; i < fontstr.Length; i++)
            {
                characters.Add(fontstr[i]);
            }

            //font = new SpriteFont(fontTexture,glyp, bound,characters,0,0, kern,'a');
        }
        public static bool IfButton(Rectangle rect)
        {
            e_solarHeart.buttons.Add(new Tuple<Rectangle, string>(rect, ""));
            if (e_solarHeart.mousestate.LeftButton == ButtonState.Pressed)
            {
                if (rect.Intersects(new Rectangle(e_solarHeart.mouseposition2.ToPoint(), new Point(2, 2))))
                    return true;
            }
            return false;
        }
        public static bool IfButton(Rectangle rect, string text)
        {
            e_solarHeart.buttons.Add(new Tuple<Rectangle, string>(rect, text));
            if (e_solarHeart.game.GetMouseDown())
            {
                if (rect.Intersects(new Rectangle(e_solarHeart.scrnMsPos.ToPoint(), new Point(1, 1))))
                    return true;
            }
            return false;
        }
        public void DrawText(string text, s_font fnt, Vector2 pos, SpriteBatch sb)
        {
            Vector2 initalVe = pos;
            if (text == null)
                return;
            int sizeX = (int)fnt.fontSize.X, sizeY = (int)fnt.fontSize.Y;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '\n')
                {
                    pos.X = initalVe.X;
                    pos.Y += 10;
                    continue;
                }

                int ind = fnt.characters.FindIndex(chr => chr == c);
                int x = (int)(ind % fnt.fontGlyphs.X),
                    y = (int)(ind / fnt.fontGlyphs.X);
                pos.X += sizeX;

                Rectangle dst = new Rectangle(new Point((int)pos.X, (int)pos.Y), fnt.fontSize.ToPoint());
                Rectangle src = new Rectangle(new Point((x * sizeX), (y * sizeY)), fnt.fontSize.ToPoint());

                sb.Draw(fnt.fontTexture, dst, src, Color.White);
            }
        }
        public void DrawText(string text, s_font fnt, Vector2 pos, SpriteBatch sb, byte alpha)
        {
            if (text == null)
                return;
            int sizeX = (int)fnt.fontSize.X, sizeY = (int)fnt.fontSize.Y;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '\n')
                {
                    pos.X = 0;
                    pos.Y += 10;
                }

                int ind = fnt.characters.FindIndex(chr => chr == c);
                int x = (int)(ind % fnt.fontGlyphs.X),
                    y = (int)(ind / fnt.fontGlyphs.X);
                pos.X += sizeX;

                Rectangle dst = new Rectangle(new Point((int)pos.X, (int)pos.Y), fnt.fontSize.ToPoint());
                Rectangle src = new Rectangle(new Point((x * sizeX), (y * sizeY)), fnt.fontSize.ToPoint());

                sb.Draw(fnt.fontTexture, dst, src, new Color(Color.White.R, Color.White.G, Color.White.B, alpha));
            }
        }
    }
    */

    /// <summary>
    /// Merge with main
    /// </summary>
    public static class s_maths
    {
        public static float Square(float number, int power)
        {
            float result = number;
            for (int i = power; i != 1; i--)
            {
                result *= number;
            }
            return result;
        }

        public static float SquareRoot(float num)
        {
            return (float)Math.Sqrt(num);
        }

        public static float HypotenuseVector(Vector2 a)
        {
            float add = Square(a.X, 2) + Square(a.Y, 2);
            float hyp = SquareRoot(add);
            return Math.Abs(hyp);
        }
        public static float HypotenuseVector(Point a)
        {
            float add = Square(a.X, 2) + Square(a.Y, 2);
            float hyp = SquareRoot(add);
            return Math.Abs(hyp);
        }

    }

    public struct s_shape
    {
        public s_shape(List<Vector2> points, Vector2 position)
        {
            this.points = points;
            this.position = position;
        }
        public Vector2 position;

        public float GetOverlap()
        {
            float small = float.MaxValue;

            return small;
        }

        public List<Vector2> GetNormals()
        {
            List<Vector2> pts = new List<Vector2>();
            Vector2 lastv = points[0];
            foreach (Vector2 v in points)
            {
                Vector2 ve = GetNormal(lastv - v);
                lastv = v;
                pts.Add(ve);
            }
            return pts;
        }

        public Tuple<Vector2, float> FindMTV(s_shape shape2)
        {
            List<Vector2> axis1 = GetAxis();
            List<Vector2> axis2 = shape2.GetAxis();
            Vector2 smallest = new Vector2(0, 0);
            float overlap = float.MaxValue;
            Vector2 lastv = shape2.points[0];
            foreach (Vector2 v in shape2.points)
            {
                Vector2 ve = GetNormal(lastv - v);

                if (IsIntersecting(shape2, ve))
                {
                    Tuple<float, float> sh = GetIntersectAxis(ve);
                    Tuple<float, float> sh1 = shape2.GetIntersectAxis(ve);

                    float[] a = new float[4];
                    a[0] = sh1.Item2 - sh.Item1;
                    a[1] = sh1.Item1 - sh.Item1;
                    a[2] = sh1.Item2 - sh.Item2;
                    a[3] = sh1.Item1 - sh.Item2;

                    for (int i = 0; i < 3; i++)
                    {
                        float ab = Math.Abs(a[i]);
                        if (ab == 0)
                            continue;
                        if (ab < overlap)
                        {
                            smallest = ve;
                            smallest.Y = smallest.Y * -1;
                            overlap = ab;
                        }
                    }
                }
                lastv = v;
            }
            return new Tuple<Vector2, float>(smallest, overlap);
        }

        public List<Vector2> GetAxis()
        {
            List<Vector2> axis = new List<Vector2>();
            foreach (Vector2 ax in points)
            {
                Vector2 v = ax;
                ax.Normalize();
                axis.Add(ax);
            }
            return axis;
        }

        public Vector2 GetNormal(Vector2 point)
        {
            Vector2 v = new Vector2(-point.Y, point.X);
            v.Normalize();
            return v;
        }

        public bool Interesect(s_shape shape2)
        {
            foreach (Vector2 axis in e_solarHeart2.axis)
            {
                if (!IsIntersecting(shape2, axis))
                    return false;
            }
            return true;
        }

        public bool Interesect(s_shape shape2, List<Vector2> axis)
        {
            foreach (Vector2 ax in axis)
            {
                if (!IsIntersecting(shape2, ax))
                    return false;
            }
            return true;
        }

        public Tuple<float, float> GetIntersectAxis(Vector2 axis)
        {
            float max = 0, min = float.MaxValue;
            for (int i = 0; i < points.Count; i++)
            {
                Vector2 pt = points[i];
                float f = Vector2.Dot(axis, pt + position);
                if (f < min)
                    min = f;
                else if (f > max)
                    max = f;
            }
            return new Tuple<float, float>(max, min);
        }

        public bool IsIntersecting(s_shape shape2, Vector2 axis)
        {
            float max1 = 0, min1 = float.MaxValue;
            float max2 = 0, min2 = float.MaxValue;

            for (int i = 0; i < points.Count; i++)
            {
                Vector2 pt = points[i];
                float f = Vector2.Dot(axis, pt + position);
                if (f < min1)
                    min1 = f;
                else if (f > max1)
                    max1 = f;
            }
            for (int i = 0; i < shape2.points.Count; i++)
            {
                Vector2 pt2 = shape2.points[i];
                float f = Vector2.Dot(axis, pt2 + shape2.position);
                if (f < min2)
                    min2 = f;
                else if (f > max2)
                    max2 = f;
            }

            if (min1 < max2 && max1 > min2)
                return true;
            return false;
        }
        public List<Vector2> points;
    }

    public struct o_button
    {
        public Rectangle rect;
        public string text;
        public o_button(string text, Rectangle rect)
        {
            this.rect = rect;
            this.text = text;
        }
    }

    public struct s_font
    {
        public s_font(Vector2 fontSize, Vector2 fontGlyphs, List<char> characters, Texture2D fontTexture)
        {
            this.fontSize = fontSize;
            this.characters = characters;
            this.fontTexture = fontTexture;
            this.fontGlyphs = fontGlyphs;
        }
        public Vector2 fontGlyphs;
        public Vector2 fontSize;
        public List<char> characters;
        public Texture2D fontTexture;
    }

    public class s_object : s_generic
    {
        public Vector2 collisionOffset;
        public bool issolid = true;
        delegate void OnTouch();
        public bool isKenematic = true;
        public string name;
        public Vector2 position;
        public Vector2 velocity;
        public s_spriterend renderer;
        public Vector2 points;
        public Rectangle collisionBox;
        public List<Vector2> contact_points = new List<Vector2>();
        public Vector2 centre
        {
            get
            {
                return new Vector2(
                    collisionBox.Location.X + (collisionBox.Width / 2),
                    collisionBox.Location.Y + (collisionBox.Height / 2));
            }
        }
        public void SetPos(Vector2 position)
        {
            collisionBox.X = (int)position.X + (int)collisionOffset.X;
            collisionBox.Y = (int)position.Y + (int)collisionOffset.Y;
        }

        public s_object()
        {
            renderer = new s_spriterend();
        }

        public virtual string DrawDebugInfo()
        {
            return null;
        }
        public virtual string DrawInfo()
        {
            return null;
        }

        public void SetCollisonSize(Vector2 size)
        {
            collisionBox = new Rectangle(position.ToPoint() + collisionOffset.ToPoint(), size.ToPoint());
        }
        /*
        public bool CheckPointCh(Vector2 point)
        {
            foreach (o_platformControler pl in e_solarHeart.chara)
            {
                points = point + position;
                if (pl.collisionBox.Intersects(
                    new Rectangle(
                        point.ToPoint() +
                        position.ToPoint(),
                        new Point(1, 1))
                        )
                        )
                    return true;
            }
            return false;
        }
        public bool CheckPoint(Vector2 point)
        {
            foreach (o_block bl in e_solarHeart.blocks)
            {
                if (bl.TYPEOFBLOCK != o_block.BLOCK_TYPE.BLOCK)
                    continue;
                points = point + position;
                if (bl.collisionBox.Intersects(
                    new Rectangle(
                        point.ToPoint() +
                        position.ToPoint(),
                        new Point(1, 1))
                        )
                        )
                    return true;
            }
            return false;
        }
        
        public void AssignSpriteToRenderer(anim_size_offset anim, Texture2D tex)
        {
            renderer.SetTexture(anim, tex);
            renderer.spriteSize = new Point(20, 20);
            renderer.spriteOffset = new Point(0, 0);
        }
        public void AssignSpriteToRenderer(anim_size_offset anim, Texture2D tex, ushort texturePos)
        {
            renderer.SetTexture(anim, tex);
            renderer.spriteSize = new Point(20, 20);
            renderer.spriteOffset = new Point(20 * texturePos, 0);
        }



        */


        public T GetComponent<T>() where T : s_object
        {
            Type t = GetType();
            if (GetType().IsSubclassOf(typeof(T)))
                return (T)this;
            if (typeof(T).ToString() != ToString())
                return null;
            return (T)this;
        }

        public bool CheckPoint<T>(Vector2 point) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null)
                    continue;
                if (obje.collisionBox.Intersects(
                    new Rectangle(points.ToPoint() + new Point(-1, -1), new Point(1, 1))))
                    return true;
            }
            return false;
        }
        public T CheckPointEnt<T>(Vector2 point) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null)
                    continue;
                if (obje.collisionBox.Intersects(
                    new Rectangle(points.ToPoint() + new Point(-1, -1), new Point(1, 1))))
                    return obje;
            }
            return null;
        }
        public T CheckPointEnt<T>(Vector2 point, Predicate<T> condition) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null)
                    continue;
                if (!condition.Invoke(obje))
                    continue;
                if (obje.collisionBox.Intersects(
                    new Rectangle(points.ToPoint() + new Point(-1, -1), new Point(1, 1))))
                    return obje;
            }
            return null;
        }
        public T IntersectBox<T>(Vector2 point) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null || obje == this)
                    continue;
                if (obje.collisionBox.Intersects(collisionBox))
                    return obje;
            }
            return null;
        }
        public T IntersectBox<T>(Vector2 point, float mult) where T : s_object
        {
            contact_points.Add(point + position + collisionOffset);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null || obje == this)
                    continue;
                Rectangle r = collisionBox;
                r.Size = new Point((int)(r.Size.X * mult), (int)(r.Size.Y * mult));
                if (obje.collisionBox.Intersects(r))
                    return obje;
            }
            return null;
        }
        public T[] IntersectBoxAll<T>(Vector2 point) where T : s_object
        {
            contact_points.Add(point + position + collisionOffset);
            points = point + position;
            List<T> intersectedBoxes = new List<T>();
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null || obje == this)
                    continue;
                if (obje.collisionBox.Intersects(collisionBox))
                    intersectedBoxes.Add(obje);
            }
            return intersectedBoxes.ToArray();
        }
        public T[] IntersectBoxAll<T>(Vector2 point, float mult) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            List<T> intersectedBoxes = new List<T>();
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null || obje == this)
                    continue;
                Rectangle r = collisionBox;
                r.Size = new Point((int)(r.Size.X * mult), (int)(r.Size.Y * mult));

                if (obje.collisionBox.Intersects(collisionBox))
                    intersectedBoxes.Add(obje);
            }
            return intersectedBoxes.ToArray();
        }
        public T IntersectBox<T>(Vector2 point, Predicate<T> condition) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                if (e_solarHeart2.objects[i] == null)
                    continue;
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null)
                    continue;
                if (!condition.Invoke(obje))
                    continue;
                if (obje.collisionBox.Intersects(collisionBox))
                    return obje;
            }
            return null;
        }
        public T IntersectBox<T>(Vector2 point, float mult, Predicate<T> condition) where T : s_object
        {
            contact_points.Add(point + position);
            points = point + position;
            for (int i = 0; i < e_solarHeart2.objects.Count; i++)
            {
                T obje = e_solarHeart2.objects[i].GetComponent<T>();
                if (obje == null)
                    continue;
                if (!condition.Invoke(obje))
                    continue;
                Rectangle r = collisionBox;
                r.Size = new Point((int)(r.Size.X * mult), (int)(r.Size.Y * mult));
                if (obje.collisionBox.Intersects(r))
                    return obje;
            }
            return null;
        }

        public s_object(Vector2 _position)
        {
            renderer = new s_spriterend();
            position = _position;
            collisionBox = new Rectangle(position.ToPoint(), new Point(20, 20));
        }


        public void ForceCollisionBoxUpdate()
        {
            collisionBox.Location = position.ToPoint() + collisionOffset.ToPoint();
        }

        public override void Update(GameTime gametime)
        {
            renderer.rect = new Rectangle((int)position.X, (int)position.Y, renderer.rect.Width, renderer.rect.Height);
            collisionBox.Location = position.ToPoint() + collisionOffset.ToPoint();
        }

    }

    public class s_spriterend
    {
        public enum SPRITE_SLICE_MODE
        {
            MANUAL,
            DIMENSION
        }
        public SpriteEffects sprEff;
        public Texture2D texture { get; internal set; }
        public Rectangle rect;
        public Vector2 position;
        public void SetSprite(string name, int num)
        {
            texture = e_solarHeart2.textures[name].Item1;
            rect = e_solarHeart2.textures[name].Item2[num];
        }
        public void SetSprite(string name, int num, SpriteEffects sprEff)
        {
            texture = e_solarHeart2.textures[name].Item1;
            rect = e_solarHeart2.textures[name].Item2[num];
            this.sprEff = sprEff;
        }
        public void SetSprite(string name, s_anim.s_frame frame)
        {
            switch (frame.type)
            {
                case s_anim.ANIM_TYPE.SPRITE:
                    texture = e_solarHeart2.textures[name].Item1;
                    rect = e_solarHeart2.textures[name].Item2[frame.pos];
                    sprEff = frame.fx;
                    break;
            }
        }
        public void SetSprite(string name, s_anim.s_frame frame, SpriteEffects sprEff)
        {
            switch (frame.type)
            {
                case s_anim.ANIM_TYPE.SPRITE:
                    texture = e_solarHeart2.textures[name].Item1;
                    rect = e_solarHeart2.textures[name].Item2[frame.pos];
                    this.sprEff = sprEff;
                    break;
            }
        }
    }

    public abstract class s_generic
    {
        public virtual void Start()
        {

        }

        public virtual void Update(GameTime gametime)
        {

        }
    }

    public struct s_sound
    {
        public Point position;
        public Point size;    //The size is spread around
        public Rectangle position_size { get; private set; }
        public SoundEffect sound;
        public bool isGlobal;   //This sound will play no matter where you are
        public bool isLoop;
        public s_sound(Point position, Point size, SoundEffect sound, bool isLoop)
        {
            isGlobal = false;
            this.position = position;
            this.size = size;
            this.sound = sound;
            this.isLoop = isLoop;
            position_size = new Rectangle(position.X - (size.X / 2), position.Y - (size.Y / 2), size.X, size.Y);
        }
        public s_sound(Point position, Point size, SoundEffect sound)
        {
            isGlobal = false;
            this.position = position;
            this.size = size;
            this.sound = sound;
            isLoop = false;
            position_size = new Rectangle(position.X - (size.X / 2), position.Y - (size.Y / 2), size.X, size.Y);
        }
        public s_sound(SoundEffect sound)
        {
            isLoop = false;
            isGlobal = true;
            position = new Point(0, 0);
            size = new Point(0, 0);
            this.sound = sound;
            position_size = new Rectangle(position.X - (size.X / 2), position.Y - (size.Y / 2), size.X, size.Y);
        }
        public s_sound(SoundEffect sound, bool isLoop)
        {
            this.isLoop = false;
            isGlobal = true;
            position = new Point(0, 0);
            size = new Point(0, 0);
            this.sound = sound;
            position_size = new Rectangle(position.X - (size.X / 2), position.Y - (size.Y / 2), size.X, size.Y);
        }
    }

    public class s_animhandler : s_generic
    {
        List<s_anim> animations;
        public s_anim currentAnimation;
        string lastAnimation;
        float animTimer = 0f;
        public int currentFrameNumber = 0;
        bool islooping = true;
        s_anim.s_frame currentFrame;

        public SpriteEffects GetCurrentAnimationFx
        {
            get
            {
                if (currentAnimation != null)
                    return currentAnimation.spriteFx;
                else
                    return SpriteEffects.None;
            }
        }

        public s_anim.s_frame GetCurrentFrame
        {
            get
            {
                if (currentFrame != null)
                {
                    return currentFrame;
                }
                else
                    return null;
            }
        }

        public void SetAnimation(string animName, bool loop)
        {
            islooping = loop;
            s_anim an = animations.Find(x => x.name == animName);
            if (an != null)
            {
                if (lastAnimation != animName)
                {
                    currentAnimation = an;
                    currentFrameNumber = 0;
                    currentFrame = currentAnimation.animations[0];
                    animTimer = currentAnimation.animations[0].timer;
                    lastAnimation = animName;
                }
            }
        }

        public void AddAnimation(s_anim anima)
        {
            if (animations != null)
                animations.Add(anima);
            else
            {
                animations = new List<s_anim>();
                animations.Add(anima);
            }
        }

        public override void Update(GameTime gametime)
        {
            if (currentAnimation != null)
            {
                int currentANIMLENG = currentAnimation.animations.Count - 1;
                if (currentANIMLENG > 0)
                {
                    if (animTimer <= 0)
                    {
                        if (currentFrame.type == s_anim.ANIM_TYPE.SOUND)
                            e_solarHeart2.game.PlaySound(currentFrame.pos);
                        if (currentFrameNumber == currentANIMLENG)
                        {
                            if (islooping)
                                currentFrameNumber = 0;
                            else
                                currentFrameNumber = currentANIMLENG;
                        }
                        else
                        {
                            currentFrameNumber++;
                        }
                        animTimer = currentFrame.timer;
                        currentFrame = currentAnimation.animations[currentFrameNumber];
                    }
                    else
                        animTimer -= e_solarHeart2.deltaTime;
                }
                else
                {
                    currentFrame = currentAnimation.animations[currentFrameNumber];
                    animTimer = currentFrame.timer;
                }
            }
        }
    }

    public class s_anim
    {
        public class s_frame
        {
            public int pos;
            public float timer;
            public ANIM_TYPE type;
            public SpriteEffects fx;
            public s_frame() { }
            public s_frame(int pos, float duration, ANIM_TYPE type)
            {
                this.pos = pos;
                timer = duration;
                this.type = type;
            }
            public s_frame(int pos, float duration)
            {
                this.pos = pos;
                timer = duration;
            }
            public s_frame(int pos, float duration, ANIM_TYPE type, SpriteEffects fx)
            {
                this.pos = pos;
                timer = duration;
                this.type = type;
                this.fx = fx;
            }
        }

        public s_anim(string name)
        {
            this.name = name;
        }
        public void AddAnimation(int pos, float duration, ANIM_TYPE type, SpriteEffects fx)
        {
            animations.Add(new s_frame(pos, duration, type, fx));
        }
        public void AddAnimation(int pos, float duration, ANIM_TYPE type)
        {
            animations.Add(new s_frame(pos, duration, type));
        }
        public void AddAnimation(int pos, float duration)
        {
            animations.Add(new s_frame(pos, duration, ANIM_TYPE.SPRITE));
        }
        public string name;
        public enum ANIM_TYPE { SPRITE, SOUND };
        public ANIM_TYPE type;
        public List<s_frame> animations = new List<s_frame>();
        public SpriteEffects spriteFx = SpriteEffects.None;
    }

    public class s_camera
    {
        public Vector3 position;
        public Vector2 screenSize;
        public float angle;
        public float zoom = 1;

        public bool camReverse;

        public Vector3 CamTarg;
        public Vector3 CamUpVec;

        public Matrix transform { get; private set; }
        Matrix angleMat;

        public void Follow(Vector2 targ)
        {
            Matrix posMat = Matrix.CreateTranslation(
                -targ.X,
                -targ.Y,
                0) * Matrix.CreateScale(zoom);
            if (!camReverse)
                posMat = Matrix.Invert(posMat);

            Matrix offset = Matrix.CreateTranslation(
            screenSize.X
            ,
            screenSize.Y
            , 0);

            angleMat = Matrix.CreateRotationZ(MathHelper.ToRadians(angle)) * offset;
            transform = posMat * angleMat;// + Matrix.CreateScale(zoom);
            //transform = Matrix.CreateLookAt(posMat.Translation, CamTarg, CamUpVec) * angleMat;
            position = transform.Translation;
        }


    }
    public class e_solarHeart2 : Game
    {
        public s_camera camera;
        public static e_solarHeart2 game;
        public Dictionary<string, List<ushort>> layers = new Dictionary<string, List<ushort>>();

        public bool enableDebug = false;   //If this flag is set, you have the ability to fly, see debug data and play an ending
        bool isPaused = false;
        bool debuginfo = false;

        public GraphicsDeviceManager graphics;

        bool introShow = false;

        Color BG_COLOUR;
        public enum GAME_MODE
        {
            INTRO,
            MENU,
            GAME,
            LEVEL_SELECT,
            INSTRUCTIONS,
            ENDING
        }
        GAME_MODE gameMode;


        bool shapeIntersect = false;

        public static Vector2 scrnMsPos;
        public static Vector2 mouseposition;
        public static Vector2 mouseposition2;
        public static Vector2 mouseToWorldPos;

        /*
        public static s_map[] levels;
        public static s_map[] StaticLevels;
        public s_map level;
        */
        public static int currentLevel = 0;

        public static float deltaTime;

        float introTimer = 1f;
        float introDelay = 1f;

        public static MouseState mousestate;
        MouseState prevmousestate;

        static KeyboardState previousKeyboardState;
        static KeyboardState currentKeyboardState;
        static Keys[] keypressDat;
        static KeyboardState ks;

        public enum SCREEN_SIZE
        {
            SMALL,
            MEDIUM,
            LARGE
        }
        public enum RESOLUTION
        {
            R21_9,
            R16_9,
            R8_7,
            R4_3
        }
        protected enum DEBUG_CONTROL
        {
            PLATFORM,
            MOVE
        }
        protected DEBUG_CONTROL dbg = DEBUG_CONTROL.PLATFORM;

        public static Vector2 campos = new Vector2(0, 0);
        Texture2D titleImg;
        Texture2D logoImg;
        Texture2D endImg;

        Vector2 player_onScreenPosition;

        #region UNUSED SHAPE CLASS
        List<List<Vector2>> normals = new List<List<Vector2>>();    //For the unused shape class
        public static Vector2[] axis = new Vector2[8] { new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(0, -0.5f), new Vector2(0.5f, 0), new Vector2(-1f, -1f) };
        s_shape shape;
        s_shape shape2;
        Tuple<Vector2, float> dist;
        Tuple<float, float> Penetration1;   //For the unused shape class
        Tuple<float, float> Penetration2;   //^ ditto
        #endregion

        Vector2 screensize = new Vector2(33, 720);

        public static List<Tuple<Rectangle, string>> buttons = new List<Tuple<Rectangle, string>>();
        public static List<s_object> objects = new List<s_object>();
        public static List<SoundEffect> sounds = new List<SoundEffect>();
        public static List<s_sound> soundObjects = new List<s_sound>();
        public Song BGM;

        #region GUI Variables
        public s_font fdefault;
        #endregion

        #region RENDER Variables
        public static RenderTarget2D VirtScreen;
        public static SpriteBatch spriteBatch;
        public static Texture2D blank;
        public static Dictionary<string, Tuple<Texture2D, anim_size_offset>> textures = new Dictionary<string, Tuple<Texture2D, anim_size_offset>>();
        #endregion

        public e_solarHeart2()
        {
            camera = new s_camera();
            game = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public void SetVritualScreen(RESOLUTION res, SCREEN_SIZE size, RESOLUTION WindowRes, SCREEN_SIZE WindowSize)
        {
            //Small * 24
            //*80
            int MultiplierWin = 0;
            Microsoft.Xna.Framework.Point WindowSi = new Microsoft.Xna.Framework.Point(0, 0);

            int Multiplier = 0;
            Microsoft.Xna.Framework.Point ScreenSize = new Point(100, 100);

            switch (WindowSize)
            {
                case SCREEN_SIZE.SMALL:
                    MultiplierWin = 24;
                    break;

                case SCREEN_SIZE.MEDIUM:
                    MultiplierWin = 50;
                    break;

                case SCREEN_SIZE.LARGE:
                    MultiplierWin = 80;
                    break;
            }
            switch (WindowRes)
            {
                case RESOLUTION.R4_3:
                    WindowSi = new Point(4, 3);
                    break;

                case RESOLUTION.R8_7:
                    WindowSi = new Point(8, 7);
                    break;

                case RESOLUTION.R21_9:
                    WindowSi = new Point(21, 9);
                    break;

                case RESOLUTION.R16_9:
                    WindowSi = new Point(16, 9);
                    break;
            }
            graphics.PreferredBackBufferWidth = WindowSi.X * MultiplierWin;
            graphics.PreferredBackBufferHeight = WindowSi.Y * MultiplierWin;
            graphics.ApplyChanges();

            switch (size)
            {
                case SCREEN_SIZE.SMALL:
                    Multiplier = 24;
                    break;

                case SCREEN_SIZE.MEDIUM:
                    Multiplier = 50;
                    break;

                case SCREEN_SIZE.LARGE:
                    Multiplier = 80;
                    break;
            }

            switch (res)
            {
                case RESOLUTION.R4_3:
                    ScreenSize = new Point(4, 3);
                    break;

                case RESOLUTION.R8_7:
                    ScreenSize = new Point(8, 7);
                    break;

                case RESOLUTION.R16_9:
                    ScreenSize = new Point(16, 9);
                    break;

                case RESOLUTION.R21_9:
                    ScreenSize = new Point(21, 9);
                    break;
            }

            ScreenSize = new Point(ScreenSize.X * Multiplier, ScreenSize.Y * Multiplier);
            VirtScreen = new RenderTarget2D(GraphicsDevice, ScreenSize.X, ScreenSize.Y);
            camera.screenSize = new Vector2(centreOfScreen.X, centreOfScreen.Y);
        }

        protected override void Initialize()
        {

            //VirtScreen = new RenderTarget2D(GraphicsDevice, 384, 216);
            mouseposition = new Vector2(graphics.GraphicsDevice.Viewport.
                       Width / 2,
                                    graphics.GraphicsDevice.Viewport.
                                    Height / 2);
            Mouse.SetPosition(graphics.GraphicsDevice.Viewport.
                                  Width / 2,
                    graphics.GraphicsDevice.Viewport.Height / 2);
            IsMouseVisible = true;
            BG_COLOUR = Color.White;
            base.Initialize();
        }

        void SetLayers()
        {
            string solid = "solid";
            List<ushort> solidBlocks = new List<ushort> { 1, 2 };

            string liquid = "liquid";
            List<ushort> liquidBlocks = new List<ushort> { 4 };

            string air = "air";
            List<ushort> airBlocks = new List<ushort> { 0 };

            string solidFall = "solidFall";
            List<ushort> solidFallBlocks = new List<ushort> { 5 };

            layers.Add(solid, solidBlocks);
            layers.Add(liquid, liquidBlocks);
            layers.Add(air, airBlocks);
            layers.Add(solidFall, solidFallBlocks);
        }

        public bool IsSameLayer(ushort num, string layr)
        {
            for (int i = 0; i < layers[layr].Count; i++)
            {
                if (num == layers[layr][i])
                    return true;
            }
            return false;
        }
        public bool IsSameLayer(ushort num, List<string> layr)
        {
            foreach (string st in layr)
            {
                for (int i = 0; i < layers[st].Count; i++)
                {
                    if (num == layers[st][i])
                        return true;
                }
            }
            return false;
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            AddTexture(new Rectangle(new Point(0, 0), new Point(10, 10)), "Font/default_font", "default_font");

            //Implement default font
            {
                Vector2 fontsize = new Vector2(10, 10);
                Vector2 fontglyph = new Vector2(12, 7);

                fdefault = AddFont(fontsize, fontglyph, "default_font");
            }
        }


        protected override void UnloadContent()
        {
        }

        public float CalculateLine(Vector2 end, Vector2 origin, GameTime gt)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);
            return hypotenuse;
        }

        Vector2 NormalizeVector(Vector2 vec)
        {
            return vec;
        }


        protected override void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            */
            buttons.Clear();
            mousestate = Mouse.GetState();
            mouseposition = new Vector2(mousestate.X, mousestate.Y);

            //float width = VirtScreen.Width / 2, height = VirtScreen.Height / 2;

            for (int i = 0; i < soundObjects.Count; i++)
            {
                s_sound s = soundObjects[i];
                s.sound.Play();
                soundObjects.Remove(s);
            }

            keypressDat = ks.GetPressedKeys();

            ks = Keyboard.GetState();
            switch (gameMode)
            {
                case GAME_MODE.INTRO:
                    break;

                case GAME_MODE.GAME:

                    if (isPaused)
                    {
                        if (IfButton(new Rectangle(20, 50, 70, 20), "Yes"))
                        {
                            isPaused = false;
                            objects.Clear();
                            gameMode = GAME_MODE.MENU;
                        }
                        if (IfButton(new Rectangle(20, 80, 120, 20), "No"))
                        {
                            isPaused = false;
                        }
                    }
                    else
                    {

                        for (int i = 0; i < objects.Count; i++)
                        {
                            s_object obje = objects[i];
                            if (obje != null)
                            {
                                obje.contact_points.Clear();
                                obje.Update(gameTime);
                                obje.ForceCollisionBoxUpdate();
                            }
                        }

                        /*
                        if (pl != null)
                            player_onScreenPosition = campos - pl.position;
                        */

                        if (currentKeyboardState.IsKeyDown(Keys.Q))
                        {
                            isPaused = true;
                        }
                    }
                    break;

                case GAME_MODE.INSTRUCTIONS:

                    if (IfButton(new Rectangle(20, 150, 120, 20), "Back"))
                    {
                        gameMode = GAME_MODE.MENU;
                    }
                    break;

                case GAME_MODE.MENU:
                    break;

                case GAME_MODE.LEVEL_SELECT:
                    break;

                case GAME_MODE.ENDING:
                    break;
            }

            if (enableDebug)
            {
                if (currentKeyboardState.IsKeyDown(Keys.Tab) && !previousKeyboardState.IsKeyDown(Keys.Tab))
                    debuginfo = debuginfo ? false : true;
            }

            /*
            if (pl != null)
            {
                pl.ForceCollisionBoxUpdate();
                campos = pl.position - new Vector2(s_renderer.centreOfScreen.X, s_renderer.centreOfScreen.Y);
                camera.position.X = MathHelper.Clamp(camera.position.X, 0, (level.mapSizeX - 19.15f) * level.tileSizeX);
                camera.position.Y = MathHelper.Clamp(camera.position.Y, 0, (level.mapSizeY - 10.2f) * level.tileSizeY);
            }
            else
            */
            //campos = new Vector2(0, 0) - new Vector2(centreOfScreen.X, centreOfScreen.Y);
            scrnMsPos = ScreenToVirtualScreen(mouseposition);
            mouseposition2 = scrnMsPos - campos - centreOfScreen;
            mouseToWorldPos = scrnMsPos + campos;

            prevmousestate = mousestate;
            previousKeyboardState = Keyboard.GetState();

            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            /*
            DrawStart(BG_COLOUR);
            switch (gameMode)
            {
                case GAME_MODE.INTRO:
                    break;

                case GAME_MODE.MENU:
                    break;

                case GAME_MODE.LEVEL_SELECT:
                    break;

                case GAME_MODE.INSTRUCTIONS:
                    break;

                case GAME_MODE.GAME:

                    for (int i = 0; i < objects.Count; i++)
                    {
                        s_object obje = objects[i];
                        if (obje == null)
                            continue;
                        float hyp = s_maths.HypotenuseVector(obje.position - (campos + centreOfScreen));
                        if (hyp > 240)
                            continue;

                    }
                    break;

                case GAME_MODE.ENDING:
                    break;
            }
            DrawEnd(BG_COLOUR);
            */
            //spriteBatch.Draw(blank, new Rectangle(scrnMsPos.ToPoint() + new Point(-2, -2), new Point(4, 4)), Color.White);

            base.Draw(gameTime);
        }

        public void Start()
        {
            blank = new Texture2D(GraphicsDevice, 1, 1);
            //CreateSpriteSheets();
        }

        #region SCALINGMISC

        /*
        public Vector2 getTruncLevel(Vector2 pos)
        {
            Vector2 lv = new Vector2();

            lv.X = pos.X / level.tileSizeX;
            lv.Y = pos.Y / level.tileSizeY;

            lv.X = (int)Math.Truncate(lv.X);
            lv.Y = (int)Math.Truncate(lv.Y);

            return lv;
        }
        public Vector2 getTruncLevel(Point pos)
        {
            Vector2 lv = new Vector2();

            lv.X = pos.X / level.tileSizeX;
            lv.Y = pos.Y / level.tileSizeY;

            lv.X = (int)Math.Truncate(lv.X);
            lv.Y = (int)Math.Truncate(lv.Y);

            return lv;
        }
        public ushort GetTile(Vector2 smallPos)
        {
            int pos = TwoDToOneDArray(smallPos);
            if (pos > level.tiles.Length - 1 || pos < 0)
                return 0;
            return level.tiles[pos];
        }

        public void ChangeTile(Vector2 realpos, ushort into)
        {
            int a = TwoDToOneDArray(realpos);
            level.tiles[a] = into;
        }

        public int TwoDToOneDArray(Vector2 smallPos)
        {
            smallPos = getTruncLevel(smallPos);
            int pos = (int)(smallPos.X + (level.mapSizeX * smallPos.Y));
            return pos;
        }

        */
        public Vector2 centreOfScreen
        {
            get
            {
                return new Vector2(VirtScreen.Width / 2, VirtScreen.Height / 2);
            }
        }

        public Vector2 screenSize
        {
            get
            {
                return new Vector2(VirtScreen.Width, VirtScreen.Height);
            }
        }

        public Vector2 ScreenToVirtualScreen(Vector2 pos)
        {
            Vector2 realScreen = new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            float posx = pos.X / realScreen.X;
            float posy = pos.Y / realScreen.Y;

            return new Vector2(VirtScreen.Width * posx, VirtScreen.Height * posy);
        }
        public Vector2 ObjectToScreenPos(Vector2 pos, Vector2 offset)
        {
            Vector2 realScreen = new Vector2(camera.transform.Translation.X, camera.transform.Translation.Y);

            float posx = realScreen.X - pos.X + offset.X;
            float posy = realScreen.Y - pos.Y + offset.Y;

            return new Vector2(posx, posy);
        }
        #endregion

        #region INPUT
        public static bool KeyPressedDown(Keys key)
        {
            if (ks.IsKeyDown(key))
            {
                foreach (Keys k in keypressDat)
                {
                    if (key == k)
                        return false;
                }
                return true;
            }
            return false;
        }
        public bool GetMouseDown()
        {
            //If mouse hasn't already been pressed
            if (prevmousestate.LeftButton == ButtonState.Released && mousestate.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            else if (prevmousestate.LeftButton == ButtonState.Pressed && mousestate.LeftButton == ButtonState.Pressed)
            {
                return false;
            }
            return false;
        }
        public static bool KeyPressed(Keys key)
        {
            if (ks.IsKeyDown(key))
                return true;
            else
                return false;
        }
        #endregion

        #region SOUND STUFF

        public void PlaySound(int sfx_num)
        {
            SoundEffect se = sounds[sfx_num];
            soundObjects.Add(new s_sound(se, false));
        }
        public void PlaySound(int sfx_num, Point position)
        {
            float hyp = s_maths.HypotenuseVector(position - (position + centreOfScreen.ToPoint()));

            if (hyp > 145)
                return;
            SoundEffect se = sounds[sfx_num];
            soundObjects.Add(new s_sound(se, false));
        }
        public void SetConstantSound(int sfx_num, Point position)
        {
            SoundEffect se = sounds[sfx_num];
            //soundObjects.Add(new s_sound(position, new Point(1, 1), se, true));
        }
        #endregion

        #region SPRITESHEETS

        public void AddTexture(Rectangle rect, string fName, string name)
        {
            anim_size_offset aso = new anim_size_offset();
            aso = new anim_size_offset();
            aso.Add(rect);
            textures.Add(name, new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>(fName), aso));
        }
        public void AddTexture(Rectangle rect, string name)
        {
            anim_size_offset aso = new anim_size_offset();
            aso = new anim_size_offset();
            aso.Add(rect);
            textures.Add(name, new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>(name), aso));
        }
        public void AddTexture(Point rectSize, string fName, string name, s_spriterend.SPRITE_SLICE_MODE mode, Point spriteMinDimension)
        {
            anim_size_offset aso = new anim_size_offset();
            aso = new anim_size_offset();
            switch (mode)
            {
                case s_spriterend.SPRITE_SLICE_MODE.DIMENSION:
                    for (int y = 0; y < spriteMinDimension.Y + 1; y++)
                        for (int x = 0; x < spriteMinDimension.X + 1; x++)
                            aso.Add(new Rectangle(x * rectSize.X, y * rectSize.Y, rectSize.X, rectSize.Y));
                    break;
            }
            textures.Add(name, new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>(fName), aso));
        }
        public void AddTexture(Point rectSize, string name, s_spriterend.SPRITE_SLICE_MODE mode, Point spriteMinDimension)
        {
            anim_size_offset aso = new anim_size_offset();
            aso = new anim_size_offset();
            switch (mode)
            {
                case s_spriterend.SPRITE_SLICE_MODE.DIMENSION:
                    for (int y = 0; y < spriteMinDimension.Y + 1; y++)
                        for (int x = 0; x < spriteMinDimension.X + 1; x++)
                            aso.Add(new Rectangle(x * rectSize.X, y * rectSize.Y, rectSize.X, rectSize.Y));
                    break;
            }
            textures.Add(name, new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>(name), aso));
        }
        public void AddTexture(anim_size_offset rects, string name, s_spriterend.SPRITE_SLICE_MODE mode)
        {
            anim_size_offset aso = new anim_size_offset();
            aso = new anim_size_offset();
            foreach (Rectangle spr in rects)
            {
                aso.Add(spr);
            }
            textures.Add(name, new Tuple<Texture2D, anim_size_offset>(Content.Load<Texture2D>(name), aso));
        }

        public void DrawSprite(s_spriterend m_sprRenderer)
        {
            spriteBatch.Draw(m_sprRenderer.texture, 
                m_sprRenderer.rect,
                new Rectangle(m_sprRenderer.position.ToPoint(), new Point(m_sprRenderer.rect.Width, m_sprRenderer.rect.Height)),
                Color.White,
                0,
                new Vector2(0, 0),
                SpriteEffects.None,
                0f);
        }
        public void DrawSprite(Texture2D texture,  Rectangle pos_size, Rectangle sprite_rect)
        {
            pos_size = new Rectangle(
                    pos_size.X,
                    pos_size.Y,
                    pos_size.Width,
                    pos_size.Height);

            spriteBatch.Draw(texture,
                new Rectangle(pos_size.X , pos_size.Y, pos_size.Width, pos_size.Height),
                sprite_rect
                //new Rectangle(sprite_rect.X + CentreOffset.X, sprite_rect.Y + CentreOffset.Y, sprite_rect.Width, sprite_rect.Height)
                ,
                Color.White,
                0,
                new Vector2(0,0),
                SpriteEffects.None,
                0f);
        }
        public void DrawSprite(Texture2D texture, Point CentreOffset, Rectangle pos_size, Rectangle sprite_rect, Color colour, SpriteEffects spriteRotation, float rot, Vector2 origin)
        {
            /*
            if (pos_size.X < camera.transform.Translation.X) {
                return;
            }
            */
            pos_size = new Rectangle(
                    pos_size.X,
                    pos_size.Y,
                    pos_size.Width,
                    pos_size.Height);

            spriteBatch.Draw(texture,
                new Rectangle(pos_size.X + CentreOffset.X, pos_size.Y + CentreOffset.Y, pos_size.Width, pos_size.Height),
                sprite_rect
                //new Rectangle(sprite_rect.X + CentreOffset.X, sprite_rect.Y + CentreOffset.Y, sprite_rect.Width, sprite_rect.Height)
                ,
                colour,
                rot,
                origin,
                spriteRotation,
                0f);
        }
        public void DrawShape(s_shape sh, GameTime gt, SpriteBatch sb, Vector2 position)
        {
            if (sh.points == null)
                return;
            if (sh.points.Count == 0)
                return;
            Vector2 point = sh.points[0];
            for (int i = 1; i < sh.points.Count; i++)
            {
                Vector2 pt = sh.points[i];
                //DrawLine(pt + position, point + position, gt);
                point = pt;
            }
        }
        public void DrawShape(s_shape sh, GameTime gt, SpriteBatch sb)
        {
            if (sh.points == null)
                return;
            if (sh.points.Count == 0)
                return;
            Vector2 point = sh.points[0] + sh.position;
            for (int i = 1; i < sh.points.Count; i++)
            {
                Vector2 pt = sh.points[i] + sh.position;
                //DrawLine(pt, point, gt);
                point = pt;
            }
        }

        public void DrawStart(Color BG_COLOUR)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SetRenderTarget(VirtScreen);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, transformMatrix: camera.transform);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.Clear(BG_COLOUR);
        }

        public void DrawTextRoutine()
        {
            GraphicsDevice.SetRenderTarget(VirtScreen);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            DrawTextRoutineCode();
            spriteBatch.End();
        }

        public virtual void DrawTextRoutineCode()
        {
            foreach (Tuple<Rectangle, string> rect in buttons)
            {
                spriteBatch.Draw(blank, rect.Item1, Color.White);
                Vector2 v = rect.Item1.Location.ToVector2();
                DrawText(rect.Item2, font, v, spriteBatch);
            }
        }

        public void DrawEnd()
        {
            spriteBatch.End();
            DrawTextRoutine();
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(VirtScreen, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.End();
        }
        public void DrawEnd(Color BG_COLOUR)
        {
            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(VirtScreen, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), BG_COLOUR);

            spriteBatch.End();
        }

        public static void DrawLine(Vector2 direction, Vector2 origin, float length)
        {
            direction.Normalize();

            Vector2 pos = origin;
            pos = new Vector2(pos.X, pos.Y);
            float ang = (float)Math.Atan2((double)pos.X, (double)pos.Y);

            spriteBatch.Draw(blank, new Rectangle((int)origin.X, (int)origin.Y, (int)length, 3), null, Color.Red, ang, origin, SpriteEffects.None, 0);
        }

        public static void DrawLine(Vector2 end, Vector2 origin)
        {

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);
            float ang = (float)Math.Atan2((double)dist.X, (double)dist.Y);

            dist.Normalize();
            spriteBatch.Draw(blank, new Rectangle((int)origin.X, (int)origin.Y, (int)hypotenuse, 3), null, Color.White, ang, origin, SpriteEffects.None, 0);
        }

        public static void DrawLine(Vector2 end, Vector2 origin, Color colour)
        {

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);
            float ang = (float)Math.Atan2((double)dist.X, (double)dist.Y);

            dist.Normalize();
            spriteBatch.Draw(blank, new Rectangle((int)origin.X, (int)origin.Y, (int)hypotenuse, 3), null, colour, ang, origin, SpriteEffects.None, 0);
        }
        /*
        public static void DrawLine(Vector2 direction, Vector2 origin, float length, GameTime gt)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;
            direction.Normalize();

            Vector2 pos = origin;
            pos = new Vector2(pos.X, pos.Y);

            for (float i = 0; i < length; i += delta)
            {
                pos += direction;
                spriteBatch.Draw(blank, pos, Color.White);
            }
        }

        public static void DrawLine(Vector2 end, Vector2 origin, GameTime gt)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);

            dist.Normalize();

            for (float i = 0; i < hypotenuse; i += delta)
            {
                pos += dist * delta;
                spriteBatch.Draw(blank, pos, Color.Black);
            }
        }

        public static void DrawLine(Vector2 direction, Vector2 origin, float length, GameTime gt, Color colour)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;
            direction.Normalize();

            Vector2 pos = origin;
            pos = new Vector2(pos.X, pos.Y);

            for (float i = 0; i < length; i += delta)
            {
                pos += direction;
                spriteBatch.Draw(blank, pos, colour);
            }
        }

        public static void DrawLine(Vector2 end, Vector2 origin, GameTime gt, Color colour)
        {
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            Vector2 pos = origin;
            Vector2 dist = end - origin;
            float hypotenuse = s_maths.HypotenuseVector(dist);

            dist.Normalize();

            for (float i = 0; i < hypotenuse; i += delta)
            {
                pos += dist * delta;
                spriteBatch.Draw(blank, pos, colour);
            }
        }
        */
        #endregion

        #region  GUI STUFF
        public s_font font;

        public s_font AddFont(Vector2 fontsize, Vector2 fontglyph, string fontTexture)
        {
            List<char> characters = new List<char>();

            string fontstr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789: .0><?,!-()+[]=_#/" +
                " " + ";%*|^abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < fontstr.Length; i++)
            {
                characters.Add(fontstr[i]);
                char c = fontstr[i];
            }
            return new s_font(fontsize, fontglyph, characters, textures[fontTexture].Item1);
        }

        public void AddFontOld()
        {
            List<Rectangle> glyp = new List<Rectangle>();
            List<Rectangle> bound = new List<Rectangle>();
            List<Vector3> kern = new List<Vector3>();
            List<char> characters = new List<char>();

            for (int i = 0; i < 66; i++)
            {
                kern.Add(new Vector3(0, 0, 0));
                glyp.Add(new Rectangle(0, 0, 10, 10));
            }
            for (int x = 0; x < 11; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    bound.Add(new Rectangle(x * 10, y * 10, 10, 10));
                }
            }
            string fontstr = "abcdefghijklmnopqrstuvwxyz123456789: .0><?,!";
            for (int i = 0; i < fontstr.Length; i++)
            {
                characters.Add(fontstr[i]);
            }

            //font = new SpriteFont(fontTexture,glyp, bound,characters,0,0, kern,'a');
        }
        public bool IfButton(Rectangle rect)
        {
            buttons.Add(new Tuple<Rectangle, string>(rect, ""));
            if (mousestate.LeftButton == ButtonState.Pressed)
            {
                if (rect.Intersects(new Rectangle(scrnMsPos.ToPoint(), new Point(2, 2))))
                    return true;
            }
            return false;
        }
        public bool IfButton(Rectangle rect, string text)
        {
            buttons.Add(new Tuple<Rectangle, string>(rect, text));
            if (game.GetMouseDown())
            {
                if (rect.Intersects(new Rectangle(scrnMsPos.ToPoint(), new Point(1, 1))))
                    return true;
            }
            return false;
        }
        public void DrawText(string text, Vector2 pos, SpriteBatch sb)
        {
            Vector2 initalVe = pos;
            if (text == null)
                return;
            int sizeX = (int)fdefault.fontSize.X, sizeY = (int)fdefault.fontSize.Y;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '\n')
                {
                    pos.X = initalVe.X;
                    pos.Y += 10;
                    continue;
                }

                int ind = fdefault.characters.FindIndex(chr => chr == c);
                int x = (int)(ind % fdefault.fontGlyphs.X),
                    y = (int)(ind / fdefault.fontGlyphs.X);
                pos.X += sizeX;

                Rectangle dst = new Rectangle(new Point((int)pos.X, (int)pos.Y), fdefault.fontSize.ToPoint());
                Rectangle src = new Rectangle(new Point((x * sizeX), (y * sizeY)), fdefault.fontSize.ToPoint());

                sb.Draw(fdefault.fontTexture, dst, src, Color.White);
            }
        }
        public void DrawText(string text, s_font fnt, Vector2 pos, SpriteBatch sb)
        {
            Vector2 initalVe = pos;
            if (text == null)
                return;
            int sizeX = (int)fnt.fontSize.X, sizeY = (int)fnt.fontSize.Y;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '\n')
                {
                    pos.X = initalVe.X;
                    pos.Y += 10;
                    continue;
                }

                int ind = fnt.characters.FindIndex(chr => chr == c);
                int x = (int)(ind % fnt.fontGlyphs.X),
                    y = (int)(ind / fnt.fontGlyphs.X);
                pos.X += sizeX;

                Rectangle dst = new Rectangle(new Point((int)pos.X, (int)pos.Y), fnt.fontSize.ToPoint());
                Rectangle src = new Rectangle(new Point((x * sizeX), (y * sizeY)), fnt.fontSize.ToPoint());

                sb.Draw(fnt.fontTexture, dst, src, Color.White);
            }
        }
        public void DrawText(string text, s_font fnt, Vector2 pos, SpriteBatch sb, byte alpha)
        {
            if (text == null)
                return;
            int sizeX = (int)fnt.fontSize.X, sizeY = (int)fnt.fontSize.Y;
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (c == '\n')
                {
                    pos.X = 0;
                    pos.Y += 10;
                }

                int ind = fnt.characters.FindIndex(chr => chr == c);
                int x = (int)(ind % fnt.fontGlyphs.X),
                    y = (int)(ind / fnt.fontGlyphs.X);
                pos.X += sizeX;

                Rectangle dst = new Rectangle(new Point((int)pos.X, (int)pos.Y), fnt.fontSize.ToPoint());
                Rectangle src = new Rectangle(new Point((x * sizeX), (y * sizeY)), fnt.fontSize.ToPoint());

                sb.Draw(fnt.fontTexture, dst, src, new Color(Color.White.R, Color.White.G, Color.White.B, alpha));
            }
        }
        #endregion

        #region LEVEL LOADING

        /*
        public void LoadMaps(List<string> levelNameslist)
        {
            int mapLeng = levelNameslist.Count;

            string[] levelNames = levelNameslist.ToArray();
            levels = new s_map[mapLeng];
            StaticLevels = new s_map[mapLeng];

            for (int i = 0; i < levelNames.Length; i++)
            {
                string st = levelNames[i];
                levels[i] = Content.Load<s_map>(st);
                StaticLevels[i] = Content.Load<s_map>(st);
            }
        }
        public void LoadMaps(List<string> levelNameslist, string foldername)
        {
            int mapLeng = levelNameslist.Count;

            string[] levelNames = levelNameslist.ToArray();
            levels = new s_map[mapLeng];
            StaticLevels = new s_map[mapLeng];

            for (int i = 0; i < levelNames.Length; i++)
            {
                string st = levelNames[i];
                levels[i] = Content.Load<s_map>(foldername + "/" + st);
                StaticLevels[i] = Content.Load<s_map>(foldername + "/" + st);
            }
        }
        public void LoadLevel(s_map map)
        {
            s_map newMap = new s_map();

            ushort sx = map.mapSizeX, sy = map.mapSizeY;
            ushort tx = map.tileSizeX, ty = map.tileSizeY;

            newMap.mapSizeX = sx;
            newMap.mapSizeY = sy;
            newMap.tileSizeX = (byte)tx;
            newMap.tileSizeY = (byte)ty;

            newMap.tiles = new ushort[map.tiles.Length];
            newMap.entities = new List<o_entity>();
            for (ushort i = 0; i < map.tiles.Length; i++)
            {
                newMap.tiles[i] = map.tiles[i];
            }
            for (int i = 0; i < map.entities.Count; i++)
            {
                o_entity ent = map.entities[i];
                newMap.entities.Add(map.entities[i]);

            }
            //level = newMap;

            #region CREATE TILES
            int x = 0, y = 0;
            for (ushort i = 0; i < map.tiles.Length; i++)
            {
                anim_size_offset anim = new anim_size_offset();
                if (x == (sx * tx))
                {
                    y += ty;
                    x = 0;
                }
                ushort tex = map.tiles[i];
                if (tex == 0)
                {
                    x += tx;
                    continue;
                }
                else
                    tex--;
                //Texture2D texTu = textures["tiles"].Item1;

                //int tilX = tex % (texTu.Width / map.tileSizeX);
                //int tilY = ((tex * map.tileSizeX) / texTu.Width);

                Vector2 pos = new Vector2(x, y);
                int intPos = 0;
                CreateTiles();
                x += tx;
            }
            #endregion

            #region CREATE ENTITIES
            int leng = map.entities.Count;
            for (int i = 0; i < map.entities.Count; i++)
            {
                CreateEntities(map.entities[i]);
            }
            #endregion
        }
        
        public void CreateEntitiesLoad(s_map mp, Point offset)
        {
            for (int i = 0; i < mp.entities.Count; i++)
            {
                mp.entities[i].position += offset;
                mp.entities[i].posX += offset.X;
                mp.entities[i].posY += offset.Y;
                CreateEntities(mp.entities[i]);
            }
        }
        public void CreateEntitiesLoad(s_map mp) {

            for (int i = 0; i < mp.entities.Count; i++)
            {
                CreateEntities(mp.entities[i]);
            }
        }

        public virtual void CreateEntities(o_entity ent)
        {
            ushort id = ent.id;
            int a = ent.position.X;
            Vector2 pos = new Vector2(ent.position.X, ent.position.Y);
            ushort label = ent.labelToCall;
            anim_size_offset anim = new anim_size_offset();
        }
        */

        public virtual void CreateTiles()
        {
            //throw new NotImplementedException();
        }
        #endregion

    }
}
