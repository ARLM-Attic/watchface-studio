using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using WatchfaceStudio.Entities;

namespace WatchfaceStudio.Editor
{

    internal class FacerLayerDesigner : ControlDesigner
    {
        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);

            if (this.Component is FacerLayer)
            {
                var layer = (FacerLayer)this.Component;

                if (layer.type != "image")
                {
                    properties.Remove("hash");
                }
            }
        }
    }
}
