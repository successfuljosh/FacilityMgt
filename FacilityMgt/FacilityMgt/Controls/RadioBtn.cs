using System;
using Xamarin.Forms;

namespace FacilityMgt.Controls
{
   public class RadioBtn:StackLayout
    {
        //Label
        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        private static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create("LabelText", typeof(string), typeof(RadioBtn), string.Empty, BindingMode.OneWay, propertyChanged: LabelTextPropertyyChanged);

        private static void LabelTextPropertyyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadioBtn)bindable;
            if (control != null)
            {
                control._label.Text = (string)newValue;
            }
        }


        //Images
        public string ImageOn
        {
            get => (string)GetValue(ImageOnProperty);
            set => SetValue(ImageOnProperty, value);
        }

        public string ImageOff
        {
            get => (string)GetValue(ImageOffProperty);
            set => SetValue(ImageOffProperty, value);
        }


        private static readonly BindableProperty ImageOnProperty =
            BindableProperty.Create("ImageOn", typeof(string), typeof(RadioBtn), string.Empty, BindingMode.OneWay, propertyChanged: ImagePropertyChanged);

        private static readonly BindableProperty ImageOffProperty =
            BindableProperty.Create("ImageOff", typeof(string), typeof(RadioBtn), string.Empty, BindingMode.OneWay, propertyChanged: ImagePropertyChanged);


        private static void ImagePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadioBtn)bindable;
            if (control != null)
            {
                control.Update();
            }
        }




        //bool
        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        private static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create("IsSelected", typeof(bool), typeof(RadioBtn), false, BindingMode.TwoWay, propertyChanged: IsSelectedPropertyChanged);
        
        
        private static void IsSelectedPropertyChanged (BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RadioBtn)bindable;
            if (control != null)
            {
                control.IsSelected = (bool)newValue;
                control.Update();
            }
        }

        private void Update()
        {
            _image.Source = IsSelected ? ImageOn :(ImageSource)ImageOff;
        }

        private Label _label;
        private Image _image;

        public RadioBtn()
        {
            HeightRequest = 30;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Orientation = StackOrientation.Horizontal;

            _label = new Label
            {
                Text = "Text goes here",
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalTextAlignment = TextAlignment.Center
            };

            _image = new Image
            {
                Source = ImageOff,
                Aspect = Aspect.AspectFill,
                WidthRequest = this.WidthRequest,
                HeightRequest = this.HeightRequest
            };

            var tap =new TapGestureRecognizer();
            tap.Tapped += (sender, e) =>
              {
                  IsSelected = true;
              };

            _image.GestureRecognizers.Add(tap);


            Children.Add(_image);
            Children.Add(_label);
        }
    }
}
