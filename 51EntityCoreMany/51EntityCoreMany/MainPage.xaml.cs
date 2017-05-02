using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _51EntityCoreMany
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnaddrecord_Click(object sender, RoutedEventArgs e)
        {
            var Context = new MyContext();
            ModelImage image = new ModelImage()
            {
                ModelImageId = 101,
                Tags = new List<ModelImageTag>()
            };
            ModelImage image2 = new ModelImage()
            {
                ModelImageId = 102,
                Tags = new List<ModelImageTag>()
            };
            ModelTag tag = new ModelTag()
            {
                ModelTagId = 201,
                Images = new List<ModelImageTag>()
            };
            ModelTag tag2 = new ModelTag()
            {
                ModelTagId = 202,
                Images = new List<ModelImageTag>()
            };
            ModelImageTag iTag = new ModelImageTag { ModelImage = image, ModelTag = tag };
            ModelImageTag iTag2 = new ModelImageTag { ModelImage = image, ModelTag = tag2 };
            ModelImageTag iTag3 = new ModelImageTag { ModelTag = tag, ModelImage = image2 };
            tag.Images.Add(iTag3);
            image.Tags.Add(iTag);
            image.Tags.Add(iTag2);
            Context.ModelImages.Add(image);
            Context.ModelImages.Add(image2);
            Context.ModelTags.Add(tag);
            Context.SaveChanges();
        }
    }
}
