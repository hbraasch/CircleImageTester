using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircleImageTester
{
    internal class StartupPage : ContentPage
    {
        const int IMAGE_SIZE = 100;
        public StartupPage()
        {
            var displayInfo = DeviceDisplay.MainDisplayInfo;
            var sizeRequest = IMAGE_SIZE * displayInfo.Density;

            var image = new Image
            {
                Aspect = Aspect.AspectFit,
                HeightRequest = sizeRequest,
                WidthRequest = sizeRequest,
            };

            image.Source = "city.jpg";
            image.Clip = new CircleClip(sizeRequest); 

            var grid = new Grid();
            grid.Children.Add(image);

            BackgroundColor = Colors.Azure;
            Content = grid;
        }
    }

    internal class CircleClip : Microsoft.Maui.Controls.Shapes.Geometry
    {
        int radius = 0;
        public CircleClip(double size)
        {
            this.radius = (int) size/2;
        }

        public override void AppendPath(PathF path)
        {
            path.AppendCircle(radius, radius, radius);
        }
    }
}
