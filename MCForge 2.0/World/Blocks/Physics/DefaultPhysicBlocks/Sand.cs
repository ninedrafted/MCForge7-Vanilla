/*
Copyright 2011 MCForge
Dual-licensed under the Educational Community License, Version 2.0 and
the GNU General Public License, Version 3 (the "Licenses"); you may
not use this file except in compliance with the Licenses. You may
obtain a copy of the Licenses at
http://www.opensource.org/licenses/ecl2.php
http://www.gnu.org/licenses/gpl-3.0.html
Unless required by applicable law or agreed to in writing,
software distributed under the Licenses are distributed on an "AS IS"
BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
or implied. See the Licenses for the specific language governing
permissions and limitations under the Licenses.
 */
using System;
using MCForge.Utils;

namespace MCForge.World.Physics
{
    public class Sand : PhysicsBlock
    {
        public override string Name
        {
            get { return "sand"; }
        }
        public override byte VisibleBlock
        {
            get { return 12; }
        }
        public override byte Permission
        {
            get { return 0; }
        }
        public Sand(int x, int z, int y)
            : base(x, z, y)
        {
        }
        public Sand() { }

        public override object Clone()
        {
            Sand g = new Sand();
            g.X = X;
            g.Y = Y;
            g.Z = Z;
            return g;
        }

        public override void Tick(Level l)
        {
            if (l.GetBlock(X, Z, Y - 1) == Block.BlockList.AIR)
            {
                Remove(l);
                Add(l, new Sand(X, Z, Y - 1));
                l.BlockChange((ushort)X, (ushort)Z, (ushort)Y, Block.BlockList.AIR);
            }
        }
    }
}
