/* This file is intended to enable a distinction between Anno 1800 and Anno 117 - Pax Romana.
 * Both games differ in some aspects like archive structure and, more importantly, content relevant
 * to the map editor. Hardcoded solutions should be made flexible utilizing this.
 */

namespace AnnoMapEditor.DataArchives
{
    public class Game
    {
        // Originally this map Editor was made for 1800 and contains quite a lot of hardcoded stuff...
        public static Game Anno1800 { get; private set; }
        
        // Anno 117 - Pax Romana uses mostly the same technical foundation regarding maps. But hardcoded
        // code segments have to be adjusted.
        public static Game Anno117 { get; private set; }
    }
}