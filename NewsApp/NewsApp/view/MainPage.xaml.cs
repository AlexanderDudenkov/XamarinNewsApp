using NewsApp.data;
using NewsApp.view;
using NewsApp.view.custom;
using NewsApp.viewmodels;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace NewsApp
{
    public partial class MainPage : ContentPage
    {
        public BindableProperty _myProperty = BindableProperty.Create("IsVisible", typeof(bool), typeof(bool), false);

        public MainPage()
        {

            IDeviceInfo deviceInfo = DependencyService.Get<IDeviceInfo>();

            var viemodel = new MainPageViewModel();
            SetBinding(_myProperty, new Binding("IsVisible"));

            AbsoluteLayout layout = new AbsoluteLayout();

            ListView listView = new ListView
            {
                HasUnevenRows = true,
                ItemsSource = viemodel.Articles,
                ItemTemplate = new DataTemplate(() =>
                {

                    if (deviceInfo.GetInfo()=="")
                    {

                    }

                    Label titleLabel = new Label();
                    titleLabel.SetBinding(Label.TextProperty, "Title");

                    Image image = new Image { Aspect = Aspect.AspectFill };
                    image.SetBinding(Image.SourceProperty, "UrlToImage");

                    Label desc = new Label();
                    desc.SetBinding(Label.TextProperty, "DescriptionFormatted");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(16, 16, 16, 0),
                            Orientation = StackOrientation.Vertical,
                            Children = { titleLabel, image, desc }
                        }
                    };
                })
            };

            listView.ItemSelected += OnSelected;

            AbsoluteLayout.SetLayoutBounds(listView, new Rectangle(1, 1, 1, 1));
            AbsoluteLayout.SetLayoutFlags(listView, AbsoluteLayoutFlags.All);


            ActivityIndicator indicator = new ActivityIndicator
            {
                Color = Color.Azure,
                IsRunning = false,
                IsVisible = false
            };

            AbsoluteLayout.SetLayoutBounds(indicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(indicator, AbsoluteLayoutFlags.PositionProportional);

            layout.Children.Add(listView);
            layout.Children.Add(indicator);

            this.Content = layout;
            BindingContext = viemodel;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            base.OnPropertyChanged(propertyName);
            if (propertyName == _myProperty.PropertyName)
            {
                var myContent = Content as AbsoluteLayout;


                for (int i = 0; i < myContent.Children.Count; i++)
                {

                    if (myContent.Children is ActivityIndicator indicator)
                    {
                        indicator.IsVisible = (bool)GetValue(_myProperty);
                    }

                }
            }
        }

        private async void OnSelected(Object sender, SelectedItemChangedEventArgs args)
        {

            if (args.SelectedItem is ArticleModel article)
            {
                await Navigation.PushAsync(new DetailPage(article));
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}
