using Io.Rollout.Rox.Core.Entities;
using Io.Rollout.Rox.Server;
using Io.Rollout.Rox.Server.Flags;
using System;

namespace Demo.FeatureManagement
{
    public class Container : IRoxContainer
    {
        public RoxFlag ShowMessage = new RoxFlag();
        public RoxString Message = new RoxString("This is the default message; try changing some flag values!");
        public RoxString FontColor = new RoxString("Black", new String[] {"Red", "Green", "Blue", "Black"});
        public RoxInt FontSize = new RoxInt(12, new int[] {12, 16, 24});
    }
}