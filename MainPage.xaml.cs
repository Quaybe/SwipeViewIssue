namespace SwipeViewIssue
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        async void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Favorite invoked.", "OK");
        }

        async void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Delete invoked.", "OK");
        }

        double offset;
        private void OnSwipeChanging(object sender, SwipeChangingEventArgs e)
        {
            var swipe = (SwipeView)sender;
            offset = e.Offset;

            if (offset <= -40)
                swipe.Open(OpenSwipeItem.RightItems);
        }

        private void OnSwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            var swipe = (SwipeView)sender;

            if (offset < -40)
                swipe.Open(OpenSwipeItem.RightItems);
        }
    }

}
