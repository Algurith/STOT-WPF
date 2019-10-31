using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCR.GMap
{
    public class GMapProviders : GMapProvider
    {
        public override Guid Id => throw new NotImplementedException();

        public override string Name => throw new NotImplementedException();

        public override PureProjection Projection => throw new NotImplementedException();

        public override GMapProvider[] Overlays => throw new NotImplementedException();

        public override PureImage GetTileImage(GPoint pos, int zoom)
        {
            throw new NotImplementedException();
        }
    }
}
